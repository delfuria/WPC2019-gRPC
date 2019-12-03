using Grpc.Core;
using HyperMathGrpcMagicShared;
using MagicOnion;
using MagicOnion.Server;
using System;


// implement RPC service to Server Project.
// inehrit ServiceBase<interface>, interface
public class CalculatorService : ServiceBase<ICalculatorService>, ICalculatorService
{
    // You can use async syntax directly.
    public async UnaryResult<double> Sum(double op1, double op2)
    {
        Logger.Debug($"Received:{op1}, {op2}");

        return op1 + op2;
    }
}