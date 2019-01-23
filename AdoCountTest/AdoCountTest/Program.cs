using System;
using System.Data;
using System.Data.OleDb;

namespace AdoCountTest
{
    class Program
    {
        static void Main(string[] args)
        {
            OleDbConnection Cn = null;
            try
            {
                // SQL Server, 프로젝트 속성에서 Target Pltform을 64비트라고 할 필요없다.
                // OJC는 SQL Server 인스턴스 이름
                string conStr = @"Provider=SQLOLEDB;Data Source=localhost\OJC;Initial Catalog=test;Integrated Security=SSPI";

                // 아래는 오라클, 오라클 클라이언트 설치 필요없다.
                //string conStr = @"Data Source=(DESCRIPTION =
                //             (ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.0.27)(PORT = 1521))
                //                        (CONNECT_DATA =
                //                          (SERVER = DEDICATED)
                //                          (SERVICE_NAME = topcredu)
                //                        )
                //                      )  ;User Id=scott;Password=tiger";

                Cn = new OleDbConnection(conStr);
                OleDbCommand cmdSelect = new OleDbCommand("select count(*) from emp", Cn);
                Cn.Open();
                object count = cmdSelect.ExecuteScalar();
                Console.WriteLine("Count of Emp = {0}", count);
                Cn.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            finally
            {
                if (Cn.State == ConnectionState.Open) { Cn.Close(); }
            }
        }
    }
}
/*
Count of Emp = 14
*/
