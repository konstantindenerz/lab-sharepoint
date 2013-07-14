﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab.Heroes.Core.Tests.DomainObjects
{
    enum EMockHeroFactoryStrategy
    {
        deadPoolWithMockSerializer,
        deadPoolWithSerializer,
        mockObject,
        mockHero
    }
}
