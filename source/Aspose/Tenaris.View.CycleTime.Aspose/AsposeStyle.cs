// -----------------------------------------------------------------------
// <copyright file="AsposeStyle.cs" company="Tenaris Tamsa S.A.">
//     Automation Unified System
//     Copyright© Tenaris S.A. 2011
// </copyright>
// -----------------------------------------------------------------------
using Aspose.Cells;

namespace Tenaris.View.CycleTime.Aspose
{
   using System;
   using System.Collections.Generic;
   using System.Drawing;
   using System.Linq;
   using System.Text;

   /// <summary>
   /// AsposeStyle class
   /// </summary>
   public class AsposeStyle
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="AsposeStyle"/> class.
      /// </summary>
      public AsposeStyle()
      {
      }

      /// <summary>
      /// Gets or sets the title style.
      /// </summary>
      /// <value>
      /// The title style.
      /// </value>
      public Style TitleStyle { get; set; }

      /// <summary>
      /// Gets or sets the row style.
      /// </summary>
      /// <value>
      /// The row style.
      /// </value>
      public Style RowStyle { get; set; }

      /// <summary>
      /// Defines the title style.
      /// </summary>
      /// <param name="cell">The cell to set style.</param>
      public void DefineTitleStyle(Cell cell)
      {
         // Defining a Style object
         Style style = cell.GetStyle();

         // Setting the vertical alignment
         style.VerticalAlignment = TextAlignmentType.Center;

         // Setting the horizontal alignment
         style.HorizontalAlignment = TextAlignmentType.Center;

         // Setting the font color of the text
         style.Font.Color = Color.FromArgb(0, 51, 102);

         // Setting the font Name of the text
         style.Font.Name = "Verdana";

         // Setting the font Name of the text
         style.Font.IsBold = true;

         // Setting the BackgroundColor of the text
         // style.BackgroundColor = Color.FromArgb(204, 217, 204);
         style.ForegroundColor = Color.LightSkyBlue;

         style.Pattern = BackgroundType.Solid;

         // Setting the bottom border color to (0, 51, 102)
         style.Borders[BorderType.BottomBorder].Color = Color.FromArgb(0, 51, 102);
         style.Borders[BorderType.TopBorder].Color = Color.FromArgb(0, 51, 102);
         style.Borders[BorderType.LeftBorder].Color = Color.FromArgb(0, 51, 102);
         style.Borders[BorderType.RightBorder].Color = Color.FromArgb(0, 51, 102);

         // Setting the bottom border type to medium
         style.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;
         style.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
         style.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
         style.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;

         // Applying the style to A1 cell
         this.TitleStyle = style;
      }

      /// <summary>
      /// Defines the row style.
      /// </summary>
      /// <param name="cell">The cell to set style.</param>
      public void DefineRowStyle(Cell cell)
      {
         // Defining a Style object
         Style style = cell.GetStyle();

         // Setting the vertical alignment
         style.VerticalAlignment = TextAlignmentType.Center;

         // Setting the horizontal alignment
         style.HorizontalAlignment = TextAlignmentType.Center;

         // Setting the font color of the text
         style.Font.Color = Color.Black;

         // Setting the font Name of the text
         style.Font.Name = "Verdana";

         // Setting the font Name of the text
         style.Font.IsBold = false;

         // Setting the BackgroundColor of the text
         // style.BackgroundColor = Color.FromArgb(204, 217, 204);

         // Applying the style to A1 cell
         this.RowStyle = style;
      }
   }
}
