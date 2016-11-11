using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace dataAccessLayer
{
    public class dataAccess
    {

        private string connectionString = "";
        // ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;

        private SqlConnection conn;
        private SqlDataAdapter da;
        private SqlCommand cmd;


        private string uid;
        private string pwd;

        public dataAccess()
        {
          
        }
        public bool OpenConnect(string uid,string pwd)
        {
            try
            {
                this.uid=uid;
                this.pwd=pwd;

                this.connectionString=string.Format(@"Data Source=.\SQLEXPRESS;Initial Catalog=[DBMS]Tramyte_Demo;User ID= {0};Password={1}", this.uid, this.pwd);
                System.Diagnostics.Debug.Write(connectionString);
                conn=new SqlConnection(this.connectionString);
                conn.Open();
                return true;
            }
            catch (SqlException)
            {
                System.Diagnostics.Debug.Write("Catch error at dataAccess");
                return false;
            }
             
        }
        public DataSet executeQueryDataSet(string sql)
        {
            

            if(conn!=null &&conn.State==ConnectionState.Open)
                     conn.Close();
            OpenConnect(this.uid, this.pwd);
            //this.connectionString=string.Format(@"Data Source=.\SQLEXPRESS;Initial Catalog=[DBMS]Tramyte_Demo;User ID= {0};Password={1}", this.uid, this.pwd);

            //conn=new SqlConnection(this.connectionString);
            cmd=conn.CreateCommand();
            cmd.CommandText=sql;
            cmd.CommandType=CommandType.Text;
            da=new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public bool executeNonQuery(string sql, CommandType ct,

            params SqlParameter[] param)
        {
            bool f = false;
            if (conn.State==ConnectionState.Open)
                conn.Close();
            conn=new SqlConnection(this.connectionString);
            cmd=conn.CreateCommand();
            conn.Open();
            cmd.Parameters.Clear();
            cmd.CommandText=sql;
            cmd.CommandType=ct;

            foreach (SqlParameter p in param)
                cmd.Parameters.Add(p);
            try
            {
                cmd.ExecuteNonQuery();
                f=true;
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return f;
        }
        public object executeScalar(string comdText, CommandType type
         , params SqlParameter[] param)
        {
            object result=null;
            //
            if(cmd.Parameters.Count!=0)
                 cmd.Parameters.Clear();
            cmd.CommandType=type;
            cmd.CommandText=comdText;

            if (conn.State==ConnectionState.Open)
                conn.Close();
            conn.Open();
            foreach (SqlParameter p in param)
            {
                System.Diagnostics.Debug.Write(p.Value);
                cmd.Parameters.Add(p);
                
            }
              
            try
            {
                result=(object)cmd.ExecuteScalar();
                System.Diagnostics.Debug.Write(result);
            }
            catch (SqlException)
            {

            }
            finally
            {
                conn.Close();
            }
            return result;
        }
        public int checkUserLogin(string comdText, CommandType type
          , params SqlParameter[] param)
        {
            int result = -1;
            //
            cmd.Parameters.Clear();
            cmd.CommandType=type;
            cmd.CommandText=comdText;

            if (conn.State==ConnectionState.Open)
                conn.Close();
            conn.Open();
            foreach (SqlParameter p in param)
                cmd.Parameters.Add(p);
            try
            {
                result=(int)cmd.ExecuteScalar();
                System.Diagnostics.Debug.Write(result);
            }
            catch (SqlException)
            {

            }
            finally
            {
                conn.Close();
            }
            return result;
        }
        public DataSet ExcuteSP(string sql, CommandType ct,
            params SqlParameter[] param)
        {
            if (conn.State==ConnectionState.Open)
                conn.Close();
            conn=new SqlConnection(this.connectionString);
            cmd=conn.CreateCommand();
            conn.Open();
            cmd.Parameters.Clear();
            cmd.CommandText=sql;
            cmd.CommandType=ct;
            foreach (SqlParameter p in param)
                cmd.Parameters.Add(p);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();

            da.Fill(ds);

            return ds;
        }
        public string getConnectionString()
        {
            return this.connectionString;
        }


    }

}
