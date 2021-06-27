using Microsoft.Azure.ServiceBus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AzoreChat
{
    class Receiver
    {
        public string ConnectionString = "Endpoint=sb://azorechat.servicebus.windows.net/;SharedAccessKeyName=AzoreChat;SharedAccessKey=lnEQZnqh7JGIL9G0ooRGMU+WZwAdZsIjWpJ3fCxH33I=;";
        public string QueuePath = "azorechat";


        public void Receive()
        {
            var queueClient = new QueueClient(ConnectionString, QueuePath);

            queueClient.RegisterMessageHandler(ProcessMessagesAsync, HandleExceptionsAsync);

            Console.WriteLine($"Done");
            Console.ReadLine();

            queueClient.CloseAsync();
        }

        private Task HandleExceptionsAsync(ExceptionReceivedEventArgs arg)
        {
            throw new NotImplementedException();
        }

        private static async Task ProcessMessagesAsync(Message message, CancellationToken cancellationToken)
        {
            string receivedMessage = Encoding.UTF8.GetString(message.Body);
            Console.WriteLine(receivedMessage);
        }
    }
}
