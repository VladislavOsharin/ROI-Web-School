﻿using System;

namespace Crm
{
    internal enum ServiceOption
    {
        Singleton,
        PerResolve
    }

    [AttributeUsage(AttributeTargets.Class)]
    internal class ServiceAttribute : Attribute
    {
        public ServiceOption Option { get; set; }

        public ServiceAttribute(ServiceOption option)
        {
            Option = option;
        }
    }
}