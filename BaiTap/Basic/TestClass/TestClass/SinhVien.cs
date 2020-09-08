using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestClass {
    public class SinhVien {

        //Attribute
        private int maSV;
        private string tenSV;

        // Constructor
        public SinhVien() {
            maSV = 0;
            tenSV = "";
        }

        public SinhVien(int maSV, string tenSV) {
            this.maSV = maSV;
            this.tenSV = tenSV;
        }

        //Getter and setter
        public int ma {
            get { return maSV; }

            set {
                maSV = value;
            }
        }

        public string ten {
            get {
                return tenSV;
            }
            set {
                tenSV = value;
            }
        }
        //toString
        public override string ToString() {
            return " Mã SV: " + maSV + "\tHọ Tên:" + tenSV;
        }


        // Method 
        public void hoc() {
            Console.WriteLine("SV học ngành CNTT");
        }
    }
}
