//-----------------------------------------------------------------------
// <copyright file="ShiftDataSource.cs" company="Tenaris Tamsa S.A.">
//     Automation Unified System
//     Copyright© Tenaris S.A. 2011
// </copyright>
//-----------------------------------------------------------------------

namespace Tenaris.View.CycleTime.Data
{
   using System;
   using System.Collections.Generic;
   using System.Configuration;
   using System.Data;
   using System.Linq;
   using System.Text;
   using Tenaris.Library.DbClient;

   /// <summary>
   /// ShiftDataSource Class
   /// </summary>
   public class ShiftDataSource
   {
      /// <summary>
      /// Gets the shifts.
      /// </summary>
      /// <returns>DataTable with the shifts</returns>
      public DataTable GetShifts()
      {
         DbClient dataBaseClient;
         DataTable dataTable;

         try
         {
            dataBaseClient = new DbClient("CycleTime");
            dataBaseClient.Activate();

            string store = ConfigurationManager.AppSettings["StoreProcedureGetShifts"];

            dataBaseClient.Activate();
            dataBaseClient.AddCommand(store);

            dataTable = dataBaseClient.GetCommand(store).ExecuteTable();

            dataBaseClient.Deactivate();
         }
         catch (Exception e)
         {
            Console.WriteLine(e.ToString());
            dataTable = new DataTable();
         }

         return dataTable;
      }
   }
}
