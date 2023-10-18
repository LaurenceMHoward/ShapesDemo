namespace ShapesConsoleApp;

using BusinessLogic.Generating;
using BusinessLogic.Interfaces;
using BusinessLogic.Output;
using BusinessLogic.Sorting;
using HostedService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

internal class Program
{
    private static void Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<IShapeSorter, ShapeSorter>();
                services.AddSingleton<IXmlExporter, XmlExporter>();
                services.AddSingleton<ICollectionFactory, CollectionFactory>();
                services.AddHostedService<ProgramService>();
            }).Build();

        host.Run();
    }
}