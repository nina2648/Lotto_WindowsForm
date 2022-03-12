namespace A106221029黃宣溶樂透機
{
    partial class Formlotto
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timerbump = new System.Windows.Forms.Timer(this.components);
            this.panelcho = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnRe = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // timerbump
            // 
            this.timerbump.Interval = 50;
            this.timerbump.Tick += new System.EventHandler(this.timerbump_Tick);
            // 
            // panelcho
            // 
            this.panelcho.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelcho.Location = new System.Drawing.Point(12, 12);
            this.panelcho.Name = "panelcho";
            this.panelcho.Size = new System.Drawing.Size(500, 400);
            this.panelcho.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 441);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "中獎號碼 :";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(542, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(655, 400);
            this.dataGridView1.TabIndex = 2;
            // 
            // btnRe
            // 
            this.btnRe.Location = new System.Drawing.Point(542, 431);
            this.btnRe.Name = "btnRe";
            this.btnRe.Size = new System.Drawing.Size(655, 35);
            this.btnRe.TabIndex = 3;
            this.btnRe.Text = "檢視目前中獎號碼紀錄";
            this.btnRe.UseVisualStyleBackColor = true;
            this.btnRe.Click += new System.EventHandler(this.btnRe_Click);
            // 
            // Formlotto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 489);
            this.Controls.Add(this.btnRe);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelcho);
            this.Name = "Formlotto";
            this.Text = "抽獎";
            this.Load += new System.EventHandler(this.Formlotto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerbump;
        private System.Windows.Forms.Panel panelcho;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnRe;
    }
}

