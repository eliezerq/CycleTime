//-----------------------------------------------------------------------
// <copyright file="TimeModel.cs" company="Tenaris Tamsa S.A.">
//     Automation Unified System
//     Copyright© Tenaris S.A. 2011
// </copyright>
//-----------------------------------------------------------------------

namespace Tenaris.View.CycleTime.Model
{
   using System;
   using System.Collections.Generic;
   using System.Linq;
   using System.Text;

   /// <summary>
   /// TimeModel Class
   /// </summary>
   public static class TimeModel
   {
      #region Properties

      /// <summary>
      /// Gets the unit.
      /// </summary>
      public static EguModel Unit
      {
         get
         {
            return new EguModel(1, 0, "Seconds");
         }
      }

      /// <summary>
      /// Gets the seconds.
      /// </summary>
      public static EguModel Seconds
      {
         get
         {
            return new EguModel(1, 0, "Seconds");
         }
      }

      /// <summary>
      /// Gets the tenths to.
      /// </summary>
      public static EguModel TenthsTo
      {
         get
         {
            return new EguModel(.1, 0, "Tenths");
         }
      }

      /// <summary>
      /// Gets the hundredths to.
      /// </summary>
      public static EguModel HundredthsTo
      {
         get
         {
            return new EguModel(.01, 0, "Hundredths");
         }
      }

      /// <summary>
      /// Gets the thousandths to.
      /// </summary>
      public static EguModel ThousandthsTo
      {
         get
         {
            return new EguModel(.001, 0, "Thousandths");
         }
      }

      /// <summary>
      /// Gets to tenths.
      /// </summary>
      public static EguModel ToTenths
      {
         get
         {
            return new EguModel(10, 0, "Tenths");
         }
      }

      /// <summary>
      /// Gets to hundredths.
      /// </summary>
      public static EguModel ToHundredths
      {
         get
         {
            return new EguModel(100, 0, "Hundredths");
         }
      }

      /// <summary>
      /// Gets to thousandths.
      /// </summary>
      public static EguModel ToThousandths
      {
         get
         {
            return new EguModel(1000, 0, "Thousandths");
         }
      }
      #endregion    

      #region Public Methods

      /// <summary>
      /// Times the specified number.
      /// </summary>
      /// <param name="number">The number.</param>
      /// <param name="egu">The egu unit.</param>
      /// <param name="format">The format print.</param>
      /// <returns>The time obteined</returns>
      public static string Time(float number, EguModel egu, string format)
      {
         return String.Format("{0:0.0}", (number * egu.Scale) + egu.Bias);
      }

      /// <summary>
      /// Times the specified number.
      /// </summary>
      /// <param name="number">The number.</param>
      /// <param name="egu">The egu unit.</param>
      /// <returns>The time obteined</returns>
      public static string Time(string number, EguModel egu)
      {
         float tempParse;
         float.TryParse(number, out tempParse);
         return Time(tempParse, egu, string.Empty);
      }

      /// <summary>
      /// Return the amount of seconds
      /// </summary>
      /// <param name="number">The float number to convert</param>
      /// <param name="egu">The unit of number</param>
      /// <returns>A float number that represents the amount of seconds</returns>
      public static float ToSeconds(double number, EguModel egu)
      {
         return (float)((number * egu.Scale) + egu.Bias);
      }

      /// <summary>
      /// Return the amount of seconds
      /// </summary>
      /// <param name="number">The string number to convert</param>
      /// <param name="egu">The unit of number</param>
      /// <returns>A float number that represents the amount of seconds</returns>
      public static float ToSeconds(string number, EguModel egu)
      {
         float tempParse;
         float.TryParse(number, out tempParse);
         return ToSeconds(tempParse, egu);
      }

      /// <summary>
      /// Returns the time.
      /// </summary>
      /// <param name="number">The number.</param>
      /// <returns>Returns the time in string.</returns>
      public static string SecondsToTime(float number)
      {
         return String.Format("{0:0.0}", number);
      }

      /// <summary>
      /// Returns the time.
      /// </summary>
      /// <param name="number">The number.</param>
      /// <param name="egu">The egu unit.</param>
      /// <returns>Returns the time in string.</returns>
      public static string SecondsToTime(float number, EguModel egu)
      {
         return String.Format("{0:0.0}", (number * egu.Scale) + egu.Bias);
      }

      /// <summary>
      /// Return the time in TeeChart format
      /// </summary>
      /// <param name="number">Time to convert</param>
      /// <param name="egu">The unit of time</param>
      /// <returns>Time in TeeChart format</returns>
      public static string TeeChartTime(float number, EguModel egu)
      {
         float totalSec = (float)((number * egu.Scale) + egu.Bias);
         int sec = (int)totalSec;
         int dec = (int)(totalSec % 10);
         int min = sec / 60;

         sec = sec % 60;

         return "00:" + String.Format("{0:00}", min) + ":" + String.Format("{0:00}", sec) + "." + String.Format("{0:00}", dec);
      }

      /// <summary>
      /// Return the time in TeeChart format
      /// </summary>
      /// <param name="number">Time in string format to convert</param>
      /// <param name="egu">The unit of time</param>
      /// <returns>Time in TeeChart format</returns>
      public static string TeeChartTime(string number, EguModel egu)
      {
         float tempParse;
         float.TryParse(number, out tempParse);

         return TeeChartTime(tempParse, egu);
      }

      /// <summary>
      /// Return the time in TeeChart format.
      /// </summary>
      /// <param name="start">The start.</param>
      /// <param name="duration">The duration.</param>
      /// <param name="egu">The egu unit.</param>
      /// <returns>Time in TeeChart format</returns>
      public static string TeeChartTime(string start, string duration, EguModel egu)
      {
         float tempParse;
         float total;

         float.TryParse(start, out total);
         float.TryParse(duration, out tempParse);
         total += tempParse;

         return TeeChartTime(total, egu);
      }

      /// <summary>
      /// Return the time in TeeChart format.
      /// </summary>
      /// <param name="start">The start.</param>
      /// <param name="duration">The duration.</param>
      /// <param name="egu">The egu unit.</param>
      /// <returns>Time in TeeChart format.</returns>
      public static string TeeChartTime(float start, float duration, EguModel egu)
      {
         return TeeChartTime(start + duration, egu);
      }

      /// <summary>
      /// Generate the offset in seconds between two times
      /// </summary>
      /// <param name="dateStringStart">The date string start.</param>
      /// <param name="dateStringEnd">The date string end.</param>
      /// <returns>Return the offset in seconds between two times in string</returns>
      public static string GenerateOffset(string dateStringStart, string dateStringEnd)
      {
         DateTime dateStart, dateEnd;
         DateTime.TryParse(dateStringStart, out dateStart);
         DateTime.TryParse(dateStringEnd, out dateEnd);
         TimeSpan offset;
         offset = dateEnd - dateStart;
         int seconds = offset.Seconds * 10;
         return seconds.ToString();
      }
      #endregion

      #region Private Methods
      /// <summary>
      /// Toes the unit.
      /// </summary>
      /// <param name="unit">The unit egu.</param>
      /// <returns>The egu unit.</returns>
      private static EguModel ToUnit(string unit)
      {
         unit = unit.ToLower();
         switch (unit)
         {
            case "second":
               return TimeModel.Seconds;
            case "Tenths":
               return TimeModel.TenthsTo;
            case "Hundredths":
               return TimeModel.HundredthsTo;
            case "Thousandths":
               return TimeModel.ThousandthsTo;
            default:
               return TimeModel.Unit;
         }
      }

      /// <summary>
      /// Gets the unit egu.
      /// </summary>
      /// <param name="unit">The unit in string.</param>
      /// <returns>The egu unit</returns>
      private static EguModel UnitTo(string unit)
      {
         unit = unit.ToLower();
         switch (unit)
         {
            case "second":
               return new EguModel(1, 0, "Seconds");
            case "Tenths":
               return TimeModel.ToTenths;
            case "Hundredths":
               return TimeModel.ToHundredths;
            case "Thousandths":
               return TimeModel.ToThousandths;
            default:
               return TimeModel.Unit;
         }
      }

      /// <summary>
      /// Convert the time to string.
      /// </summary>
      /// <param name="time">The time to convert.</param>
      /// <param name="posicions">The posicions.</param>
      /// <returns>The time in string.</returns>
      private static string ToTimeString(float time, int posicions)
      {
         string temp;

         float totalSec = time;
         int sec = (int)totalSec;
         int dec = (int)(totalSec % 10);
         int min = sec / 60;
         sec = sec % 60;
         switch (posicions)
         {
            case 3:
               temp = "00:" + String.Format("{0:00}", min) + ":" + String.Format("{0:00}", sec) + "." + String.Format("{0:00}", dec);
               break;
            case 2:
               temp = String.Format("{0:00}", min) + ":" + String.Format("{0:00}", sec) + "." + String.Format("{0:00}", dec);
               break;
            case 1:
               temp = String.Format("{0:00}", sec) + "." + String.Format("{0:00}", dec);
               break;
            case 0:
               temp = String.Format("{0:00}", dec);
               break;
            default:
               temp = "00:" + String.Format("{0:00}", min) + ":" + String.Format("{0:00}", sec) + "." + String.Format("{0:00}", dec);
               break;
         }

         return temp;
      }

      /// <summary>
      /// The time string.
      /// </summary>
      /// <param name="time">The time to convert.</param>
      /// <param name="posicions">The posicions.</param>
      /// <param name="egu">The egu unit.</param>
      /// <returns>Return the time in string.</returns>
      private static string ToTimeString(float time, int posicions, EguModel egu)
      {
         string temp;

         float totalSec = (float)((time * egu.Scale) + egu.Bias);
         int sec = (int)totalSec;
         int dec = (int)(totalSec % 10);
         int min = sec / 60;
         sec = sec % 60;
         switch (posicions)
         {
            case 3:
               temp = "00:" + String.Format("{0:00}", min) + ":" + String.Format("{0:00}", sec) + "." + String.Format("{0:00}", dec);
               break;
            case 2:
               temp = String.Format("{0:00}", min) + ":" + String.Format("{0:00}", sec) + "." + String.Format("{0:00}", dec);
               break;
            case 1:
               temp = String.Format("{0:00}", sec) + "." + String.Format("{0:00}", dec);
               break;
            case 0:
               temp = String.Format("{0:00}", dec);
               break;
            default:
               temp = "00:" + String.Format("{0:00}", min) + ":" + String.Format("{0:00}", sec) + "." + String.Format("{0:00}", dec);
               break;
         }

         return temp;
      }
      #endregion
   }
}
