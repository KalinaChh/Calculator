using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        double value = 0;
        string operand = string.Empty;
        bool pressedOperand = false;
        double memory = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            if (resultBox.Text=="0"||pressedOperand)
            {
                resultBox.Clear();
            }
            pressedOperand = false;

            Button button = (Button)sender;
            if (button.Text==".")
            {
                if (!resultBox.Text.Contains("."))
                {
                    resultBox.Text = resultBox.Text + button.Text; 
                }
            }
            else
            {
                 resultBox.Text = resultBox.Text + button.Text;
            }
        }
        private void OperandClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (value!=0)
            {
                if (button.Text== "√")
                {
                    resultBox.Text = Math.Sqrt(Double.Parse(resultBox.Text)).ToString();
                    buttonEquals.PerformClick();
                    pressedOperand = true;
                    operand = button.Text;
                    label.Text = value + " " + operand;
                }
            }
            else if(button.Text == "√")
            {
                resultBox.Text = Math.Sqrt(Double.Parse(resultBox.Text)).ToString();
                value = Math.Sqrt(Double.Parse(resultBox.Text));
            }
            if (value != 0)
            {
                buttonEquals.PerformClick();
                pressedOperand = true;
                operand = button.Text;
                label.Text = value + " " + operand;

            }
            else
            {
                operand = button.Text;
                value = Double.Parse(resultBox.Text);
                pressedOperand = true;
                label.Text = value + " " + operand;
            }
        }
        private void ButtonCE_Click(object sender, EventArgs e)
        {
            resultBox.Text = "0";
        }
        private void ButtonC_Click(object sender, EventArgs e)
        {
            resultBox.Text = "0";
            value = 0;
            label.Text = "";
        }
        private void ButtonEquals_Click(object sender, EventArgs e)
        {
            label.Text = "";
            switch (operand)
            {
                case "+":resultBox.Text = (value + Double.Parse(resultBox.Text)).ToString();break;
                case "-":resultBox.Text = (value - Double.Parse(resultBox.Text)).ToString();break;               
                case "/":
                    if (resultBox.Text != "0")
                    {
                        resultBox.Text = (value / Double.Parse(resultBox.Text)).ToString();
                    }
                    else
                    {
                        MessageBox.Show("Cannot divide by zero", "Attention",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;
                case "*":resultBox.Text = (value * Double.Parse(resultBox.Text)).ToString();break;

                default:
                    break;
            }
            value = Double.Parse(resultBox.Text);
            operand = string.Empty;
            
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar.ToString())
            {
                case "0": buttonZero.PerformClick(); break;
                case "1": buttonOne.PerformClick();break;
                case "2": buttonTwo.PerformClick();break;
                case "3": buttonThree.PerformClick();break;
                case "4": buttonFour.PerformClick();break;
                case "5": buttonFive.PerformClick();break;
                case "6": buttonSix.PerformClick();break;
                case "7": buttonSeven.PerformClick();break;
                case "8": buttonEight.PerformClick();break;
                case "9": buttonNine.PerformClick();break;

                case "+": buttonPlus.PerformClick(); break;
                case "-": buttonMinus.PerformClick(); break;
                case "*": buttonMultiply.PerformClick(); break;
                case "/": buttonDivide.PerformClick(); break;
                case "=": buttonEquals.PerformClick(); break;

                default:
                    break;
            }
        }
        private void MClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operand = button.Text;

            switch (operand)
            {
                case "M+": memory += Double.Parse(resultBox.Text); break;
                case "M-": memory -= Double.Parse(resultBox.Text);break;
                case "MR": resultBox.Text = memory.ToString(); break; 
                case "MC": 
                    resultBox.Text = "0";
                    memory =0;
                    break;
                default:
                    break;
            }
        }
    }
}
