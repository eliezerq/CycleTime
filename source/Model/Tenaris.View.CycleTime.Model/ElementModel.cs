//-----------------------------------------------------------------------
// <copyright file="ElementModel.cs" company="Tenaris Tamsa S.A.">
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
    using System.Data;

    /// <summary>
    /// ElementModel Class
    /// </summary>
    public class ElementModel
    {
        #region Constructor
        public ElementModel()
        {
        }
        public ElementModel(DataRow row)
        {
            int idElement;
            int.TryParse(row["idElement"].ToString(), out idElement);
            this.Id = idElement;

            this.Name = row["ElementName"].ToString();            

            float standarDuration;
            float.TryParse(row["StandardDuration"].ToString(), out standarDuration);
            this.StandardTimeInSeconds = standarDuration;

            float duration;
            float.TryParse(row["Duration"].ToString(), out duration);
            this.RealTimeInSeconds = duration;
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id element.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name element.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the id PLC tag.
        /// </summary>
        /// <value>
        /// The id PLC tag.
        /// </value>
        public string IdPLCTag { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the real time.
        /// </summary>
        /// <value>
        /// The real time.
        /// </value>
        public string RealTime { get; set; }

        /// <summary>
        /// Gets or sets the real time in seconds.
        /// </summary>
        /// <value>
        /// The real time in seconds.
        /// </value>
        public float RealTimeInSeconds { get; set; }

        /// <summary>
        /// Gets or sets the standard time in seconds.
        /// </summary>
        /// <value>
        /// The standard time in seconds.
        /// </value>
        public float StandardTimeInSeconds { get; set; }

        /// <summary>
        /// Gets or sets the standard time offset in seconds.
        /// </summary>
        /// <value>
        /// The standard time offset in seconds.
        /// </value>
        public float StandardTimeOffsetInSeconds { get; set; }

        /// <summary>
        /// Gets or sets the average time in seconds.
        /// </summary>
        /// <value>
        /// The average time in seconds.
        /// </value>
        public float AverageTimeInSeconds { get; set; }

        /// <summary>
        /// Gets or sets the average time offset in seconds.
        /// </summary>
        /// <value>
        /// The average time offset in seconds.
        /// </value>
        public float AverageTimeOffsetInSeconds { get; set; }

        /// <summary>
        /// Gets or sets the standard cycle time.
        /// </summary>
        /// <value>
        /// The standard cycle time.
        /// </value>
        public float StandardCycleTime { get; set; }

        /// <summary>
        /// Gets or sets the real cycle time.
        /// </summary>
        /// <value>
        /// The real cycle time.
        /// </value>
        public float RealCycleTime { get; set; }
        #endregion
    }
}
