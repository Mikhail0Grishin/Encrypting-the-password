using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Encrypting_the_password
{
    public class MainViewModel
    {
        private ICommand loginCommand;
        private ICommand registerCommand;
        MainContext context = new MainContext();
        public ICommand LoginCommand => loginCommand ??= new RelayCommand(parameter =>
        {

        });
        public ICommand RegisterCommand => registerCommand ??= new RelayCommand(parameter =>
        {
            using (SqlConnection connection = new SqlConnection(context.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();

                string login = GetLogin();
                string password = GetPassword();

                if (login != null && password != null)
                {
                    command.CommandText = $" USE Encrypting; INSERT Users(Login, Password) VALUES ('{login}', '{password}')";
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                }
            }
        });
        private string GetLogin() 
        {
            foreach (MainWindow window in App.Current.Windows)
            {
                if (window as MainWindow != null)
                {
                    return (window as MainWindow).TBLogin;
                }      
            }
            return null;
        }
        private string GetPassword()
        {
            foreach (MainWindow window in App.Current.Windows)
            {
                if (window as MainWindow != null)
                {
                    return (window as MainWindow).TBPassword;
                }
            }
            return null;
        }
    }
}
