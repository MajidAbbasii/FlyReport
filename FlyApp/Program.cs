// See https://aka.ms/new-console-template for more information

using System.ServiceProcess;
using FlyApp;
using FlyApp.Services;
Task.Run(() =>
{
    var flyService = new FlyService();
});
while (true)
{
    Thread.Sleep(new TimeSpan(1,1,1));
}