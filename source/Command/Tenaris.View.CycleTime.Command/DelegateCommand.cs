//-----------------------------------------------------------------------
// <copyright file="DelegateCommand.cs" company="Tenaris Tamsa S.A.">
//     Automation Unified System
//     Copyright© Tenaris S.A. 2011
// </copyright>
//-----------------------------------------------------------------------

namespace Tenaris.View.CycleTime.Command
{
   using System;
   using System.Collections.Generic;
   using System.Linq;
   using System.Text;
   using System.Windows.Input;

   /// <summary>
   /// DelegateCommand Class
   /// </summary>
   public class DelegateCommand : ICommand
   {
      /// <summary>
      /// Property Read Only Predicate
      /// </summary>
      private readonly Predicate<object> canExecute;

      /// <summary>
      /// Property Read Only Action
      /// </summary>
      private readonly Action<object> execute;

      /// <summary>
      /// Initializes a new instance of the <see cref="DelegateCommand"/> class.
      /// </summary>
      /// <param name="execute">The execute.</param>
      public DelegateCommand(Action<object> execute)
         : this(execute, null)
      {
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="DelegateCommand"/> class.
      /// </summary>
      /// <param name="execute">The execute.</param>
      /// <param name="canExecute">The can execute.</param>
      public DelegateCommand(Action<object> execute, Predicate<object> canExecute)
      {
         this.execute = execute;
         this.canExecute = canExecute;
      }

      /// <summary>
      /// Occurs when changes occur that affect whether or not the command should execute.
      /// </summary>
      public event EventHandler CanExecuteChanged;

      /// <summary>
      /// Defines the method that determines whether the command can execute in its current state.
      /// </summary>
      /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
      /// <returns>
      /// true if this command can be executed; otherwise, false.
      /// </returns>
      public bool CanExecute(object parameter)
      {
         if (this.canExecute == null)
         {
            return true;
         }

         return this.canExecute(parameter);
      }

      /// <summary>
      /// Defines the method to be called when the command is invoked.
      /// </summary>
      /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
      public void Execute(object parameter)
      {
         this.execute(parameter);
      }

      /// <summary>
      /// Raises the can execute changed.
      /// </summary>
      public void RaiseCanExecuteChanged()
      {
         if (this.CanExecuteChanged != null)
         {
            this.CanExecuteChanged(this, EventArgs.Empty);
         }
      }
   }
}