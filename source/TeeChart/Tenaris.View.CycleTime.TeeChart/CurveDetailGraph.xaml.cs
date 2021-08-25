// -----------------------------------------------------------------------
// <copyright file="CurveDetailGraph.xaml.cs" company="Tenaris Tamsa S.A.">
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
    using Tenaris.View.CycleTime.ViewModel;
    using Tenaris.View.CycleTime.ViewModel.Classes;

    /// <summary>
    /// Interaction logic for CurveDetailGraph.xaml
    /// </summary>
    public partial class CurveDetailGraph : UserControl
    {
        /// <summary>
        /// Dependency property for <see cref="Series"/> property 
        /// </summary>
        public static readonly DependencyProperty SeriesProperty =
           DependencyProperty.Register("Series", typeof(Distribution), typeof(CurveDetailGraph), new UIPropertyMetadata(SeriesChanged));

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="CurveDetailGraph"/> class.
        /// </summary>
        public CurveDetailGraph()
        {
            InitializeComponent();
            this.InitializeGraph();
        }
        #endregion

        #region Dependency Properties

        /// <summary>
        /// Gets or sets the series.
        /// </summary>
        /// <value>
        /// The series.
        /// </value>
        public Distribution Series
        {
            get
            {
                return (Distribution)GetValue(SeriesProperty);
            }

            set
            {
                SetValue(SeriesProperty, value);
            }
        }
        #endregion

        #region Methods
        #region Public
        /// <summary>
        /// Initializes the graph.
        /// </summary>
        public void InitializeGraph()
        {
            this.Graph.Aspect.View3D = false;
            this.Graph.Header.Visible = false;
            this.Graph.Legend.Visible = false;
            this.Graph.Axes.Left.Labels.Visible = false;
            this.Graph.Axes.Bottom.Labels.Angle = 90;

            //this.Graph.BeforeDrawSeries += new Steema.TeeChart.WPF.PaintChartEventHandler(this.DistributionGraph_BeforeDrawSeries);
            this.Graph.AfterDraw += new Steema.TeeChart.WPF.PaintChartEventHandler(this.Graph_AfterDraw);
        }

        /// <summary>
        /// Sets the series.
        /// </summary>
        public void SetSeries()
        {
            Steema.TeeChart.WPF.Styles.Bar lineser;
            lineser = new Steema.TeeChart.WPF.Styles.Bar(Graph.Chart);

            if (!(this.Series == null))
            {
                for (int i = 0; i < this.Series.NumOfBars; i++)
                {
                    lineser.Add(i + 1, this.Series.Bars[i].Frecuency, Color.FromRgb(255, 172, 87));
                    if (this.Series.InterruptionsIndex == i)
                    {
                        lineser.Add(i + 1, this.Series.Interruptions[i], Color.FromRgb(255, 0, 0));
                    }
                }

                Graph.Axes.Bottom.Labels.Items.Clear();
                for (int i = 0; i < this.Series.NumOfBars; i++)
                {
                    // Graph.Axes.Bottom.Labels.Items.Add(i + 0.5, " ");
                    Graph.Axes.Bottom.Labels.Items.Add(i + 0.5, this.Series.Bars[i].MinRangeTime);

                    // Graph.Axes.Bottom.Labels.Items.Add(i + 0.5, "Gerardo");
                }
            }

            Graph.Axes.Bottom.Title.Text = "Seconds";
            Graph.Axes.Left.Title.Text = "Pipes";

        }
        #endregion

        #region private
        /// <summary>
        /// Serieses the changed.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void SeriesChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            CurveDetailGraph curveDetailGraph = source as CurveDetailGraph;

            curveDetailGraph.Graph.Series.Clear();
            curveDetailGraph.SetSeries();
        }

        /// <summary>
        /// Distributions the graph_ before draw series.
        /// </summary>
        /// <param name="sender">The object sender.</param>
        /// <param name="g">The g is the Graphic3d teeChart variable.</param>

        
        private void DistributionGraph_BeforeDrawSeries(object sender, Steema.TeeChart.WPF.Drawing.Graphics3D g)
        {
            //for (int i = 2; i < 15; i++)
            //{
            //    // double yVal = Graph[0].YValues[i];   
            //    Point p0;
            //    Point p1;

            //    p0 = new Point(Graph.Axes.Bottom.CalcPosValue(2.9), Graph.Axes.Left.IStartPos);
            //    p1 = new Point(Graph.Axes.Bottom.CalcPosValue(2.9), Graph.Axes.Left.IEndPos);

            //    g.Pen.Color = Color.FromRgb(0, 51, 102);
            //    g.Pen.Style = DashStyles.Solid;
            //    g.Pen.Width = 5;
            //    g.Line(p0, p1);

            //    p0 = new Point(Graph.Axes.Bottom.CalcPosValue(3.1), Graph.Axes.Left.IStartPos);
            //    p1 = new Point(Graph.Axes.Bottom.CalcPosValue(3.1), Graph.Axes.Left.IEndPos);

            //    g.Pen.Color = Color.FromRgb(0, 153, 0);
            //    g.Pen.Style = DashStyles.Solid;
            //    g.Pen.Width = 5;
            //    g.Line(p0, p1);
            //}

        }
        #endregion
        #endregion

        #region Events
        /// <summary>
        /// Handles the Loaded event of the UsrCycleTimeGraph control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void UsrCycleTimeGraph_Loaded(object sender, RoutedEventArgs e)
        {
            this.InitializeGraph();
        }
        #endregion

        private void Graph_AfterDraw(object sender, Steema.TeeChart.WPF.Drawing.Graphics3D g)
        {
            Point p0;
            Point p1;

            // Draw Average
            double pFloat = this.Series.Average - 0.2;
            p0 = new Point(Graph.Axes.Bottom.CalcPosValue(pFloat), Graph.Axes.Left.IStartPos);
            p1 = new Point(Graph.Axes.Bottom.CalcPosValue(pFloat), Graph.Axes.Left.IEndPos);

            //g.Pen.Color = Color.FromRgb(0, 51, 102);
            g.Pen.Color = Color.FromRgb(0, 150, 50);
            g.Pen.Style = DashStyles.Solid;
            g.Pen.Width = 5;
            g.Line(p0, p1);

            // Draw Interruptions
            pFloat = this.Series.Standard + 0.2;
            p0 = new Point(Graph.Axes.Bottom.CalcPosValue(pFloat), Graph.Axes.Left.IStartPos);
            p1 = new Point(Graph.Axes.Bottom.CalcPosValue(pFloat), Graph.Axes.Left.IEndPos);

            //g.Pen.Color = Color.FromRgb(0, 51, 102);
            g.Pen.Color = Color.FromRgb(50, 50, 150);
            g.Pen.Style = DashStyles.Solid;
            g.Pen.Width = 5;
            g.Line(p0, p1);
        }
    }
}