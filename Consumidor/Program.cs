using Consumidor;
using Consumidor.Eventos;
using Core;
using MassTransit;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        var configuration = hostContext.Configuration;
        var fila = configuration.GetSection("MassTransitAzure")["NomeFila"] ?? string.Empty;
        var conexao = configuration.GetSection("MassTransitAzure")["Conexao"] ?? string.Empty;
       
        services.AddMassTransit(x =>
        {
           x.UsingAzureServiceBus((context, cfg) => {
               
               cfg.Host(conexao);
               //cfg.ReceiveEndpoint(fila, e =>
               //{
               //    e.Consumer<PedidoCriadoConsumidor>();             
               //});
               cfg.SubscriptionEndpoint("sub-1","topico", e =>
               {
                     e.Consumer<PedidoCriadoConsumidor>();
                });

           });
        });
    })
    .Build();

host.Run();
