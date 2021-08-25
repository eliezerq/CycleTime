// -----------------------------------------------------------------------
// <copyright file="MachineComponentDataSource.cs" company="Tenaris Tamsa S.A.">
//     Automation Unified System
//     Copyright© Tenaris S.A. 2011
// </copyright>
// -----------------------------------------------------------------------

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
   /// MachineDataSource Class
   /// </summary>
   public class MachineComponentDataSource
   {
      /// <summary>
      /// Gets the machines catalog.
      /// </summary>
      /// <param name="idArea">The id area.</param>
      /// <returns>
      /// DataTable with the machines catalog
      /// </returns>
      public DataTable GetMachinesCatalog(string idArea)
      {
         DbClient dataBaseClient;
         DataTable dataTable;

         try
         {
            dataBaseClient = new DbClient("CycleTime");
            dataBaseClient.Activate();

            string store = ConfigurationManager.AppSettings["StoreProcedureGetMachineComponentsCatalog"];

            var parameters = new List<DbParameter>();
            dataBaseClient.Activate();
            dataBaseClient.AddCommand(store);

            if (idArea != string.Empty)
            {
               parameters.Add(new DbParameter("@idArea", idArea)); 
               dataTable = dataBaseClient.GetCommand(store).ExecuteTable(parameters);
            }
            else
            {
               dataTable = dataBaseClient.GetCommand(store).ExecuteTable();
            }

            dataBaseClient.Deactivate();
         }
         catch (Exception e)
         {
            Console.WriteLine(e.ToString());
            dataTable = new DataTable();
         }

         return dataTable;
      }

      /// <summary>
      /// Gets the machines catalog.
      /// </summary>
      /// <param name="parameters">The parameters.</param>
      /// <returns>DataTable with the machines catalog</returns>
      public DataTable GetMachinesCatalog(List<DbParameter> parameters)
      {
         DbClient dataBaseClient;
         DataTable dataTable;

         try
         {
            dataBaseClient = new DbClient("CycleTime");
            dataBaseClient.Activate();

            string store = ConfigurationManager.AppSettings["StoreProcedureGetMachineComponentsCatalog"];

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
