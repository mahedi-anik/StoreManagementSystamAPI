using AspNetCore.Reporting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace StoreManagementSystemAPI.Services
{
    public class ReportServices
    {
        string constr = "Server=DESKTOP-54JPA7R\\SQLEXPRESS01;Database=StoreManagementDB;Trusted_Connection=True;User ID=Jait;Password=jaiT;";
        
        public DataTable GetAllShelf()
        {
            var dt = new DataTable();
            using(SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("GetAllShelfList", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
                con.Close();
            }
            return dt;
        }









        private RenderType GetRenderType(string reportType)
        {
            var renderType = RenderType.Pdf;

            switch(reportType.ToUpper())
            {
                default:
                case "PDF":
                    renderType = RenderType.Pdf;
                    break;
                case "XLS":
                    renderType = RenderType.Excel;
                    break;
                case "WORD":
                    renderType = RenderType.Word;
                    break;
            }

            return renderType;
        }

    }
}
