// -----------------------------------------------------------------------
// <copyright file="TrendGraph.xaml.cs" company="Tenaris Tamsa S.A.">
//     Automation Unified System
//     Copyright© Tenaris S.A. 2011
// </copyright>
// -----------------------------------------------------------------------

namespace Tenaris.View.CycleTime.TeeChart
{      
   using System;
   using System.Collections.Generic;
   using System.Collections.ObjectModel;
   using System.Linq;
   using System.Text;
   using System.Windows;
   using System.Windows.Controls;
   using System.Windows.Data;
   using System.Windows.Documents;
   using System.Windows.Input;
   using System.Windows.Media;
   using System.Windows.Media.Imaging;
   using System.Windows.Navigation;
   using System.Windows.Shapes;            
   using Tenaris.View.CycleTime.ViewModel;
   using Tenaris.View.CycleTime.ViewModel.Classes;

   /// <summary>
   /// Interaction logic for TrendGraph.xaml
   /// </summary>
   public partial class TrendGraph : UserControl
   {
      #region Dependency Properties
      /// <summary>
      /// Dependency property for <see cref="Series"/> property
      /// </summary>
      public static readonly DependencyProperty SeriesProperty =
         DependencyProperty.Register("Series", typeof(List<Bar>), typeof(TrendGraph), new UIPropertyMetadata(SeriesChanged));
      #endregion

      #region Constructor
      /// <summary>
      /// Initializes a new instance of the <see cref="TrendGraph"/> class.
      /// </summary>
      public TrendGraph()
      {
         InitializeComponent();
         this.InitializeGraph();
      }
      #endregion

      #region Properties
      /// <summary>
      /// Gets or sets the series.
      /// </summary>
      /// <value>
      /// The series.
      /// </value>
      public List<Bar> Series
      {
         get
         {
            return (List<Bar>)GetValue(SeriesProperty);
         }

         set
         {
            SetValue(SeriesProperty, value);
         }
      }        
      #endregion   

      #region Methods
      /// <summary>
      /// Initializes the graph.
      /// </summary>
      public void InitializeGraph()
      {
         this.Graph.Aspect.View3D = false;
         this.Graph.Header.Visible = false;
         this.Graph.Legend.Visible = false;

         //Graph.Axes.Left.Increment = Steema.TeeChart.WPF.Utils.GetDateTimeStep(Steema.TeeChart.WPF.DateTimeSteps.OneSecond);
         //Graph.Axes.Left.Labels.DateTimeFormat = "mm:ss";
                
      }          

      /// <summary>
      /// Sets the series.
      /// </summary>
      public void SetSeries()
      {
          //Steema.TeeChart.WPF.Styles.Line horizBar = new Steema.TeeChart.WPF.Styles.Line(Graph.Chart);
          //horizBar.YValues.DateTime = true;
          //Graph.Aspect.View3D = false;

          //DateTime today = DateTime.Today;
          //TimeSpan oneDay = TimeSpan.FromDays(1);
          //for (int i = 1; i < 10; i++)
          //{
          //    horizBar.Add(i, today.ToOADate(), Color.FromRgb(255, 172, 87));
          //    today += oneDay;
          //}

          ////DateTime dateIni;
          ////DateTime dateFin;

          ////for (int i = 0; i < this.Series.Count; i++)
          ////{
          ////    dateIni = Convert.ToDateTime("00:00:00.00");
          ////    dateFin = Convert.ToDateTime(this.Series[i].FrecuencyToTeeCharTime);
          ////    //lineser.Add(i + 1, this.Series[i].Frecuency, Color.FromRgb(255, 172, 87));
          ////    horizBar.Add(i + 1, dateFin, Color.FromRgb(0, 153, 0));
          ////}

          Graph.Axes.Bottom.Increment = Steema.TeeChart.WPF.Utils.GetDateTimeStep(Steema.TeeChart.WPF.DateTimeSteps.OneSecond);
          Graph.Axes.Bottom.Labels.DateTimeFormat = "mm:ss";
          Graph.Axes.Bottom.Labels.Angle = 90;

          Steema.TeeChart.WPF.Styles.Gantt lineser;
          lineser = new Steema.TeeChart.WPF.Styles.Gantt(Graph.Chart);
          //lineser.Pointer.VertSize = 5;
          //lineser.Pointer.HorizSize = 5;

          DateTime dateIni;
          DateTime dateFin;

          if (this.Series != null)
          {
              for (int i = 0; i < this.Series.Count; i++)
              {
                  dateIni = Convert.ToDateTime("00:00:00.00");
                  dateFin = Convert.ToDateTime(this.Series[i].FrecuencyToTeeCharTime);
                  //lineser.Add(i + 1, this.Series[i].Frecuency, Color.FromRgb(255, 172, 87));
                  lineser.Add(dateIni, dateFin, i + 1, Color.FromRgb(0, 153, 0));
              }
          }
      }

      /// <summary>
      /// Action for series propeperty changed.
      /// </summary>
      /// <param name="source">The source.</param>
      /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
      private static void SeriesChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
      {
         TrendGraph trendGraph = source as TrendGraph;

         trendGraph.Graph.Series.Clear();
         trendGraph.SetSeries();
      }
      #endregion
   }
}
