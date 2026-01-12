namespace SarasaviLibraryManagement
{
    partial class UserRegistration
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtUserNo = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.Label();
            this.txtNIC = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.cmbSex = new System.Windows.Forms.Label();
            this.cmSex = new System.Windows.Forms.ComboBox();
            this.txtAddress = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(566, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Registration";
            // 
            // txtUserNo
            // 
            this.txtUserNo.AutoSize = true;
            this.txtUserNo.Location = new System.Drawing.Point(372, 195);
            this.txtUserNo.Name = "txtUserNo";
            this.txtUserNo.Size = new System.Drawing.Size(87, 16);
            this.txtUserNo.TabIndex = 1;
            this.txtUserNo.Text = "User Number";
            // 
            // txtName
            // 
            this.txtName.AutoSize = true;
            this.txtName.Location = new System.Drawing.Point(372, 248);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(44, 16);
            this.txtName.TabIndex = 2;
            this.txtName.Text = "Name";
            // 
            // txtNIC
            // 
            this.txtNIC.AutoSize = true;
            this.txtNIC.Location = new System.Drawing.Point(372, 311);
            this.txtNIC.Name = "txtNIC";
            this.txtNIC.Size = new System.Drawing.Size(29, 16);
            this.txtNIC.TabIndex = 3;
            this.txtNIC.Text = "NIC";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(543, 192);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(371, 22);
            this.textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(543, 248);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(371, 22);
            this.textBox2.TabIndex = 5;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(543, 308);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(371, 22);
            this.textBox3.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(375, 514);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(176, 52);
            this.button1.TabIndex = 7;
            this.button1.Text = "Register ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(679, 514);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(167, 52);
            this.button2.TabIndex = 8;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(1005, 514);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(143, 52);
            this.button3.TabIndex = 9;
            this.button3.Text = "Back";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // cmbSex
            // 
            this.cmbSex.AutoSize = true;
            this.cmbSex.Location = new System.Drawing.Point(372, 361);
            this.cmbSex.Name = "cmbSex";
            this.cmbSex.Size = new System.Drawing.Size(30, 16);
            this.cmbSex.TabIndex = 10;
            this.cmbSex.Text = "Sex";
            // 
            // cmSex
            // 
            this.cmSex.FormattingEnabled = true;
            this.cmSex.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cmSex.Location = new System.Drawing.Point(543, 361);
            this.cmSex.Name = "cmSex";
            this.cmSex.Size = new System.Drawing.Size(170, 24);
            this.cmSex.TabIndex = 11;
            // 
            // txtAddress
            // 
            this.txtAddress.AutoSize = true;
            this.txtAddress.Location = new System.Drawing.Point(372, 415);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(58, 16);
            this.txtAddress.TabIndex = 12;
            this.txtAddress.Text = "Address";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(543, 424);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(371, 22);
            this.textBox4.TabIndex = 13;
            // 
            // UserRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SarasaviLibraryManagement.Properties.Resources.library;
            this.ClientSize = new System.Drawing.Size(1377, 701);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.cmSex);
            this.Controls.Add(this.cmbSex);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtNIC);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtUserNo);
            this.Controls.Add(this.label1);
            this.Name = "UserRegistration";
            this.Text = "UserRegistration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtUserNo;
        private System.Windows.Forms.Label txtName;
        private System.Windows.Forms.Label txtNIC;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label cmbSex;
        private System.Windows.Forms.ComboBox cmSex;
        private System.Windows.Forms.Label txtAddress;
        private System.Windows.Forms.TextBox textBox4;
    }
}