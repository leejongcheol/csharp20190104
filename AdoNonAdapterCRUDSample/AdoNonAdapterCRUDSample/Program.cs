using System;
using System.Data;
using System.Data.OleDb;

namespace AdoNonAdapterCRUDSample
{
    class CommandExam
    {
        static OleDbConnection cn;
        public static void Main()
        {
            OleCn(); Openning();

            Console.WriteLine("The Original Table");
            Output();

            Console.WriteLine("Added Table"); Adding(); Output();
            Console.WriteLine("Modified Table"); Modifying(); Output();
            Console.WriteLine("Deleted Table"); Deleting(); Output();
            Closing();
        }

        public static void OleCn()
        {
            //오라클, 프로젝트 속성에서 타겟플랫폼을 32비트 또는 64비트로 설정해야 한다.
            //64비트용, topcredu는 $ORACLE_HOME/network/admin tnsnames.ora 파일에정의된 TNS 이름 
            //string conStr = "Provider=OraOLEDB.ORACLE;data source=topcredu;User ID=scott;Password=tiger";

            // SQL Server, 프로젝트 속성에서 Target Pltform을 64비트라고 할 필요없다.
            // OJC는 SQL Server 인스턴스 이름
            string conStr = @"Provider=SQLOLEDB;Data Source=localhost\OJC;Initial Catalog=test;Integrated Security=SSPI";

            cn = new OleDbConnection(conStr);
        }

        public static void Openning() { cn.Open(); }
        public static void Output()
        {
            string sql = "SELECT empno id, ename name FROM emp";
            OleDbCommand cmd; OleDbDataReader dr;
            cmd = new OleDbCommand(sql, cn);
            dr = cmd.ExecuteReader();

            Console.Write("\n");
            while (dr.Read())
            {
                Console.WriteLine("{0, -10}\t{1, -10}", dr[0].ToString().Trim(), dr[1].ToString().Trim());
            }
            Console.Write("\n"); dr.Close();
        }

        public static void Adding()
        {
            try
            {
                string sqladd = "INSERT INTO emp (empno, ename) VALUES (888, 'OJC')";
                OleDbCommand cmdAdd = new OleDbCommand(sqladd, cn);

                int rowsadded = cmdAdd.ExecuteNonQuery();
                Console.WriteLine("Number of rows added: " + rowsadded);
            }
            catch (Exception e) { Console.WriteLine(e.ToString()); }
        }

        public static void Modifying()
        {
            try
            {
                string sqlmodify = "UPDATE emp SET ename = '오닷넷'  WHERE empno = 888";
                OleDbCommand cmdupdate = new OleDbCommand(sqlmodify, cn);
                int rows = cmdupdate.ExecuteNonQuery();
                Console.WriteLine("Number of rows modified: " + rows);
            }
            catch (Exception e) { Console.WriteLine(e.ToString()); }
        }
        public static void Deleting()
        {
            try
            {
                string sqldelete = "DELETE FROM emp WHERE empno = 888 ";
                OleDbCommand cmddelete = new OleDbCommand(sqldelete, cn);
                int rows = cmddelete.ExecuteNonQuery();
                Console.WriteLine("Number of rows deleted: " + rows);
            }
            catch (Exception e) { Console.WriteLine(e.ToString()); }
        }
        public static void Closing() { cn.Close(); }
    }
}
