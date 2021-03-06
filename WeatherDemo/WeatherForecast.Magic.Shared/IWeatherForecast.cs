﻿using MagicOnion;
using System;
using System.Collections.Generic;
using System.Text;

namespace HyperMathGrpcMagicShared
{
    // define interface as Server/Client IDL.
    // implements T : IService<T> and share this type between server and client.
    public interface IWeatherForecast : IService<IWeatherForecast>
    {
        // Return type must be `UnaryResult<T>` or `Task<UnaryResult<T>>`.
        // If you can use C# 7.0 or newer, recommend to use `UnaryResult<T>`.
        UnaryResult<WeatherReply> GetWeather();
    }
}
