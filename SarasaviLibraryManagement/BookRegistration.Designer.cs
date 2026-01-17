namespace SarasaviLibraryManagement
{
    partial class BookRegistration
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookRegistration));
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textstock = new System.Windows.Forms.TextBox();
            this.txtbk = new System.Windows.Forms.TextBox();
            this.txttitle = new System.Windows.Forms.TextBox();
            this.txtauthour = new System.Windows.Forms.TextBox();
            this.cmbcl = new System.Windows.Forms.ComboBox();
            this.cmbcopy = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(433, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Book Registration From";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(328, 376);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 36);
            this.button1.TabIndex = 1;
            this.button1.Text = "Save Book";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(536, 376);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 36);
            this.button2.TabIndex = 2;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(382, 127);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Classification";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(382, 169);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Book Number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(386, 209);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Title";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(386, 245);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Author";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(382, 279);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Copy Type";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(382, 317);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Stock quantity";
            // 
            // textstock
            // 
            this.textstock.Location = new System.Drawing.Point(518, 312);
            this.textstock.Margin = new System.Windows.Forms.Padding(2);
            this.textstock.Name = "textstock";
            this.textstock.Size = new System.Drawing.Size(92, 20);
            this.textstock.TabIndex = 10;
            // 
            // txtbk
            // 
            this.txtbk.Location = new System.Drawing.Point(518, 169);
            this.txtbk.Margin = new System.Windows.Forms.Padding(2);
            this.txtbk.Name = "txtbk";
            this.txtbk.Size = new System.Drawing.Size(92, 20);
            this.txtbk.TabIndex = 11;
            // 
            // txttitle
            // 
            this.txttitle.Location = new System.Drawing.Point(518, 209);
            this.txttitle.Margin = new System.Windows.Forms.Padding(2);
            this.txttitle.Name = "txttitle";
            this.txttitle.Size = new System.Drawing.Size(92, 20);
            this.txttitle.TabIndex = 12;
            // 
            // txtauthour
            // 
            this.txtauthour.Location = new System.Drawing.Point(518, 245);
            this.txtauthour.Margin = new System.Windows.Forms.Padding(2);
            this.txtauthour.Name = "txtauthour";
            this.txtauthour.Size = new System.Drawing.Size(92, 20);
            this.txtauthour.TabIndex = 14;
            // 
            // cmbcl
            // 
            this.cmbcl.FormattingEnabled = true;
            this.cmbcl.Items.AddRange(new object[] {
            "Mathematics",
            "Technology ",
            "Medicine & Health",
            "Science",
            "History",
            ""});
            this.cmbcl.Location = new System.Drawing.Point(518, 124);
            this.cmbcl.Margin = new System.Windows.Forms.Padding(2);
            this.cmbcl.Name = "cmbcl";
            this.cmbcl.Size = new System.Drawing.Size(92, 21);
            this.cmbcl.TabIndex = 16;
            // 
            // cmbcopy
            // 
            this.cmbcopy.FormattingEnabled = true;
            this.cmbcopy.Items.AddRange(new object[] {
            "Hardcover",
            "Paperback",
            "Digital Copy",
            "Reference Copy",
            "Special Edition"});
            this.cmbcopy.Location = new System.Drawing.Point(518, 279);
            this.cmbcopy.Margin = new System.Windows.Forms.Padding(2);
            this.cmbcopy.Name = "cmbcopy";
            this.cmbcopy.Size = new System.Drawing.Size(92, 21);
            this.cmbcopy.TabIndex = 17;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(733, 376);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(107, 36);
            this.button3.TabIndex = 18;
            this.button3.Text = "Back";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // BookRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SarasaviLibraryManagement.Properties.Resources.library;
            this.ClientSize = new System.Drawing.Size(1028, 570);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.cmbcopy);
            this.Controls.Add(this.cmbcl);
            this.Controls.Add(this.txtauthour);
            this.Controls.Add(this.txttitle);
            this.Controls.Add(this.txtbk);
            this.Controls.Add(this.textstock);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "BookRegistration";
            this.Text = "BookRegistration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textstock;
        private System.Windows.Forms.TextBox txtbk;
        private System.Windows.Forms.TextBox txttitle;
        private System.Windows.Forms.TextBox txtauthour;
        private System.Windows.Forms.ComboBox cmbcl;
        private System.Windows.Forms.ComboBox cmbcopy;
        private System.Windows.Forms.Button button3;
    }
}