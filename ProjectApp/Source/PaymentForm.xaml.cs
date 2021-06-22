using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Threading;

namespace ProjectApp.Source
{
    /// <summary>
    /// Interaction logic for PaymentForm.xaml
    /// </summary>
    public partial class PaymentForm : Window
    {
        private decimal _totalPrice;

        private decimal totalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = value; }
        }

        public PaymentForm()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetTimer();
        }

        public void showReceiptInfo()
        {
            SqlConnection _conn = new SqlConnection(GlobalVariable.sqlCon);
            try
            {
                totalPrice = 0;
                SqlCommand cmdShowReceiptInfo = new SqlCommand("ShowReceiptInfo", _conn);
                cmdShowReceiptInfo.Parameters.Add(new SqlParameter("@recAcc", GlobalVariable.accNO));
                cmdShowReceiptInfo.CommandType = CommandType.StoredProcedure;
                _conn.Open();
                cmdShowReceiptInfo.ExecuteNonQuery();

                SqlDataAdapter dataAdp = new SqlDataAdapter(cmdShowReceiptInfo);

                DataTable dt = new DataTable("CuisineVision");
                dataAdp.Fill(dt);
                gridReceiptInfo.ItemsSource = dt.DefaultView;

                dataAdp.Update(dt);

                SqlDataReader dr = cmdShowReceiptInfo.ExecuteReader();
                while (dr.Read())
                {
                    decimal price = dr.GetDecimal(2);
                    totalPrice = totalPrice + price;
                }
                lbTotalPrice.Content = "Total Price :" + Convert.ToString(totalPrice) + " Baht";
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

        private void autoClosed()
        {
            SqlConnection _conn = new SqlConnection(GlobalVariable.sqlCon);
            int statusCheck;
            try
            {
                SqlCommand cmdCheckPayStatus = new SqlCommand("CheckPayStatus", _conn);
                cmdCheckPayStatus.Parameters.Add(new SqlParameter("@recAcc", GlobalVariable.accNO));
                cmdCheckPayStatus.Parameters.Add(new SqlParameter("@payStatus", "0"));
                cmdCheckPayStatus.CommandType = CommandType.StoredProcedure;
                _conn.Open();
                SqlDataReader dr = cmdCheckPayStatus.ExecuteReader();
                while (dr.Read())
                {
                    statusCheck = dr.GetInt32(0);
                    if (statusCheck == 1)
                    {
                        this.Hide();
                    }
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

        protected void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            autoClosed();
        }

        private void SetTimer()
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            dispatcherTimer.Start();
        }
    }
}
