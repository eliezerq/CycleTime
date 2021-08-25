// -----------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="Tenaris Tamsa S.A.">
//     Automation Unified System
//     Copyright© Tenaris S.A. 2011
// </copyright>
// -----------------------------------------------------------------------

namespace Tenaris.View.CycleTime.Test
{
   using System;
   using System.Collections.Generic;
   using System.Configuration;
   using System.Data;
   using System.Globalization;
   using System.Linq;
   using System.Threading;
   using System.Windows;     

   /// <summary>
   /// Interaction logic for App.xaml
   /// </summary>
   public partial class App : Application
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="App"/> class.
      /// </summary>
      /// <exception cref="T:System.InvalidOperationException">More than one instance of the <see cref="T:System.Windows.Application"/> class is created per <see cref="T:System.AppDomain"/>.</exception>
      public App()
      {
         // var ci = new CultureInfo("en-US");
         var ci = new CultureInfo("es-MX");
         Thread.CurrentThread.CurrentCulture = ci;
         Thread.CurrentThread.CurrentUICulture = ci;
      }
   }
}
