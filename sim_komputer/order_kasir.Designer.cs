namespace sim_komputer
{
    partial class order_kasir
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
            this.tBsearch = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tBqty = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tBqty2 = new System.Windows.Forms.TextBox();
            this.bTupdate = new System.Windows.Forms.Button();
            this.bTremove = new System.Windows.Forms.Button();
            this.bTcharge = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // tBsearch
            // 
            this.tBsearch.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tBsearch.Location = new System.Drawing.Point(563, 21);
            this.tBsearch.Name = "tBsearch";
            this.tBsearch.Size = new System.Drawing.Size(114, 20);
            this.tBsearch.TabIndex = 37;
            this.tBsearch.Text = "Search";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(33, 47);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(644, 196);
            this.dataGridView1.TabIndex = 36;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 21);
            this.label1.TabIndex = 35;
            this.label1.Text = "Order";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(190, 323);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 29);
            this.button1.TabIndex = 39;
            this.button1.Text = "Add Barang";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(33, 396);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(644, 196);
            this.dataGridView2.TabIndex = 40;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(33, 274);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 41;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // tBqty
            // 
            this.tBqty.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tBqty.Location = new System.Drawing.Point(33, 328);
            this.tBqty.Name = "tBqty";
            this.tBqty.Size = new System.Drawing.Size(100, 20);
            this.tBqty.TabIndex = 42;
            this.tBqty.TextChanged += new System.EventHandler(this.tBqty_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 255);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 17);
            this.label2.TabIndex = 43;
            this.label2.Text = "Name Barang";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 308);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 44;
            this.label3.Text = "Quantity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 619);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 46;
            this.label4.Text = "Quantity";
            // 
            // tBqty2
            // 
            this.tBqty2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tBqty2.Location = new System.Drawing.Point(33, 639);
            this.tBqty2.Name = "tBqty2";
            this.tBqty2.Size = new System.Drawing.Size(100, 20);
            this.tBqty2.TabIndex = 45;
            this.tBqty2.TextChanged += new System.EventHandler(this.tBqty2_TextChanged);
            // 
            // bTupdate
            // 
            this.bTupdate.BackColor = System.Drawing.SystemColors.ControlDark;
            this.bTupdate.FlatAppearance.BorderSize = 0;
            this.bTupdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bTupdate.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bTupdate.Location = new System.Drawing.Point(181, 630);
            this.bTupdate.Name = "bTupdate";
            this.bTupdate.Size = new System.Drawing.Size(114, 29);
            this.bTupdate.TabIndex = 47;
            this.bTupdate.Text = "Update";
            this.bTupdate.UseVisualStyleBackColor = false;
            this.bTupdate.Click += new System.EventHandler(this.bTupdate_Click);
            // 
            // bTremove
            // 
            this.bTremove.BackColor = System.Drawing.SystemColors.ControlDark;
            this.bTremove.FlatAppearance.BorderSize = 0;
            this.bTremove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bTremove.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bTremove.Location = new System.Drawing.Point(181, 674);
            this.bTremove.Name = "bTremove";
            this.bTremove.Size = new System.Drawing.Size(114, 29);
            this.bTremove.TabIndex = 48;
            this.bTremove.Text = "Remove";
            this.bTremove.UseVisualStyleBackColor = false;
            this.bTremove.Click += new System.EventHandler(this.bTremove_Click);
            // 
            // bTcharge
            // 
            this.bTcharge.BackColor = System.Drawing.SystemColors.ControlDark;
            this.bTcharge.FlatAppearance.BorderSize = 0;
            this.bTcharge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bTcharge.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bTcharge.Location = new System.Drawing.Point(316, 674);
            this.bTcharge.Name = "bTcharge";
            this.bTcharge.Size = new System.Drawing.Size(114, 29);
            this.bTcharge.TabIndex = 49;
            this.bTcharge.Text = "Charge";
            this.bTcharge.UseVisualStyleBackColor = false;
            this.bTcharge.Click += new System.EventHandler(this.bTcharge_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(510, 595);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 19);
            this.label5.TabIndex = 50;
            this.label5.Text = "Total Harga";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // order_kasir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bTcharge);
            this.Controls.Add(this.bTremove);
            this.Controls.Add(this.bTupdate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tBqty2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tBqty);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tBsearch);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "order_kasir";
            this.Size = new System.Drawing.Size(714, 749);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tBsearch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox tBqty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tBqty2;
        private System.Windows.Forms.Button bTupdate;
        private System.Windows.Forms.Button bTremove;
        private System.Windows.Forms.Button bTcharge;
        private System.Windows.Forms.Label label5;
    }
}
