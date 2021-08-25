//-----------------------------------------------------------------------
// <copyright file="ProductionDataSource.cs" company="Tenaris Tamsa S.A.">
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
   /// ProductionDataSource Class
   /// </summary>
   public class ProductionDataSource
   {
      /// <summary>
      /// Gets the details.
      /// </summary>
      /// <param name="idMachineComponent">The id machine component.</param>
      /// <param name="idHistorys">The id historys.</param>
      /// <returns>
      /// DataTable with the production details
      /// </returns>
      public DataTable GetDetails(int idMachineComponent, List<int> idHistorys)
      {
         DbClient dataBaseClient;
         DataTable dataTable;

         try
         {
            dataBaseClient = new DbClient("CycleTime");
            dataBaseClient.Activate();

            string store = ConfigurationManager.AppSettings["StoreProcedureGetProductionDetails"];

            var parameters = new List<DbParameter>();

            int i = 0;
            bool isThereIdHistory = false;
            string idHistoryParameterString = string.Empty;
            while (i < idHistorys.Count)
            {
               if (idHistorys[i] != 0)
               {
                  if (isThereIdHistory)
                  {
                     idHistoryParameterString = idHistoryParameterString + ", " + idHistorys[i].ToString();
                  }
                  else
                  {
                     isThereIdHistory = true;
                     idHistoryParameterString = idHistorys[i].ToString();
                  }
               }

               i++;
            }

            if (isThereIdHistory)
            {
               parameters.Add(new DbParameter("@IdHistory", idHistoryParameterString));
            }

            if (idMachineComponent != 0)
            {
               parameters.Add(new DbParameter("@IdMachineComponent", idMachineComponent));
            }

            dataBaseClient.Activate();
            dataBaseClient.AddCommand(store);

            dataTable = dataBaseClient.GetCommand(store).ExecuteTable(parameters);

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