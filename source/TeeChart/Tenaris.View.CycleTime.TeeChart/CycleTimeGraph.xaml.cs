// -----------------------------------------------------------------------
// <copyright file="CycleTimeGraph.xaml.cs" company="Tenaris Tamsa S.A.">
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
   using Steema.TeeChart.WPF;
   using Tenaris.View.CycleTime.Model;
   using Tenaris.View.CycleTime.ViewModel;

   /// <summary>
   /// Interaction logic for CycleTimeGraph.xaml
   /// </summary>
   public partial class CycleTimeGraph : UserControl
   {
      #region Dependency Properties
      /// <summary>
      /// Dependency property for <see cref="Series"/> property 
      /// </summary>
      public static readonly DependencyProperty SeriesProperty =
         DependencyProperty.Register("Series", typeof(ObservableCollection<ElementViewModel>), typeof(CycleTimeGraph), new UIPropertyMetadata(SeriesChanged));

      /// <summary>
      /// Dependency property for <see cref="PaintAverageTime"/> property
      /// </summary>
      public static readonly DependencyProperty PaintAverageTimeProperty =
         DependencyProperty.Register("IsPaintAverageTime", typeof(bool), typeof(CycleTimeGraph), new UIPropertyMetadata(false, IsPaintAverageTimeChange));

      /// <summary>
      /// Expose Command like dependency property for <see cref="ClickedSeriesCommand"/>
      /// </summary>
      public static readonly DependencyProperty ClickedSeriesCommandProperty =
         DependencyProperty.Register("ClickedSeriesCommand", typeof(ICommand), typeof(CycleTimeGraph), new UIPropertyMetadata(null));

      #region Constructor
      /// <summary>
      /// Initializes a new instance of the <see cref="CycleTimeGraph"/> class.
      /// </summary>
      public CycleTimeGraph()
      {
         InitializeComponent();
      }
      #endregion

      /// <summary>
      /// Gets or sets the series.
      /// </summary>
      /// <value>
      /// The series.
      /// </value>
      public ObservableCollection<ElementViewModel> Series
      {
         get
         {
            return (ObservableCollection<ElementViewModel>)GetValue(SeriesProperty);
         }

         set
         {
            SetValue(SeriesProperty, value);
         }
      }

      /// <summary>
      /// Gets or sets a value indicating whether this instance is paint average time.
      /// </summary>
      /// <value>
      ///   <c>true</c> if this instance is paint average time; otherwise, <c>false</c>.
      /// </value>
      public bool IsPaintAverageTime
      {
         get
         {
            return (bool)GetValue(PaintAverageTimeProperty);
         }

         set
         {
            SetValue(PaintAverageTimeProperty, value);
         }
      }

      /// <summary>
      /// Gets or sets the clicked series command.
      /// </summary>
      /// <value>
      /// The clicked series command.
      /// </value>
      public ICommand ClickedSeriesCommand
      {
         get
         {
            return (ICommand)GetValue(ClickedSeriesCommandProperty);
         }

         set
         {
            SetValue(ClickedSeriesCommandProperty, value);
         }
      }
      #endregion

      #region Initialize
      /// <summary>
      /// Initializes the graph.
      /// </summary>
      public void InitializeGraph()
      {
         Graph.Series.Clear();

         this.Graph.Aspect.View3D = false;
         this.Graph.Header.Visible = false;
         this.Graph.Legend.Visible = false;

         // Option3: Manual drawing lines
         this.Graph.Axes.Left.Labels.Visible = false;
         this.Graph.BeforeDrawSeries += new Steema.TeeChart.WPF.PaintChartEventHandler(this.Graph_BeforeDrawSeries);

         this.Graph.Panel.MarginUnits = Steema.TeeChart.WPF.PanelMarginUnits.Pixels;
         this.Graph.Panel.MarginLeft = 0;
         this.Graph.Panel.MarginTop = 0;

         this.Graph.Axes.Bottom.Increment = Steema.TeeChart.WPF.Utils.GetDateTimeStep(Steema.TeeChart.WPF.DateTimeSteps.OneSecond);
         this.Graph.Axes.Bottom.Labels.DateTimeFormat = "mm:ss";
         this.Graph.Axes.Bottom.Labels.Angle = 90;

         // Graph.Tools.Add(new Steema.TeeChart.WPF.Tools.MarksTip());
         Steema.TeeChart.WPF.Axis leftAxis = this.Graph.Axes.Left;
         Steema.TeeChart.WPF.Axis botomAxis = this.Graph.Axes.Bottom;

         leftAxis.Labels.Visible = false;
         leftAxis.StartEndPositionUnits = PositionUnits.Pixels;

         leftAxis.Automatic = false;
         leftAxis.Maximum = 15;
         leftAxis.Minimum = 1;
         leftAxis.Increment = 1;
         leftAxis.StartPosition = 0;

         // leftAxis.EndPosition = 88.5;
         // row.Height = 54 pixels
         leftAxis.EndPosition = 378;   
         leftAxis.Inverted = true;
      }
      #endregion

      #region Methods
      /// <summary>
      /// Action for series changed.
      /// </summary>
      /// <param name="source">The source.</param>
      /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
      private static void SeriesChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
      {
         CycleTimeGraph cycleTimeGraph = source as CycleTimeGraph;

         cycleTimeGraph.Graph.Series.Clear();
         cycleTimeGraph.SetSeries();
      }

      /// <summary>
      /// Determines whether [is paint average time change] [the specified source].
      /// </summary>
      /// <param name="source">The source.</param>
      /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
      private static void IsPaintAverageTimeChange(DependencyObject source, DependencyPropertyChangedEventArgs e)
      {
         CycleTimeGraph cycleTimeGraph = source as CycleTimeGraph;
         if (cycleTimeGraph.IsPaintAverageTime)
         {
            cycleTimeGraph.PaintAverageTime();
         }
         else
         {
            cycleTimeGraph.Graph.Series.Clear();
            cycleTimeGraph.SetSeries();
         }
      }    

      /// <summary>
      /// Sets the series.
      /// </summary>
      private void SetSeries()
      {
          double spaceBetweenLines;
          double startLines;

          Graph.Series.Add(new Steema.TeeChart.WPF.Styles.Gantt());
          Graph.Series.Add(new Steema.TeeChart.WPF.Styles.Gantt());

          Steema.TeeChart.WPF.Styles.Gantt standarGantt = Graph.Series[0] as Steema.TeeChart.WPF.Styles.Gantt;
          Steema.TeeChart.WPF.Styles.Gantt realGantt = Graph.Series[1] as Steema.TeeChart.WPF.Styles.Gantt;

          standarGantt.Pointer.VertSize = 2;
          realGantt.Pointer.VertSize = 2;
          startLines = 0.15;
          spaceBetweenLines = 0.30;

          this.Graph.Axes.Left.GetAxisDrawLabel += new Steema.TeeChart.WPF.GetAxisDrawLabelEventHandler(this.Left_GetAxisDrawLabel);

          DateTime dateIni;
          DateTime dateFin;

          int line = 1;
          if (!(this.Series == null))
          {
              foreach (ElementViewModel e in this.Series)
              {
                  dateIni = Convert.ToDateTime(e.StandardTimeStart);
                  dateFin = Convert.ToDateTime(e.StandardTimeEnd);
                  standarGantt.Add(dateIni, dateFin, (line + startLines), Color.FromRgb(0, 51, 102));
                  foreach (ActionModel action in e.Actions)
                  {
                      dateIni = Convert.ToDateTime(action.RealTimeStart);
                      dateFin = Convert.ToDateTime(action.RealTimeEnd);
                      if (e.IsExceededTime)
                      {
                          realGantt.Add(dateIni, dateFin, (line + (startLines + spaceBetweenLines)), "Statistical\nElement:\t\tPressure Time\nBegin Date:\t1 jun 2010", Color.FromRgb(204, 0, 102));
                      }
                      else
                      {
                          realGantt.Add(dateIni, dateFin, (line + (startLines + spaceBetweenLines)), Color.FromRgb(0, 153, 0));
                      }
                  }

                  line++;
              }
          }
          // Pinta promedios si esta activo el checkbox
          if (this.IsPaintAverageTime)
          {
              this.PaintAverageTime();
          }
      }

      /// <summary>
      /// Draws the lines.
      /// </summary>
      private void DrawLines()
      {
         if ((!(this.Series == null)) && this.Series.Count > 1)
         {
            for (int i = 2; i < this.Series.Count + 2; i++)
            {
               // double YVal = Graph[0].YValues[i];  
               Point p0 = new Point(Graph.Axes.Bottom.IStartPos, Graph.Axes.Left.CalcPosValue(i));
               Point p1 = new Point(Graph.Axes.Bottom.IEndPos, Graph.Axes.Left.CalcPosValue(i));

               Graph.Graphics3D.Pen.Color = Graph.Axes.Left.Grid.Color;

               // g.Pen.Color = Color.FromRgb(243, 243, 243);
               Graph.Graphics3D.Pen.Style = DashStyles.Solid;
               Graph.Graphics3D.Pen.Width = 2;
               Graph.Graphics3D.Line(p0, p1);
            }
         }
      }

      /// <summary>
      /// Paints the average time.
      /// </summary>
      private void PaintAverageTime()
      {
         DateTime dateIni;
         DateTime dateFin;

         Graph.Series.Add(new Steema.TeeChart.WPF.Styles.Gantt());
         Steema.TeeChart.WPF.Styles.Gantt averageGantt = Graph.Series[2] as Steema.TeeChart.WPF.Styles.Gantt;

         averageGantt.Pointer.VertSize = 1;   

         int line = 1;
         if (!(this.Series == null))
         {
            foreach (ElementViewModel e in this.Series)
            {
               dateIni = Convert.ToDateTime(e.AverageTimeStart);
               dateFin = Convert.ToDateTime(e.AverageTimeEnd);
               averageGantt.Add(dateIni, dateFin, (line + 0.80), Color.FromRgb(255, 155, 0));
               line++;
            }
         }      
      }
      #endregion

      #region Private methods
      /// <summary>
      /// Handles the Loaded event of the UsrCycleTimeGraph control.
      /// </summary>
      /// <param name="sender">The source of the event.</param>
      /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
      private void UsrCycleTimeGraph_Loaded(object sender, RoutedEventArgs e)
      {
         this.InitializeGraph();
         this.SetSeries();
      }

      // Manual Drawing Lines

      /// <summary>
      /// Graph_s the before draw series.
      /// </summary>
      /// <param name="sender">The object sender.</param>
      /// <param name="g">The graphic where the event occurs.</param>
      private void Graph_BeforeDrawSeries(object sender, Steema.TeeChart.WPF.Drawing.Graphics3D g)
      {
         this.DrawLines();
      }

      /// <summary>
      /// Handles the GetAxisDrawLabel event of the Left control.
      /// </summary>
      /// <param name="sender">The source of the event.</param>
      /// <param name="e">The <see cref="Steema.TeeChart.WPF.GetAxisDrawLabelEventArgs"/> instance containing the event data.</param>
      private void Left_GetAxisDrawLabel(object sender, Steema.TeeChart.WPF.GetAxisDrawLabelEventArgs e)
      {
         Graph.Axes.Left.Labels.Items.Clear();
         e.Text = " ";
      }

      /// <summary>
      /// Graph_s the click series.
      /// </summary>
      /// <param name="sender">The sender.</param>
      /// <param name="s">The serie where the event occurs.</param>
      /// <param name="valueIndex">Index of the value.</param>
      /// <param name="e">The <see cref="System.Windows.Input.MouseEventArgs"/> instance containing the event data.</param>
      private void Graph_ClickSeries(object sender, Steema.TeeChart.WPF.Styles.Series s, int valueIndex, MouseEventArgs e)
      {
         ChartSeriesViewModel csvm = new ChartSeriesViewModel();

         csvm.Index = valueIndex;
         csvm.Serie = Graph.Series.IndexOf(s);

         this.ClickedSeriesCommand.Execute(csvm);
      }   
      #endregion      
   }
}