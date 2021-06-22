using System;
using System.Windows;

namespace ProjectApp.Source
{
    /// <summary>
    /// Interaction logic for OrderedQueueForm.xaml
    /// </summary>
    public partial class OrderedQueueForm : Window
    {
        public OrderedQueueForm()
        {
            InitializeComponent();
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Hide();
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            try
            {
                LoginForm logForm = new LoginForm();
                logForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }   
        }
    }
}
