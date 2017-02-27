using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;
using System.Threading;

namespace IoTHubReaderConsole
{
    class Program
    {
        static string myHubString = "HostName=benkoIoTHub2.azure-devices.net;SharedAccessKeyName=service;SharedAccessKey=3wTZ2MiwjTLnzGyRIrpvP0hkuFZe7/zjP7+GbMsBSGA=";
        static string iotHubEndpoint = "messages/events";
        static EventHubClient myHubClient;

        static void Main(string[] args)
        {
            Console.WriteLine($"Receive  messages. Ctrl-C to exit\n");

            myHubClient = EventHubClient.CreateFromConnectionString(myHubString, iotHubEndpoint);
            var d2cPartitions = myHubClient.GetRuntimeInformation().PartitionIds;
            CancellationTokenSource cts = new CancellationTokenSource();

            System.Console.CancelKeyPress += (s, e) =>
            {
                e.Cancel = true;
                cts.Cancel();
                Console.WriteLine("Exiting...");

            };

            var tasks = new List<Task>();
            foreach (string partition in d2cPartitions)
            {
                tasks.Add(ReceiveMsgs(partition, cts.Token));

            }
            Task.WaitAll(tasks.ToArray());
        }

        private static async Task ReceiveMsgs(string partition, CancellationToken ct)
        {
            var ehReceiver = myHubClient.GetDefaultConsumerGroup().CreateReceiver(partition, DateTime.UtcNow);
            while (true)
            {
                if (ct.IsCancellationRequested)
                    break;
                EventData myData = await ehReceiver.ReceiveAsync();
                if (myData == null)
                    continue;

                string data = Encoding.UTF8.GetString(myData.GetBytes());
                Console.WriteLine($"{DateTime.UtcNow.ToShortTimeString()} > Message Received. Partition: {partition} Data: {data}");
            }
        }
    }
}

