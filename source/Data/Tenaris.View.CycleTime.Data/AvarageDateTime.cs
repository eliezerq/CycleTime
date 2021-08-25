//-----------------------------------------------------------------------
// <copyright file="AvarageDateTime.cs" company="Tenaris Tamsa S.A.">
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
    /// AvarageDateTime Class
    /// </summary>
    public class AvarageDateTime
    {
        /// <summary>
        /// Gets the cycle time elements.
        /// </summary>
        /// <param name="idMachineComponent">The id machine component.</param>
        /// <param name="idHistory">The id history.</param>
        /// <returns>
        /// DataTable with cycle time elements
        /// </returns>
        public DataTable GetCycleTimeElements(int idMachineComponent, int idHistory)
        {
            DbClient dataBaseClient;
            DataTable dataTable;

            try
            {
                dataBaseClient = new DbClient("CycleTime");
                dataBaseClient.Activate();

                string store = ConfigurationManager.AppSettings["StoreProcedureGetCycleTimeElements"];

                var parameters = new List<DbParameter>();
                if (idHistory != 0)
                {
                    parameters.Add(new DbParameter("@IdHistory", idHistory));
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

        /// <summary>
        /// Reads the elements by campaign.
        /// </summary>
        /// <param name="idBatchMachine">The id batch machine.</param>
        /// <param name="idElement">The id element.</param>
        /// <returns>DataTable with the elements by campaign</returns>
        public DataTable ReadElementsByCampaign(int idBatchMachine, int idElement)
        {
            DbClient dataBaseClient;
            DataTable dataTable;

            try
            {
                dataBaseClient = new DbClient("CycleTime");
                dataBaseClient.Activate();

                string store = ConfigurationManager.AppSettings["StoreProcedureGetElementsByCampaign"];

                var parameters = new List<DbParameter> 
            { 
               new DbParameter("@idBatchMachine", idBatchMachine), 
               new DbParameter("@IdElement", idElement) 
            };

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

        /// <summary>
        /// Reads the cycle times.
        /// </summary>
        /// <param name="numOfLastCycleTimes">The num of last cycle times.</param>
        /// <returns>DataTable with cycle times</returns>
        public DataTable ReadCycleTimes(int numOfLastCycleTimes)
        {
            DbClient dataBaseClient;
            DataTable dataTable;

            try
            {
                dataBaseClient = new DbClient("CycleTime");
                dataBaseClient.Activate();

                string store = ConfigurationManager.AppSettings["StoreProcedureGetCycleTimes"];

                var parameters = new List<DbParameter> 
            { 
               new DbParameter("@NumCycleTimes", numOfLastCycleTimes),             
            };

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

        /// <summary>
        /// Gets the trend general information.
        /// </summary>
        /// <param name="numOfLastCycleTimes">The num of last cycle times.</param>
        /// <param name="idMachineComponent">The id machine component.</param>
        /// <returns></returns>
        public DataTable GetTrendGeneralInformation(int numOfLastCycleTimes, int? idMachineComponent, string idCycletimes)
        {
            DbClient dataBaseClient;
            DataTable dataTable;

            try
            {
                dataBaseClient = new DbClient("CycleTime");
                dataBaseClient.Activate();

                string store = ConfigurationManager.AppSettings["StoreProcedureGetTrendGeneralInformation"];

                var parameters = new List<DbParameter>()
                { 
                    new DbParameter("@NumCycleTimes", numOfLastCycleTimes)
                };
                if (idMachineComponent != null)
                {
                    parameters.Add(new DbParameter("@idMachineComponent", idMachineComponent));
                }
                if (idCycletimes != null)
                {
                    parameters.Add(new DbParameter("@idHistories", idCycletimes));
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

        /// <summary>
        /// Reads the elements catalog.
        /// </summary>
        /// <param name="machineComponent">The machine component.</param>
        /// <returns>
        /// DataTable with the elements catalog
        /// </returns>
        public DataTable ReadElementsCatalog(int machineComponent)
        {
            DbClient dataBaseClient;
            DataTable dataTable;

            try
            {
                dataBaseClient = new DbClient("CycleTime");
                dataBaseClient.Activate();

                string store = ConfigurationManager.AppSettings["StoreProcedureGetElementsCatalog"];

                var parameters = new List<DbParameter> 
            { 
               new DbParameter("@IdMachineComponent", machineComponent),             
            };

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
