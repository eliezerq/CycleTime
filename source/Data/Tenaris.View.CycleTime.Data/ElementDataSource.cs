//-----------------------------------------------------------------------
// <copyright file="ElementDataSource.cs" company="Tenaris Tamsa S.A.">
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
    /// ElementDataSource Class
    /// </summary>
    public class ElementDataSource
    {
        /// <summary>
        /// Gets the cycle time elements.
        /// </summary>
        /// <param name="idMachineComponent">The id machine component.</param>
        /// <param name="idHistorys">The id historys.</param>
        /// <returns>
        /// DataTable with cycle time elements
        /// </returns>
        public DataTable GetCycleTimeElements(int idMachineComponent, List<int> idHistorys)
        {
            DbClient dataBaseClient;
            DataTable dataTable;

            try
            {
                dataBaseClient = new DbClient("CycleTime");
                dataBaseClient.Activate();

                string store = ConfigurationManager.AppSettings["StoreProcedureGetCycleTimeElements"];

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

        /// <summary>
        /// Gets the average cycle time elements.
        /// </summary>
        /// <param name="idBatcMachine">The id batc machine.</param>
        /// <returns></returns>
        public DataTable GetAverageCycleTimeElements(int? idBatcMachine, int? numOfLastCycleTimes, int? idMachineComponent, string idCycletimes)
        {
            DbClient dataBaseClient;
            DataTable dataTable;

            try
            {
                dataBaseClient = new DbClient("CycleTime");
                dataBaseClient.Activate();

                string store = ConfigurationManager.AppSettings["StoreProcedureGetAverageCycleTimeElements"];

                var parameters = new List<DbParameter>();
                if (idBatcMachine != null)
                {
                    parameters.Add(new DbParameter("@idBatchMachine", idBatcMachine));
                }
                if (numOfLastCycleTimes != null)
                {
                    parameters.Add(new DbParameter("@NumCycleTimes", numOfLastCycleTimes));
                }
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
        /// Gets the elements by campaign.
        /// </summary>
        /// <param name="idBatchMachine">The id batch machine.</param>
        /// <param name="idElement">The id element.</param>
        /// <returns>DataTable with elements by campaign</returns>
        public DataTable GetElementsByCampaign(int idBatchMachine, int idElement)
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
        /// <returns>DataTable with the cycle times</returns>
        public DataTable ReadCycleTimes(int numOfLastCycleTimes, int idMachineComponent)
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
               new DbParameter("@idMachineComponent", idMachineComponent),
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
        /// Gets the elements catalog.
        /// </summary>
        /// <param name="machineComponent">The machine component.</param>
        /// <returns>
        /// DataTable with the elements catalog
        /// </returns>
        public DataTable GetElementsCatalog(int machineComponent)
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
