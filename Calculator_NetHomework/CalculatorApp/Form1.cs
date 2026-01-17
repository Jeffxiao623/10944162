using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class Form1 : Form
    {
        // 定義變數
        Double resultValue = 0;
        String operationPerformed = "";
        bool isOperationPerformed = false;

        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "0";
            // 讓文字靠右
            textBox1.TextAlign = HorizontalAlignment.Right;
        }

        // 數字鍵共用這個功能
        private void number_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "0") || (isOperationPerformed))
                textBox1.Clear();

            isOperationPerformed = false;
            Button button = (Button)sender;

            if (button.Text == ".")
            {
                if (!textBox1.Text.Contains("."))
                    textBox1.Text = textBox1.Text + button.Text;
            }
            else
            {
                textBox1.Text = textBox1.Text + button.Text;
            }
        }

        // 加減乘除共用這個功能
        private void operator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (resultValue != 0)
            {
                if (!isOperationPerformed)
                {
                    btnEquals.PerformClick();
                    operationPerformed = button.Text;
                    isOperationPerformed = true;
                }
                else
                {
                    operationPerformed = button.Text;
                }
            }
            else
            {
                operationPerformed = button.Text;
                resultValue = Double.Parse(textBox1.Text);
                isOperationPerformed = true;
            }
        }

        // 清除 (CE)
        private void button_CE_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        // 全部清除 (C) - 請確認你的按鈕點兩下後是不是叫這個名字，如果不是請手動改這裡的名稱
        private void button_C_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            resultValue = 0;
            operationPerformed = "";
        }

        // 等於
        private void btnEquals_Click(object sender, EventArgs e)
        {
            switch (operationPerformed)
            {
                case "+":
                    textBox1.Text = (resultValue + Double.Parse(textBox1.Text)).ToString();
                    break;
                case "-":
                    textBox1.Text = (resultValue - Double.Parse(textBox1.Text)).ToString();
                    break;
                case "×":
                    textBox1.Text = (resultValue * Double.Parse(textBox1.Text)).ToString();
                    break;
                case "÷":
                    textBox1.Text = (resultValue / Double.Parse(textBox1.Text)).ToString();
                    break;
                default:
                    break;
            }
            resultValue = Double.Parse(textBox1.Text);
            operationPerformed = "";
        }

        // 倒退鍵 (Backspace)
        private void button_Back_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
            }
            if (textBox1.Text == "")
            {
                textBox1.Text = "0";
            }
        }

        // 正負號 (+/-)
        private void button_PlusMinus_Click(object sender, EventArgs e)
        {
            double v = Double.Parse(textBox1.Text);
            textBox1.Text = (-1 * v).ToString();
        }

        // 根號
        private void button_Sqrt_Click(object sender, EventArgs e)
        {
            double v = Double.Parse(textBox1.Text);
            textBox1.Text = Math.Sqrt(v).ToString();
        }

        // 平方
        private void button_Square_Click(object sender, EventArgs e)
        {
            double v = Double.Parse(textBox1.Text);
            textBox1.Text = (v * v).ToString();
        }

        // 倒數 (1/x)
        private void button_Reciprocal_Click(object sender, EventArgs e)
        {
            double v = Double.Parse(textBox1.Text);
            textBox1.Text = (1.0 / v).ToString();
        }

        // 百分比 (%)
        private void button_Percent_Click(object sender, EventArgs e)
        {
            double v = Double.Parse(textBox1.Text);
            textBox1.Text = (v / 100).ToString();
        }
    }
}
