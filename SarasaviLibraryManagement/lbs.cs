using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SarasaviLibraryManagement
{
    public partial class lbs : Form
    {
        public lbs()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserRegistration br = new UserRegistration();
            br.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            BookRegistration br = new BookRegistration();
            br.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoanBook br = new LoanBook();
            br.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ReturnBook br = new ReturnBook();
            br.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Resevation br = new Resevation();
            br.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Inquiry br = new Inquiry();
            br.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            this.Owner?.Show();
            this.Close();
        }
    }
}
