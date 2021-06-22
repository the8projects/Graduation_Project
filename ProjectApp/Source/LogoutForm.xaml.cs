using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace ProjectApp.Source
{
    /// <summary>
    /// Interaction logic for LogoutForm.xaml
    /// </summary>
    public partial class LogoutForm : Window
    {
        public LogoutForm()
        {
            InitializeComponent();
            txtEmpAcc.Focus();
        }

        private int _checkAcc;
        private string _checkPos;

        private int checkAcc
        {
            get { return _checkAcc; }
            set { _checkAcc = value; }
        }

        private string checkPos
        {
            get { return _checkPos; }
            set { _checkPos = value; }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtEmpAcc.Text.Trim() == "" || txtEmpPass.Password == "")
                {
                    lbLogout.Content = "*Please enter your Account and Password";
                }

                else
                {
                    checkAcc = 0;
                    SqlConnection _con = new SqlConnection(GlobalVariable.sqlCon);
                    _con.Open();
                    //Logout
                    SqlCommand cmdLogoutCheck = new SqlCommand("LogoutCheck", _con);
                    cmdLogoutCheck.CommandType = CommandType.StoredProcedure;
                    cmdLogoutCheck.Parameters.Add(new SqlParameter("@empAcc", txtEmpAcc.Text.Trim()));
                    cmdLogoutCheck.Parameters.Add(new SqlParameter("@empPass", txtEmpPass.Password.Trim()));
                    SqlDataReader checkRead = cmdLogoutCheck.ExecuteReader();
                    while (checkRead.Read())
                    {
                        checkPos = checkRead.GetString(0);
                        checkAcc++;
                    }
                    _con.Close();
                    clearForm();

                    if (checkAcc == 1 && (checkPos == "E" || checkPos == "O" || checkPos == "A" ))
                    {
                        //logout
                        _con.Open();
                        SqlCommand cmdLogout = new SqlCommand("Logout", _con);
                        cmdLogout.CommandType = CommandType.StoredProcedure;
                        cmdLogout.Parameters.Add(new SqlParameter("@username", GlobalVariable.username));
                        cmdLogout.Parameters.Add(new SqlParameter("@password", GlobalVariable.password));
                        cmdLogout.ExecuteNonQuery();
                        _con.Close();
                        this.Hide();
                        GlobalVariable.cusForm.Hide();
                        GlobalVariable.logForm.ShowDialog();
                    }
                    else if (checkAcc == 1 && checkPos == "C")
                    {
                        lbLogout.Content = "*Your account don't have permission to logout!";
                    }
                    else if (checkAcc > 1)
                    {
                        lbLogout.Content = "*Your account don't have permission to logout!";
                    }
                    else if (checkAcc == 0)
                    {
                        lbLogout.Content = "*Your account don't have permission to logout!";
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GlobalVariable.outForm.Hide();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }

        public void clearForm()
        {
            try
            {
                txtEmpAcc.Clear();
                txtEmpPass.Clear();
                lbLogout.Content = "";
                txtEmpAcc.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
