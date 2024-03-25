using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.ServiceProcess;
using System.Text;
using System.Text.Json;
using FlyApp.Classes;
using FlyApp.Entities;
using FlyApp.Extensions;
using FlyApp.Infrastructure;
using FlyApp.Log;
using Microsoft.EntityFrameworkCore;

namespace FlyApp.Services;

public class FlyService
{
    private readonly Timer _timer;
    private readonly EventLogger _eventLogger;

    public FlyService()
    {
        _eventLogger = new EventLogger("FlyService");
        _timer = new Timer(OnTimerElapsed, null, TimeSpan.Zero, TimeSpan.FromSeconds(30));
    }

    private async void OnTimerElapsed(object state)
    {
        try
        {
            var result = await FetchFlightData();
            var emailBody = new StringBuilder();
            await using (var dbContext = new AppDbContext())
            {
                await dbContext.Database.MigrateAsync();
                foreach (var pricedItinerary in result.pricedItineraries)
                {
                    var price = pricedItinerary.airItineraryPricingInfo.itinTotalFare.totalFare;
                    var date = pricedItinerary.originDestinationOptions[0].flightSegments[0].departureDateTime;
                    var quantity = pricedItinerary.originDestinationOptions[0].flightSegments[0].seatsRemaining;
                    dbContext.ChangeTracker.Clear();
                    Flight existingFlight = dbContext.Flights.FirstOrDefault(f => f.Date == date);
                    if (existingFlight != null)
                    {
                        if (existingFlight.Price <= price)
                        {
                            continue;
                        }
                        else
                        {
                            existingFlight.Price = price;
                            await dbContext.SaveChangesAsync();
                            
                            emailBody.AppendLine($"تاریخ : {date.ToPersianDateTime()}");
                            emailBody.AppendLine($"قیمت : {price:N0}");
                            emailBody.AppendLine($"تعداد : {quantity}");
                            
                            continue;
                        }
                    }
                    
                    var newFlight = new Flight
                    {
                        Price = price,
                        Date = date,
                        Quantity = quantity ?? 0
                    };

                    dbContext.Flights.Add(newFlight);
                    await dbContext.SaveChangesAsync();

                    emailBody.AppendLine($"تاریخ : {date.ToPersianDateTime()}");
                    emailBody.AppendLine($"قیمت : {price:N0}");
                    emailBody.AppendLine($"تعداد : {quantity}");
                }
            }

            await new MailService().SendEmail(emailBody.ToString());
        }
        catch (Exception ex)
        {
            _eventLogger.LogError($"An error occurred: {ex.Message}");
        }
    }

    private async Task<ResponseFlightService?> FetchFlightData()
    {
        try
        {
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(Guid.NewGuid().ToString("N"));
            var response = await httpClient.PostAsync("https://api.flytoday.ir/api/V1/Flight/SearchAnytime",
                new StringContent(
                    "{\"pricingSourceType\":0,\"adultCount\":1,\"childCount\":0,\"infantCount\":0,\"travelPreference\":{\"cabinType\":\"Y\",\"maxStopsQuantity\":\"All\",\"airTripType\":\"OneWay\"},\"originDestinationInformations\":[{\"destinationLocationCode\":\"MHD\",\"destinationType\":\"1\",\"originLocationCode\":\"THR\",\"originType\":\"1\"}],\"isJalali\":true}",
                    Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ResponseFlightService>(content);
            }
            else
            {
                _eventLogger.LogInformation(
                    $"Failed to retrieve data from the API. Status code: {response.StatusCode}");
                return null;
            }
        }
        catch (Exception e)
        {
            _eventLogger.LogError($"An error occurred: {e.Message}");
            return null;
        }
    }
}