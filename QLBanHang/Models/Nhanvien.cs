﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class Nhanvien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nhanvien()
        {
            this.HoaDons = new HashSet<HoaDon>();
        }
        [Display(Name = "Mã Nhân viên")]
        public int MaNV { get; set; }
        [Display(Name = "Họ Nhân viên")]
        public string HoNV { get; set; }
        [Display(Name = "Tên Nhân viên")]
        public string Ten { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Diachi { get; set; }
        [Display(Name = "Điện thoại")]
        public string Dienthoai { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
