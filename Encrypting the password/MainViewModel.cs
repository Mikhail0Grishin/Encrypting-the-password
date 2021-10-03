using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Encrypting_the_password
{
    public class MainViewModel
    {
        private ICommand loginCommand;
        private ICommand registerCommand;
        private bool isLoginFree;
        MainContext context = new MainContext();
        public ICommand LoginCommand => loginCommand ??= new RelayCommand(parameter =>
        {
            string login = GetLogin();
            string password = GetPassword();
            string hashCode;

            HashCodeBase hashBase = new HashCodeBase(login, password);

            hashCode = hashBase.CalculateHashCode();

            using (SqlConnection connection = new SqlConnection(context.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = $"USE Encrypting; SELECT * FROM Users WHERE Users.Login = '{login}'";
                command.Connection = connection;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows == false)
                    {
                        MessageBox.Show("There is not login in the data base");
                    }
                    else
                    {
                        reader.Read();
                        object loginFromDb = reader.GetValue(1);
                        object passwordFromDB = reader.GetValue(2);
                        object salt = reader.GetValue(3);

                        if (login != (string)loginFromDb)
                        {
                            MessageBox.Show("There is not login in the data base");
                        }
                        else if (hashBase.CompareHashCodes((string)passwordFromDB, (string)salt))
                        {
                            MessageBox.Show("You have successfully logged in");
                        }
                        else
                        {
                            MessageBox.Show("Something went wrong");
                        }
                        
                    }
                }
            }

        });
        public ICommand RegisterCommand => registerCommand ??= new RelayCommand(parameter =>
        {
            string login = GetLogin();
            string password = GetPassword();
            string hashCode;

            HashCodeBase hashBase = new HashCodeBase(login, password);  

            using (SqlConnection connection = new SqlConnection(context.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = $"Use Encrypting; SELECT * FROM Users WHERE Users.Login = '{login}'";
                command.Connection = connection;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows == false)
                    {
                        isLoginFree = true;
                    }
                    else
                    {
                        isLoginFree = false;
                        MessageBox.Show("That login is already used");
                    }
                }
            }

            using (SqlConnection connection = new SqlConnection(context.ConnectionString))
            {
                if (isLoginFree == true)
                {
                    hashCode = hashBase.CalculateHashCode();
                    string salt = hashBase.Salt;
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = $"Use Encrypting; INSERT INTO Users(Login, Password, Salt) VALUES ('{login}', '{hashCode}', '{salt}')";
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                    MessageBox.Show("You have successfully registered");
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
