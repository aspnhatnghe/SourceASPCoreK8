using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using D10_ADONET.Models;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace D10_ADONET.Controllers
{
    public class HomeController : Controller
    {
        string ChuoiKetNoi = @"Data Source=.;Initial Catalog=MyeStore;Integrated Security=True";

        public IActionResult GetLoai()
        {
            SqlConnection con = new SqlConnection(ChuoiKetNoi);

            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Loai", con);

            DataTable dtLoai = new DataTable();
            da.Fill(dtLoai);

            //xứ lý kết quả
            StringBuilder sb = new StringBuilder();
            foreach(DataRow dr in dtLoai.Rows)
            {
                sb.AppendLine($"{dr["MaLoai"]} - {dr["TenLoai"]}");
            }

            return Content(sb.ToString());
        }

        public IActionResult UpdateGia()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("UPDATE HangHoa SET DonGia = ");
            sb.AppendLine("CASE ");
            sb.AppendLine("WHEN DonGia BETWEEN 100 AND 500 THEN DonGia *0.98 ");
            sb.AppendLine("    WHEN DonGia BEtWEEN 501 AND 1000 THEN DonGia *0.95 ");
            sb.AppendLine("WHEN DonGia > 1000 THEN DonGia * 0.93 ");
            sb.AppendLine("END");

            SqlConnection con = new SqlConnection(ChuoiKetNoi);
            SqlCommand cmd = new SqlCommand(sb.ToString(), con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            return Json(true);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
