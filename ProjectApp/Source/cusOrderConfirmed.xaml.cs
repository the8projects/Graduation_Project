using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Input;

namespace ProjectApp.Source
{
    /// <summary>
    /// Interaction logic for cusOrderConfirmed.xaml
    /// </summary>
    public partial class cusOrderConfirmed : Window
    {
        public cusOrderConfirmed()
        {
            InitializeComponent();
        }

        private void button_MouseEnter(object sender, MouseEventArgs e)
        {
            glow1.Opacity = 100;
        }

        private void button_MouseLeave(object sender, MouseEventArgs e)
        {
            glow1.Opacity = 0;
        }

        private void vbClose_MouseLeftButtonUp(object sender, MouseEventArgs e)
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

        public void showOrderedList()
        {
            SqlConnection _conn = new SqlConnection(GlobalVariable.sqlCon);
            try
            {
                SqlCommand cmdShowOrderedList = new SqlCommand("ShowOrderedList", _conn);
                cmdShowOrderedList.Parameters.Add(new SqlParameter("@recAcc", GlobalVariable.accNO));
                cmdShowOrderedList.CommandType = CommandType.StoredProcedure;
                _conn.Open();
                cmdShowOrderedList.ExecuteNonQuery();

                SqlDataAdapter dataAdp = new SqlDataAdapter(cmdShowOrderedList);

                DataTable dt = new DataTable("CuisineVision");
                dataAdp.Fill(dt);
                gridOrderConfirm.ItemsSource = dt.DefaultView;

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
    }
}
