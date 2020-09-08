using Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View___Model
{
    public class SinhVienViewModel
    {
        private ObservableCollection<SinhVien> listSinhVien;

        public ObservableCollection<SinhVien> ListSinhVien
        {
            get
            {
                return listSinhVien;
            }

            set
            {
                listSinhVien = value;
            }
        }

        public SinhVienViewModel()
        {
            ListSinhVien = new ObservableCollection<SinhVien>();
            ListSinhVien.Add(new SinhVien() { Id = 1, Ten = "Nguyễn Văn Hải" });
            ListSinhVien.Add(new SinhVien() { Id = 2, Ten = "Vũ Ngọc Anh" });
            ListSinhVien.Add(new SinhVien() { Id = 3, Ten = "Trần Văn Thái" });
            ListSinhVien.Add(new SinhVien() { Id = 4, Ten = "Hoàng Văn Long" });
        }

        public SinhVienViewModel(ObservableCollection<SinhVien> li)
        {
            ListSinhVien = li;
        }
    }
}
