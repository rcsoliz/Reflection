using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

/*
* Title:Roberto 
* Author:Soliz
* Date: 26/04/2020
* Purpose: Connect to Sql-Server database and get data
*/

namespace Initial
{
    public class Conection
    {

        #region Global attributes
        public DataSet dsDatos { get; set; }
        #endregion

        #region Constructor
        public Conection()
        {
            dsDatos = new DataSet();
        }
        #endregion

        #region Methods And Functions
        /// <summary>
        /// responsible for opening the connection with the database
        /// </summary>
        /// <param name="objConection">Connection parameter</param>
        public void openConection(SqlConnection odcConexion)
        {
            try
            {
                odcConexion.Open();
            }
            catch (Exception exException)
            {
                throw new Exception("Error occurred connecting to the database" + "\n\nDetail Error:\n" + exException.Message);
            }
        }

        /// <summary>
        /// Close the database connection
        /// </summary>
        /// <param name="objConection">Connection parameter</param>
        public void closeConection(SqlConnection objConection)
        {
            try
            {
                objConection.Close();
                objConection.Dispose();
                objConection = null;
            }
            catch(Exception ex)
            {
                throw new Exception("Error occurred close to the database" + "\n\nDetail Error:\n" + ex.Message);
            }
        }
      
        public void Consult(string strSQL)
        {
            try
            {
                SqlConnection objConection = null;
                string connectionString = "Server=DESKTOP-5ES1ETN; Initial Catalog=TESTPOWERBATCH; User Id=sa; Password=sa";
                objConection = new SqlConnection(connectionString);
                openConection(objConection);

                SqlDataAdapter objDataAdapter = new SqlDataAdapter();
                objDataAdapter.SelectCommand = new SqlCommand();
                objDataAdapter.SelectCommand.CommandText = strSQL;
                objDataAdapter.SelectCommand.Connection = objConection;

                objDataAdapter.Fill(dsDatos, "nametable");

                closeConection(objConection);

            }
            catch (Exception exException)
            {
                throw new Exception("Error has occurred executing the query:\n" + strSQL + "\n\nDetail Error:\n" + exException.Message);
            }
        }

        public void GetDataInformation(string strSQL, int parameterBlock, ref DataSet dts)
        {
            try
            {
                SqlConnection objConection = null;
                string connectionString = "Server=DESKTOP-5ES1ETN; Initial Catalog=TESTPOWERBATCH; User Id=sa; Password=sa";
                objConection = new SqlConnection(connectionString);
                openConection(objConection);

                SqlDataAdapter objDataAdapter = new SqlDataAdapter();
                objDataAdapter.SelectCommand = new SqlCommand();
                objDataAdapter.SelectCommand.CommandText = strSQL;
                objDataAdapter.SelectCommand.Connection = objConection;

                objDataAdapter.Fill(dts, "nametable");

                closeConection(objConection);
            }
            catch(Exception ex)
            {
                throw new Exception("Error has occurred executing the query:\n" + strSQL + "\n\n Error detail:\n" + ex.Message);
            }
        }

        #endregion

    }
}
