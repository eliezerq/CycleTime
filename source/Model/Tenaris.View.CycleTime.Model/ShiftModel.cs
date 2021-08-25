//-----------------------------------------------------------------------
// <copyright file="ShiftModel.cs" company="Tenaris Tamsa S.A.">
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
   /// ShiftModel Class
   /// </summary>
   public class ShiftModel
   {
      /// <summary>
      /// Gets or sets the id regime.
      /// </summary>
      /// <value>
      /// The id regime.
      /// </value>
      public int IdRegime { get; set; }

      /// <summary>
      /// Gets or sets the code.
      /// </summary>
      /// <value>
      /// The code for Shift.
      /// </value>
      public string Code { get; set; }

      /// <summary>
      /// Gets or sets the name.
      /// </summary>
      /// <value>
      /// The name for shift.
      /// </value>
      public string Name { get; set; }

      /// <summary>
      /// Gets or sets the description.
      /// </summary>
      /// <value>
      /// The description.
      /// </value>
      public string Description { get; set; }

      /// <summary>
      /// Gets or sets the date.
      /// </summary>
      /// <value>
      /// The date for shift.
      /// </value>
      public DateTime Date { get; set; }

      /// <summary>
      /// Gets or sets the shift number.
      /// </summary>
      /// <value>
      /// The shift number.
      /// </value>
      public int ShiftNumber { get; set; }

      /// <summary>
      /// Gets or sets the begin time.
      /// </summary>
      /// <value>
      /// The begin time.
      /// </value>
      public DateTime BeginTime { get; set; }

      /// <summary>
      /// Gets or sets the end time.
      /// </summary>
      /// <value>
      /// The end time.
      /// </value>
      public DateTime EndTime { get; set; }
   }
}
