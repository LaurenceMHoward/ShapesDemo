namespace ShapesConsoleApp;

using BusinessLogic.Flight;
using BusinessLogic.Generating;
using BusinessLogic.Interfaces;
using BusinessLogic.Output;
using HostedService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

internal class Program
{
    private static void Main(string[] args)
    {
        // each process is run in the ProgramService class, with DI in accordance with SOLID principles.
        // the design pattern associated with dotnet is that of the IHost interface, which handles DI and processes in the HostedService.
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<IShapeSorter, ShapeSorter>(); // sorting shapes collections by different parameters, and direction
                services.AddSingleton<ICounters, Counters>(); // the shape counters
                services.AddSingleton<IXmlExporter, XmlExporter>(); // to export an xml file of the shapes collection
                services.AddSingleton<ICollectionFactory, CollectionFactory>(); // a factory method to generate many different shapes
                services.AddHostedService<ProgramService>(); // the application where the processes are run in the IHost.
            }).Build();

        host.Run();
    }
}