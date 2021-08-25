//-----------------------------------------------------------------------
// <copyright file="CycleTimeDataSource.cs" company="Tenaris Tamsa S.A.">
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
    using Tenaris.Library.Log;

    /// <summary>
    /// CycleTimeDataSource Class
    /// </summary>
    public class CycleTimeDataSource
    {
        /// <summary>
        /// Searches the specified parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="storedProcedure">The stored procedure.</param>
        /// <returns></returns>
        public DataTable Search(List<DbParameter> parameters)
        {
            DbClient dataBaseClient;
            DataTable dataTable;

            try
            {
                dataBaseClient = new DbClient("CycleTime");
                dataBaseClient.Activate();

                string store = ConfigurationManager.AppSettings["StoreProcedureSearchCycleTimes"];

                dataBaseClient.Activate();
                dataBaseClient.AddCommand(store);

                dataTable = dataBaseClient.GetCommand(store).ExecuteTable(parameters);

                dataBaseClient.Deactivate();
            }
            catch (Exception e)
            {
                dataTable = new DataTable();
                Trace.Exception(e);
            }
            
            return dataTable;
        }
        
        /// <summary>
        /// Searches the specified parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>DataTable with the specified parameters</returns>
        public DataTable Search(List<DbParameter> parameters, string storedProcedure)
        {
            DbClient dataBaseClient;
            DataTable dataTable;

            try
            {
                dataBaseClient = new DbClient("CycleTime");
                dataBaseClient.Activate();

                string store = ConfigurationManager.AppSettings[storedProcedure];

                dataBaseClient.Activate();
                dataBaseClient.AddCommand(store);

                dataTable = dataBaseClient.GetCommand(store).ExecuteTable(parameters);

                dataBaseClient.Deactivate();
            }
            catch (Exception e)
            {
                dataTable = new DataTable();
                Trace.Exception(e);                
            }

            Trace.Message("Search Executed with parameters");
            return dataTable;
        }
        
        /// <summary>
        /// Searches the elements for ids history.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public DataTable SearchElementsForIdsHistory(List<DbParameter> parameters)
        {
            DbClient dataBaseClient;
            DataTable dataTable;

            try
            {
                dataBaseClient = new DbClient("CycleTime");
                dataBaseClient.Activate();

                string store = ConfigurationManager.AppSettings["StoreProcedureSearchElementsForIdsHistory"];

                dataBaseClient.Activate();
                dataBaseClient.AddCommand(store);

                //List<DbParameter> parameters = new List<DbParameter>();
                //if (listOfIdsHistorys.Count > 0)
                //{
                //    string ids = listOfIdsHistorys[0].ToString();
                //    for (int i = 1; i < listOfIdsHistorys.Count; i++)
                //    {
                //        ids += ", " + listOfIdsHistorys[i].ToString();
                //    }
                //    parameters.Add(new DbParameter("@IdHistorys", ids));
                //}                

                dataTable = dataBaseClient.GetCommand(store).ExecuteTable(parameters);

                dataBaseClient.Deactivate();
            }
            catch (Exception e)
            {
                dataTable = new DataTable();
                Trace.Exception(e);
            }
            
            return dataTable;
        }

        /// <summary>
        /// Gets the cycle times for calculate average.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public DataTable GetCycleTimesForCalculateAverage(List<DbParameter> parameters)
        {
            DbClient dataBaseClient;
            DataTable dataTable;

            try
            {
                dataBaseClient = new DbClient("CycleTime");
                dataBaseClient.Activate();

                string store = ConfigurationManager.AppSettings["StoreProcedureGetCycleTimesForCalculateAverage"];

                dataBaseClient.Activate();
                dataBaseClient.AddCommand(store);

                dataTable = dataBaseClient.GetCommand(store).ExecuteTable(parameters);

                dataBaseClient.Deactivate();
            }
            catch (Exception e)
            {
                dataTable = new DataTable();
                Trace.Exception(e);
            }

            Trace.Message("GetCycleTimesForCalculateAverage Executed");
            return dataTable;
        }
    }
}