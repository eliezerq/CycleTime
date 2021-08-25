//-----------------------------------------------------------------------
// <copyright file="ProductionModel.cs" company="Tenaris Tamsa S.A.">
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
   /// ProductionModel Class
   /// </summary>
   public class ProductModel
   {
       /// <summary>
       /// Gets or sets the order.
       /// </summary>
       /// <value>
       /// The order for the product.
       /// </value>
       public string Order { get; set; }

       /// <summary>
       /// Gets or sets the heat.
       /// </summary>
       /// <value>
       /// The heat for the product.
       /// </value>
       public string Heat { get; set; }

       /// <summary>
       /// Gets or sets the product.
       /// </summary>
       /// <value>
       /// The product number.
       /// </value>
       public string Product { get; set; }

       /// <summary>
       /// Gets or sets the pipe number.
       /// </summary>
       /// <value>
       /// The pipe number for the product.
       /// </value>
       public string PipeNumber { get; set; }

       /// <summary>
       /// Gets or sets the customer.
       /// </summary>
       /// <value>
       /// The customer for the product.
       /// </value>
       public string Customer { get; set; }

       /// <summary>
       /// Gets or sets the steel code.
       /// </summary>
       /// <value>
       /// The steel code for the product.
       /// </value>
       public string SteelCode { get; set; }

       /// <summary>
       /// Gets or sets the steel grade.
       /// </summary>
       /// <value>
       /// The steel grade for the product.
       /// </value>
       public string SteelGrade { get; set; }

       /// <summary>
       /// Gets or sets the diameter.
       /// </summary>
       /// <value>
       /// The diameter for the product.
       /// </value>
       public string Diameter { get; set; }

       /// <summary>
       /// Gets or sets the thickness.
       /// </summary>
       /// <value>
       /// The thickness for the product.
       /// </value>
       public string Thickness { get; set; }

       /// <summary>
       /// Gets or sets the type of the pipe.
       /// </summary>
       /// <value>
       /// The type of the pipe.
       /// </value>
       public string PipeType { get; set; }

       /// <summary>
       /// Gets or sets the pressure time.
       /// </summary>
       /// <value>
       /// The pressure time.
       /// </value>
       public string PressureTime { get; set; }

       /// <summary>
       /// Gets or sets a value indicating whether [work mode].
       /// </summary>
       /// <value>
       ///   <c>true</c> if [work mode] is Automatic; Manual, <c>false</c>.
       /// </value>
       public bool WorkMode { get; set; }

       /// <summary>
       /// Gets or sets the id comment.
       /// </summary>
       /// <value>
       /// The id comment.
       /// </value>
       public int IdComment { get; set; }

       /// <summary>
       /// Gets or sets the comment detail.
       /// </summary>
       /// <value>
       /// The comment detail.
       /// </value>
       public string CommentDetail { get; set; }

       /// <summary>
       /// Gets or sets the detail comments.
       /// </summary>
       /// <value>
       /// The detail comments.
       /// </value>
       public string DetailComments { get; set; }

       /// <summary>
       /// Gets or sets the id batch machine.
       /// </summary>
       /// <value>
       /// The id batch machine.
       /// </value>
       public string IdBatchMachine { get; set; }

       /// <summary>
       /// Gets or sets the caliber.
       /// </summary>
       /// <value>
       /// The caliber.
       /// </value>
       public string Caliber { get; set; }

       /// <summary>
       /// Gets or sets the billet diameter.
       /// </summary>
       /// <value>
       /// The billet diameter.
       /// </value>
       public string BilletDiameter { get; set; }

       /// <summary>
       /// Gets or sets the length of the billet.
       /// </summary>
       /// <value>
       /// The length of the billet.
       /// </value>
       public string BilletLength { get; set; }

       /// <summary>
       /// Gets or sets the length of the piercing.
       /// </summary>
       /// <value>
       /// The length of the piercing.
       /// </value>
       public string PiercingLength { get; set; }
   }
}
