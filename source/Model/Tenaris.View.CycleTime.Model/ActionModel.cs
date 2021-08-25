//-----------------------------------------------------------------------
// <copyright file="ActionModel.cs" company="Tenaris Tamsa S.A.">
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
   /// ActionModel Class
   /// </summary>
   public class ActionModel
   {
      /// <summary>
      /// Gets or sets the real time in seconds.
      /// </summary>
      /// <value>
      /// The real time in seconds.
      /// </value>
      public float RealTimeInSeconds { get; set; }

      /// <summary>
      /// Gets or sets the real time offset in seconds.
      /// </summary>
      /// <value>
      /// The real time offset in seconds.
      /// </value>
      public float RealTimeOffsetInSeconds { get; set; }

      /// <summary>
      /// Gets or sets the real time start.
      /// </summary>
      /// <value>
      /// The real time start.
      /// </value>
      public string RealTimeStart { get; set; }

      /// <summary>
      /// Gets or sets the real time end.
      /// </summary>
      /// <value>
      /// The real time end.
      /// </value>
      public string RealTimeEnd { get; set; }
      /*public string StandardTime;
      public string StandardTimeOffset;*/
   }
}
