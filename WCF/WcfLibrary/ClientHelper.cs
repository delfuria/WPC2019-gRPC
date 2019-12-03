using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using CalculatorLibrary;

namespace WcfLibrary
{
    public class ClientHelper
    {
        public static ICalculator Connect(string uri)
        {
            var resp = Connect<ICalculator>(uri);
            return resp;

        }

        public static T Connect<T>(string uri) //, out CommunicationState status)
        {
            string uriService = uri;
            WebHttpBinding webHttp = new WebHttpBinding(WebHttpSecurityMode.None);
            //webHttp.MaxReceivedMessageSize = wcfSetting.WcfMaxReceiveMessageSize.Current;
            //webHttp.MaxBufferPoolSize = wcfSetting.WcfMaxBufferPoolSize.Current;
            //webHttp.MaxBufferSize = wcfSetting.WcfMaxBufferSize.Current;
            //webHttp.ReaderQuotas.MaxArrayLength = Int32.MaxValue;

            //binding.SendTimeout = TimeSpan.FromSeconds(config.SendClientTimeout.Current);
            //binding.ReceiveTimeout = TimeSpan.FromSeconds(config.SendClientTimeout.Current);
            T svcChannel;
            ChannelFactory<T> fact =
                new ChannelFactory<T>(
                    webHttp,
                    new EndpointAddress(uriService)
                    );

            // var defaultCredentials = fact.Endpoint.Behaviors.Find<ClientCredentials>();

            //#1 IF this dosen not work then try #2
            //fact.Credentials.UserName.UserName = "h";
            //fact.Credentials.UserName.Password = "p";
            //fact.Credentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;

            ///#2
            //ClientCredentials CC = new ClientCredentials();
            //CC.UserName.UserName = "h";
            //CC.UserName.Password = "p";
            // myChannelFactory.Endpoint.Behaviors.Remove(defaultCredentials); //remove default ones
            // myChannelFactory.Endpoint.Behaviors.Add(CC); //add required on

            svcChannel = fact.CreateChannel();
            //status = ((IClientChannel) svcGate).State;

            return svcChannel;
        }
    }
}
