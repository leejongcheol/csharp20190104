using System;
using System.Data;
using System.Data.OleDb;

namespace ConsoleApplication20
{
    class Program
    {
        static void Main(string[] args)
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

            OleDbConnection myOleDbConnection = new OleDbConnection(conStr);
            OleDbCommand myOleDbCommand = myOleDbConnection.CreateCommand();

            //CommendText에 직접 테이블 명을 기술하겠다는 의미
            myOleDbCommand.CommandType = CommandType.TableDirect;

            myOleDbCommand.CommandText = "EMP"; //테이블명이다. 

            myOleDbConnection.Open();

            OleDbDataReader myOleDbDataReader = myOleDbCommand.ExecuteReader();

            //전체 EMP 테이블의 데이터중 두 건만 출력하자.
            for (int count = 1; count <= 2; count++)
            {
                myOleDbDataReader.Read();
                Console.WriteLine("myOleDbDataReader[\" EMPNO\"] = " + myOleDbDataReader["EMPNO"]);
                Console.WriteLine("myOleDbDataReader[\" ENAME\"] = " + myOleDbDataReader["ENAME"]);
                Console.WriteLine("myOleDbDataReader[\" SAL\"] = " + myOleDbDataReader["SAL"]);
            }
            myOleDbDataReader.Close();
            myOleDbConnection.Close();
        }
    }
}
/*
[실행결과]
myOleDbDataReader[" EMPNO"] = 3456
myOleDbDataReader[" ENAME"] = 3000길동
myOleDbDataReader[" SAL"] =
myOleDbDataReader[" EMPNO"] = 7369
myOleDbDataReader[" ENAME"] = SMITH
myOleDbDataReader[" SAL"] = 800
*/
