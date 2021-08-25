// -----------------------------------------------------------------------
// <copyright file="AsposeWrite.cs" company="Tenaris Tamsa S.A.">
//     Automation Unified System
//     Copyright© Tenaris S.A. 2011
// </copyright>
// -----------------------------------------------------------------------

using Aspose.Cells;

namespace Tenaris.View.CycleTime.Aspose
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Tenaris.View.CycleTime.Model;

    /// <summary>
    /// AsposeWrite class
    /// </summary>
    public class AsposeWrite
    {
        /// <summary>
        /// Field license.
        /// </summary>
        private License license;

        /// <summary>
        /// Initializes a new instance of the <see cref="AsposeWrite"/> class.
        /// </summary>
        public AsposeWrite()
        {
            this.InitializeLicense();
            this.Book = new Workbook();
            this.Style = new AsposeStyle();
            this.Position = new AsposePosition();
            this.Fields = new List<AsposeFieldNames>();
            this.Sheet = this.Book.Worksheets[0];
            this.SetNumSheet = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AsposeWrite"/> class.
        /// </summary>
        /// <param name="numWorkSheet">The num work sheet.</param>
        public AsposeWrite(int numWorkSheet)
        {
            this.InitializeLicense();
            this.Book = new Workbook();
            this.Style = new AsposeStyle();
            this.Position = new AsposePosition();
            this.Fields = new List<AsposeFieldNames>();
            this.SetNumSheet = numWorkSheet;
            this.Sheet = this.Book.Worksheets[this.SetNumSheet];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AsposeWrite"/> class.
        /// </summary>
        /// <param name="numWorkSheet">The num work sheet.</param>
        /// <param name="position">The position.</param>
        public AsposeWrite(int numWorkSheet, AsposePosition position)
        {
            this.InitializeLicense();
            this.Book = new Workbook();
            this.Style = new AsposeStyle();
            this.Position = position;
            this.Fields = new List<AsposeFieldNames>();
            this.SetNumSheet = numWorkSheet;
            this.Sheet = this.Book.Worksheets[this.SetNumSheet];
        }

        /// <summary>
        /// Gets or sets the book.
        /// </summary>
        /// <value>
        /// The work book.
        /// </value>
        public Workbook Book { get; set; }

        /// <summary>
        /// Gets or sets the style.
        /// </summary>
        /// <value>
        /// The style.
        /// </value>
        public AsposeStyle Style { get; set; }

        /// <summary>
        /// Gets or sets the fields.
        /// </summary>
        /// <value>
        /// The fields.
        /// </value>
        public List<AsposeFieldNames> Fields { get; set; }

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        public AsposePosition Position { get; set; }

        /// <summary>
        /// Gets or sets the sheet.
        /// </summary>
        /// <value>
        /// The sheet.
        /// </value>          
        public Worksheet Sheet { get; set; }

        /// <summary>
        /// Gets or sets the set num sheet.
        /// </summary>
        /// <value>
        /// The set num sheet.
        /// </value>
        public int SetNumSheet { get; set; }

        /// <summary>
        /// Writes the titles.
        /// </summary>
        public void WriteTitles()
        {
            this.Sheet = this.Book.Worksheets[this.SetNumSheet];
            this.Style.DefineTitleStyle(this.Sheet.Cells["A1"]);
            foreach (AsposeFieldNames field in this.Fields)
            {
                string textCell = field.Title;
                this.Sheet.Cells[this.Position.Value].Style = this.Style.TitleStyle;
                this.Sheet.Cells[this.Position.Value].PutValue(textCell);
                this.Position.Column++;
            }

            this.Position.Row++;
            this.Position.Column.ValueInt = this.Position.FixColumn;
        }
               
        public void WriteTitles(List<AsposeFieldNames> fns)
        {
            this.Sheet = this.Book.Worksheets[this.SetNumSheet];
            this.Style.DefineTitleStyle(this.Sheet.Cells["A1"]);
            foreach (AsposeFieldNames field in fns)
            {
                string textCell = field.Title;
                this.Sheet.Cells[this.Position.Value].Style = this.Style.TitleStyle;
                this.Sheet.Cells[this.Position.Value].PutValue(textCell);
                this.Position.Column++;
            }

            this.Position.Row++;
            this.Position.Column.ValueInt = this.Position.FixColumn;
        }

        public void WriteCycleTime(CycleTimeModel cycleTime, List<ElementModel> elementCatalog)
        {
            this.Sheet = this.Book.Worksheets[this.SetNumSheet];
            this.Style.DefineRowStyle(this.Sheet.Cells["A1"]);

            AsposePosition position = new AsposePosition(this.Position);

            this.WriteCycleTimeGeneral(cycleTime);
            this.WriteElements(cycleTime.Elements, elementCatalog);

            int rows = this.Position.Row.Value - position.Row.Value;
            if (rows > 0)
            {
                this.Position.Row.Value = position.Row.Value;
                this.Position.Column.ValueInt = this.Position.FixColumn;
                while (rows > 0)
                {
                    this.Position.Row++;
                    this.Position.Column.ValueInt = this.Position.FixColumn;
                    this.WriteCycleTimeGeneral(cycleTime);
                    rows--;
                }
            }

            this.Position.Row++;
            this.Position.Column.ValueInt = this.Position.FixColumn;
        }

        public void WriteCycleTimeGeneral(CycleTimeModel cycleTime)
        {
            //this.Sheet.Cells[this.Position.Value].Style = this.Style.RowStyle;
            //this.Sheet.Cells[this.Position.Value].PutValue(cycleTime.idHistory);
            //this.Position.Column++;
            this.Sheet.Cells[this.Position.Value].Style = this.Style.RowStyle;
            this.Sheet.Cells[this.Position.Value].PutValue(cycleTime.Order);
            this.Position.Column++;
            this.Sheet.Cells[this.Position.Value].Style = this.Style.RowStyle;
            this.Sheet.Cells[this.Position.Value].PutValue(cycleTime.Heat);
            this.Position.Column++;
            this.Sheet.Cells[this.Position.Value].Style = this.Style.RowStyle;
            this.Sheet.Cells[this.Position.Value].PutValue(cycleTime.Product);
            this.Position.Column++;
            this.Sheet.Cells[this.Position.Value].Style = this.Style.RowStyle;
            this.Sheet.Cells[this.Position.Value].PutValue(cycleTime.PipeNumber);
            this.Position.Column++;
            this.Sheet.Cells[this.Position.Value].Style = this.Style.RowStyle;
            this.Sheet.Cells[this.Position.Value].PutValue(cycleTime.StartTime.ToString());
            this.Position.Column++;
            this.Sheet.Cells[this.Position.Value].Style = this.Style.RowStyle;
            this.Sheet.Cells[this.Position.Value].PutValue(cycleTime.EndTime.ToString());
            this.Position.Column++;
            this.Sheet.Cells[this.Position.Value].Style = this.Style.RowStyle;
            this.Sheet.Cells[this.Position.Value].PutValue(cycleTime.StandarCycleTime);

            this.Position.Column++;
            this.Sheet.Cells[this.Position.Value].Style = this.Style.RowStyle;
            this.Sheet.Cells[this.Position.Value].PutValue(cycleTime.RealCycleTime);

            this.Position.Column++;
            this.Sheet.Cells[this.Position.Value].Style = this.Style.RowStyle;
            this.Sheet.Cells[this.Position.Value].PutValue(cycleTime.PipeType);
            this.Position.Column++;
            this.Sheet.Cells[this.Position.Value].Style = this.Style.RowStyle;
            this.Sheet.Cells[this.Position.Value].PutValue(cycleTime.WorkMode);
            this.Position.Column++;
            this.Sheet.Cells[this.Position.Value].Style = this.Style.RowStyle;
            this.Sheet.Cells[this.Position.Value].PutValue(cycleTime.Comments);
            this.Position.Column++;

            foreach (ColumnCustomExportModel columnCustomn in cycleTime.ColumnsCustom)
            {
                this.Sheet.Cells[this.Position.Value].Style = this.Style.RowStyle;
                this.Sheet.Cells[this.Position.Value].PutValue(columnCustomn.Value);
                this.Position.Column++;
            }
        }

        public AsposeRow WriteElements(List<ElementModel> elements, List<ElementModel> elementCatalog)
        {
            this.Sheet = this.Book.Worksheets[this.SetNumSheet];
            this.Style.DefineRowStyle(this.Sheet.Cells["A1"]);

            AsposePosition position = new AsposePosition(this.Position);
            AsposeRow rowMax = new AsposeRow(this.Position.Row + 1);

            bool isAddedRows = false;
            int idElement = -1;
            foreach (ElementModel e in elements)
            {
                int idElementNew = e.Id;
                if (idElement == idElementNew)
                {
                    this.Position.Row++;
                    this.WriteElement(e);
                    if (rowMax.Value < this.Position.Row.Value)
                    {
                        rowMax.Value = this.Position.Row.Value;
                    }
                    isAddedRows = true;
                }
                else
                {
                    idElement = idElementNew;
                    this.Position.Row = new AsposeRow(position.Row);
                    int index = elementCatalog.FindIndex(item => item.Id == e.Id);
                    index = index * 2;
                    this.Position.Column = position.Column + index;
                    this.WriteElement(e);
                }
            }

            if (isAddedRows)
            {
                this.Position.Row.Value = rowMax.Value;
            }
            this.Position.Column.ValueInt = this.Position.FixColumn;

            return rowMax;
        }

        public void WriteElement(ElementModel e)
        {
            this.Sheet.Cells[this.Position.Value].Style = this.Style.RowStyle;
            this.Sheet.Cells[this.Position.Value].PutValue(e.StandardTimeInSeconds.ToString());
            this.Position.Column++;

            this.Sheet.Cells[this.Position.Value].Style = this.Style.RowStyle;
            this.Sheet.Cells[this.Position.Value].PutValue(e.RealTimeInSeconds.ToString());
            this.Position.Column--;
        }

        public void WriteCycleTimes(List<CycleTimeModel> cycleTimes, List<ElementModel> elementCatalog)
        {
            this.Position.FixColumn = this.Position.Column.ValueInt;
            this.Position.FixRow = this.Position.Row.Value;
            this.WriteTitles();
            foreach (CycleTimeModel cycleTime in cycleTimes)
            {
                this.WriteCycleTime(cycleTime, elementCatalog);
            }
        }

        /// <summary>
        /// Saves the specified path.
        /// </summary>
        /// <param name="path">The path to write field.</param>
        public void Save(string path)
        {
            try
            {
                this.Book.Save(path, FileFormatType.Excel2003);
            }
            catch (Exception e) {
                Tenaris.Library.Log.Trace.Exception(e);
            }
        }

        /// <summary>
        /// Initializes the license.
        /// </summary>
        private void InitializeLicense()
        {
            this.license = new License();
            Stream s = new MemoryStream(Tenaris.View.CycleTime.Aspose.Properties.Resources.Aspose_Total);
            this.license.SetLicense(s);
        }
    }
}