using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Threading;

namespace ProjectApp.Source
{
    /// <summary>
    /// Interaction logic for OrderFoodForm.xaml
    /// </summary>
    public partial class OrderFoodForm : Window
    {
        public OrderFoodForm()
        {
            InitializeComponent();
        }

        private int _lowAmount;
        private int _medAmount;
        private int _sweAmount;
        private decimal _totalPrice;
        private int _totalAmount;
        private int _prodAmount;

        private int lowAmount
        {
            get { return _lowAmount; }
            set { _lowAmount = value; }
        }

        private int medAmount
        {
            get { return _medAmount; }
            set { _medAmount = value; }
        }

        private int sweAmount
        {
            get { return _sweAmount; }
            set { _sweAmount = value; }
        }

        private decimal totalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = value; }
        }

        private int totalAmount
        {
            get { return _totalAmount; }
            set { _totalAmount = value; }
        }

        public int prodAmount
        {
            get { return _prodAmount; }
            set { _prodAmount = value; }
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lowAmount = 0;
            medAmount = 0;
            sweAmount = 0;
            lbTotalAmount.Content = "0";
            lbTotalPrice.Content = "0";
            txtLowAmount.Text = Convert.ToString(lowAmount);
            checkAmount();
            SetTimer();
        }

        public void selectedMenu(string ProductNO, string ProductName, string ProdPrice, string ProdStock)
        {
            try
            {
                lbProdName.Content = ProductName;
                lbProdStock.Content = ProdStock;
                lbProdPrice.Content = ProdPrice;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void calTotal(int Amount)
        {
            totalPrice = Amount * Convert.ToDecimal(lbTotalPrice.Content);
            lbTotalPrice.Content = Convert.ToString(totalPrice);
        }

        private void btnLowDec_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lowAmount <= 0)
                {
                    txtLowAmount.Text = Convert.ToString(lowAmount);
                }
                else
                {
                    lowAmount--;
                    txtLowAmount.Text = Convert.ToString(lowAmount);
                    lbTotalAmount.Content = Convert.ToString(Convert.ToInt16(lbTotalAmount.Content) - 1);
                    lbTotalPrice.Content = Convert.ToString(Convert.ToInt16(lbTotalAmount.Content) * Convert.ToDecimal(lbProdPrice.Content));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                limitAmount();
            }
        }

        private void btnLowInc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lowAmount >= prodAmount)
                {
                    txtLowAmount.Text = Convert.ToString(lowAmount);
                }
                else
                {
                    lowAmount++;
                    txtLowAmount.Text = Convert.ToString(lowAmount);
                    lbTotalAmount.Content = Convert.ToString(Convert.ToInt16(lbTotalAmount.Content) + 1);
                    lbTotalPrice.Content = Convert.ToString(Convert.ToInt16(lbTotalAmount.Content) * Convert.ToDecimal(lbProdPrice.Content));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                limitAmount();
            }
        }

        private void btnConfirmOrder_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection _conn = new SqlConnection(GlobalVariable.sqlCon);
            try
            {
                SqlCommand cmdAddOrdList = new SqlCommand("addOrderList", _conn);
                cmdAddOrdList.CommandType = CommandType.StoredProcedure;
                cmdAddOrdList.Parameters.Add(new SqlParameter("@recAcc", GlobalVariable.accNO));
                cmdAddOrdList.Parameters.Add(new SqlParameter("@recProdNO", GlobalVariable.orderProdNO));
                cmdAddOrdList.Parameters.Add(new SqlParameter("@recAmount", Convert.ToInt32(lbTotalAmount.Content)));
                cmdAddOrdList.Parameters.Add(new SqlParameter("@recOrdDetail", ""));
                _conn.Open();
                cmdAddOrdList.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Hide();
                _conn.Close();
                GlobalVariable.cusForm.showWishlist();
            }
        }

        private void checkAmount()
        {
            SqlConnection _conn = new SqlConnection(GlobalVariable.sqlCon);
            try
            {
                SqlCommand cmdCheckAmount = new SqlCommand("checkProdAmount", _conn);
                cmdCheckAmount.CommandType = CommandType.StoredProcedure;
                cmdCheckAmount.Parameters.Add(new SqlParameter("@prodNO", GlobalVariable.orderProdNO));
                _conn.Open();
                SqlDataReader checkAmount = cmdCheckAmount.ExecuteReader();
                if (checkAmount.Read())
                {
                    prodAmount = checkAmount.GetInt32(0);
                    lbProdStock.Content = checkAmount.GetInt32(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                limitAmount();
            }
        }

        protected void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            checkAmount();
        }

        private void SetTimer()
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            dispatcherTimer.Start();
        }

        private void limitAmount()
        {
            try
            {
                int orderAmount = Convert.ToInt32(lbTotalAmount.Content);
                if (orderAmount == prodAmount)
                {
                    btnLowInc.IsEnabled = false;
                    lbAlert.Content = "";
                    btnConfirmOrder.IsEnabled = true;
                }
                else if (orderAmount > prodAmount)
                {
                    btnLowInc.IsEnabled = false;
                    lbAlert.Content = "ไม่สามารถสั่งซื้ออาหารเกินจำนวนที่มีอยู่!!";
                    btnConfirmOrder.IsEnabled = false;
                }
                else
                {
                    btnLowInc.IsEnabled = true;
                    lbAlert.Content = "";
                    if (orderAmount == 0)
                    {
                        btnConfirmOrder.IsEnabled = false;
                    }
                    else
                    {
                        btnConfirmOrder.IsEnabled = true;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public void clearValue()
        {
            try
            {
                lowAmount = 0;
                medAmount = 0;
                sweAmount = 0;
                txtLowAmount.Text = "0";
                lbTotalAmount.Content = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
