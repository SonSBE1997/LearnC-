using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class RelayCommand<T> : ICommand
    {
        private readonly Predicate<T> _canExecute; //lưu trữ điều kiện để thực hiện command - thực hiện hàm ủy thác
        private readonly Action<T> _execute; //lưu trữ hàm ủy thác làm việc gì đó

        //tạo event tương ứng để ủy thác
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        //điều kiện để chạy command
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute((T)parameter);
        }

        //hàm ủy thác khi gọi command
        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }

        //khi khởi tạo truyền điều kiện ủy thác và hàm ủy thác 
        public RelayCommand(Predicate<T> canExecute, Action<T> execute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }
            _canExecute = canExecute;
            _execute = execute;
        }
    }
}
