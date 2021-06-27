using System;

namespace AzoreChat
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var sender = new Sender();
            sender.Send();

            var receiver = new Receiver();
            receiver.Receive();

        }
    }
}
