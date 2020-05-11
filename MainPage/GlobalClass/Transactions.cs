using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineShopping.GlobalTransaction
{
    class Transactions
    {
        NpgsqlConnection conn = new NpgsqlConnection();
        NpgsqlCommand command = new NpgsqlCommand();
        NpgsqlTransaction transaction;

        public void OpenConnection(String sql)
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                else
                {                
                    conn = new NpgsqlConnection(sql);
                    conn.Open();
                }


            }
            catch (Exception)
            {
                MessageBox.Show("Cannot Connect to Server at this Time");

            }
            finally
            {
                conn.Close();
            }

        }
        public void rollBackQuery()
        {
            transaction.Rollback();

            conn.Close();
        }

        public void startTransaction()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            transaction = conn.BeginTransaction();
            command.Connection = conn;
            command.CommandTimeout = 0;
            command.Transaction = transaction;
        }

        public void closeTransaction()
        {

            conn.Close();
          
        }

        public void commitQuery()
        {
            try
            {
                transaction.Commit();
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString());
            }

        }
        //public void Datasource(string sql, bool optionalBool = true)
        //{
        //    command.CommandText = sql;
        //    command.ExecuteNonQuery();

        //}

        // gamita ni if mag select ka sa imong  query or mag insert ka nga naay returning datatable form nani siya 
        //ready na for manipulation
        public DataTable Datasource(string sql)
        {
            DataSet dataSet = new DataSet();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            da.Fill(dataSet, "Custom_Command");
            da.Dispose();
            return dataSet.Tables["Custom_Command"];

        }

    }
}
