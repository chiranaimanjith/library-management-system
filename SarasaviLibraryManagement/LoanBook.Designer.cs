namespace SarasaviLibraryManagement
{
    partial class LoanBook
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoanBook));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnconfirm = new System.Windows.Forms.Button();
            this.btnclear = new System.Windows.Forms.Button();
            this.mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            this.txtun = new System.Windows.Forms.TextBox();
            this.dgvBooksToLoan = new System.Windows.Forms.DataGridView();
            this.colCopyNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.checkuser = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.dateTimeexpedcted = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooksToLoan)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(487, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loan Book";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(72, 128);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "User Number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(72, 258);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "Borrower Date";
            // 
            // btnconfirm
            // 
            this.btnconfirm.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnconfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnconfirm.ForeColor = System.Drawing.SystemColors.Control;
            this.btnconfirm.Location = new System.Drawing.Point(100, 445);
            this.btnconfirm.Margin = new System.Windows.Forms.Padding(2);
            this.btnconfirm.Name = "btnconfirm";
            this.btnconfirm.Size = new System.Drawing.Size(183, 47);
            this.btnconfirm.TabIndex = 5;
            this.btnconfirm.Text = "Confirm Loan";
            this.btnconfirm.UseVisualStyleBackColor = false;
            this.btnconfirm.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnclear
            // 
            this.btnclear.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnclear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclear.ForeColor = System.Drawing.SystemColors.Control;
            this.btnclear.Location = new System.Drawing.Point(817, 443);
            this.btnclear.Margin = new System.Windows.Forms.Padding(2);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(167, 48);
            this.btnclear.TabIndex = 6;
            this.btnclear.Text = "Clear";
            this.btnclear.UseVisualStyleBackColor = false;
            this.btnclear.Click += new System.EventHandler(this.button2_Click);
            // 
            // mySqlCommand1
            // 
            this.mySqlCommand1.CacheAge = 0;
            this.mySqlCommand1.Connection = null;
            this.mySqlCommand1.EnableCaching = false;
            this.mySqlCommand1.Transaction = null;
            // 
            // txtun
            // 
            this.txtun.Location = new System.Drawing.Point(77, 171);
            this.txtun.Margin = new System.Windows.Forms.Padding(2);
            this.txtun.Name = "txtun";
            this.txtun.Size = new System.Drawing.Size(267, 22);
            this.txtun.TabIndex = 3;
            // 
            // dgvBooksToLoan
            // 
            this.dgvBooksToLoan.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.dgvBooksToLoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBooksToLoan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCopyNo,
            this.colTitle,
            this.colStatus});
            this.dgvBooksToLoan.Location = new System.Drawing.Point(570, 168);
            this.dgvBooksToLoan.Margin = new System.Windows.Forms.Padding(4);
            this.dgvBooksToLoan.Name = "dgvBooksToLoan";
            this.dgvBooksToLoan.RowHeadersWidth = 51;
            this.dgvBooksToLoan.Size = new System.Drawing.Size(430, 199);
            this.dgvBooksToLoan.TabIndex = 8;
            this.dgvBooksToLoan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBooksToLoan_CellContentClick);
            // 
            // colCopyNo
            // 
            this.colCopyNo.HeaderText = "Copy No";
            this.colCopyNo.MinimumWidth = 6;
            this.colCopyNo.Name = "colCopyNo";
            this.colCopyNo.Width = 125;
            // 
            // colTitle
            // 
            this.colTitle.HeaderText = "Title";
            this.colTitle.MinimumWidth = 6;
            this.colTitle.Name = "colTitle";
            this.colTitle.Width = 125;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Status";
            this.colStatus.MinimumWidth = 6;
            this.colStatus.Name = "colStatus";
            this.colStatus.Width = 125;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(706, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 26);
            this.label4.TabIndex = 9;
            this.label4.Text = "Book details";
            // 
            // checkuser
            // 
            this.checkuser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkuser.Location = new System.Drawing.Point(371, 168);
            this.checkuser.Name = "checkuser";
            this.checkuser.Size = new System.Drawing.Size(85, 35);
            this.checkuser.TabIndex = 10;
            this.checkuser.Text = "Check";
            this.checkuser.UseVisualStyleBackColor = true;
            this.checkuser.Click += new System.EventHandler(this.button3_Click);
            // 
            // btncancel
            // 
            this.btncancel.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btncancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancel.ForeColor = System.Drawing.SystemColors.Control;
            this.btncancel.Location = new System.Drawing.Point(494, 445);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(142, 47);
            this.btncancel.TabIndex = 11;
            this.btncancel.Text = "Back";
            this.btncancel.UseVisualStyleBackColor = false;
            this.btncancel.Click += new System.EventHandler(this.button4_Click);
            // 
            // dateTimeexpedcted
            // 
            this.dateTimeexpedcted.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeexpedcted.Location = new System.Drawing.Point(77, 299);
            this.dateTimeexpedcted.Name = "dateTimeexpedcted";
            this.dateTimeexpedcted.Size = new System.Drawing.Size(298, 26);
            this.dateTimeexpedcted.TabIndex = 7;
            this.dateTimeexpedcted.ValueChanged += new System.EventHandler(this.dateTimeexpedcted_ValueChanged);
            // 
            // LoanBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1171, 611);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.checkuser);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvBooksToLoan);
            this.Controls.Add(this.dateTimeexpedcted);
            this.Controls.Add(this.btnclear);
            this.Controls.Add(this.btnconfirm);
            this.Controls.Add(this.txtun);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "LoanBook";
            this.Text = "LoanBook";
            this.Load += new System.EventHandler(this.LoanBook_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooksToLoan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnconfirm;
        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private System.Windows.Forms.TextBox txtun;
        private System.Windows.Forms.DataGridView dgvBooksToLoan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCopyNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button checkuser;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.DateTimePicker dateTimeexpedcted;
    }
}