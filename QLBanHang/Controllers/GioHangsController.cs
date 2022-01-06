using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLBanHang.Models;
using System.Net;
using System.Net.Mail;

namespace QLBanHang.Controllers
{
    public class GioHangsController : Controller
    {
        private QLBanHangEntities db = new QLBanHangEntities();
        // GET: GioHangs
        public ActionResult Index()
        {
            List<CartItem> gioHang = Session["gioHang"] as List<CartItem>;
            return View(gioHang);
        }
        public RedirectToRouteResult AddToCart(String MaSP)
        {
            if (Session["gioHang"] == null)//chưa tồn tại=>tạo biến session để lưu sản phẩm vào giỏ hàng
            {
                Session["gioHang"] = new List<CartItem>();
            }
            //cập nhập/thêm
            List<CartItem> gioHang = Session["gioHang"] as List<CartItem>;
            // Kiểm tra gioHang đã có sp đang chọn(MaSP), nếu ch có => thêm
            if(gioHang.FirstOrDefault(c => c.MaSP== MaSP)== null)
            {
                SanPham sp = db.SanPhams.Find(MaSP);//Truy vấn bản sp để lấy thông tin sp
                CartItem newCart = new CartItem();
                newCart.MaSP = MaSP;
                newCart.TenSP = sp.TenSP;
                newCart.SoLuong = 1;
                newCart.DonGia = Convert.ToDouble(sp.Dongia);
                gioHang.Add(newCart);
            }
            else//SP đã có  trong giỏ hang ==> tăng sô lượng lên 1 
            {
                CartItem item = gioHang.FirstOrDefault(c => c.MaSP == MaSP);// tìm phần tử trong giỏ hàng
                item.SoLuong++;
            }
            Session["gioHang"] = gioHang;
             
            return RedirectToAction("index");
        }
        public RedirectToRouteResult Update(String MaSP, int txtSoLuong)
        {
            List<CartItem> gioHang = Session["gioHang"] as List<CartItem>;
            CartItem item = gioHang.FirstOrDefault(c => c.MaSP == MaSP);
            if (item != null)
            {
                item.SoLuong = txtSoLuong;
                Session["gioHang"] = gioHang;
            }
            return RedirectToAction("Index");
        }
        public RedirectToRouteResult Delete(String MaSP)
        {
            List<CartItem> gioHang = Session["gioHang"] as List<CartItem>;
            CartItem item = gioHang.FirstOrDefault(c => c.MaSP == MaSP);
            if (item != null)
            {
                gioHang.Remove(item);
                Session["gioHang"] = gioHang;
            }
            return RedirectToAction("Index");
        }
        public RedirectToRouteResult Order(String Email, string Phone)
        {
            List<CartItem> gioHang = Session["gioHang"] as List<CartItem>;
            string sMsg = "<html><body><table boder='1'><caption>Thông tin đặt hàng</caption>" +
                "<tr> <th>STT</th> <th>Tên hàng</th> <th>Số lượng</th> <th>Đơn giá</th> <th>Thành tiền</th> </tr>";
            int i = 0;
            double tongTien = 0;
            foreach(CartItem item in gioHang)
            {
                i++;
                sMsg += "<tr>";
                sMsg += "<td>" + i.ToString() + "</td>";
                sMsg += "<td>" + item.TenSP + "</td>";
                sMsg += "<td>" + item.SoLuong.ToString() + "</td>";
                sMsg += "<td>" + item.DonGia.ToString()+ "<t/d>";
                sMsg += "<td>" + String.Format("{0:0,###}", item.ThanhTien) + "<td>";
                sMsg += "</tr>";
                tongTien += item.ThanhTien;
            }
            sMsg += "<tr><th colspan='5'>Tổng cộng: " + string.Format("{0:0,###}", tongTien) + "</th></tr></table></body></html>";
            MailMessage mail = new MailMessage("1851050134thien@ou.edu.vn", Email, "Thông tin đơn hàng", sMsg);
            SmtpClient client = new SmtpClient("smtp.gamil.com", 587);
            client.EnableSsl = true;
            client.Credentials= new NetworkCredential("NguyenMinhThien", "241803229");
            mail.IsBodyHtml = true;
            client.Send(mail);
            ViewBag.SendMail = "Đặt hàng thành công";
            return RedirectToAction("Index");
        }
    }
}