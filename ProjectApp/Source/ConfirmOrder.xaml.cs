using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace ProjectApp.Source
{
    /// <summary>
    /// Interaction logic for ConfirmOrder.xaml
    /// </summary>
    public partial class ConfirmOrder : Window
    {
        public ConfirmOrder()
        {
            InitializeComponent();
        }

        private void btnConfirmOrder_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection _conn = new SqlConnection(GlobalVariable.sqlCon);
            try
            {
                SqlCommand cmdConfirmOrder = new SqlCommand("confirmOrder", _conn);
                cmdConfirmOrder.CommandType = CommandType.StoredProcedure;
                cmdConfirmOrder.Parameters.Add(new SqlParameter("@recAcc", GlobalVariable.accNO));
                _conn.Open();
                cmdConfirmOrder.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                GlobalVariable.cusForm.showWishlist();
                GlobalVariable.cusOrdCon.showOrderedList();
                this.Hide();
                _conn.Close();
            }
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
    }
}
