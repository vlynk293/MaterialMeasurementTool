using MaterialMeasurement.Data;
using MaterialMeasurement.Data.DataAccessLayer.Concrete;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaterialMeasurementTool
{
    public partial class LoginForm : MetroForm
    {
        //private MaterialMeasurementEntities db;
        private readonly UserService _userService;

        private bool canCancelClosing = false;
        private User signedInUser;
        public User SignedInUser { get { return signedInUser; } }

        public LoginForm()
        {
            _userService = new UserService();
            
            InitializeComponent();
            signedInUser = null;
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string username = this.txtUsername.Text.Trim();
            string password = this.txtPassword.Text;
            signedInUser = _userService.SignIn(username, password);

            if (signedInUser == null)
            {
                this.txtSignInError.Visible = true;
                canCancelClosing = true;
            }
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            canCancelClosing = !canCancelClosing;
            e.Cancel = !canCancelClosing;
        }
    }
}
