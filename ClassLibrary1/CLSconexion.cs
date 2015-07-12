using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SAAR.Datos
{
    class CLSconexion
    {
        public void ExecuteNonQuery(string strSQL)
        {
            SqlConnection cnn = null;
            //SqlTransaction trans = cnn.BeginTransaction();
            try
            {
                cnn = new SqlConnection(ObtenerCadenaConexion());
                cnn.Open();
                SqlCommand cmd = cnn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL;

                //cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                //trans.Rollback();   
                throw;
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
        }

        public DataSet ExecuteDataSet(string strSQL)
        {
            DataSet ds = new DataSet();
            SqlConnection cnn = null;
            try
            {
                cnn = new SqlConnection(ObtenerCadenaConexion());

                cnn.Open();
                SqlCommand cmd = cnn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL;


                //cmd.Transaction = trans;
                cmd.CommandTimeout = 0; // infinito

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds, "tabla1");
                return ds;
            }

            catch (Exception)
            {
                //trans.Rollback();
                throw;
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }


        }

        private string ObtenerCadenaConexion()
        {
            try
            {
               return @"Data Source=(local);Initial Catalog=SAAR;Integrated Security=True";
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
