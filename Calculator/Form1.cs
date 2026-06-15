using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Calculator
{
    public partial class Form1 : Form
    {

        private double value = 0;
        private string operation = ""; // This will hold the current operation (+, -, *, /) 
        private bool operatorPressed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void DigitButton_Click(object sender, EventArgs e)
        {

            if (NumericField.Text == "0" || (operatorPressed))
                NumericField.Clear(); //clears the field before the digit inputted after an operation button is clicked shows

            operatorPressed = false;

            if(sender is System.Windows.Forms.Button button)
            {
                NumericField.Text += button.Text; // Append the digit to the NumericField text  
            }
        }

        private void OperationButton_Click(object sender, EventArgs e)
        {
            if(sender is System.Windows.Forms.Button button)
            {
               operation = button.Text; // Store the operation for later use in EqualsButton_Click   
               operatorPressed = true; //condition for numericfield to clear first before the additional digit appears
               value = double.Parse(NumericField.Text); //this is the first number being inputted before an operation is selected
            }
            
        }

        private void EqualsButton_Click(object sender, EventArgs e)
        {
            
            operatorPressed = false;
            switch(operation)
            {   case "+":
                    NumericField.Text = (value + Double.Parse(NumericField.Text)).ToString(); 
                    break; //NumericField.Text is being parsed to read what number was inputted so that it can be added to value 
                case "-":
                    NumericField.Text = (value - Double.Parse(NumericField.Text)).ToString();
                    break;
                case "X":
                    NumericField.Text = (value * Double.Parse(NumericField.Text)).ToString();
                    break;
                case "/":
                    if (Double.Parse(NumericField.Text) != 0)
                        NumericField.Text = (value / Double.Parse(NumericField.Text)).ToString();
                    else
                        MessageBox.Show("Cannot divide by zero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case "√²":
                    NumericField.Text = (Math.Sqrt(Double.Parse(NumericField.Text))).ToString();
                    break;
                case "X²":
                    NumericField.Text = (Math.Pow(Double.Parse(NumericField.Text), 2)).ToString();
                    break;
                case "½":
                    NumericField.Text = (Double.Parse(NumericField.Text) / 2).ToString();
                    break;

            }
            
        }

        private void NegativeButton_Click(object sender, EventArgs e)
        {
            /*if the operator button was just pressed,
            pressing the negative button will set the field to "-" for the next number input,
            instead of appending a negative sign to the current number in the field*/
            if (operatorPressed) 
            {
                NumericField.Text = "-";
                operatorPressed = false;
                return;
            }

            /*if the field currently shows "0", 
             pressing the negative button will change it to "-" to allow for negative number input*/
            if (NumericField.Text == "0")
            {
                NumericField.Text = "-";
                return;
            }

            /*if the field already contains a negative sign, pressing the negative button will remove it, 
             allowing for positive number input without needing to clear the field first*/
            if (NumericField.Text.StartsWith("-"))
            {
                NumericField.Text = NumericField.Text.Substring(1);

                if (string.IsNullOrEmpty(NumericField.Text))
                {
                    NumericField.Text = "0";
                }
            }
            else
            {
                NumericField.Text += "-" ;
            }
        }

        private void BackspaceButton_Click(object sender, EventArgs e)
        {
            //deletes the newest appended digit
            NumericField.Text = NumericField.Text.Length > 1 ? NumericField.Text.Substring(0, NumericField.Text.Length - 1) : "0";             
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            if (sender is System.Windows.Forms.Button button)
            {        
                //clear field 
                NumericField.Text = "0";
            }
        }
    }
}
