using System;
using System.Data.SqlClient;

namespace SqlConnectionExample
{
    class Program
    {
        static void Main()
        {
            string connectionString = @"Data Source=localhost\OJC;Initial Catalog=test;Integrated Security=true";

            SqlConnection sqlConn = new SqlConnection(connectionString);
            SqlCommand sqlComm = new SqlCommand();
            sqlComm.Connection = sqlConn;

            sqlComm.CommandText = "select top 10 empno, ename, job, sal from emp where job=@Job order by empno asc";
            sqlComm.Parameters.AddWithValue("@Job", "Clerk");
            sqlConn.Open();

            using (SqlDataReader SqlRs = sqlComm.ExecuteReader())
            {
                Console.WriteLine("Empno | Ename | Job  | Sal");
                Console.WriteLine("-----------------------------");
                while (SqlRs.Read())
                {
                    Console.WriteLine($"{SqlRs[0]} | {SqlRs[1]} | {SqlRs[2]} | {SqlRs[3]}");
                }
            }
            sqlConn.Close();
        }
    }
}
/*
Empno | Ename | Job  | Sal
---------------------------
7369 | SMITH | CLERK | 800
7876 | ADAMS | CLERK | 1100
7900 | JAMES | CLERK | 950
*/
