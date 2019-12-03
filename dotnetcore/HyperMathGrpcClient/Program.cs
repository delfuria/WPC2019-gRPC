using Grpc.Core;
using Grpc.Net.Client;
using HyperMath.Grpc;
using System;
using System.Threading.Tasks;

namespace HyperMathGrpcClient
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome to the gRPC client, Press Enter to continue");
            Console.ReadLine();
            GetSum();
            Console.ReadLine();
            await GetStreamedResultAsync();
            Console.ReadLine();
        }

        static void GetSum()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var mathClient = new HyperMath.Grpc.MathService.MathServiceClient(channel);

            var mathRequest = new MathRequest() { Op1 = 10, Op2 = 20 };
            var reply = mathClient.Sum(mathRequest);
            Console.WriteLine($"Sum Calculated: {reply.Resp}");
        }
        static async Task GetStreamedResultAsync()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var mathClient = new HyperMath.Grpc.MathService.MathServiceClient(channel);
            var mathRequest = new MathRequest() { Op1 = 10, Op2 = 20 };

            using (var statusReplies = mathClient.GetAllCalc(mathRequest))
            {
                int i = 0;
                while (await statusReplies.ResponseStream.MoveNext())
                {
                    var statusReply = statusReplies.ResponseStream.Current.Resp;
                    Console.WriteLine($"Calc #{++i} : Result {statusReply}");
                }
            }
        }
    }
}
