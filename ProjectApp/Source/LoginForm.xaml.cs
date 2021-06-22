using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace ProjectApp.Source
{
    /// <summary>
    /// Interaction logic for LoginForm.xaml
    /// </summary>

    public partial class LoginForm : Window
    {
        public LoginForm()
        {
            InitializeComponent();
            txtAccount.Focus();
        }

        #region Variable
        private int _checkLogin;
        private int _checkAcc;

        private int checkLogin
        {
            get { return _checkLogin; }
            set { _checkLogin = value; }
        }

        private int checkAcc
        {
            get { return _checkAcc; }
            set { _checkAcc = value; }
        }

        private int _checkOnLogin;
        private int checkOnLogin
        {
            get { return _checkOnLogin; }
            set { _checkOnLogin = value; }
        }
        
        #endregion

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtAccount.Text.Trim() == "" || txtPassword.Password == "")
                {
                    lbLoginStatus.Content = "*Please enter your Account and Password";
                }
                else
                {
                    
                    checkAcc = 0;
                    checkOnLogin = 0;
                    GlobalVariable.username = txtAccount.Text.Trim();
                    GlobalVariable.password = txtPassword.Password;
                    SqlConnection _con = new SqlConnection(GlobalVariable.sqlCon);
                    //Login
                    _con.Open();
                    SqlCommand commandLogin = new SqlCommand("Login", _con);
                    commandLogin.CommandType = CommandType.StoredProcedure;
                    commandLogin.Parameters.Add(new SqlParameter("@username", GlobalVariable.username));
                    commandLogin.Parameters.Add(new SqlParameter("@password", GlobalVariable.password));
                    SqlDataReader checkRead = commandLogin.ExecuteReader();
                    while (checkRead.Read())
                    {
                        checkLogin = Convert.ToInt16(checkRead.GetInt32(1));
                        GlobalVariable.accNO = checkRead.GetInt32(2);
                        if (checkLogin == 1)
                        {
                            checkOnLogin++;
                        }
                        checkAcc++;
                    }
                    _con.Close();

                    if (checkAcc == 1 && checkOnLogin == 0)
                    {
                        //set status OnLogin
                        _con.Open();
                        SqlCommand commandOnLogin = new SqlCommand("OnLogin", _con);
                        commandOnLogin.CommandType = CommandType.StoredProcedure;
                        commandOnLogin.Parameters.Add(new SqlParameter("@username", GlobalVariable.username));
                        commandOnLogin.Parameters.Add(new SqlParameter("@password", GlobalVariable.password));
                        commandOnLogin.ExecuteNonQuery();
                        _con.Close();

                        _con.Open();
                        SqlDataReader loginRead = commandLogin.ExecuteReader();
                        if (loginRead.Read())
                        {
                            string checkPosition = null;
                            checkPosition = loginRead.GetString(0);
                            textClear();
                            GlobalVariable.cusForm.lbTable.Content = "โต๊ะที่ : " + GlobalVariable.username.Substring(3);
                            GlobalVariable.cusForm.showMenu();
                            GlobalVariable.cusForm.showWishlist();
                            GlobalVariable.cusOrdCon.showOrderedList();

                            if (checkPosition == "A")
                            {
                                this.Hide();
                                checkPosition = "Admin";
                                GlobalVariable.admForm.ShowDialog();
                            }
                            else if (checkPosition == "O")
                            {
                                this.Hide();
                                checkPosition = "Owner";
                                GlobalVariable.admForm.ShowDialog();
                            }
                            else if (checkPosition == "E")
                            {
                                this.Hide();
                                checkPosition = "Employee";
                                GlobalVariable.empForm.ShowDialog();
                                //orderedForm.ShowDialog();
                            }
                            else if (checkPosition == "C")
                            {
                                this.Hide();
                                checkPosition = "Customer";
                                GlobalVariable.cusForm.ShowDialog();
                            }
                        }
                        _con.Close();
                    }
                    else if (checkAcc == 1 && checkOnLogin == 1)
                    {
                        lbLoginStatus.Content = "*Your account is already logged in other device!. Please try again!";
                    }
                    else if (checkAcc > 1)
                    {
                        lbLoginStatus.Content = "*Duplicate Username and Password!";
                    }
                    else if (checkAcc == 0)
                    {
                        lbLoginStatus.Content = "*Username or Password incorrect!";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            textClear();
        }

        private void textClear()
        {
            txtAccount.Clear();
            txtPassword.Clear();
            lbLoginStatus.Content = "";
            txtAccount.Focus();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Do you want to close CuisineVision application?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message) ;
            }
        }


        //private void Window_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == Key.F2)
        //    {
        //        MessageBox.Show("F2 Pressed");
        //    }
        //}
    }
}
