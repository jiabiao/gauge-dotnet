﻿// Copyright 2018 ThoughtWorks, Inc.
//
// This file is part of Gauge-Dotnet.
//
// Gauge-Dotnet is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// Gauge-Dotnet is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with Gauge-Dotnet.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Diagnostics;

namespace Gauge.Dotnet
{
    internal static class Program
    {
        [STAThread]
        [DebuggerHidden]
        private static void Main(string[] args)
        {
            LogConfiguration.Initialize();
            if (args.Length == 0)
            {
                Console.WriteLine("usage: {0} --<start|init>", AppDomain.CurrentDomain.FriendlyName);
                Environment.Exit(1);
            }

            var phase = args[0];
            var command = GaugeCommandFactory.GetExecutor(phase);
            command.Execute();
        }
    }
}