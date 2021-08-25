//-----------------------------------------------------------------------
// <copyright file="AsposePosition.cs" company="Tenaris Tamsa S.A.">
//     Automation Unified System
//     Copyright© Tenaris S.A. 2011
// </copyright>
//-----------------------------------------------------------------------

namespace Tenaris.View.CycleTime.Aspose
{
   using System;
   using System.Collections.Generic;
   using System.Linq;
   using System.Text;

   /// <summary>
   /// AsposePosition class
   /// </summary>
   public class AsposePosition
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="AsposePosition"/> class.
      /// </summary>
      public AsposePosition()
      {
         this.Row = new AsposeRow();
         this.Column = new AsposeColumn();
      }

      public AsposePosition(AsposePosition position)
      {
          this.Row = new AsposeRow(position.Row);
          this.Column = new AsposeColumn(position.Column);
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="AsposePosition"/> class.
      /// </summary>
      /// <param name="column">The column cell.</param>
      /// <param name="row">The row cell.</param>
      public AsposePosition(int column, int row)
      {
         this.Row = new AsposeRow(row);
         this.Column = new AsposeColumn(column);
      }

      /// <summary>
      /// Gets or sets the fix column.
      /// </summary>
      /// <value>
      /// The fix column.
      /// </value>
      public int FixColumn { get; set; }

      /// <summary>
      /// Gets or sets the fix row.
      /// </summary>
      /// <value>
      /// The fix row.
      /// </value>
      public int FixRow { get; set; }

      /// <summary>
      /// Gets or sets the row.
      /// </summary>
      /// <value>
      /// The row cell.
      /// </value>
      public AsposeRow Row { get; set; }

      /// <summary>
      /// Gets or sets the column.
      /// </summary>
      /// <value>
      /// The column cell.
      /// </value>
      public AsposeColumn Column { get; set; }

      /// <summary>
      /// Gets the value.
      /// </summary>
      public string Value
      {
         get
         {
            return this.Column.Value + this.Row.Value;
         }
      }                         
   }
}
