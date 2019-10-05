using System.ComponentModel.DataAnnotations;

namespace D10_ADONET.Models
{
    public class Loai
    {
        public int MaLoai { get; set; }
        public string TenLoai { get; set; }
        public string Hinh { get; set; }
        [DataType(DataType.MultilineText)]
        public string MoTa { get; set; }
    }
}