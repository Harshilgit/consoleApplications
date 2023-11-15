using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjStdGrdEvaluation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnevaluate_Click(object sender, EventArgs e)
        {
            Int32 age, mid_term, final, project, total;
            age = 2022 - Convert.ToInt32(textBox2.Text);
            mid_term = (Convert.ToInt32(textBox3.Text) * 25 / 100);
            final = (Convert.ToInt32(textBox4.Text) * 40 / 100);
            project = (Convert.ToInt32(textBox5.Text) * 35 / 100);
            total = mid_term + final + project;
            lblresult.Text = "Sir or Miss " + textBox1.Text + "\n" +
                            "Born in " + textBox2.Text + ", " + "You are " + age + "years old" + "\n" +
                            "Here are the calculations of your grades " + "\n" +
                            "-MidTerm Exam : " + mid_term + "\n" +
                            "-Final Project is : " + final + "\n" +
                            "-Project grade : " + project + "\n" +
                            "--------------------------------" + "\n" +
                            "Total Average : " + total;
        }
    }
}
