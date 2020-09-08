using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace ViewModel
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
            ListSinhVien.Add(new SinhVien() { Id = 1, Ten = "ABC" });
            ListSinhVien.Add(new SinhVien() { Id = 2, Ten = "SBE" });
            ListSinhVien.Add(new SinhVien() { Id = 3, Ten = "Nguyễn Văn Hải" });
            ListSinhVien.Add(new SinhVien() { Id = 4, Ten = "Vũ Kim Ngọc" });

            DeleteCommand = new RelayCommand<object>(_ => _ != null, _ => { ListSinhVien.Remove(_ as SinhVien); });

            AddCommand = new RelayCommand<UIElementCollection>(_ => _ != null, _ => {
                int id = -1;
                string ten = "";
                bool isIDInt = false;
                foreach (var item in _)
                {
                    TextBox textBox = item as TextBox;
                    if (textBox == null) continue;
                    switch (textBox.Name)
                    {
                        case "txbId":
                            isIDInt = Int32.TryParse(textBox.Text, out id);
                            break;
                        case "txbTen":
                            ten = textBox.Text;
                            break;
                    }
                }
                if (isIDInt == false || string.IsNullOrEmpty(ten)) return;
                ListSinhVien.Add(new SinhVien() { Id = id, Ten = ten });
            });
        }

        public ICommand DeleteCommand { get; set; }
        public ICommand AddCommand { get; set; }
    }
}
