using System;
using System.Windows;

namespace ProjectApp.Source
{
    /// <summary>
    /// Interaction logic for CalculatorForm.xaml
    /// </summary>
    public partial class CalculatorForm : Window
    {
                int i = 0;
        int flag;
        int flag2 = 0;
        int ckZero = 0;
        int ckDot = 0;
        double total = 0;
        double num;
        String[] preText = new string[12];
        String answer;

        public CalculatorForm()
        {
            InitializeComponent();
        }
        
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtResult.Text == "")
                {
                    num = 0;
                }
                else
                {
                    num = Convert.ToDouble(txtResult.Text.Trim());
                }
                if (flag == 1)
                {
                    Plus();
                }
                else if (flag == 2)
                {
                    Minus();
                }
                else if (flag == 3)
                {
                    Multi();
                }
                else if (flag == 4)
                {
                    Divide();
                }
                answer = Convert.ToString(total);
                txtTotal.Text = answer;
                i = 0;
            }
            catch
            {
                MessageBox.Show("Can't calculate!");
            }
            ClearValue();
        }

        private void Plus()
        {
            //int num1 = Convert.ToInt32(txtNum1.Text.Trim());
            total = total + num;
            flag2 = 1;
        }

        private void Minus()
        {
            if (flag2 == 0)
            {
                total = num;
                flag2 = 1;
            }
            else
            {
                total = total - num;
            }
        }

        private void Multi()
        {
            if (flag2 == 0)
            {
                total = num;
                flag2 = 1;
            }
            else
            {
                total = total * num;
            }
        }

        private void Divide()
        {
            if (flag2 == 0)
            {
                total = num;
                flag2 = 1;
            }
            else
            {
                total = total / num;
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            try
            {
                num = Convert.ToDouble(txtResult.Text.Trim());
                txtValue.Text = txtValue.Text.Trim() + txtResult.Text.Trim() + "+";
                if (flag == 2)
                {
                    Minus();
                }
                else if(flag == 3)
                {
                    Multi();
                }
                else if (flag == 4)
                {
                    Divide();
                }
                else
                {
                    Plus();
                }
                txtResult.Clear();
                answer = Convert.ToString(total);
                txtTotal.Text = answer;
                flag = 1;
                i = 0;
            }
            catch
            {
                MessageBox.Show("Can't calculate!");
            }
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            try
            {
                num = Convert.ToDouble(txtResult.Text.Trim());
                txtValue.Text = txtValue.Text.Trim() + txtResult.Text.Trim() + "-";
                if (flag == 1)
                {
                    Plus();
                }
                else if(flag == 3)
                {
                    Multi();
                }
                else if (flag == 4)
                {
                    Divide();
                }
                else
                {
                    Minus();
                }
                txtResult.Clear();
                answer = Convert.ToString(total);
                txtTotal.Text = answer;
                flag = 2;
                i = 0;
            }
            catch
            {
                MessageBox.Show("Can't calculate!");
            }
        }

        private void btnMulti_Click(object sender, EventArgs e)
        {
            try
            {
                num = Convert.ToDouble(txtResult.Text.Trim());
                txtValue.Text = txtValue.Text.Trim() + txtResult.Text.Trim() + "x";
                if (flag == 1)
                {
                    Plus();
                }
                else if(flag == 2)
                {
                    Minus();
                }
                else if (flag == 4)
                {
                    Divide();
                }
                else
                {
                    Multi();
                }
                txtResult.Clear();
                answer = Convert.ToString(total);
                txtTotal.Text = answer;
                flag = 3;
                i = 0;
            }
            catch
            {
                MessageBox.Show("Can't calculate!");
            }
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            try
            {
                num = Convert.ToDouble(txtResult.Text.Trim());
                txtValue.Text = txtValue.Text.Trim() + txtResult.Text.Trim() + "/";
                if (flag == 1)
                {
                    Plus();
                }
                else if (flag == 2)
                {
                    Minus();
                }
                else if (flag == 3)
                {
                    Multi();
                }
                else
                {
                    Divide();
                }
                txtResult.Clear();
                answer = Convert.ToString(total);
                txtTotal.Text = answer;
                flag = 4;
                i = 0;
            }
            catch
            {
                MessageBox.Show("Can't calculate!");
            }
        }

        private void ClearValue()
        {
            i = 0;
            total = 0;
            num = 0;
            txtValue.Clear();
            txtResult.Clear();
            flag = 0;
            flag2 = 0;
            ckZero = 0;
            ckDot = 0;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearValue();
            txtTotal.Clear();
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            try
            {
                if (ckZero == 0)
                {
                    txtResult.Text = "0";
                    preText[i] = txtResult.Text;
                    i++;
                }
                else
                {
                    preText[i] = txtResult.Text.Trim();
                    txtResult.Text = txtResult.Text.Trim() + "0";
                    i++;
                }
            }
            catch
            {
                MessageBox.Show("");
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            check_button("1");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            check_button("2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            check_button("3");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            check_button("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            check_button("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            check_button("6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            check_button("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            check_button("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            check_button("9");
        }

        private void check_button(string num)
        {
            try
            {
                if (ckZero == 0)
                {
                    preText[i] = txtResult.Text.Trim();
                    txtResult.Text = num;
                    ckZero = 1;
                    i++;
                }
                else
                {
                    preText[i] = txtResult.Text.Trim();
                    txtResult.Text = txtResult.Text.Trim() + num;
                    i++;
                }
            }
            catch
            {
                MessageBox.Show("");
            }
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            try
            {
                if (ckZero == 0)
                {
                    preText[i] = txtResult.Text.Trim();
                    txtResult.Text = ".";
                    ckZero = 1;
                    ckDot = 1;
                    i++;
                }
                else
                {
                    if (ckDot == 0)
                    {
                        preText[i] = txtResult.Text.Trim();
                        txtResult.Text = txtResult.Text.Trim() + ".";
                        ckDot = 1;
                        i++;
                    }
                }
            }
            catch
            {
                MessageBox.Show("");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (i > 0)
            {
                i--;
                txtResult.Text = preText[i]; 
            }
        }

        private void btn1x_Click(object sender, EventArgs e)
        {
            double num2;
            num = Convert.ToDouble(txtResult.Text.Trim());
            num2 = 1 / num;
            txtResult.Text = Convert.ToString(num2);
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            double num2;
            num = Convert.ToDouble(txtResult.Text.Trim());
            num2 = (num / 100) * total;
            txtResult.Text = Convert.ToString(num2);
        }

        private void btnSQRT_Click(object sender, EventArgs e)
        {
            double num2;
            num = Convert.ToDouble(txtResult.Text.Trim());
            num2 = Math.Sqrt(num);
            txtResult.Text = Convert.ToString(num2);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
