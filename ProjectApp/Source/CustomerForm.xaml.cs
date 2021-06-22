using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.IO;
using System.Windows.Threading;

namespace ProjectApp.Source
{
    /// <summary>
    /// Interaction logic for CustomerForm.xaml
    /// </summary>
    public partial class CustomerForm : Window
    {
        public CustomerForm()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetTimer();
        }

        #region
        private string _prodNumber;
        private string _prodAmount;
        private string _cancelOrderProdNO;
        private string _orderTime;

        private string productNumber
        {
            get { return _prodNumber; }
            set { _prodNumber = value; }
        }

        public string productAmount
        {
            get { return _prodAmount; }
            set { _prodAmount = value; }
        }

        public string cancelOrderProdNO
        {
            get { return _cancelOrderProdNO; }
            set { _cancelOrderProdNO = value; }
        }

        public  string orderTime
        {
            get { return _orderTime; }
            set { _orderTime = value; }
        }
        #endregion

        private void btnCal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GlobalVariable.calForm.ShowDialog();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            LogOut();
        }

        private void LogOut()
        {
            try
            {
                GlobalVariable.outForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox  .Show(ex.Message);
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F2)
            {
                MessageBox.Show("F2 Pressed");
                LogOut();
            }
        }

        public void showMenu()
        {
            SqlConnection _conn = new SqlConnection(GlobalVariable.sqlCon);
            try
            {
                SqlCommand cmdShowMenu = new SqlCommand("ShowMenu", _conn);
                cmdShowMenu.CommandType = CommandType.StoredProcedure;
                _conn.Open();
                cmdShowMenu.ExecuteNonQuery();

                SqlDataAdapter dataAdp = new SqlDataAdapter(cmdShowMenu);

                DataTable dt = new DataTable("CuisineVision");
                dataAdp.Fill(dt);
                gridMenu.ItemsSource = dt.DefaultView;

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

        public void showWishlist()
        {
            SqlConnection _conn = new SqlConnection(GlobalVariable.sqlCon);
            try
            {
                SqlCommand cmdShowWishList = new SqlCommand("ShowWishList", _conn);
                cmdShowWishList.Parameters.Add(new SqlParameter("@recAcc", GlobalVariable.accNO));
                cmdShowWishList.CommandType = CommandType.StoredProcedure;
                _conn.Open();
                cmdShowWishList.ExecuteNonQuery();

                SqlDataAdapter dataAdp = new SqlDataAdapter(cmdShowWishList);

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

        private void gridMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (gridMenu.SelectedItem == null) { return; }
                DataRowView dr = gridMenu.SelectedItem as DataRowView;
                DataRow dr1 = dr.Row;

                GlobalVariable.orderProdNO = Convert.ToString(dr1.ItemArray[0]);
                //productAmount = Convert.ToString(dr1.ItemArray[3]);
                //txtSurname.Text = Convert.ToString(dr1.ItemArray[2]);
                //txtAge.Text = Convert.ToString(dr1.ItemArray[3]);
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

                cancelOrderProdNO = Convert.ToString(dr1.ItemArray[0]);
                orderTime = Convert.ToString(dr1.ItemArray[5]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            showMenu();
            showWishlist();
        }

        private void SetTimer()
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            dispatcherTimer.Start();
        }

        private void button_MouseEnter2(object sender, MouseEventArgs e)
        {
            glow2.Opacity = 100;
        }

        private void button_MouseLeave2(object sender, MouseEventArgs e)
        {
            glow2.Opacity = 0;
        }

        private void button_MouseEnter3(object sender, MouseEventArgs e)
        {
            glow3.Opacity = 100;
        }

        private void button_MouseLeave3(object sender, MouseEventArgs e)
        {
            glow3.Opacity = 0;
        }

        private void button_MouseEnter4(object sender, MouseEventArgs e)
        {
            glow4.Opacity = 100;
        }

        private void button_MouseLeave4(object sender, MouseEventArgs e)
        {
            glow4.Opacity = 0;
        }

        private void vbCal_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.ClickCount == 1)
                {
                    GlobalVariable.calForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnOrder_Click(object sender, MouseButtonEventArgs e)
        {
            SqlConnection _conn = new SqlConnection(GlobalVariable.sqlCon);
            try
            {
                string ProdName = "";
                string ProdStock = "";
                string ProdPrice = "";
                string ProdType = "";
                SqlCommand cmdSelectedMenu = new SqlCommand("SelectedProduct", _conn);
                cmdSelectedMenu.CommandType = CommandType.StoredProcedure;
                cmdSelectedMenu.Parameters.Add(new SqlParameter("@prodNO", GlobalVariable.orderProdNO));
                SqlCommand getOrdImage = new SqlCommand("getOrdImage", _conn);
                getOrdImage.CommandType = CommandType.StoredProcedure;
                getOrdImage.Parameters.Add(new SqlParameter("@prodNO", GlobalVariable.orderProdNO));
                _conn.Open();
                byte[] imageBuffer = (Byte[])getOrdImage.ExecuteScalar();

                if (imageBuffer != null)
                {
                    Stream StreamObj = new MemoryStream(imageBuffer);
                    BitmapImage BitImg = new BitmapImage();
                    BitImg.BeginInit();
                    BitImg.StreamSource = StreamObj;
                    BitImg.EndInit();
                    GlobalVariable.cofForm.imDrink.Source = BitImg;
                    GlobalVariable.foodForm.imDrink.Source = BitImg;
                }

                SqlDataReader checkProduct = cmdSelectedMenu.ExecuteReader();
                if (checkProduct.Read())
                {
                    ProdName = checkProduct.GetString(0);
                    ProdStock = checkProduct.GetString(1);
                    ProdPrice = checkProduct.GetString(2);
                    ProdType = checkProduct.GetString(3);
                }

                if (ProdType == "D")
                {
                    try
                    {
                        GlobalVariable.cofForm.clearValue();
                        GlobalVariable.cofForm.selectedMenu(GlobalVariable.orderProdNO, ProdName, ProdPrice, ProdStock);
                        GlobalVariable.cofForm.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (ProdType == "B" || ProdType == "F")
                {
                    try
                    {
                        GlobalVariable.cofForm.clearValue();
                        GlobalVariable.foodForm.selectedMenu(GlobalVariable.orderProdNO, ProdName, ProdPrice, ProdStock);
                        GlobalVariable.foodForm.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
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

        private void vbPurchase_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
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

        private void vbOrderConfirm_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.ClickCount == 1)
                {
                    if (gridOrdered.Items.Count > 0)
                    {
                        GlobalVariable.conOrder.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void vbPayment_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.ClickCount == 1)
                {
                    if (GlobalVariable.cusOrdCon.gridOrderConfirm.Items.Count > 0)
                    {
                        if (gridOrdered.Items.Count > 0)
                        {
                            GlobalVariable.conPayment.lbPaymentStatus.Content = "(สินค้าที่อยู่ในรายการที่เลือกจะถูกลบ!)";
                        }
                        else if (gridOrdered.Items.Count == 0)
                        {
                            GlobalVariable.conPayment.lbPaymentStatus.Content = "";
                        }
                        GlobalVariable.conPayment.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                cancelOrder(cancelOrderProdNO,orderTime);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                showMenu();
                showWishlist();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void cancelOrder(string canOrdProdNO, string ordTime)
        {
            try
            {
                if (gridOrdered.Items.Count > 0)
                {
                    if (MessageBox.Show("ต้องการยกเลิกรายการที่เลือก?", "ยกเลิกการสั่งซื้อ", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        SqlConnection _conn = new SqlConnection(GlobalVariable.sqlCon);
                        try
                        {
                            SqlCommand cmdDelOrderList = new SqlCommand("delOrderList", _conn);
                            cmdDelOrderList.CommandType = CommandType.StoredProcedure;
                            cmdDelOrderList.Parameters.Add(new SqlParameter("@recAcc", GlobalVariable.accNO));
                            cmdDelOrderList.Parameters.Add(new SqlParameter("@prodNO", canOrdProdNO));
                            cmdDelOrderList.Parameters.Add(new SqlParameter("@orderTime", ordTime));
                            _conn.Open();
                            cmdDelOrderList.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            _conn.Close();
                            showWishlist();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

            //_conn.Open();
            //SqlCommandBuilder builder = new SqlCommandBuilder(dataAdp);
            //dataAdp.UpdateCommand = builder.GetUpdateCommand();
            //dataAdp.Update(dt);
            //_conn.Close();
    }
}
