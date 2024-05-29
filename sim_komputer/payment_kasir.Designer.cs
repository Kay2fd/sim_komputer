namespace sim_komputer
{
    partial class payment_kasir
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tBdiscount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tBprice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.tBcharge = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bTbyr = new System.Windows.Forms.Button();
            this.tBttl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tBdiscount
            // 
            this.tBdiscount.Location = new System.Drawing.Point(275, 233);
            this.tBdiscount.Name = "tBdiscount";
            this.tBdiscount.Size = new System.Drawing.Size(141, 20);
            this.tBdiscount.TabIndex = 46;
            this.tBdiscount.TextChanged += new System.EventHandler(this.tBdiscount_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(140, 232);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 24);
            this.label10.TabIndex = 45;
            this.label10.Text = "Discount";
            // 
            // tBprice
            // 
            this.tBprice.Location = new System.Drawing.Point(275, 206);
            this.tBprice.Name = "tBprice";
            this.tBprice.Size = new System.Drawing.Size(141, 20);
            this.tBprice.TabIndex = 36;
            this.tBprice.Text = "Total Price...";
            this.tBprice.TextChanged += new System.EventHandler(this.tBprice_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(142, 285);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 24);
            this.label3.TabIndex = 35;
            this.label3.Text = "Charge";
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotal.Location = new System.Drawing.Point(140, 258);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(129, 24);
            this.labelTotal.TabIndex = 34;
            this.labelTotal.Text = "Total Payment";
            // 
            // tBcharge
            // 
            this.tBcharge.Location = new System.Drawing.Point(277, 290);
            this.tBcharge.Name = "tBcharge";
            this.tBcharge.Size = new System.Drawing.Size(141, 20);
            this.tBcharge.TabIndex = 33;
            this.tBcharge.Text = "Enter amount...";
            this.tBcharge.TextChanged += new System.EventHandler(this.tBcharge_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Menu;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(294, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 31);
            this.label1.TabIndex = 31;
            this.label1.Text = "Payment";
            // 
            // bTbyr
            // 
            this.bTbyr.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.bTbyr.FlatAppearance.BorderSize = 0;
            this.bTbyr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bTbyr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bTbyr.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.bTbyr.Location = new System.Drawing.Point(313, 345);
            this.bTbyr.Name = "bTbyr";
            this.bTbyr.Size = new System.Drawing.Size(90, 38);
            this.bTbyr.TabIndex = 49;
            this.bTbyr.Text = "Charge";
            this.bTbyr.UseVisualStyleBackColor = false;
            this.bTbyr.Click += new System.EventHandler(this.bTbyr_Click);
            // 
            // tBttl
            // 
            this.tBttl.Location = new System.Drawing.Point(275, 264);
            this.tBttl.Name = "tBttl";
            this.tBttl.Size = new System.Drawing.Size(141, 20);
            this.tBttl.TabIndex = 50;
            this.tBttl.Text = "Total Price...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(140, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 24);
            this.label2.TabIndex = 51;
            this.label2.Text = "Total";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(655, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(37, 20);
            this.button1.TabIndex = 52;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // payment_kasir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tBttl);
            this.Controls.Add(this.bTbyr);
            this.Controls.Add(this.tBdiscount);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tBprice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.tBcharge);
            this.Controls.Add(this.label1);
            this.Name = "payment_kasir";
            this.Size = new System.Drawing.Size(714, 640);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tBdiscount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tBprice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.TextBox tBcharge;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bTbyr;
        private System.Windows.Forms.TextBox tBttl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}
