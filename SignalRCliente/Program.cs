using Microsoft.AspNetCore.SignalR.Client;

const string url = "https://localhost:44339/messageHub";

await using HubConnection? connection = new HubConnectionBuilder()
    .WithUrl(url)
    .Build();

await connection.StartAsync();

await foreach (DateTime date in connection.StreamAsync<DateTime>("Streaming"))
{
    Console.WriteLine(date);
}