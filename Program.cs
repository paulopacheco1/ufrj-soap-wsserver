using Microsoft.Extensions.DependencyInjection.Extensions;
using SoapCore;
using wsServer;
using wsServer.Repositories.Contracts;
using wsServer.Repositories.InMemory;
using wsServer.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.TryAddSingleton<IAutoresRepository, InMemoryAutoresRepository>();
builder.Services.TryAddSingleton<IPublicacoesRepository, InMemoryPublicacoesRepository>();

builder.Services.TryAddSingleton<Initialize>();

builder.Services.AddSoapCore();
builder.Services.TryAddSingleton<PublicacoesService>();
builder.Services.AddMvc();

var app = builder.Build();

app.MapGet("/", () => "Hello WebService!");

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.UseSoapEndpoint<PublicacoesService>("/Publicacoes.asmx", new SoapEncoderOptions(), SoapSerializer.DataContractSerializer);
});

app.Services.GetService<Initialize>()?.Init();

app.Run();
