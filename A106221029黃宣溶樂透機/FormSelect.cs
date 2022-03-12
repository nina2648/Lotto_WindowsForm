using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A106221029黃宣溶樂透機
{
    public partial class FormSelect : Form
    {
        public class ary
        {
            public static int[] numary = new int[7];
        }
        
        public FormSelect()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormSelect_Load(object sender, EventArgs e)
        {
            int n=1;
            for (int i = 1; i <= 7; i++)
            {
                for(int j=1; j <=7 ; j++) { 
                    Button btn = new Button();
                    btn.Text = (n).ToString();
                    selecttable.Controls.Add(btn, j-1, i-1);
                    btn.Click += btnclick;
                    n++;
                }
            }
            
        }
        int cholbl = 2;
        private void btnclick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            
            foreach(Control con in this.Controls)
            {
                string lbl = "label" + (cholbl).ToString();
                if (con.Name == "label8" && con.Text!="-")
                {
                    MessageBox.Show("無法下注更多號碼!");
                }
                else { 
                    if (con.Name == lbl) { 
                        if (con.Text == "-")
                        {
                            btn.Enabled = false;
                            con.Text = btn.Text;
                            ary.numary[cholbl - 2] = int.Parse(btn.Text);
                            cholbl++;
                            return;
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = "-";
            label3.Text = "-";
            label4.Text = "-";
            label5.Text = "-";
            label6.Text = "-";
            label7.Text = "-";
            label8.Text = "-";
            foreach (Control con in selecttable.Controls)
            {
                con.Enabled = true;
            }
            cholbl = 2;
            Array.Clear(ary.numary, 0, ary.numary.Length);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ary.numary[6] == 0) {
                MessageBox.Show("需下注7個號碼!");
            }
            else { 
                Formlotto f = new Formlotto();
                f.Show();
                this.Enabled = false;
            }
        }
    }
}
