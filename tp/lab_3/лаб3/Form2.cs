using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace лаб3
{
    public partial class Form2 : Form
    {
        public Lib Lib { get; set; }
        public Form2()
        {
            InitializeComponent();
            Lib = new Lib();


        }
        public Form2(Lib lib)
        {
            InitializeComponent();
            Lib = new Lib();
            numericUpDown1.Value = lib.Id;
            
            maskedTextBox1.Text = lib.Brand;
            maskedTextBox3.Text = lib.Color;
            dateTimePicker1.Value = lib.Year;
            comboBox1.Text = lib.Condition;
 
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
            Lib.Id = numericUpDown1.Value;   
            Lib.Brand = maskedTextBox1.Text;
            Lib.Color = maskedTextBox3.Text;
            Lib.Year = dateTimePicker1.Value;
            Lib.Condition = comboBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
