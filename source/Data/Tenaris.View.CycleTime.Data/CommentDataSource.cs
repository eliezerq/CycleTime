//-----------------------------------------------------------------------
// <copyright file="CommentDataSource.cs" company="Tenaris Tamsa S.A.">
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
   /// CommentDataSource Class
   /// </summary>
   public class CommentDataSource
   {
      /// <summary>
      /// Gets the comments catalog.
      /// </summary>
      /// <returns>DataTable with comments catalog</returns>
      public DataTable GetCommentCatalog()
      {
         DbClient dataBaseClient;
         DataTable dataTable;

         try
         {
            dataBaseClient = new DbClient("CycleTime");
            dataBaseClient.Activate();

            string store = ConfigurationManager.AppSettings["StoreProcedureGetCatalogComments"];

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

      /// <summary>
      /// Saves the comment.
      /// </summary>
      /// <param name="parameters">The parameters.</param>
      public void SaveComment(List<DbParameter> parameters)
      {
         DbClient dataBaseClient;

         try
         {
            dataBaseClient = new DbClient("CycleTime");
            dataBaseClient.Activate();

            string store = ConfigurationManager.AppSettings["StoreProcedureSaveComment"];
            dataBaseClient.Activate();
            dataBaseClient.AddCommand(store);

            dataBaseClient.GetCommand(store).ExecuteNonQuery(parameters);

            dataBaseClient.Deactivate();
         }
         catch (Exception e)
         {
            Console.WriteLine(e.ToString());
         }
      }
   }
}
