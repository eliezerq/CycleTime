// -----------------------------------------------------------------------
// <copyright file="CycleTimeMachineClient.cs" company="Tenaris Tamsa S.A.">
//     Automation Unified System
//     Copyright© Tenaris S.A. 2011
// </copyright>
// -----------------------------------------------------------------------        

namespace Tenaris.View.CycleTime.ManagerClient
{
   using System;
   using System.Collections.Generic;
   using System.Linq;
   using System.Text;
   using Tenaris.Library.ConnectionMonitor;
   using Tenaris.Library.Log;              
   using Tenaris.Library.System.Remoting;  
   using Tenaris.Manager.CycleTime.Common;
   using Tenaris.View.CycleTime.Model;

   /// <summary>
   /// CycleTimeMachineClient class.
   /// </summary>
   public class CycleTimeMachineComponentClient
   {
      /// <summary>
      /// List of RemotableEvents for CycleTimeHandler 
      /// </summary>
      public readonly RemotableEvent<CycleTimeEventArgs> OnCycleTimeHandler = new RemotableEvent<CycleTimeEventArgs>();

      /// <summary>
      /// Initializes a new instance of the <see cref="CycleTimeMachineClient"/> class.
      /// </summary>
      /// <param name="machine">The machine.</param>
      /// <param name="manager">The manager.</param>
      public CycleTimeMachineComponentClient(MachineComponentModel machineComponent, CycleTimeManagerConnection manager)
      {
         this.MachineComponent = machineComponent;
         this.MachineComponentReference = null;
         this.ManagerConnection = manager;
         this.ManagerConnection.StateChangedManager += this.InstanceStateChanged;
         if (this.ManagerConnection.IsConnected && !this.IsConnected)
         {
            this.Activate();
         }
      }  
      
      /// <summary>
      /// Delegate for Cycle Time
      /// </summary>
      /// <param name="sender">The sender.</param>
      /// <param name="args">The <see cref="Tenaris.Manager.CycleTime.Common.CycleTimeEventArgs"/> instance containing the event data.</param>
      public delegate void CycleTimeDelagete(object sender, CycleTimeEventArgs args);

      /// <summary>
      /// Occurs when [on cycle time].
      /// </summary>
      public event CycleTimeDelagete OnCycleTime;

      /// <summary>
      /// Gets or sets the machine.
      /// </summary>
      /// <value>
      /// The machine.
      /// </value>
      public MachineComponentModel MachineComponent { get; set; }

      /// <summary>
      /// Gets or sets the name of the client.
      /// </summary>
      /// <value>
      /// The name of the client.
      /// </value>
      public string ClientName { get; set; }

      /// <summary>
      /// Gets or sets a value indicating whether this instance is connected.
      /// </summary>
      /// <value>
      ///   <c>true</c> if this instance is connected; otherwise, <c>false</c>.
      /// </value>
      public bool IsConnected { get; set; }
            
      /// <summary>
      /// Gets or sets the machine reference.
      /// </summary>
      /// <value>
      /// The machine reference.
      /// </value>
      //internal ICycleTimeMachine MachineReference { get; set; }

      internal ICycleTimeComponent MachineComponentReference { get; set; }


      /// <summary>
      /// Gets or sets the manager connection.
      /// </summary>
      /// <value>
      /// The manager connection.
      /// </value>
      private CycleTimeManagerConnection ManagerConnection { get; set; }

      /// <summary>
      /// Instances the state changed.
      /// </summary>
      /// <param name="sender">The sender.</param>
      /// <param name="e">The <see cref="Tenaris.Library.ConnectionMonitor.StateChangeEventArgs"/> instance containing the event data.</param>
      public void InstanceStateChanged(object sender, StateChangeEventArgs e)
      {
         if (e.Connection is ICycleTimeManager)
         {
            if (e.IsConnected)
            {
               this.Activate();
            }
            else
            {
               this.Deactivate();
            }
         }
      }

      /// <summary>
      /// Activates this instance.
      /// </summary>
      /// <returns>
      ///   <c>true</c> if this instance was activated; otherwise, <c>false</c>.
      /// </returns>
      internal bool Activate()
      {
         try
         {
            if (!this.IsConnected)
            {
               this.MachineComponentReference = this.ManagerConnection.InstanceManager.GetCycleTimeComponent(this.MachineComponent.IdMachineComponent);
               this.MachineComponentReference.OnCycleTime += this.OnCycleTimeHandler.Handler;
               this.OnCycleTimeHandler.Event += this.OnCycleTimeEvent;
               Trace.Message("------------------------------------------------");
               Trace.Message("CycleTime Client Connection Machine: " + this.MachineComponent.IdMachineComponent + ", READY!!!");
               this.IsConnected = true;
            }
            else
            {
               Trace.Debug("The Client Connection Machine: " + this.MachineComponent.IdMachineComponent + ". {0}, Is alredy Connected");
            }

            return true;
         }
         catch (Exception ex)
         {
            Trace.Debug("Error Activating the Client Connection Machine: " + this.MachineComponent.IdMachineComponent + ". {0}", ex.Message);
            return false;
         }
      }

      /// <summary>
      /// Deactivates this instance.
      /// </summary>
      /// <returns>
      ///   <c>true</c> if this instance was deactivated; otherwise, <c>false</c>.
      /// </returns>
      internal bool Deactivate()
      {
         try
         {
            if (this.MachineComponentReference != null)
            {
               this.OnCycleTimeHandler.Event -= this.OnCycleTimeEvent;
               this.MachineComponentReference.OnCycleTime -= this.OnCycleTimeHandler.Handler;
               this.MachineComponentReference = null;
               Trace.Message("------------------------------------------------");
               Trace.Message("CycleTime Client Connection Machine Component: " + this.MachineComponent.IdMachineComponent + ", LOST!!!");
               this.IsConnected = false;
            }
            else
            {
               Trace.Debug("The Client Connection Machine Component: " + this.MachineComponent.IdMachineComponent + ". {0}, Is alredy Disconnected");
            }

            return true;
         }
         catch (Exception ex)
         {
            Trace.Debug("ERROR DeActivating the Client Connection Machine Component: " + this.MachineComponent.IdMachineComponent + ". {0}", ex.Message);
            return false;
         }
      }

      /// <summary>
      /// Called when [cycle time event].
      /// </summary>
      /// <param name="sender">The sender.</param>
      /// <param name="args">The <see cref="Tenaris.Manager.CycleTime.Common.CycleTimeEventArgs"/> instance containing the event data.</param>
      private void OnCycleTimeEvent(object sender, CycleTimeEventArgs args)
      {
         Trace.Message(string.Empty);
         Trace.Message("-----------------------");
         Trace.Message(this.ClientName + ": Recieve the OnCycleTime Event ...");
         Trace.Message(">>> Machine:{0}", this.MachineComponentReference.Name);
         string message = ">>> IdHistory: ";         
         for (int i = 0; i < args.HistoryList.Count; i++)
         {
            message = message + args.HistoryList[i].ToString() + ", ";
         }
         Trace.Message(message);
         Trace.Message(">>> DateTime:{0}", args.EventDateTime);
         if (this.OnCycleTime != null)
         {
            this.OnCycleTime(sender, args);
         }
      }         
   }
}
