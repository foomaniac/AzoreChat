using Microsoft.Azure.ServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzoreChat
{
    class Sender
    {
        public string ConnectionString = "Endpoint=sb://azorechat.servicebus.windows.net/;SharedAccessKeyName=AzoreChat;SharedAccessKey=lnEQZnqh7JGIL9G0ooRGMU+WZwAdZsIjWpJ3fCxH33I=;";
        public string QueuePath = "azorechat";


        public void Send()
        {
            var queueClient = new QueueClient(ConnectionString, QueuePath);


            for(int i = 0; i < 4; i++)
            {
                var content = $"MESSAGE {i}";

                var newMessage = new Message(Encoding.UTF8.GetBytes(content));
                queueClient.SendAsync(newMessage).Wait();

                Console.WriteLine($"Sent message {content}");
            }

            queueClient.CloseAsync();
        }


    }
}
