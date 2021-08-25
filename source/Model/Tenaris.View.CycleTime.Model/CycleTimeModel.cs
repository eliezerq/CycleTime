//-----------------------------------------------------------------------
// <copyright file="CycleTimeModel.cs" company="Tenaris Tamsa S.A.">
//     Automation Unified System
//     Copyright© Tenaris S.A. 2011
// </copyright>
//-----------------------------------------------------------------------

namespace Tenaris.View.CycleTime.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// CycleTimeModel Class
    /// </summary>
    public class CycleTimeModel
    {
        /// <summary>
        /// Gets or sets the elements.
        /// </summary>
        /// <value>
        /// The elements.
        /// </value>
        public List<ElementModel> Elements { get; set; }

        public int idHistory { get; set; }
        public string Order { get; set; }
        public string Heat { get; set; }
        public string Product { get; set; }
        public string PipeNumber { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string StandarCycleTime { get; set; }
        public string RealCycleTime { get; set; }
        public string PipeType { get; set; }
        public string WorkMode { get; set; }
        public string Comments { get; set; }
        public bool IsSelected { get; set; }        
        public List<ColumnCustomExportModel> ColumnsCustom { get; set; }
    }
}
