using EvaluationManager.Models;
using EvaluationManager.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvaluationManager
{
    public partial class FrmLogin : Form
    {
        public static Teacher LoggedTeacher { get; set; }
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (txtUsername.Text == "" || txtPassword.Text == "") {
                MessageBox.Show("Popunite sva polja", "Pogreška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else
                LoggedTeacher = TeacherRepository.GetTeacher(txtUsername.Text);
            if(LoggedTeacher != null &&  LoggedTeacher.Password == txtPassword.Text)
            {
                FrmStudents frmStudents = new FrmStudents();
                frmStudents.Text = $"{LoggedTeacher.FirstName} {LoggedTeacher.LastName}";
                Hide();
                frmStudents.ShowDialog();
                Close();
            }
        }
    }
}
