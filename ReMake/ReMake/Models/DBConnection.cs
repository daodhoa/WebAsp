using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace ReMake.Models
{
    public class DBConnection
    {
        private string strCon = ConfigurationManager.ConnectionStrings["SQLSTRING"].ConnectionString;
       
        public DataTable DangNhapHeThong(string email, string pw)
        {
            try
            {
                DataTable table = new DataTable();
                //Khai bao connection String
                SqlConnection cnn = new SqlConnection(strCon);
                cnn.Open();
                // khoi tao command de thuc thi thu thuc
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;

                //khoi tao cac parameter (string email, string pw)
                SqlParameter para1 = new SqlParameter();
                para1.DbType = DbType.String;
                para1.ParameterName = "@email";
                para1.Value = email;
                cmd.Parameters.Add(para1);

                SqlParameter para2 = new SqlParameter();
                para2.DbType = DbType.String;
                para2.ParameterName = "@pw";
                para2.Value = pw;
                cmd.Parameters.Add(para2);

                // Gan thu tuc vao doi tuong command
                cmd.CommandText = "DANG_NHAP_HE_THONG";
                cmd.CommandType = CommandType.StoredProcedure;

                // dua gia tri tu commandtext vao adter
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                //fill vao table

                ad.Fill(table);


                return table;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void DoiMatKhau(string email, string oldpw, string newpw, string repw)
        {
            try
            {
                //Khai bao connection String
                SqlConnection cnn = new SqlConnection(strCon);
                cnn.Open();
                // khoi tao command de thuc thi thu thuc
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;

                SqlParameter para1 = new SqlParameter();
                para1.DbType = DbType.String;
                para1.ParameterName = "@email";
                para1.Value = email;
                cmd.Parameters.Add(para1);

                SqlParameter para2 = new SqlParameter();
                para2.DbType = DbType.String;
                para2.ParameterName = "@oldpw";
                para2.Value = oldpw;
                cmd.Parameters.Add(para2);

                SqlParameter para3 = new SqlParameter();
                para3.DbType = DbType.String;
                para3.ParameterName = "@newpw";
                para3.Value = newpw;
                cmd.Parameters.Add(para3);

                SqlParameter para4 = new SqlParameter();
                para4.DbType = DbType.String;
                para4.ParameterName = "@repw";
                para4.Value = repw;
                cmd.Parameters.Add(para4);

                // Gan thu tuc vao doi tuong command
                cmd.CommandText = "DOI_MAT_KHAU";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

    }
}