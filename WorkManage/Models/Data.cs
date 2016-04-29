using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WorkManage.Models
{
    public class Data
    {
        static SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["WorksDB"]);
        public static DataTable GetWorks()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Works WHERE WorkProgress=0  ORDER BY WorkProgress", cn)
            {
                CommandType = CommandType.Text
            };
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                cn.Open();
                sda.Fill(ds);
                return ds.Tables[0];
            }
            catch
            {
                return null;
            }
            finally
            {
                sda.Dispose();
                cmd.Dispose();
                cn.Close();
            }
        }

        public static bool InsertWork(Works work)
        {
            SqlCommand cmd =
                new SqlCommand(
                    "INSERT Works(WorkName,WorkProgress,Description,WorkMark,CompletionTime,CreateDate) VALUES(@WorkName,0,@Description,@WorkMark,'1970-01-01',GETDATE())",
                    cn) { CommandType = CommandType.Text };
            cmd.Parameters.Add("@WorkName", SqlDbType.VarChar).Value = work.WorkName;
            cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = work.Description;
            cmd.Parameters.Add("@WorkMark", SqlDbType.VarChar).Value = work.WorkMark;
            try
            {
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
            }
        }
        public static bool Update(Works work)
        {
            SqlCommand cmd =
                new SqlCommand(
                    "Update Works SET WorkName=@WorkName,Description=@Description,WorkMark=@WorkMark WHERE WorkId=@WorkId", cn) { CommandType = CommandType.Text };
            cmd.Parameters.Add("@WorkId", SqlDbType.Int).Value = work.WorkId;
            cmd.Parameters.Add("@WorkName", SqlDbType.VarChar).Value = work.WorkName;
            cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = work.Description;
            cmd.Parameters.Add("@WorkMark", SqlDbType.VarChar).Value = work.WorkMark;
            try
            {
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
            }
        }

        public static bool FinishWork(int workId)
        {
            SqlCommand cmd =
                new SqlCommand(
                    "Update Works SET WorkProgress=1 WHERE WorkId=@WorkId", cn) { CommandType = CommandType.Text };
            cmd.Parameters.Add("@WorkId", SqlDbType.Int).Value = workId;
            try
            {
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
            }
        }

        public static bool DeleteWork(int workId)
        {
            SqlCommand cmd =
                new SqlCommand(
                    "Delete Works  WHERE WorkId=@WorkId", cn) { CommandType = CommandType.Text };
            cmd.Parameters.Add("@WorkId", SqlDbType.Int).Value = workId;
            try
            {
                cn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
            }
        }
    }
}