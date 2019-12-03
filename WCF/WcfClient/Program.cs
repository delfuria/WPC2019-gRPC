using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfLibrary;
using System.ServiceModel;
using CalculatorLibrary;
using System.Diagnostics;

namespace WcfClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the WCF client, Press Enter to continue");
            Console.ReadLine();

            //Step 1: Crea una istanza del WCF proxy.
            ClientProxy client =
                new ClientProxy(new BasicHttpBinding(),
                                new EndpointAddress("http://localhost:9001/CalculatorService"));

            // Step 2: Chiama le operazioni messe a disposizione dal servizio.
            double value1 = 10D;
            double value2 = 20D;

            double result = client.Sum(value1, value2);

            Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result);

            //Step 3: Chiude il ciente, la connessione e rilascia le risorse.
            client.Close();
            Console.ReadLine();
        }
    }
}
