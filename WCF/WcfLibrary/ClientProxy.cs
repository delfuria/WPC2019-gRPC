using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using CalculatorLibrary;

namespace WcfLibrary
{
    public class ClientProxy
           : ClientBase<ICalculator>,
             ICalculator
    {
        public ClientProxy(Binding binding,
            EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {
        }

        public double Sum(double op1, double op2)
        {
            return Channel.Sum(op1, op2);
        }

    }
}
