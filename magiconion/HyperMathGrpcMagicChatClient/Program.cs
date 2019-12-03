using ChatApp.Shared.MessagePackObjects;
using Grpc.Core;
using System;

namespace HyperMathGrpcMagicChatClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert a name to start");
            string name = Console.ReadLine();
            //Step 1: Crea una istanza del canale standard gRPC e dal client magic
            var channel = new Channel("localhost", 5001, ChannelCredentials.Insecure);

            ChatHubClient client = new ChatHubClient();
            client.ConnectAsync(channel);
            client.OnJoin(name);

            Console.WriteLine("Insert a message");
            string message = Console.ReadLine();

            client.OnSendMessage(new MessageResponse() { Message = message, UserName = name });
            Console.ReadLine();
        }
    }
}
