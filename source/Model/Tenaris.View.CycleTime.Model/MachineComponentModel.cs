//-----------------------------------------------------------------------
// <copyright file="MachineComponentModel.cs" company="Tenaris Tamsa S.A.">
//     Automation Unified System
//     Copyright© Tenaris S.A. 2011
// </copyright>
//-----------------------------------------------------------------------

namespace Tenaris.View.CycleTime.Model
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// MachineModel Class
    /// </summary>
    public class MachineComponentModel
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="MachineComponentModel"/> class.
        /// </summary>
        public MachineComponentModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MachineComponentModel"/> class.
        /// </summary>
        /// <param name="idMachineComponent">The id machine component.</param>
        public MachineComponentModel(int idMachineComponent)
        {
            this.IdMachineComponent = idMachineComponent;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MachineComponentModel"/> class.
        /// </summary>
        /// <param name="row">The DataRow with machine data.</param>
        public MachineComponentModel(DataRow row)
        {
            int tempIntParse;
            bool tempBoolParse;

            int.TryParse(row["idMachineComponent"].ToString(), out tempIntParse);
            this.IdMachineComponent = tempIntParse;

            int.TryParse(row["idArea"].ToString(), out tempIntParse);
            this.IdArea = tempIntParse;

            this.Name = row["Name"].ToString();

            int.TryParse(row["SortOrder"].ToString(), out tempIntParse);
            this.SortOrder = tempIntParse;

            bool.TryParse(row["Active"].ToString(), out tempBoolParse);
            this.IsActive = tempBoolParse;
        }

        public MachineComponentModel(DataRow row, string areaCode)
        {
            int tempIntParse;
            bool tempBoolParse;

            int.TryParse(row["idMachineComponent"].ToString(), out tempIntParse);
            this.IdMachineComponent = tempIntParse;

            int.TryParse(row["idArea"].ToString(), out tempIntParse);
            this.IdArea = tempIntParse;

            this.Name = row["Name"].ToString();

            int.TryParse(row["SortOrder"].ToString(), out tempIntParse);
            this.SortOrder = tempIntParse;

            bool.TryParse(row["Active"].ToString(), out tempBoolParse);
            this.IsActive = tempBoolParse;

            this.AreaCode = areaCode;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the id machine.
        /// </summary>
        /// <value>
        /// The id machine.
        /// </value>
        public int IdMachineComponent { get; set; }

        /// <summary>
        /// Gets or sets the id area.
        /// </summary>
        /// <value>
        /// The id area.
        /// </value>
        public int IdArea { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name of Machine.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>
        /// The sort order.
        /// </value>
        public int SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the real time.
        /// </summary>
        /// <value>
        /// The real time.
        /// </value>
        public int RealTime { get; set; }

        /// <summary>
        /// Gets or sets the standard time.
        /// </summary>
        /// <value>
        /// The standard time.
        /// </value>
        public int StandardTime { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is bottle neck.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is bottle neck; otherwise, <c>false</c>.
        /// </value>
        public bool IsBottleNeck { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the area code.
        /// </summary>
        /// <value>
        /// The area code.
        /// </value>
        public string AreaCode { get; set; }
        #endregion
    }
}
