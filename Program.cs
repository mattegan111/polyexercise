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
            Console.WriteLine("Opened Connection");
            Timeout = new TimeSpan();
        }

        public override void CloseConnection()
        {
            Console.WriteLine("Closed Connection");
        }
    }

    class OracleConnection : DbConnection
    {
        public override void OpenConnection()
        {
            Console.WriteLine("Opened Connection");
        }

        public override void CloseConnection()
        {
            Console.WriteLine("Closed Connection");
        }
    }

    class dbCommand
    {
        
    }

    class Program
    {
        static void Main(string[] args)
        {
            var thing = new SqlConnection();
            thing.OpenConnection();
            thing.CloseConnection();
            thing.ConnectionString = "Hi";
        }
    }
}

