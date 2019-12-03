using ChatApp.Shared.Hubs;
using ChatApp.Shared.MessagePackObjects;
using Grpc.Core;
using HyperMathGrpcMagicChatShared;
using MagicOnion.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HyperMathGrpcMagicChatClient
{
    public class ChatHubClient : IChatHubReceiver
    {

        IChatHub client;

        public async Task ConnectAsync(Channel grpcChannel)
        {
            client = StreamingHubClient.Connect<IChatHub, IChatHubReceiver>(grpcChannel, this);
        }

        void IChatHubReceiver.OnJoin(string name)
        {
            Console.WriteLine($"Join {name}");
        }

        void IChatHubReceiver.OnLeave(string name)
        {
            Console.WriteLine($"leave {name}");
        }

        void IChatHubReceiver.OnSendMessage(MessageResponse message)
        {
            Console.WriteLine($"Message: {message.Message}");
        }

        public void OnJoin(string name)
        {
            var req = new JoinRequest() { RoomName = "r1", UserName = name };
            client.JoinAsync(req);
        }

        public void OnLeave()
        {
            client.LeaveAsync();
        }

        public void OnSendMessage(MessageResponse message)
        {
            client.SendMessageAsync(message.Message);
        }
    }
}
