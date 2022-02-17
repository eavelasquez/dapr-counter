using Dapr.Client;

const string storeName = "statestore";
const string keyCounter = "counter";
const string keyAccumulator = "accumulator";


var daprClient = new DaprClientBuilder().Build();
var counter = await daprClient.GetStateAsync<int>(storeName, keyCounter);
var accumulator = await daprClient.GetStateAsync<int>(storeName, keyAccumulator);

while (true)
{
  Console.WriteLine($"Counter = {counter++}");
  Console.WriteLine($"Accumulator = {accumulator--}");

  await daprClient.SaveStateAsync(storeName, keyCounter, counter);
  await daprClient.SaveStateAsync(storeName, keyAccumulator, accumulator);
  await Task.Delay(1000);
}
