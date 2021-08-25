//-----------------------------------------------------------------------
// <copyright file="AsposeRow.cs" company="Tenaris Tamsa S.A.">
//     Automation Unified System
//     Copyright© Tenaris S.A. 2011
// </copyright>
//-----------------------------------------------------------------------

namespace Tenaris.View.CycleTime.Aspose
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// AsposeRow cell
    /// </summary>
    public class AsposeRow
    {
        /// <summary>
        /// Field value use for relative position
        /// </summary>
        private int value;

        /// <summary>
        /// Initializes a new instance of the <see cref="AsposeRow"/> class.
        /// </summary>
        public AsposeRow()
        {
            this.Value = 1;
        }

        public AsposeRow(AsposeRow row)
        {
            this.value = row.Value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AsposeRow"/> class.
        /// </summary>
        /// <param name="initialValue">The initial value.</param>
        public AsposeRow(int initialValue)
        {
            this.Value = initialValue;
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// Get or set the counter value
        /// </value>
        public int Value
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
        /// Increment the counter by one. 
        /// </summary> 
        /// <param name="counter">Counter to increment</param> 
        /// <returns>Incremented counter</returns> 
        public static AsposeRow operator ++(AsposeRow counter)
        {
            counter.Value++;
            return counter;
        }

        /// <summary> 
        /// Decrement the counter by one. 
        /// </summary> 
        /// <param name="counter">Counter to decrement</param> 
        /// <returns>Decremented counter</returns> 
        public static AsposeRow operator --(AsposeRow counter)
        {
            if (counter.Value <= 1)
            {
                counter.Value = 1;
            }
            else
            {
                counter.Value--;
            }

            return counter;
        }

        public static AsposeRow operator +(AsposeRow counter, int add)
        {            
            AsposeRow x = new AsposeRow();
            x.Value = counter.Value + add;

            return x;
        }

        public static AsposeRow operator -(AsposeRow counter, int sub)
        {
            AsposeRow x = new AsposeRow();
            x.Value = counter.Value - sub;

            if (x.Value < 1)
            {
                x.Value = 1;
            }

            return x;
        }
    }
}
