using Grpc.Core;
using HyperMathGrpcMagicShared;
using MagicOnion.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome to the gRPC client, Press Enter to continue");
            Console.ReadLine();

            //Step 1: Crea una istanza del canale standard gRPC e dal client magic
            var channel = new Channel("localhost", 5001, ChannelCredentials.Insecure);
            // get MagicOnion dynamic client proxy
            var client = MagicOnionClient.Create<ICalculatorService>(channel);

            // Step 2: Chiama le operazioni messe a disposizione dal servizio.
            double value1 = 10D;
            double value2 = 20D;

            // Chiamata all'operazione del servizio Add.
            double result = await client.Sum(value1,  value2 );
            Console.WriteLine("Sum({0},{1}) = {2}", value1, value2, result);

            //Step 3: Chiude il ciente, la connessione e rilascia le risorse.
            Console.ReadLine();
        }
    }
}
