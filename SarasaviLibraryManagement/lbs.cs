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

        private Form activeForm;
        private readonly Stack<Type> backStack = new Stack<Type>();

        private void LoadFormToPanel(Panel targetPanel, Form frm, bool addToHistory = true)
        {
            if (targetPanel == null) throw new ArgumentNullException(nameof(targetPanel));
            if (frm == null) throw new ArgumentNullException(nameof(frm));

            targetPanel.SuspendLayout();

            if (activeForm != null && addToHistory)
                backStack.Push(activeForm.GetType());

           
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm.Dispose();
                activeForm = null;
            }

           
            foreach (Control c in targetPanel.Controls) c.Dispose();
            targetPanel.Controls.Clear();

           
            activeForm = frm;
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            targetPanel.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();

            targetPanel.ResumeLayout();
        }

        
        public void BackToPrevious(Panel targetPanel)
        {
            if (backStack.Count > 0)
            {
                var prevType = backStack.Pop();
                var prevForm = (Form)Activator.CreateInstance(prevType);
                LoadFormToPanel(targetPanel, prevForm, addToHistory: false);
            }
            else
            {
               
                if (activeForm != null)
                {
                    activeForm.Close();
                    activeForm.Dispose();
                    activeForm = null;
                }
                foreach (Control c in targetPanel.Controls) c.Dispose();
                targetPanel.Controls.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

           LoadFormToPanel(panel4, new UserRegistration(this));
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lbs_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            LoadFormToPanel(panel4, new BookRegistration());
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            LoadFormToPanel(panel4, new LoanBook());
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            LoadFormToPanel(panel4, new ReturnBook()); 
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            LoadFormToPanel(panel4, new Resevation());
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            LoadFormToPanel(panel4, new Inquiry());
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            LoadFormToPanel(panel4, new AdminPermission()); 
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }
    }
}
