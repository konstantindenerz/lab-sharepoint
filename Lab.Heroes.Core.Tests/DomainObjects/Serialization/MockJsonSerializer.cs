﻿using Lab.Heroes.Core.DomainObjects;
using Lab.Heroes.Core.DomainObjects.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab.Heroes.Core.Tests.DomainObjects.Serialization
{
    class MockJsonSerializer : AbstractJsonSerializer
    {
        public MockJsonSerializer(IObjectBase objectBase)
            : base(objectBase)
        {

        }


        public override void Load(string jsonString)
        {
            
        }

        public override string AsString()
        {
            return "42";
        }
    }
}