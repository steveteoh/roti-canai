using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using GriauleFingerprintLibrary.DataTypes;


namespace FingerprintACL.Models.DB
{
    public sealed class SQLDataAccessLayer : IGRDal
    {
        public SqlConnection dbConection;

        //to be moved to web.config
        public readonly string CONNECTION_STRING = "Data Source=localhost;Initial Catalog=DEMO;Integrated Security=True";

        private SQLDataAccessLayer()
        {
            dbConection = new SqlConnection(CONNECTION_STRING);
        }

        public void SaveTemplate(FingerprintTemplate fingerprintTemplate)
        {

            using (dbConection)
            {
                dbConection.Open();

                string strCommand = "INSERT INTO [dbo].[tblEnroll](Template,quality) VALUES (@template, @quality)";
 

                SqlCommand sqlCommand = new SqlCommand(strCommand, dbConection);
                sqlCommand.Parameters.Add(new SqlParameter("@template", SqlDbType.VarBinary,
                    fingerprintTemplate.Size, ParameterDirection.Input, false, 0, 0, "ID", DataRowVersion.Current, fingerprintTemplate.Buffer));
                sqlCommand.Parameters.Add(new SqlParameter("@quality", SqlDbType.SmallInt));
                sqlCommand.Parameters["@quality"].Value = (Int16)fingerprintTemplate.Quality;
                int i = sqlCommand.ExecuteNonQuery();
            }


        }

        public void SaveTemplate(string User, FingerprintTemplate fingerprintTemplate)
        {

            using (dbConection)
            {
                dbConection.Open();

                string strCommand = "INSERT INTO [dbo].[tblEnroll](StaffID, Template,quality) VALUES (@StaffID, @template, @quality)";

                SqlCommand sqlCommand = new SqlCommand(strCommand, dbConection);

                sqlCommand.Parameters.Add(new SqlParameter("@StaffID", SqlDbType.Text));
                sqlCommand.Parameters["@StaffID"].Value = User;   //to add in staff id
                sqlCommand.Parameters.Add(new SqlParameter("@template", SqlDbType.VarBinary,
                    fingerprintTemplate.Size, ParameterDirection.Input, false, 0, 0, "ID", DataRowVersion.Current, fingerprintTemplate.Buffer));
                sqlCommand.Parameters.Add(new SqlParameter("@quality", SqlDbType.SmallInt));
                sqlCommand.Parameters["@quality"].Value = (Int16)fingerprintTemplate.Quality;
                int i = sqlCommand.ExecuteNonQuery();
            }
        }

        public IDataReader GetTemplates()
        {


            dbConection.Open();

            string strCommand = "SELECT * FROM [dbo].[tblEnroll]";

            SqlCommand sqlCommand = new SqlCommand(strCommand, dbConection);
            return sqlCommand.ExecuteReader();

        }

        ~SQLDataAccessLayer()
        {
            if (dbConection.State == ConnectionState.Open)
            {
                try
                {
                    dbConection.Dispose();
                }
                catch { }
            }
        }

        public IDataReader GetTemplate(int idTemplate)
        {
            dbConection.Open();

            string strCommand = "SELECT * FROM [dbo].[tblEnroll] WHERE ID = ?";

            SqlCommand sqlCommand = new SqlCommand(strCommand, dbConection);
            sqlCommand.Parameters.Add(new SqlParameter("@ID", idTemplate));
            return sqlCommand.ExecuteReader();
        }

        public void DeleteTemplate(int idTemplate)
        {
        }


        public void DeleteTemplate()
        {
            using (dbConection)
            {
                dbConection.Open();

                string strCommand = "DELETE FROM [dbo].[tblEnroll]";

                SqlCommand sqlCommand = new SqlCommand(strCommand, dbConection);
                int i = sqlCommand.ExecuteNonQuery();

            }
        }

    }


}