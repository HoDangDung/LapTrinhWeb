using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lab03_MVC.Controllers;

namespace lab03_MVC.Models
{
    public class Giohang
    {
        //Tao doi tuong data chua du lieu tu model dbBansach da tao
        DataClassesDataContext data = new DataClassesDataContext();
        public int iMasach { set; get; }
        public string sTenSach { set; get; }
        public string sAnhbia { set; get; }
        public double dDongia { set; get; }
        public int iSoluong { set; get; }
        public double dThanhtien {
            get { return iSoluong * dDongia; }
        }
        //Khoi tao gio hang theo Masach duoc truyen vao voi Soluong mac dinh la 1
        public Giohang(int Masach)
        {
            iMasach = Masach;
            SACH sach = data.SACHes.Single(n => n.Masach == iMasach);
            sTenSach = sach.Tensach;
            sAnhbia = sach.Anhbia;
            dDongia = double.Parse(sach.Giaban.ToString());
            iSoluong = 1;
        }
    }
}