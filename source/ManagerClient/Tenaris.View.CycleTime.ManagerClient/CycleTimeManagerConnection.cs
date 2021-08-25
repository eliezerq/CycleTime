// -----------------------------------------------------------------------
// <copyright file="CycleTimeManagerConnection.cs" company="Tenaris Tamsa S.A.">
//     Automation Unified System
//     Copyright© Tenaris S.A. 2011
// </copyright>
// -----------------------------------------------------------------------

namespace Tenaris.View.CycleTime.ManagerClient
{
   using System;
   using Tenaris.Library.ConnectionMonitor;
   using Tenaris.Library.Log;
   using Tenaris.Library.System.Factory;
   using Tenaris.Library.System.Remoting;
   using Tenaris.Manager.CycleTime.Common;

   /// <summary>
   /// CycleTimeManagerConnection class
   /// </summary>
   public class CycleTimeManagerConnection
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="CycleTimeManagerConnection"/> class.
      /// </summary>
      public CycleTimeManagerConnection()
      {
         this.IsConnected = false;

         // Configura el canal remoting del cliente
         System.Runtime.Remoting.RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
         ConnectionMonitor.Instance.StateChanged += this.InstanceStateChanged;

         // Instanciacion del manager a traves de FactoryProvider
         IFactory<ICycleTimeManager> factory = FactoryProvider.Instance.CreateFactory<ICycleTimeManager>("Tenaris.Manager.CycleTime.CycleTimeManager");
         this.InstanceManager = factory.Create();
      }

      /// <summary>
      /// State Change Delagete
      /// </summary>
      /// <param name="sender">The sender.</param>
      /// <param name="args">The <see cref="Tenaris.Library.ConnectionMonitor.StateChangeEventArgs"/> instance containing the event data.</param>
      public delegate void StateChangeDelagete(object sender, StateChangeEventArgs args);

      /// <summary>
      /// Occurs when [state changed manager].
      /// </summary>
      public event StateChangeDelagete StateChangedManager;      

      /// <summary>
      /// Gets or sets a value indicating whether this instance manager is connected.
      /// </summary>
      /// <value>
      ///   <c>true</c> if this instance is connected; otherwise, <c>false</c>.
      /// </value>
      public bool IsConnected { get; set; }

      /// <summary>
      /// Gets or sets the instance manager.
      /// </summary>
      /// <value>
      /// The instance manager.
      /// </value>
      public ICycleTimeManager InstanceManager { get; set; }

      /// <summary>
      /// Uns the load connection monitor.
      /// </summary>
      public void UnLoadConnectionMonitor()
      {
         ConnectionMonitor.Instance.Stop(true);
         ConnectionMonitor.Instance.Dispose();
      }

      /// <summary>
      /// Uns the load manager.
      /// </summary>
      public void UnLoadManager()
      {
         // InstanceManager.Dispose();
         this.InstanceManager = null;
      }

      /// <summary>
      /// Handler for CycleTime manager state changed event
      /// </summary>
      /// <param name="sender">The sender.</param>
      /// <param name="e">The arguments for state changed event</param>
      private void InstanceStateChanged(object sender, StateChangeEventArgs e)
      {
         if (e.Connection is ICycleTimeManager)
         {
            if (e.IsConnected)
            {
               Trace.Message("------------------------------------------------");
               Trace.Message("CycleTime MANAGER CONNECTION READY!!!");

               // this.Activate();
               this.IsConnected = true;
            }
            else
            {
               Trace.Message("------------------------------------------------");
               Trace.Message("CycleTime MANAGER CONNECTION LOST!!!");

               // this.DeActivate();
               this.IsConnected = false;
            }
         }

         if (this.StateChangedManager != null)
         {
            this.StateChangedManager(sender, e);
         }
      }
   }
}

