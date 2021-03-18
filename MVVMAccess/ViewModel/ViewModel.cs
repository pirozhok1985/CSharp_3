using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVMAccess.Model;
using MVVMAccess.ViewModel;

namespace MVVMAccess.ViewModel
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Публичное свойство для привязки Account
        public Model.Account Account { get; set; } = new Model.Account("None", "None");

        public int AttemptCount 
        { 
            get
            {
                return Model.AccessToApp.Attempt;
            } 
        }

        public string Status
        {
            get 
            {
                return Model.AccessToApp.Status;
            }
        }
        #endregion


        private void Execute(object obj)
        {
            //Проверяем есть ли такой аккаунт в базе данных
            if (MVVMAccess.Model.AccessToApp.Checks(Account))
                MVVMAccess.Model.AccessToApp.Status = "Access Granted";
            else
                MVVMAccess.Model.AccessToApp.Status = "Access Denied";
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AttemptCount"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Status"));
        }

        private bool CanExecute(object obj)
        {
            return MVVMAccess.Model.AccessToApp.Attempt < 3;
        }

        public ICommand ClickAccess
        {
            get
            {
                return new DelegateCommand(Execute, CanExecute);
            }
        }


        public ICommand ClickClearLogin
        {
            get
            {
               return new DelegateCommand(PerformClickClearLogin);
            }
        }

        private void PerformClickClearLogin(object commandParameter)
        {
            Account.Password = string.Empty;
            Account.Login = string.Empty;
            AccessToApp.Attempt = 0;
        }
    }
}
