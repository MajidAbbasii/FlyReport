// See https://aka.ms/new-console-template for more information

using System.ServiceProcess;
using FlyApp;
using FlyApp.Services;

try
{
    if (System.Diagnostics.Debugger.IsAttached)
    {
        Task.Run(() =>
        {
            var flyService = new FlyService();
        });
        while (true)
        {
            Thread.Sleep(new TimeSpan(1,1,1));
        }
    }
    else
    {
        System.Environment.CurrentDirectory = new System.IO.FileInfo(typeof(Program).Assembly.Location).DirectoryName;
        ServiceBase[] ServicesToRun = new ServiceBase[]
        {
            new FlyService()
        };
        ServiceBase.Run(ServicesToRun);
    }
}
catch (Exception ex)
{
    System.Diagnostics.EventLog.WriteEntry("Catch", ex.ToString());
}