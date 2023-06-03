﻿using Container_Cat.Containers.Models;

namespace Container_Cat.Utilities.Models
{
    public class SystemDataObj
    {
        Guid Id;
        public HostAddress NetworkAddress { get; set; }
        public ContainerEngine InstalledContainerEngines { get; set; }
        public SystemDataObj(HostAddress _networkAddr)
        {
            NetworkAddress = _networkAddr;
            Id = Guid.NewGuid();
            NetworkAddress.SetStatus(HostAddress.HostAvailability.NotTested);
        }
        public SystemDataObj() { }
    }
}
