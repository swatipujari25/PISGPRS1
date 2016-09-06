using System;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Logger;

namespace PISGPRS
{
   public static class DbConnection
    {
     static  string dbPath=Application.StartupPath+ @"\Data\PIS.accdb";
     static  string  conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dbPath;
     static  OleDbCommand    cmd = null;
    static   OleDbConnection con = null;
     static  OleDbDataAdapter da = null;

       public static void Open()
       {
           try
           {
               con = new OleDbConnection(conStr);
               con.Open();
           }
           catch (Exception ex)
           {
               Logger.Logger.WriteLog(ex);
           }
       }

       public static void Close()
       {
           try
           {
               if (con != null)
               {                  
                   con.Close();
               }
           }
           catch (Exception ex)
           {
               Logger.Logger.WriteLog(ex);
           }
       }

       public static int CreateUpdateDelete(string sqlSyntax )
       {
           int result = 0;
           try
           {               
               Open();
               cmd = new OleDbCommand(sqlSyntax);
               cmd.Connection = con;  
              result= cmd.ExecuteNonQuery();               
           }
           catch (Exception ex)
           {
               Logger.Logger.WriteLog(ex);
           }
           return result;
       }

       public static DataTable GetData(string sqlSyntax)
       {
           DataTable dtt = new DataTable();
           try
           {
               Open();
               cmd = new OleDbCommand(sqlSyntax);
               cmd.Connection = con;             
               da = new OleDbDataAdapter(cmd);
               da.Fill(dtt);

           }
           catch (Exception ex)
           {
               Logger.Logger.WriteLog(ex);
           }
           return dtt;
       }

    }
}
