// See https://aka.ms/new-console-template for more information

using System.ServiceProcess;
using FlyApp;

try
{
    if (System.Diagnostics.Debugger.IsAttached)
    {
        Task.Run(() =>
        {
            FlyWindowsService flyWindowsService = new FlyWindowsService();
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
            new FlyWindowsService()
        };
        ServiceBase.Run(ServicesToRun);
    }
}
catch (Exception ex)
{
    System.Diagnostics.EventLog.WriteEntry("Catch", ex.ToString());
}