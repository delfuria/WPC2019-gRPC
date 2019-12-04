using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using CalculatorLibrary;
using WcfLibrary;

namespace WcfServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:9001/");
            ServiceHost selfHost = new ServiceHost(typeof(CalculatorService), baseAddress);

            selfHost.AddServiceEndpoint(typeof(ICalculator), new BasicHttpBinding(), "CalculatorService");

            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            selfHost.Description.Behaviors.Add(smb);
            selfHost.AddServiceEndpoint(
              ServiceMetadataBehavior.MexContractName,
              MetadataExchangeBindings.CreateMexHttpBinding(),
              "mex"
            );
            selfHost.Open();
             // Fa qualcosa
            selfHost.Close();
        }
    }
}
