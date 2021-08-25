//-----------------------------------------------------------------------
// <copyright file="AsposeFieldNames.cs" company="Tenaris Tamsa S.A.">
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
   /// AsposeFieldNames Class
   /// </summary>
   public class AsposeFieldNames
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="AsposeFieldNames"/> class.
      /// </summary>
      /// <param name="fieldName">Name of the field.</param>
      /// <param name="title">The title.</param>
      public AsposeFieldNames(string fieldName, string title)
      {
         this.FieldName = fieldName;
         this.Title = title;
      }

      /// <summary>
      /// Gets or sets the name of the field.
      /// </summary>
      /// <value>
      /// The name of the field.
      /// </value>
      public string FieldName { get; set; }

      /// <summary>
      /// Gets or sets the title.
      /// </summary>
      /// <value>
      /// The title file.
      /// </value>
      public string Title { get; set; }  
   }
}
