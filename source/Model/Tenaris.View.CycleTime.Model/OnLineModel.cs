//-----------------------------------------------------------------------
// <copyright file="OnLineModel.cs" company="Tenaris Tamsa S.A.">
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
   /// OnLineModel Class
   /// </summary>
   public class OnLineModel
   {
      /// <summary>
      /// Gets or sets the machines.
      /// </summary>
      /// <value>
      /// The machines.
      /// </value>
      public List<MachineComponentModel> Machines { get; set; }

      /// <summary>
      /// Gets or sets the bottle neck.
      /// </summary>
      /// <value>
      /// The bottle neck.
      /// </value>
      public int BottleNeck { get; set; }
   }
}
