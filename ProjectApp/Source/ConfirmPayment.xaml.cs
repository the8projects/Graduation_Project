using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace ProjectApp.Source
{
    /// <summary>
    /// Interaction logic for ConfirmPayment.xaml
    /// </summary>
    public partial class ConfirmPayment : Window
    {
        public ConfirmPayment()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnConfirmPayment_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection _conn = new SqlConnection(GlobalVariable.sqlCon);
            try
            {
                int length = GlobalVariable.cusForm.gridOrdered.Items.Count;
                if (length > 0)
                {
                    SqlCommand cmdDelAllOrderList = new SqlCommand("delAllOrderList", _conn);
                    cmdDelAllOrderList.CommandType = CommandType.StoredProcedure;
                    cmdDelAllOrderList.Parameters.Add(new SqlParameter("@recAcc", GlobalVariable.accNO));
                    _conn.Open();
                    cmdDelAllOrderList.ExecuteNonQuery();
                    _conn.Close();
                }
                SqlCommand cmdConPayment = new SqlCommand("confirmPayment", _conn);
                cmdConPayment.CommandType = CommandType.StoredProcedure;
                cmdConPayment.Parameters.Add(new SqlParameter("@recAcc", GlobalVariable.accNO));
                _conn.Open();
                cmdConPayment.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                GlobalVariable.cusForm.showWishlist();
                this.Hide();
                GlobalVariable.payForm.showReceiptInfo();
                GlobalVariable.payForm.ShowDialog();
                _conn.Close();
            }
        }
    }
}
