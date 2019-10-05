using D10_ADONET.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace D10_ADONET.Models
{
    public class LoaiDataAccessLayer
    {
        public static IEnumerable<Loai> GetAll()
        {
            DataTable dtLoai = DataProvider.SelectData("spLayTatCaLoai", CommandType.StoredProcedure, null);

            List<Loai> result = new List<Loai>();
            foreach (DataRow row in dtLoai.Rows)
            {
                result.Add(new Loai
                {
                    MaLoai = int.Parse(row["MaLoai"].ToString()),
                    TenLoai = row["TenLoai"].ToString(),
                    MoTa = row["MoTa"].ToString(),
                    Hinh = row["Hinh"].ToString()
                });
            }

            return result;
        }

        public static Loai Get(int maLoai)
        {
            SqlParameter[] pa = new SqlParameter[1];
            pa[0] = new SqlParameter("MaLoai", maLoai);

            DataTable dtLoai = DataProvider.SelectData("spLayLoai", CommandType.StoredProcedure, pa);

            if (dtLoai.Rows.Count == 0) return null;

            DataRow row = dtLoai.Rows[0];
            return new Loai
            {
                MaLoai = int.Parse(row["MaLoai"].ToString()),
                TenLoai = row["TenLoai"].ToString(),
                MoTa = row["MoTa"].ToString(),
                Hinh = row["Hinh"].ToString()
            };
        }

        public static Loai Add(Loai lo)
        {
            try
            {
                SqlParameter[] pa = new SqlParameter[4];
                pa[0] = new SqlParameter("MaLoai", SqlDbType.Int);
                pa[0].Direction = ParameterDirection.Output;
                pa[1] = new SqlParameter("TenLoai", lo.TenLoai);
                pa[2] = new SqlParameter("MoTa", lo.MoTa);
                pa[3] = new SqlParameter("Hinh", lo.Hinh);

                DataProvider.ExcuteNonQuery("spThemLoai", CommandType.StoredProcedure, pa);
                lo.MaLoai = (int)pa[0].Value;

                return lo;
            }
            catch { return null; }
        }

        public static bool Update(Loai lo)
        {
            try
            {
                SqlParameter[] pa = new SqlParameter[4];
                pa[0] = new SqlParameter("MaLoai", lo.MaLoai);
                pa[1] = new SqlParameter("TenLoai", lo.TenLoai);
                pa[2] = new SqlParameter("MoTa", lo.MoTa);
                pa[3] = new SqlParameter("Hinh", lo.Hinh);

                DataProvider.ExcuteNonQuery("spSuaLoai", CommandType.StoredProcedure, pa);

                return true;
            }
            catch { return false; }
        }

        public static bool Remove(int maLoai)
        {
            try
            {
                SqlParameter[] pa = new SqlParameter[1];
                pa[0] = new SqlParameter("MaLoai", maLoai);

                DataProvider.ExcuteNonQuery("spXoaLoai", CommandType.StoredProcedure, pa);

                return true;
            }
            catch { return false; }
        }
    }
}
