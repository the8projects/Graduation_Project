using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace ProjectApp.Source
{
    /// <summary>
    /// Interaction logic for EmployeeForm.xaml
    /// </summary>
    public partial class EmployeeForm : Window
    {
        public EmployeeForm()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            showCallPayment();
            showOrdered();
            SetTimer();
        }

        int recInfoNO = 0;
        int recNO = 0;

        public void showOrdered()
        {
            SqlConnection _conn = new SqlConnection(GlobalVariable.sqlCon);
            try
            {
                SqlCommand cmdShowOrdered = new SqlCommand("ShowOrdered", _conn);
                cmdShowOrdered.CommandType = CommandType.StoredProcedure;
                _conn.Open();
                cmdShowOrdered.ExecuteNonQuery();

                SqlDataAdapter dataAdp = new SqlDataAdapter(cmdShowOrdered);

                DataTable dt = new DataTable("CuisineVision");
                dataAdp.Fill(dt);
                gridOrdered.ItemsSource = dt.DefaultView;

                dataAdp.Update(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                _conn.Close();
            }
        }

        public void showCallPayment()
        {
            SqlConnection _conn = new SqlConnection(GlobalVariable.sqlCon);
            try
            {
                SqlCommand cmdShowCallPayment = new SqlCommand("ShowCallPayment", _conn);
                cmdShowCallPayment.CommandType = CommandType.StoredProcedure;
                _conn.Open();
                cmdShowCallPayment.ExecuteNonQuery();

                SqlDataAdapter dataAdp = new SqlDataAdapter(cmdShowCallPayment);

                DataTable dt = new DataTable("CuisineVision");
                dataAdp.Fill(dt);
                gridPayment.ItemsSource = dt.DefaultView;

                dataAdp.Update(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                _conn.Close();
            }
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
                else if (result == MessageBoxResult.Yes)
                {
                    SqlConnection _con = new SqlConnection(GlobalVariable.sqlCon);
                    _con.Open();
                    SqlCommand cmdLogout = new SqlCommand("Logout", _con);
                    cmdLogout.CommandType = CommandType.StoredProcedure;
                    cmdLogout.Parameters.Add(new SqlParameter("@username", GlobalVariable.username));
                    cmdLogout.Parameters.Add(new SqlParameter("@password", GlobalVariable.password));
                    cmdLogout.ExecuteNonQuery();
                    _con.Close();
                    this.Hide();
                    GlobalVariable.logForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            showOrdered();
            showCallPayment();
        }

        private void SetTimer()
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            dispatcherTimer.Start();
        }

        private void vbProduct_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.ClickCount == 1)
                {
                    GlobalVariable.cusOrdCon.showOrderedList();
                    GlobalVariable.cusOrdCon.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gridOrdered_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (gridOrdered.SelectedItem == null) { return; }
                DataRowView dr = gridOrdered.SelectedItem as DataRowView;
                DataRow dr1 = dr.Row;

                recInfoNO = Convert.ToInt32(dr1.ItemArray[0]);
                //productAmount = Convert.ToString(dr1.ItemArray[3]);
                //txtSurname.Text = Convert.ToString(dr1.ItemArray[2]);
                //txtAge.Text = Convert.ToString(dr1.ItemArray[3]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gridPayment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (gridPayment.SelectedItem == null) { return; }
                DataRowView dr = gridPayment.SelectedItem as DataRowView;
                DataRow dr1 = dr.Row;

                recNO = Convert.ToInt32(dr1.ItemArray[0]);
                //productAmount = Convert.ToString(dr1.ItemArray[3]);
                //txtSurname.Text = Convert.ToString(dr1.ItemArray[2]);
                //txtAge.Text = Convert.ToString(dr1.ItemArray[3]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnProduct_Click(object sender, MouseButtonEventArgs e)
        {
            SqlConnection _conn = new SqlConnection(GlobalVariable.sqlCon);
            try
            {
                if (MessageBox.Show("ยืนยันการชำระเงิน?", "ยืนยันการชำระเงิน", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    SqlCommand cmdConfirmRecStatus = new SqlCommand("ConfirmRecStatus", _conn);
                    cmdConfirmRecStatus.Parameters.Add(new SqlParameter("@RecNO", recNO));
                    cmdConfirmRecStatus.CommandType = CommandType.StoredProcedure;
                    _conn.Open();
                    cmdConfirmRecStatus.ExecuteNonQuery();
                    showCallPayment();
                }
                else
                {
                    //do no stuff
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                _conn.Close();
            }
        }

        private void btnOrdered_Click(object sender, MouseButtonEventArgs e)
        {
            SqlConnection _conn = new SqlConnection(GlobalVariable.sqlCon);
            try
            {
                if (MessageBox.Show("ยืนยันการทำรายการอาหาร?", "สินค้าพร้อมเสิร์ฟ", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    SqlCommand cmdConfirmRecOrdStatus = new SqlCommand("ConfirmRecOrdStatus", _conn);
                    cmdConfirmRecOrdStatus.Parameters.Add(new SqlParameter("@RecInfoNO", recInfoNO));
                    cmdConfirmRecOrdStatus.CommandType = CommandType.StoredProcedure;
                    _conn.Open();
                    cmdConfirmRecOrdStatus.ExecuteNonQuery();
                    showOrdered();
                }
                else
                {
                    //do no stuff
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                _conn.Close();
            }
        }

        private void btnFake_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection _con = new SqlConnection(GlobalVariable.sqlCon);
            try
            {
                    SqlCommand cmdFake = new SqlCommand("updateFake", _con);
                    cmdFake.CommandType = CommandType.StoredProcedure;
                    _con.Open();
                    cmdFake.ExecuteNonQuery();
                    _con.Close();
                    GlobalVariable.logForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
