using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLBanHang.Models
{
    public class CartItem
    {
        public String MaSP { get; set; }
        public String TenSP { get; set; }
        public Double DonGia { get; set; }
        public int SoLuong { get; set; }
        public double ThanhTien
        {
            get
            {
                return SoLuong*DonGia;
            }
        }
    }
}