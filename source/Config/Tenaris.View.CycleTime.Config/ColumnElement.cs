using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Tenaris.View.CycleTime.Config
{
    public class ColumnElement : ConfigurationElement
    {
        [ConfigurationProperty("Name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get
            {
                return this["Name"].ToString();
            }
            set
            {
                this["Name"] = value;
            }
        }
    }
}
