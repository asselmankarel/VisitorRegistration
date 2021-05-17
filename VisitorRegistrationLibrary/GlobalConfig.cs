using System;
using System.Collections.Generic;
using VisitorRegistrationLibrary.DataAccess;

namespace VisitorRegistrationLibrary
{
    public static class GlobalConfig
    {

        private enum DataConnections
        {
            MySql,
            Csv
        }

        private const DataConnections  DataConnection = DataConnections.MySql;

        public static IDataConnector Connection()
        {
            IDataConnector connection;

            switch (DataConnection)
            {
                case DataConnections.Csv: connection =  new CsvConnector(); break;
                default: connection = new MySqlConnector(); break;
            }

            return connection;
        }

    }
}
