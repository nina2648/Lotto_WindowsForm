using Microsoft.VisualBasic.PowerPacks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
//using System.Windows.Media;

namespace A106221029黃宣溶樂透機
{
    public partial class Formlotto : Form
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // Turn on WS_EX_COMPOSITED 
                return cp;
            }
        }
        public Formlotto()
        {
            InitializeComponent();
        }

        Random r = new Random();
        Label[] shape = new Label[49];
        ShapeContainer sc = new ShapeContainer();
        //OvalShape[] shape = new OvalShape[49];
        int k=0;
        int[] i = new int[49];
        int[] j = new int[49];
        int[] runlr = new int[49];
        int[] runtb = new int[49];
        //PictureBox[] shape = new PictureBox[49];
        //GeometryDrawing[] ellipseDrawing = new GeometryDrawing[49];
        Image image = Image.FromFile("c1.png");
        System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 16);
        private void Formlotto_Load(object sender, EventArgs e)
        {
            
            timerbump.Enabled = true;
            sc.Parent = panelcho;
            for (int n = 0; n < 49; n++)
            {
                i[n] = 0;
                j[n] = 0;
                int t = r.Next(1, 2);
                int x = r.Next(10, 15);
                if (t == 1) { runlr[n] = x; }
                else if (t == 2) { runlr[n] = -x; }
                int y = r.Next(1, 2);
                if (y == 1) { runtb[n] = x; }
                else if (y == 2) { runtb[n] = -x; }
            }
            /*for (int sh = 0; sh < shape.Length; sh++)
            {
                Graphics g;
                shape[sh] = new PictureBox();
                panelcho.Controls.Add(shape[sh]);
                g = shape[sh].CreateGraphics();
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Brush bush = new SolidBrush(Color.Orange);//填充的顏色
                g.FillEllipse(bush, r.Next(20,380), r.Next(20, 380), 20, 20);
            }*/
            for (int sh = 0; sh < shape.Length; sh++)
            {
                shape[sh] = new Label();
                shape[sh].Text = (sh+1).ToString();
                panelcho.Controls.Add(shape[sh]);
                shape[sh].Location = new Point(r.Next(20, panelcho.Width-40), r.Next(20, panelcho.Height-40));
                shape[sh].TextAlign= ContentAlignment.MiddleCenter;
                shape[sh].BackColor = Color.Transparent;
                shape[sh].FlatStyle = FlatStyle.Flat;
                shape[sh].Font = new Font("Arial", 11,FontStyle.Bold);
                shape[sh].Size = new Size(30,30);
                shape[sh].Image = image;
                shape[sh].AutoSize = true;


            }
            lottoblock();
            //testcreat();

            /*for (int i = 0; i <= 48; i++)
            {
                shape[i] = new OvalShape(sc);
                //lbl[i] = new Label();
                //lbl[i].Text = i.ToString();
                shape[i].Left = r.Next(20, 400);
                shape[i].Top = r.Next(20, 340);
                shape[i].Width = 20;
                shape[i].Height = 20;
                shape[i].BackStyle = BackStyle.Opaque;
                shape[i].BackColor = System.Drawing.Color.Orange;
                /*Font df = new Font("Arial", 12);
                SolidBrush db = new SolidBrush(System.Drawing.Color.Black);
                using (Graphics g = Graphics.FromHwnd(IntPtr.Zero))
                {
                    g.DrawString(i.ToString(), df, db, shape[i].Location.X, shape[i].Location.Y);
                    
                }
            }*/

        }
        private void lottoblock()
        {
            Label hole = new Label();
            panelcho.Controls.Add(hole);
            hole.Location = new Point(460,360);
            hole.BackColor = Color.Black;
            hole.Size = new Size(40, 40);

        }

        int draw = 0;
        private void Draw(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Font df = new Font("Arial", 12);
            Brush db = new SolidBrush(Color.Black);
            Brush bc = new SolidBrush(Color.Orange);
            g.FillEllipse(bc, 0, 0, 50, 50);
            e.Graphics.DrawString(draw.ToString(), df, db, shape[draw].Location.X, shape[draw].Location.Y);
            draw++;
        }
        //int[] s = new int[49];
        
        
        private void timerbump_Tick(object sender, EventArgs e)
        {
            for (k = 0; k < shape.Length; k++) {
                if (shape[k].Text != "") { 
                    checkloca(k);
                    bump(k);
                    if (win < 7) { 
                        check(k);
                    }
                }
            }
            if (win == 7)
            {
                timerbump.Enabled = false;
                string result="";
                string resultos = "你選擇的號碼:";
                for(int re=0;re< FormSelect.ary.numary.Length; re++)
                {
                    resultos += "  "+FormSelect.ary.numary[re];
                }
                resultos += "\n";

                if (comnum != 0 && spnum != 0)
                {
                    result+= "你中了" + comnum + "個一般號";
                }
                else if(comnum == 0 && spnum != 0)
                {
                    result += "你只中了特別號!";
                }
                else
                {
                    result += "你未中獎";
                }
                if (spnum != 0)
                {
                    result += "以及特別號!";
                }
                else
                {
                    result += "!";
                }
                instertoacc();
                MessageBox.Show(resultos+result);

            }
        }
        Label[] lblwin = new Label[7];
        int comnum=0;
        int spnum = 0;
        int win = 0;
        private void check(int loto)
        {
                if(shape[loto].Bottom>=370 && shape[loto].Right >= 470)
            {
                lblwin[win] = new Label();
                this.Controls.Add(lblwin[win]);
                lblwin[win].Location = new Point(label1.Location.X+label1.Width+40*win, label1.Location.Y-15);
                lblwin[win].Text = shape[loto].Text;
                lblwin[win].Size = new Size(30, 30);
                lblwin[win].Image = image;
                lblwin[win].TextAlign = ContentAlignment.MiddleCenter;
                lblwin[win].BackColor = Color.Transparent;
                lblwin[win].FlatStyle = FlatStyle.Flat;
                lblwin[win].Font = new Font("Arial", 10, FontStyle.Bold);
                if (win == 6)
                {
                    lblwin[win].ForeColor = Color.DarkRed;
                    for(int w =0;w< FormSelect.ary.numary.Length; w++) { 
                        if(int.Parse(lblwin[win].Text) == FormSelect.ary.numary[w])
                        {
                            spnum++;
                        }
                    }
                }
                else
                {
                    for (int w = 0; w < FormSelect.ary.numary.Length; w++)
                    {
                        if (int.Parse(lblwin[win].Text) == FormSelect.ary.numary[w])
                        {
                            comnum++;
                        }
                    }
                }
                shape[loto].Text = null;
                shape[loto].Image = null;
                win++;
                    
                }
        }

        private void bump(int s)
        {
                shape[s].Top += runtb[s];
                shape[s].Left += runlr[s];
                if (shape[s].Top <= 0 )
                {
                    shape[s].Top -= runtb[s];
                    runtb[s] *= -1;
                }
                else if (shape[s].Bottom >= 400)
                {
                    shape[s].Top -= runtb[s];
                    runtb[s] *= -1;
                }
                else if (shape[s].Left <= 0)
                {
                    shape[s].Left -= runlr[s];
                    runlr[s] *= -1;
                }
                else if (shape[s].Right >= 500)
                {
                    shape[s].Left -= runlr[s];
                    runlr[s] *= -1;
                }
        }
        private void checkloca(int s)
        {
            for (int m = 0; m < shape.Length; m++)
            {
                if (!Object.Equals(shape[s], shape[m]))
                {
                    float dis = (float)Math.Sqrt(Math.Pow(shape[s].Location.X - shape[m].Location.X, 2) + (Math.Pow(shape[s].Location.Y - shape[m].Location.Y, 2)));
                    if (dis < 20)
                    {
                        runlr[s] *= -1;
                        runlr[m] *= -1;
                        runtb[s] *= -1;
                        runtb[m] *= -1;
                    }
                }
            }
        }
        private void instertoacc()
        {
            String strConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=dbball.accdb";
            OleDbConnection cn = new OleDbConnection(strConnectionString);
            cn.Open();
            String sqlstr = "";
            sqlstr = "insert into ballre(ballone, balltwo, ballthree, ballfour, ballfive, ballsix, ballsp)values(";
            for(int b=0; b<= 5; b++)
            {
                sqlstr += "'" + lblwin[b].Text + "',";
            }
            sqlstr += "'" + lblwin[6].Text + "')";


            OleDbCommand command_ = new OleDbCommand(sqlstr, cn);
            command_.ExecuteNonQuery();

            cn.Close();


        }

        private void btnRe_Click(object sender, EventArgs e)
        {
            BindingSource BindingSource1;
            BindingSource1 = new BindingSource();
            String strConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=dbball.accdb";
            
            OleDbConnection cn = new OleDbConnection(strConnectionString);
            
            cn.Open();
            
            OleDbDataAdapter oleda = new OleDbDataAdapter("SELECT * FROM ballre", cn);
            DataSet ds = new DataSet("ballre");
            oleda.Fill(ds, "ds_ballre");

            //第六步：設定 DataSource
            //DataGridView1.DataSource = ds.Tables("ds_客戶")
            BindingSource1.DataSource = ds.Tables[0];
            dataGridView1.DataSource = BindingSource1;

            //關閉資料庫連線
            cn.Close();

        }
    }
}
