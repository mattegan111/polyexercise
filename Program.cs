using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

namespace Empty_3
{
    public abstract class DbConnection
    {
        public string ConnectionString { get; set; }
        public TimeSpan Timeout { get; set; }

        public abstract void OpenConnection();
        public abstract void CloseConnection();
    }

    class SqlConnection : DbConnection
    {
        public override void OpenConnection()
        {
            Console.WriteLine("Opened Sql Connection");
            Timeout = new TimeSpan();
        }

        public override void CloseConnection()
        {
            Console.WriteLine("Closed Sql Connection");
        }
    }

    class OracleConnection : DbConnection
    {
        public override void OpenConnection()
        {
            Console.WriteLine("Opened Oracle Connection");
        }

        public override void CloseConnection()
        {
            Console.WriteLine("Closed Oracle Connection");
        }
    }

    class DbCommand
    {
        private readonly DbConnection _conn;
        private readonly string _command;

        public DbCommand(DbConnection conn, string command)
        {
            if (string.IsNullOrWhiteSpace(command))
                throw new ArgumentException("Cannot be empty", nameof(command));

            _conn = conn ?? throw new ArgumentNullException(nameof(conn));
            _command = command;
        }

        public void Execute()
        {
            _conn.OpenConnection();
            Console.WriteLine($"Command: {_command}");
            _conn.CloseConnection();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sqlConnection = new SqlConnection();
            var sqlCommand = new DbCommand(sqlConnection, "SQL");
            sqlCommand.Execute();

            var oracleConnection = new OracleConnection();
            var oracleCommand = new DbCommand(oracleConnection, "Oracle");
            oracleCommand.Execute();
        }
    }
}
