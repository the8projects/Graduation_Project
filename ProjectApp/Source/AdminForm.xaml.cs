using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace ProjectApp.Source
{
    /// <summary>
    /// Interaction logic for AdminForm.xaml
    /// </summary>
    public partial class AdminForm : Window
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fill_cbProdType();
            fill_cbEmpPosition();
            fill_cbEmpNumber();
            showDelProduct("All", "");
            showEditProduct("All", "");
            showDelEmp("All", "");
            showEditEmp("All", "");
            showDelAcc("All", "");
            showEditAcc("All", "");
        }

        #region Variable
        private string _delProdNumber;
        private string _editProdNumber;
        private string _prodType;
        private string _delEmpNO;
        private string _editEmpNO;
        private string _delAccNO;
        private string _editAccNO;

        private string delProductNumber
        {
            get { return _delProdNumber; }
            set { _delProdNumber = value; }
        }

        private string editProductNumber
        {
            get { return _editProdNumber; }
            set { _editProdNumber = value; }
        }

        private string productType
        {
            get { return _prodType; }
            set { _prodType = value; }
        }

        private string delEmpNO
        {
            get { return _delEmpNO; }
            set { _delEmpNO = value; }
        }

        private string editEmpNO
        {
            get { return _editEmpNO; }
            set { _editEmpNO = value; }
        }

        private string delAccNO
        {
            get { return _delAccNO; }
            set { _delAccNO = value; }
        }

        private string editAccNO
        {
            get { return _editAccNO; }
            set { _editAccNO = value; }
        }
        #endregion

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

        private void fill_cbProdType()
        {
            try
            {
                SqlConnection _con = new SqlConnection(GlobalVariable.sqlCon);
                _con.Open();
                SqlCommand cmdFillCbProdType = new SqlCommand("fill_cbProdType", _con);
                cmdFillCbProdType.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmdFillCbProdType.ExecuteReader();
                while(dr.Read())
                {
                    string type = dr.GetString(0);
                    cbProdAddType.Items.Add(type);
                    cbProdDelTypeSearch.Items.Add(type);
                    cbProdEditTypeSearch.Items.Add(type);
                }
                _con.Close();
            }

            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message);
            }
        }

        private void fill_cbEmpPosition()
        {
            try
            {
                SqlConnection _con = new SqlConnection(GlobalVariable.sqlCon);
                _con.Open();
                SqlCommand cmdFillCbEmpPos = new SqlCommand("fill_cbEmpPosition", _con);
                cmdFillCbEmpPos.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmdFillCbEmpPos.ExecuteReader();
                while (dr.Read())
                {
                    string type = dr.GetString(0);
                    cbEmpAddPos.Items.Add(type);
                    cbEmpDelPosition.Items.Add(type);
                    cbEmpEditPosSearch.Items.Add(type);
                    cbEmpEditPos.Items.Add(type);
                    cbAccDelPosition.Items.Add(type);
                    cbAccEditPosition.Items.Add(type);
                }
                _con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fill_cbEmpNumber()
        {
            try
            {
                SqlConnection _con = new SqlConnection(GlobalVariable.sqlCon);
                _con.Open();
                SqlCommand cmdFillCbEmpNO = new SqlCommand("fill_cbEmpNO", _con);
                cmdFillCbEmpNO.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmdFillCbEmpNO.ExecuteReader();
                while (dr.Read())
                {
                    string type = dr.GetString(0) + " " + dr.GetString(1) + "  " + dr.GetString(2) + "(" + dr.GetString(3) + ")";
                    cbAccAddEmpNo.Items.Add(type);
                }
                _con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void showDelProduct(string ProdType, string Keyword)
        {
            try
            {
                SqlConnection _conn = new SqlConnection(GlobalVariable.sqlCon);
                _conn.Open();
                SqlCommand cmdShowProduct = new SqlCommand("ShowProduct", _conn);
                cmdShowProduct.Parameters.Add(new SqlParameter("@type", ProdType));
                cmdShowProduct.Parameters.Add(new SqlParameter("@keyword", Keyword));
                cmdShowProduct.CommandType = CommandType.StoredProcedure;
                cmdShowProduct.ExecuteNonQuery();

                SqlDataAdapter dataAdp = new SqlDataAdapter(cmdShowProduct);

                DataTable dt = new DataTable("CuisineVision");
                dataAdp.Fill(dt);
                gridProdDel.ItemsSource = dt.DefaultView;

                dataAdp.Update(dt);
                _conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void showEditProduct(string ProdType, string Keyword)
        {
            try
            {
                SqlConnection _conn = new SqlConnection(GlobalVariable.sqlCon);
                _conn.Open();
                SqlCommand cmdShowProduct = new SqlCommand("ShowProduct", _conn);
                cmdShowProduct.Parameters.Add(new SqlParameter("@type", ProdType));
                cmdShowProduct.Parameters.Add(new SqlParameter("@keyword", Keyword));
                cmdShowProduct.CommandType = CommandType.StoredProcedure;
                cmdShowProduct.ExecuteNonQuery();

                SqlDataAdapter dataAdp = new SqlDataAdapter(cmdShowProduct);

                DataTable dt = new DataTable("CuisineVision");
                dataAdp.Fill(dt);
                gridProdEdit.ItemsSource = dt.DefaultView;

                dataAdp.Update(dt);
                _conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void showDelEmp(string EmpPos, string Keyword)
        {
            try
            {
                SqlConnection _conn = new SqlConnection(GlobalVariable.sqlCon);
                _conn.Open();
                SqlCommand cmdShowEmployee = new SqlCommand("ShowEmployee", _conn);
                cmdShowEmployee.Parameters.Add(new SqlParameter("@type", EmpPos));
                cmdShowEmployee.Parameters.Add(new SqlParameter("@keyword", Keyword));
                cmdShowEmployee.CommandType = CommandType.StoredProcedure;
                cmdShowEmployee.ExecuteNonQuery();

                SqlDataAdapter dataAdp = new SqlDataAdapter(cmdShowEmployee);

                DataTable dt = new DataTable("CuisineVision");
                dataAdp.Fill(dt);
                gridEmpDel.ItemsSource = dt.DefaultView;

                dataAdp.Update(dt);
                _conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void showEditEmp(string EmpPos, string Keyword)
        {
            try
            {
                SqlConnection _conn = new SqlConnection(GlobalVariable.sqlCon);
                _conn.Open();
                SqlCommand cmdShowEmp = new SqlCommand("ShowEmployee", _conn);
                cmdShowEmp.Parameters.Add(new SqlParameter("@type", EmpPos));
                cmdShowEmp.Parameters.Add(new SqlParameter("@keyword", Keyword));
                cmdShowEmp.CommandType = CommandType.StoredProcedure;
                cmdShowEmp.ExecuteNonQuery();

                SqlDataAdapter dataAdp = new SqlDataAdapter(cmdShowEmp);

                DataTable dt = new DataTable("CuisineVision");
                dataAdp.Fill(dt);
                gridEmpEdit.ItemsSource = dt.DefaultView;

                dataAdp.Update(dt);
                _conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void showDelAcc(string Username, string Keyword)
        {
            try
            {
                SqlConnection _conn = new SqlConnection(GlobalVariable.sqlCon);
                _conn.Open();
                SqlCommand cmdShowAccount = new SqlCommand("ShowAccount", _conn);
                cmdShowAccount.Parameters.Add(new SqlParameter("@type", Username));
                cmdShowAccount.Parameters.Add(new SqlParameter("@keyword", Keyword));
                cmdShowAccount.CommandType = CommandType.StoredProcedure;
                cmdShowAccount.ExecuteNonQuery();

                SqlDataAdapter dataAdp = new SqlDataAdapter(cmdShowAccount);

                DataTable dt = new DataTable("CuisineVision");
                dataAdp.Fill(dt);
                gridAccDel.ItemsSource = dt.DefaultView;

                dataAdp.Update(dt);
                _conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void showEditAcc(string Username, string Keyword)
        {
            try
            {
                SqlConnection _conn = new SqlConnection(GlobalVariable.sqlCon);
                _conn.Open();
                SqlCommand cmdShowAccount = new SqlCommand("ShowAccount", _conn);
                cmdShowAccount.Parameters.Add(new SqlParameter("@type", Username));
                cmdShowAccount.Parameters.Add(new SqlParameter("@keyword", Keyword));
                cmdShowAccount.CommandType = CommandType.StoredProcedure;
                cmdShowAccount.ExecuteNonQuery();

                SqlDataAdapter dataAdp = new SqlDataAdapter(cmdShowAccount);

                DataTable dt = new DataTable("CuisineVision");
                dataAdp.Fill(dt);
                gridAccEdit.ItemsSource = dt.DefaultView;

                dataAdp.Update(dt);
                _conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gridProdDel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (gridProdDel.SelectedItem == null) { return; }
                DataRowView dr = gridProdDel.SelectedItem as DataRowView;
                DataRow dr1 = dr.Row;

                delProductNumber = Convert.ToString(dr1.ItemArray[0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gridProdEdit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (gridProdEdit.SelectedItem == null) { return; }
                DataRowView dr = gridProdEdit.SelectedItem as DataRowView;
                DataRow dr1 = dr.Row;

                editProductNumber = Convert.ToString(dr1.ItemArray[0]);
                txtProdEditName.Text = Convert.ToString(dr1.ItemArray[1]);
                txtProdEditType.Text = Convert.ToString(dr1.ItemArray[2]);
                txtProdEditPrice.Text = Convert.ToString(dr1.ItemArray[3]);
                txtProdEditAmount.Text = Convert.ToString(dr1.ItemArray[4]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gridEmpDel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (gridEmpDel.SelectedItem == null) { return; }
                DataRowView dr = gridEmpDel.SelectedItem as DataRowView;
                DataRow dr1 = dr.Row;

                delEmpNO = Convert.ToString(dr1.ItemArray[0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gridEmpEdit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (gridEmpEdit.SelectedItem == null) { return; }
                DataRowView dr = gridEmpEdit.SelectedItem as DataRowView;
                DataRow dr1 = dr.Row;

                editEmpNO = Convert.ToString(dr1.ItemArray[0]);
                cbEmpEditPos.Text = Convert.ToString(dr1.ItemArray[9]);
                txtEmpEditName.Text = Convert.ToString(dr1.ItemArray[1]);
                txtEmpEditLastName.Text = Convert.ToString(dr1.ItemArray[2]);
                txtEmpEditTel.Text = Convert.ToString(dr1.ItemArray[8]);
                txtEmpEditEmail.Text = Convert.ToString(dr1.ItemArray[7]);
                txtEmpEditAddrNO.Text = Convert.ToString(dr1.ItemArray[3]);
                txtEmpEditAddrTumbol.Text = Convert.ToString(dr1.ItemArray[4]);
                txtEmpEditAddrAmphoe.Text = Convert.ToString(dr1.ItemArray[5]);
                txtEmpEditAddrProvince.Text = Convert.ToString(dr1.ItemArray[6]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gridAccDel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (gridAccDel.SelectedItem == null) { return; }
                DataRowView dr = gridAccDel.SelectedItem as DataRowView;
                DataRow dr1 = dr.Row;

                delAccNO = Convert.ToString(dr1.ItemArray[0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gridAccEdit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (gridAccEdit.SelectedItem == null) { return; }
                DataRowView dr = gridAccEdit.SelectedItem as DataRowView;
                DataRow dr1 = dr.Row;

                editAccNO = Convert.ToString(dr1.ItemArray[0]);
                txtAccEditPos.Text = Convert.ToString(dr1.ItemArray[3]);
                txtAccountEdit.Text = Convert.ToString(dr1.ItemArray[1]);
                txtAccEditPassword.Password = Convert.ToString(dr1.ItemArray[2]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnProdAdd_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection _conn = new SqlConnection(GlobalVariable.sqlCon);
            try
            {
                var imageBuffer = BitmapSourceToByteArray((BitmapSource)imPicture.Source);
                SqlCommand cmdProdAdd = new SqlCommand("ProdAdd", _conn);
                cmdProdAdd.Parameters.Add(new SqlParameter("@ProdName", txtProdAddName.Text.Trim()));
                cmdProdAdd.Parameters.Add(new SqlParameter("@ProdPrice", txtProdAddPrice.Text.Trim()));
                cmdProdAdd.Parameters.Add(new SqlParameter("@ProdAmount", txtProdAddAmount.Text.Trim()));
                cmdProdAdd.Parameters.Add(new SqlParameter("@ProdImage", imageBuffer));
                cmdProdAdd.Parameters.Add(new SqlParameter("@ProdType", productType));
                cmdProdAdd.CommandType = CommandType.StoredProcedure;
                _conn.Open();
                cmdProdAdd.ExecuteNonQuery();
                lbAddStatus.Content = txtProdAddName.Text.Trim() + " has been added";
                showDelProduct(cbProdDelTypeSearch.Text, txtProdDelSearch.Text.Trim());
                showEditProduct(cbProdEditTypeSearch.Text, txtProdEditSearch.Text.Trim());
                prodAddClear();
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

        private void btnAccAdd_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection _conn = new SqlConnection(GlobalVariable.sqlCon);
            try
            {
                if (txtAccPassword.Password != "" || txtAccRePassword.Password !="")
                {
                    string accPos;
                    if (cbAccAddEmpNo.Text.Trim().Substring(0, 1) == "C")
                    {
                        accPos = "C";
                    }
                    else
                    {
                        accPos = cbAccAddEmpNo.Text.Trim().Substring(0, 13);
                    }
                    SqlCommand cmdAccAdd = new SqlCommand("AccAdd", _conn);
                    cmdAccAdd.Parameters.Add(new SqlParameter("@Username", txtAccount.Text.Trim()));
                    cmdAccAdd.Parameters.Add(new SqlParameter("@Password", txtAccPassword.Password));
                    cmdAccAdd.Parameters.Add(new SqlParameter("@Ref", accPos));
                    cmdAccAdd.CommandType = CommandType.StoredProcedure;
                    _conn.Open();
                    cmdAccAdd.ExecuteNonQuery();
                    //lbAddStatus.Content = txtProdAddName.Text.Trim() + " has been added";
                    showEditEmp(cbEmpEditPosSearch.Text, txtEmpEditSearch.Text.Trim());
                    showDelAcc(cbAccDelPosition.Text, txtAccDelSearch.Text.Trim());
                }
                prodAddClear();
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

        private void btnProdDelSearch_Click(object sender, RoutedEventArgs e)
        {
            showDelProduct(cbProdDelTypeSearch.Text, txtProdDelSearch.Text.Trim());
        }

        private void btnProdEditSearch_Click(object sender, RoutedEventArgs e)
        {
            showEditProduct(cbProdEditTypeSearch.Text, txtProdEditSearch.Text.Trim());
        }

        private void btnEmpEditSearch_Click(object sender, RoutedEventArgs e)
        {
            showEditEmp(cbEmpEditPosSearch.Text, txtEmpEditSearch.Text);
        }

        private void btnEmpEditUpdate_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection _conn = new SqlConnection(GlobalVariable.sqlCon);
            try
            {
                if (MessageBox.Show("Update Data? " + "?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    SqlCommand cmdEmpUpdate = new SqlCommand("EmpUpdate", _conn);
                    cmdEmpUpdate.Parameters.Add(new SqlParameter("@EmpNO", editEmpNO));
                    cmdEmpUpdate.Parameters.Add(new SqlParameter("@AddrNO", txtEmpEditAddrNO.Text.Trim()));
                    cmdEmpUpdate.Parameters.Add(new SqlParameter("@AddrTumbol", txtEmpEditAddrTumbol.Text.Trim()));
                    cmdEmpUpdate.Parameters.Add(new SqlParameter("@AddrAmphoe", txtEmpEditAddrAmphoe.Text.Trim()));
                    cmdEmpUpdate.Parameters.Add(new SqlParameter("@AddrProvince", txtEmpEditAddrProvince.Text.Trim()));
                    cmdEmpUpdate.Parameters.Add(new SqlParameter("@Email", txtEmpEditEmail.Text.Trim()));
                    cmdEmpUpdate.Parameters.Add(new SqlParameter("@Tel", txtEmpEditTel.Text.Trim()));
                    cmdEmpUpdate.Parameters.Add(new SqlParameter("@Position", cbEmpEditPos.Text.Substring(0,1)));
                    cmdEmpUpdate.CommandType = CommandType.StoredProcedure;
                    _conn.Open();
                    cmdEmpUpdate.ExecuteNonQuery();
                    showEditEmp(cbEmpEditPosSearch.Text, txtEmpEditSearch.Text.Trim());
                    showDelEmp(cbEmpDelPosition.Text, txtEmpDelSearch.Text.Trim());
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

        private void btnProdAddClear_Click(object sender, RoutedEventArgs e)
        {
            prodAddClear();
        }

        private void btnProdDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("ยืนยันการลบข้อมูล?", "ลบข้อมูล", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    SqlConnection _conn = new SqlConnection(GlobalVariable.sqlCon);
                    _conn.Open();
                    SqlCommand cmdProdDelete = new SqlCommand("ProdDelete", _conn);
                    cmdProdDelete.Parameters.Add(new SqlParameter("@ProdNO", delProductNumber));
                    cmdProdDelete.CommandType = CommandType.StoredProcedure;
                    cmdProdDelete.ExecuteNonQuery();
                    _conn.Close();
                    showDelProduct(cbProdDelTypeSearch.Text, txtProdDelSearch.Text.Trim());
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
        }

        private void btnAccDelSearch_Click(object sender, RoutedEventArgs e)
        {
            showDelAcc(cbAccDelPosition.Text.Trim(), txtAccDelSearch.Text.Trim());
        }

        private void btnAccDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("ยืนยันการลบข้อมูล?", "ลบข้อมูล", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    SqlConnection _conn = new SqlConnection(GlobalVariable.sqlCon);
                    _conn.Open();
                    SqlCommand cmdAccDelete = new SqlCommand("AccDelete", _conn);
                    cmdAccDelete.Parameters.Add(new SqlParameter("@AccNO", delAccNO));
                    cmdAccDelete.CommandType = CommandType.StoredProcedure;
                    cmdAccDelete.ExecuteNonQuery();
                    _conn.Close();
                    showDelAcc(cbAccDelPosition.Text, txtAccDelSearch.Text.Trim());
                    showEditEmp(cbEmpEditPosSearch.Text, txtEmpEditSearch.Text.Trim());
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
        }

        private void prodAddClear()
        {
            try
            {
                txtProdAddName.Clear();
                txtProdAddPrice.Clear();
                txtProdAddAmount.Clear();
                imPicture.Source = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbProdAddType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string prodTypeValue = Convert.ToString(cbProdAddType.SelectedItem);
                productType = prodTypeValue.Substring(0, 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnProdEditUpdate_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection _conn = new SqlConnection(GlobalVariable.sqlCon);
            try
            {
                if (MessageBox.Show("Update Data? " + "?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    SqlCommand cmdProdUpdate = new SqlCommand("ProdUpdate", _conn);
                    cmdProdUpdate.Parameters.Add(new SqlParameter("@ProdNO", editProductNumber));
                    cmdProdUpdate.Parameters.Add(new SqlParameter("@ProdName", txtProdEditName.Text.Trim()));
                    cmdProdUpdate.Parameters.Add(new SqlParameter("@ProdPrice", txtProdEditPrice.Text.Trim()));
                    cmdProdUpdate.Parameters.Add(new SqlParameter("@ProdAmount", txtProdEditAmount.Text.Trim()));
                    cmdProdUpdate.CommandType = CommandType.StoredProcedure;
                    _conn.Open();
                    cmdProdUpdate.ExecuteNonQuery();
                    showEditProduct(cbProdEditTypeSearch.Text, txtProdEditSearch.Text.Trim());
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

        private void btnUpload_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FileDialog openFile = new OpenFileDialog();
                openFile.Title = "Select a picture";
                openFile.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                openFile.Filter = "Image File|*.jpg;*.jpeg;*.png|" +
                                    "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                                    "Portable Network Graphic (*.png)|*.png";
                if (openFile.ShowDialog() == true)
                {
                    imPicture.Source = new BitmapImage(new Uri(openFile.FileName));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private byte[] BitmapSourceToByteArray(BitmapSource image)
        {
            using (var stream = new MemoryStream())
            {
                var encoder = new PngBitmapEncoder(); // or some other encoder
                encoder.Frames.Add(BitmapFrame.Create(image));
                encoder.Save(stream);
                return stream.ToArray();
            }
        }

        private void btnEmpDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("ยืนยันการลบข้อมูล?", "ลบข้อมูล", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    SqlConnection _conn = new SqlConnection(GlobalVariable.sqlCon);
                    _conn.Open();
                    SqlCommand cmdEmpDelete = new SqlCommand("EmpDelete", _conn);
                    cmdEmpDelete.Parameters.Add(new SqlParameter("@EmpNO", delEmpNO));
                    cmdEmpDelete.CommandType = CommandType.StoredProcedure;
                    cmdEmpDelete.ExecuteNonQuery();
                    _conn.Close();
                    showDelEmp(cbEmpDelPosition.Text, txtEmpDelSearch.Text.Trim());
                    showEditEmp(cbEmpEditPosSearch.Text, txtEmpEditSearch.Text.Trim());
                }
                else
                {
                    //do yes stuff
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEmpDelSearch_Click(object sender, RoutedEventArgs e)
        {
            showDelEmp(cbEmpDelPosition.Text.Trim(), txtEmpDelSearch.Text.Trim());
        }

        private void btnAccEditSearch_Click(object sender, RoutedEventArgs e)
        {
            showEditAcc(cbAccEditPosition.Text.Trim(), txtAccEditSearch.Text.Trim());
        }

        private void btnAccEditUpdate_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection _conn = new SqlConnection(GlobalVariable.sqlCon);
            try
            {
                if (MessageBox.Show("Update Data? " + "?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    SqlCommand cmdAccUpdate = new SqlCommand("AccUpdate", _conn);
                    cmdAccUpdate.Parameters.Add(new SqlParameter("@AccNO", editEmpNO));
                    cmdAccUpdate.Parameters.Add(new SqlParameter("@Password", txtEmpEditAddrNO.Text.Trim()));
                    cmdAccUpdate.CommandType = CommandType.StoredProcedure;
                    _conn.Open();
                    cmdAccUpdate.ExecuteNonQuery();
                    showEditEmp(cbEmpEditPosSearch.Text, txtEmpEditSearch.Text.Trim());
                    showDelAcc(cbAccDelPosition.Text, txtAccDelSearch.Text.Trim());
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

        private void btnEmpAdd_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection _conn = new SqlConnection(GlobalVariable.sqlCon);
            try
            {
                    SqlCommand cmdEmpAdd = new SqlCommand("EmpAdd", _conn);
                    cmdEmpAdd.Parameters.Add(new SqlParameter("@EmpNO", txtEmpAddID.Text.Trim()));
                    cmdEmpAdd.Parameters.Add(new SqlParameter("@Name", txtEmpAddName.Text.Trim()));
                    cmdEmpAdd.Parameters.Add(new SqlParameter("@Lastname", txtEmpAddLastName.Text.Trim()));
                    cmdEmpAdd.Parameters.Add(new SqlParameter("@AddrNO", txtEmpAddAddrNO.Text.Trim()));
                    cmdEmpAdd.Parameters.Add(new SqlParameter("@AddrTumbol", txtEmpAddAddrTumbol.Text.Trim()));
                    cmdEmpAdd.Parameters.Add(new SqlParameter("@AddrAmphoe", txtEmpAddAddrAmphoe.Text.Trim()));
                    cmdEmpAdd.Parameters.Add(new SqlParameter("@AddrProvince", txtEmpAddAddrProvince.Text.Trim()));
                    cmdEmpAdd.Parameters.Add(new SqlParameter("@Email", txtEmpAddEmail.Text.Trim()));
                    cmdEmpAdd.Parameters.Add(new SqlParameter("@Tel", txtEmpAddTel.Text.Trim()));
                    cmdEmpAdd.Parameters.Add(new SqlParameter("@Pos", cbEmpAddPos.Text.Trim().Substring(0,1)));
                    //cmdEmpAdd.Parameters.Add(new SqlParameter("@Ref", accPos));
                    cmdEmpAdd.CommandType = CommandType.StoredProcedure;
                    _conn.Open();
                    cmdEmpAdd.ExecuteNonQuery();
                    //lbAddStatus.Content = txtProdAddName.Text.Trim() + " has been added";
                    showEditEmp(cbEmpEditPosSearch.Text, txtEmpEditSearch.Text.Trim());
                    showDelEmp(cbEmpDelPosition.Text, txtEmpDelSearch.Text.Trim());
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
