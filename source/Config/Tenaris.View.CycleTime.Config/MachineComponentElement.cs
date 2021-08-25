using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Tenaris.View.CycleTime.Config
{
    public class MachineComponentElement : ConfigurationElement
    {
        [ConfigurationProperty("Id", IsKey = true, IsRequired = true)]
        public int Id
        {
            get
            {
                
                return (int)this["Id"];
            }
            set
            {
                this["Id"] = value;
            }
        }

        [ConfigurationProperty("StoredProcedureExportCustom", IsRequired = true)]
        public string StoredProcedureExportCustom
        {
            get
            {
                return (string)this["StoredProcedureExportCustom"];
            }
            set
            {
                this["StoredProcedureExportCustom"] = value;
            }
        }

        [ConfigurationProperty("VisualizeMachine", IsRequired = false)]
        public string VisualizeMachine
        {
            get
            {
                return (string)this["VisualizeMachine"];
            }
            set
            {
                this["VisualizeMachine"] = value;
            }
        }

        [ConfigurationProperty("ColumnsForExport")]
        public ColumnCollection ColumnsForExport
        {
            get
            {
                return (ColumnCollection)this["ColumnsForExport"];
            }
            set
            {
                this["ColumnsForExport"] = value;
            }
        }
    }
}
