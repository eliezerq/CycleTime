using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tenaris.View.CycleTime.Aspose
{
    public class AsposeColumn
    {
        private int value;
        /// <value>
        /// Get or set the counter value
        /// </value> 
        public string Value
        {
            get
            {
                return this.getExcelColumnName(this.value);
            }

        }

        public int ValueInt
        {
            get
            {
                return this.value;
            }

            set
            {
                this.value = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public AsposeColumn()
        {
            this.value = 1;
        }
        /// <summary> 
        /// Constructor 
        /// </summary> 
        /// <param name="InitialValue">Initial counter value</param> 
        public AsposeColumn(int InitialValue)
        {
            this.value = InitialValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AsposeColumn"/> class.
        /// </summary>
        /// <param name="column">The column.</param>
        public AsposeColumn(AsposeColumn column)
        {
            this.value = column.ValueInt;
        }
        /// <summary> 
        /// Increment the counter by one. 
        /// </summary> 
        /// <param name="Counter">Counter to increment</param> 
        /// <returns>Incremented counter</returns> 
        public static AsposeColumn operator ++(AsposeColumn counter)
        {
            counter.ValueInt++;
            return counter;
        }
        /// <summary> 
        /// Decrement the counter by one. 
        /// </summary> 
        /// <param name="Counter">Counter to decrement</param> 
        /// <returns>Decremented counter</returns> 
        public static AsposeColumn operator --(AsposeColumn counter)
        {
            if (counter.ValueInt <= 1)
            {
                counter.ValueInt = 1;
            }
            else
            {
                counter.ValueInt--;
            }

            return counter;
        }

        public static AsposeColumn operator +(AsposeColumn counter, int add)
        {
            AsposeColumn x = new AsposeColumn();
            x.ValueInt = counter.ValueInt + add;

            return x;
        }

        public static AsposeColumn operator -(AsposeColumn counter, int sub)
        {
            AsposeColumn x = new AsposeColumn();
            x.ValueInt = counter.ValueInt - sub;

            if (x.ValueInt < 1)
            {
                x.ValueInt = 1;
            }

            return x;
        }

        /// <summary>
        /// Dets the name of the excel column.
        /// </summary>
        /// <param name="columnNumber">The column number.</param>
        /// <returns></returns>
        private string getExcelColumnName(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = String.Empty; int modulo; while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName; dividend = (int)((dividend - modulo) / 26);
            }
            return columnName;
        } 
    }
}