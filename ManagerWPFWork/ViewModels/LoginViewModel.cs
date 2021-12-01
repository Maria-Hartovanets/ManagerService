using BLLServiceManager.IService;
using DTO.Model;
using ManagerWpf.Windows;
using ManagerWPFWork.Command;
using ManagerWPFWork.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ManagerWPFWork.ViewModels
{
    public class LoginViewModel : ViewModelBase, INotifyPropertyChanged
    {

        //private MainViewModel _mainViewModel;
        WindowLoggin _windowLog;
        IServiceManager _serviceManager;
        public IServiceManager ServiceManager { get => _serviceManager; }

        private string _email;
        private string _password;

        public ICommand LogCommand { get; set; }
        public void CloseWindow()
        {
            _windowLog.Close();
        }
       
        public string EnteredEmail
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged("EnteredEmail");
            }
        }
        public string EnteredPassword
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged("EnteredPassword");
            }
        }
        public LoginViewModel(IServiceManager serviceManager, WindowLoggin windowLog)
        {
            //FillInfo();
            _serviceManager = serviceManager;
            LogCommand = new LoginCommand(this);
            _windowLog = windowLog;
        }
        //void FillInfo()
        //{
        //    _email = _windowLog.textBox_Login.Text;
        //    _password = _windowLog.textBox_Pass.Text;
        //}
       

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
       
    }
}
