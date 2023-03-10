using Microsoft.AspNetCore.SignalR.Client;

const string url = "https://localhost:44339/messageHub";

await using var connection = new HubConnectionBuilder()
    .WithUrl(url, options => options.HttpMessageHandlerFactory = _ => new HttpClientHandler { ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator })
    //.WithUrl(url)
    .Build();

await connection.StartAsync();

await foreach (DateTime date in connection.StreamAsync<DateTime>("Streaming"))
{
    Console.WriteLine(date);
}