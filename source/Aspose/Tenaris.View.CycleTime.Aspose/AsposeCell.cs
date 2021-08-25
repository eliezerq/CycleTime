// -----------------------------------------------------------------------
// <copyright file="AsposeCell.cs" company="Tenaris Tamsa S.A.">
//     Automation Unified System
//     Copyright© Tenaris S.A. 2011
// </copyright>
// -----------------------------------------------------------------------

namespace Tenaris.View.CycleTime.Aspose
{
   using System;
   using System.Collections.Generic;
   using System.IO;
   using System.Linq;
   using System.Reflection;
   using System.Text;                   
   
   /// <summary>
   /// AsposeCell Class
   /// </summary>
   public class AsposeCell
   {
      /// <summary>
      /// Gets or sets the row.
      /// </summary>
      /// <value>
      /// The row cell.
      /// </value>
      public int Row { get; set; }

      /// <summary>
      /// Gets or sets the column.
      /// </summary>
      /// <value>
      /// The column cell.
      /// </value>
      public string Column { get; set; }
   }
}
