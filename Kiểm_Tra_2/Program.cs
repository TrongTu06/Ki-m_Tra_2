using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiểm_Tra_2
{
    public class NhanVien
    {
        public string maso { get; set; }
        public string hoten { get; set; }
        public int luongcung { get; set; }
        public NhanVien()
        {
            maso = "";
            hoten = "";
            luongcung = 0;
        }
        public NhanVien(string maso, string hoten, int luongcung)
        {
            this.maso = maso;
            this.hoten = hoten;
            this.luongcung = luongcung;
        }
        public void Nhap()
        {
            Console.Write("Nhập mã số nhân viên: ");
            maso = Console.ReadLine();
            Console.Write("Nhập họ tên nhân viên: ");
            hoten = Console.ReadLine();
            Console.Write("Nhập lương cô bản: ");
            luongcung = int.Parse(Console.ReadLine());
        }
        public int Tinhluong()
        {
            return luongcung;
        }
        public class NhanVienBC : NhanVien
        {
            public string mucxeploai { get; set; }
            public NhanVienBC() : base()
            {
                mucxeploai = "";
            }
            public NhanVienBC(string maso, string hoten, int luongcung, string mucxeploai)
        : base(maso, hoten, luongcung)
            {
                this.mucxeploai = mucxeploai;
            }
            public void Nhap()
            {
                base.Nhap();
                Console.Write("Nhập mức xếp loại (A, B, C): ");
                mucxeploai = Console.ReadLine();
            }
            public int Tinhluong()
            {
                int luong = base.Tinhluong();
                if (mucxeploai == "A")
                {
                    luong += 1000000;
                }
                else if (mucxeploai == "B")
                {
                    luong += 500000;
                }
                else if (mucxeploai == "C")
                {
                    luong += 200000;
                }
                return luong;
            }
        }
        public class NhanVienHD : NhanVien
        {
            public int doanhthu { get; set; }
            public NhanVienHD() : base()
            {
                doanhthu = 0;
            }
            public NhanVienHD(string maso, string hoten, int luongcung, int doanhthu) : base(maso, hoten, luongcung)
            {
                this.doanhthu = doanhthu;
            }

            public void Nhap()
            {
                base.Nhap();
                Console.Write("Nhập doanh thu: ");
                doanhthu = int.Parse(Console.ReadLine());
            }
            public override int Tinhluong()
            {
                int luong = base.Tinhluong();
                if (doanhthu > 10000000)
                {
                    luong += 2000000;
                }
                else if (doanhthu > 5000000)
                {
                    luong += 1000000;
                }
                return luong;
            }
        }
        public class QuanLyNV
        {
            public List<NhanVien> dsNV { get; set; }
            public QuanLyNV()
            {
                dsNV = new List<NhanVien>();
            }
            public void NhapDS()
            {
                Console.WriteLine("Nhập số lượng nhân viên:");
                int soLuong = int.Parse(Console.ReadLine());
                for (int i = 0; i < soLuong; i++)
                {
                    Console.WriteLine("Nhập loại nhân viên (1 - Biên chế, 2 - Hợp đồng):");
                    int loaiNV = int.Parse(Console.ReadLine());
                    Console.WriteLine("Nhập mã số nhân viên:");
                    int maSo = int.Parse(Console.ReadLine());
                    Console.WriteLine("Nhập họ tên nhân viên:");
                    string hoTen = Console.ReadLine();
                    Console.WriteLine("Nhập lương cơ bản:");
                    double luong = double.Parse(Console.ReadLine());
                    if (loaiNV == 1)
                    {
                        Console.WriteLine("Nhập mức xếp loại (A, B, C):");
                        string mucXeploai = Console.ReadLine();
                        dsNV.Add(new NhanVienBC());
                    }
                    else if (loaiNV == 2)
                    {
                        Console.WriteLine("Nhập phụ cấp:");
                        double phuCap = double.Parse(Console.ReadLine());
                        dsNV.Add(new NhanVienHD());
                    }
                    else
                    {
                        Console.WriteLine("Loại nhân viên không hợp lệ!");
                    }
                }
            }
            public void XuatDS()
            {
                Console.WriteLine("Danh sách nhân viên:");
                foreach (var nv in dsNV)
                {
                    Console.WriteLine($"Mã số: {nv.maso}, Họ tên: {nv.hoten}, Lương thực lãnh: {nv.Tinhluong()}");
                }
            }
            public double TinhTongLuong()
            {
                double tongLuong = 0;
                foreach (var nv in dsNV)
                {
                    tongLuong += nv.Tinhluong();
                }
                return tongLuong;
            }
            public double TinhLuongTrungBinh()
            {
                if (dsNV.Count == 0) return 0;
                return TinhTongLuong() / dsNV.Count;
            }
        }
        static void Main(string[] args)
        {
            NhanVienBC nvbc = new NhanVienBC();
            nvbc.Nhap();
            Console.WriteLine($"Lương của nhân viên bảng công {nvbc.hoten} là: {nvbc.Tinhluong()} VNĐ");
            NhanVienHD nvhd = new NhanVienHD();
            nvhd.Nhap();
            Console.WriteLine($"Lương của nhân viên hợp đồng {nvhd.hoten} là: {nvhd.Tinhluong()} VNĐ");
            QuanLyNV qlnv = new QuanLyNV();

            // Nhập danh sách nhân viên
            qlnv.NhapDS();

            // Xuất danh sách nhân viên
            qlnv.XuatDS();

            // Tính tổng lương
            double tongLuong = qlnv.TinhTongLuong();
            Console.WriteLine($"Tổng tiền lương công ty phải trả: {tongLuong}");

            // Tính lương trung bình
            double luongTrungBinh = qlnv.TinhLuongTrungBinh();
            Console.WriteLine($"Lương thực lãnh trung bình của các nhân viên: {luongTrungBinh}");
        }
    }
}
