using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjMcDonald
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btncalculate_Click(object sender, EventArgs e)
        {
            Int32 hourly, time, overtime, weekly_sal, result;
            double overtime_sal, total;
            hourly = Convert.ToInt32(textBox2.Text);
            time = Convert.ToInt32(textBox3.Text);
            overtime = Convert.ToInt32(textBox4.Text);
            weekly_sal = hourly * time;
            overtime_sal = hourly * overtime * 1.5;
            total = weekly_sal + overtime_sal;
            lblresult.Text = "Sir or Miss " + textBox1.Text + "\n" +
                            "Your weekly salary is " + weekly_sal + "\n" +
                            "Your Overtime salary is " + overtime_sal + "\n" +
                            "----------------------------------------"  +"\n" +
                            "Your total income will be " + total;    
        }
    }
}
