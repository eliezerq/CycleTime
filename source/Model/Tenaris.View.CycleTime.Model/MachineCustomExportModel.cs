using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tenaris.View.CycleTime.Model
{
    public class MachineCustomExportModel
    {
        #region Constructor
        public MachineCustomExportModel()
        {
        }
        #endregion
        #region Properties
        public int Id { get; set; }
        public string StoredProcedure { get; set; }
        public List<ColumnCustomExportModel> ColumnsCustom { get; set; }
        #endregion
    }
}
