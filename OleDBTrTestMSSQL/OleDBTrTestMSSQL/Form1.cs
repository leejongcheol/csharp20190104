using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace OleDBTrTestMSSQL
{
    public partial class Form1 : Form
    {
        OleDbDataAdapter adapter = null;
        DataSet ds = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ds = new DataSet("emp");
            //오라클 topcredu는 $ORACLE_HOME/network/admin의 tnsnames.ora 파일에 정의된 TNS이름
            //string conStr = "Provider=ORAOLEDB.ORACLE;data source=topcredu;User ID=scott;Password=tiger";
            //string conStr = "Provider=OraOLEDB.ORACLE;data source=topcredu;User ID=scott;Password=tiger";

            // SQL Server, 프로젝트 속성에서 Target Pltform을 64비트라고 할 필요없다.
            string conStr = @"Provider=SQLOLEDB;Data Source=localhost\OJC;Initial Catalog=test;Integrated Security=SSPI";

            using (OleDbConnection connection = new OleDbConnection(conStr))
            {
                OleDbCommand command = new OleDbCommand();
                OleDbTransaction tr = null;

                try
                {
                    connection.Open();
                    tr = connection.BeginTransaction();
                    command.Connection = connection;
                    command.Transaction = tr;

                    command.CommandText = "insert into emp (empno, ename)"
                         + " values (3456, '3000길동')";
                    int i = command.ExecuteNonQuery();
                    Console.WriteLine(i + "건 Inserted!");

                    command.CommandText = "insert into emp (empno, ename)"
                         + " values (7890, '3000길동')";
                    i = command.ExecuteNonQuery();

                    tr.Commit();

                    adapter = new OleDbDataAdapter("select * from emp", connection);
                    adapter.Fill(ds, "EMP");
                    dataGridView1.DataSource = ds.Tables["EMP"];

                    adapter.Fill(ds, "EMP");
                }
                catch (Exception ex)
                {
                    tr?.Rollback();
                    MessageBox.Show(ex.Message, "emp Table Loading Error");
                }
                finally
                {
                    connection.Close();
                }

            }
        }
    }
}
