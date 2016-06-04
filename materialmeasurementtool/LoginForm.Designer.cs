namespace MaterialMeasurementTool
{
    partial class LoginForm
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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtUsername = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtPassword = new MetroFramework.Controls.MetroTextBox();
            this.btnSignIn = new MetroFramework.Controls.MetroButton();
            this.btnCancelSignIn = new MetroFramework.Controls.MetroButton();
            this.txtSignInError = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(55, 76);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(85, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Tên tài khoản";
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.White;
            this.txtUsername.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtUsername.Lines = new string[0];
            this.txtUsername.Location = new System.Drawing.Point(146, 72);
            this.txtUsername.MaxLength = 32767;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PasswordChar = '\0';
            this.txtUsername.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtUsername.SelectedText = "";
            this.txtUsername.Size = new System.Drawing.Size(200, 23);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.UseCustomBackColor = true;
            this.txtUsername.UseSelectable = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(77, 115);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(63, 19);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "Mật khẩu";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtPassword.Lines = new string[0];
            this.txtPassword.Location = new System.Drawing.Point(146, 111);
            this.txtPassword.MaxLength = 32767;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '•';
            this.txtPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPassword.SelectedText = "";
            this.txtPassword.Size = new System.Drawing.Size(200, 23);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.UseCustomBackColor = true;
            this.txtPassword.UseSelectable = true;
            // 
            // btnSignIn
            // 
            this.btnSignIn.BackColor = System.Drawing.Color.SkyBlue;
            this.btnSignIn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSignIn.Location = new System.Drawing.Point(240, 140);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(106, 34);
            this.btnSignIn.TabIndex = 4;
            this.btnSignIn.Text = "Đăng nhập";
            this.btnSignIn.UseCustomBackColor = true;
            this.btnSignIn.UseSelectable = true;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // btnCancelSignIn
            // 
            this.btnCancelSignIn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelSignIn.Location = new System.Drawing.Point(146, 140);
            this.btnCancelSignIn.Name = "btnCancelSignIn";
            this.btnCancelSignIn.Size = new System.Drawing.Size(88, 34);
            this.btnCancelSignIn.TabIndex = 5;
            this.btnCancelSignIn.Text = "Hủy";
            this.btnCancelSignIn.UseSelectable = true;
            // 
            // txtSignInError
            // 
            this.txtSignInError.AutoSize = true;
            this.txtSignInError.ForeColor = System.Drawing.Color.Red;
            this.txtSignInError.Location = new System.Drawing.Point(146, 186);
            this.txtSignInError.Name = "txtSignInError";
            this.txtSignInError.Size = new System.Drawing.Size(192, 19);
            this.txtSignInError.TabIndex = 6;
            this.txtSignInError.Text = "* Đăng nhập không thành công";
            this.txtSignInError.UseCustomForeColor = true;
            this.txtSignInError.Visible = false;
            // 
            // LoginForm
            // 
            this.AcceptButton = this.btnSignIn;
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Dialog;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelSignIn;
            this.ClientSize = new System.Drawing.Size(425, 225);
            this.Controls.Add(this.txtSignInError);
            this.Controls.Add(this.btnCancelSignIn);
            this.Controls.Add(this.btnSignIn);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.metroLabel1);
            this.Name = "LoginForm";
            this.Resizable = false;
            this.Text = "Đăng nhập";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtUsername;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txtPassword;
        private MetroFramework.Controls.MetroButton btnSignIn;
        private MetroFramework.Controls.MetroButton btnCancelSignIn;
        private MetroFramework.Controls.MetroLabel txtSignInError;
    }
}