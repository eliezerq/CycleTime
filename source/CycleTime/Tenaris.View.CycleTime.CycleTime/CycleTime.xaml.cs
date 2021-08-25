//-----------------------------------------------------------------------
// <copyright file="CycleTime.xaml.cs" company="Tenaris Tamsa S.A.">
//     Automation Unified System
//     Copyright© Tenaris S.A. 2011
// </copyright>
//-----------------------------------------------------------------------

namespace Tenaris.View.CycleTime.CycleTime
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;
    using Tenaris.View.CycleTime.ViewModel;
    using Tenaris.View.CycleTime.Config;

    /// <summary>
    /// Interaction logic for CycleTime.xaml
    /// </summary>
    public partial class CycleTime : Window
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="CycleTime"/> class.
        /// </summary>
        public CycleTime()
        {
            InitializeComponent();

            string title = Tenaris.View.CycleTime.View.Resources.CycleTimeStrings.CycleTime;
            string typeLine = ConfigurationManager.AppSettings["Line"];
            string areaName = ConfigurationManager.AppSettings["AreaName"];
            
            Tenaris.Library.Log.Trace.Message("Inicializando la vista: Línea: {0}", typeLine);

            this.Main = new CycleTimeMainViewModel(title, areaName, typeLine);
            this.DataContext = this.Main;

            Application.Current.Exit += new ExitEventHandler(this.Current_Exit);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the main.
        /// </summary>
        /// <value>
        /// The main view model.
        /// </value>
        public CycleTimeMainViewModel Main { get; set; }
        #endregion

        #region Method
        /// <summary>
        /// Handles the Exit event of the Current control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.ExitEventArgs"/> instance containing the event data.</param>
        public void Current_Exit(object sender, ExitEventArgs e)
        {
            this.Main.UnLoad();
        }
        #endregion
    }
}
