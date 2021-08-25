//-----------------------------------------------------------------------
// <copyright file="EguModel.cs" company="Tenaris Tamsa S.A.">
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
   /// EguModel Class
   /// </summary>
   public class EguModel
   {
      #region Constructor
      /// <summary>
      /// Initializes a new instance of the <see cref="EguModel"/> class.
      /// </summary>
      public EguModel()
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="EguModel"/> class.
      /// </summary>
      /// <param name="scale">The scale of Egu.</param>
      /// <param name="bias">The bias of Egu.</param>
      public EguModel(float scale, float bias)
      {
         this.Scale = scale;
         this.Bias = bias;
         this.Name = string.Empty;
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="EguModel"/> class.
      /// </summary>
      /// <param name="scale">The scale.</param>
      /// <param name="bias">The bias of Egu.</param>
      /// <param name="name">The name of Egu.</param>
      public EguModel(double scale, float bias, string name)
      {
         this.Scale = scale;
         this.Bias = bias;
         this.Name = string.Empty;
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="EguModel"/> class.
      /// </summary>
      /// <param name="scale">The scale.</param>
      /// <param name="bias">The bias of Egu.</param>
      /// <param name="name">The name of Egu.</param>
      public EguModel(float scale, float bias, string name)
      {
         this.Scale = scale;
         this.Bias = bias;
         this.Name = name;
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="EguModel"/> class.
      /// </summary>
      /// <param name="scale">The scale.</param>
      /// <param name="bias">The bias of Egu.</param>
      /// <param name="name">The name of Egu.</param>
      public EguModel(string scale, string bias, string name)
      {
         float tempParse;
         float.TryParse(scale, out tempParse);
         this.Scale = tempParse;
         float.TryParse(bias, out tempParse);
         this.Bias = tempParse;
         this.Name = name;
      }
      #endregion

      #region Properties
      /// <summary>
      /// Gets or sets the scale.
      /// </summary>
      /// <value>
      /// The scale of Egu.
      /// </value>
      public double Scale { get; set; }

      /// <summary>
      /// Gets or sets the bias.
      /// </summary>
      /// <value>
      /// The bias of Egu.
      /// </value>
      public float Bias { get; set; }

      /// <summary>
      /// Gets or sets the name.
      /// </summary>
      /// <value>
      /// The name of Egu.
      /// </value>
      public string Name { get; set; }
      #endregion
   }
}
