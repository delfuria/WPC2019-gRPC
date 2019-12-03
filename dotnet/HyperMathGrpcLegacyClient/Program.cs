using Grpc.Core;
using HyperMath.Grpc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HyperMathGrpcLegacyClient
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome to the gRPC client, Press Enter to continue");
            Console.ReadLine();


            // STEP 1: Crea una istanza del Canale di comunicazione verso il server
            Channel channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);

            // STEP 2: Dichiara la tipologia del servizio da invocare
            var client = new HyperMath.Grpc.MathService.MathServiceClient(channel);

            // Call the Add service operation.
            MathRequest req = new MathRequest() { Op1 = 10, Op2 = 20 };
            MathReply resp = client.Sum(req);
            Console.WriteLine("Sum({0},{1}) = {2}", req.Op1, req.Op2, resp.Resp);
            Console.ReadLine();

            var mathRequest = new MathRequest() { Op1 = 10, Op2 = 20 };

            using (var statusReplies = client.GetAllCalc(mathRequest))
            {
                int i = 0;
                while (await statusReplies.ResponseStream.MoveNext())
                {
                    var statusReply = statusReplies.ResponseStream.Current.Resp;
                    Console.WriteLine($"Calc #{++i} : Result {statusReply}");
                }
            }
            Console.ReadLine();


        }
    }
}
