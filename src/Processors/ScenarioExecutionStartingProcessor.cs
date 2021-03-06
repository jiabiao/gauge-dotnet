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

using System.Collections.Generic;
using System.Linq;
using Gauge.Dotnet.Wrappers;
using Gauge.Messages;

namespace Gauge.Dotnet.Processors
{
    public class ScenarioExecutionStartingProcessor : UntaggedHooksFirstExecutionProcessor
    {
        private readonly IExecutionOrchestrator _executionOrchestrator;

        public ScenarioExecutionStartingProcessor(IExecutionOrchestrator executionOrchestrator,
            IAssemblyLoader assemblyLoader, IReflectionWrapper reflectionWrapper)
            : base(executionOrchestrator, assemblyLoader, reflectionWrapper)
        {
            _executionOrchestrator = executionOrchestrator;
        }

        protected override string HookType => "BeforeScenario";

        public override Message Process(Message request)
        {
            _executionOrchestrator.StartExecutionScope("scenario");
            return base.Process(request);
        }

        protected override ExecutionInfo GetExecutionInfo(Message request)
        {
            return request.ScenarioExecutionStartingRequest.CurrentExecutionInfo;
        }

        protected override List<string> GetApplicableTags(Message request)
        {
            return GetExecutionInfo(request).CurrentScenario.Tags
                .Union(GetExecutionInfo(request).CurrentSpec.Tags).ToList();
        }
    }
}