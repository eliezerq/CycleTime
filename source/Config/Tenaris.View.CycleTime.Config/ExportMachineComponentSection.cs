using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Tenaris.View.CycleTime.Config
{
    public class ExportMachineComponentSection : ConfigurationSection
    {
        [ConfigurationProperty("MachineComponents")]
        public MachineComponentCollection MachineComponents
        {
            get
            {
                return (MachineComponentCollection)this["MachineComponents"];
            }
            set
            {
                this["MachineComponents"] = value;
            }
        }
    }
}
