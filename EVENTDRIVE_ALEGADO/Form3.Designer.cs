namespace EVENTDRIVE_ALEGADO
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.pnlSignIn = new System.Windows.Forms.Panel();
            this.chkshowpassword = new System.Windows.Forms.CheckBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblSign = new System.Windows.Forms.Label();
            this.pnlSignIn.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSignIn
            // 
            this.pnlSignIn.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pnlSignIn.Controls.Add(this.chkshowpassword);
            this.pnlSignIn.Controls.Add(this.btnLogin);
            this.pnlSignIn.Controls.Add(this.txtPassword);
            this.pnlSignIn.Controls.Add(this.txtUsername);
            this.pnlSignIn.Controls.Add(this.lblPassword);
            this.pnlSignIn.Controls.Add(this.lblUsername);
            this.pnlSignIn.Controls.Add(this.lblSign);
            this.pnlSignIn.Location = new System.Drawing.Point(223, 165);
            this.pnlSignIn.Name = "pnlSignIn";
            this.pnlSignIn.Size = new System.Drawing.Size(369, 262);
            this.pnlSignIn.TabIndex = 0;
            // 
            // chkshowpassword
            // 
            this.chkshowpassword.AutoSize = true;
            this.chkshowpassword.BackColor = System.Drawing.Color.Transparent;
            this.chkshowpassword.Location = new System.Drawing.Point(223, 161);
            this.chkshowpassword.Name = "chkshowpassword";
            this.chkshowpassword.Size = new System.Drawing.Size(101, 17);
            this.chkshowpassword.TabIndex = 15;
            this.chkshowpassword.Text = "Show password";
            this.chkshowpassword.UseVisualStyleBackColor = false;
            this.chkshowpassword.CheckedChanged += new System.EventHandler(this.chkshowpassword_CheckedChanged);
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(138, 200);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(92, 32);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(139, 133);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(185, 20);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(139, 101);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(185, 20);
            this.txtUsername.TabIndex = 1;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(43, 133);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(88, 18);
            this.lblPassword.TabIndex = 14;
            this.lblPassword.Text = "Password:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.BackColor = System.Drawing.Color.Transparent;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(43, 100);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(90, 18);
            this.lblUsername.TabIndex = 13;
            this.lblUsername.Text = "Username:";
            // 
            // lblSign
            // 
            this.lblSign.AutoSize = true;
            this.lblSign.BackColor = System.Drawing.Color.Transparent;
            this.lblSign.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSign.Location = new System.Drawing.Point(152, 31);
            this.lblSign.Name = "lblSign";
            this.lblSign.Size = new System.Drawing.Size(75, 24);
            this.lblSign.TabIndex = 12;
            this.lblSign.Text = "Sign In";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 498);
            this.Controls.Add(this.pnlSignIn);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.pnlSignIn.ResumeLayout(false);
            this.pnlSignIn.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSignIn;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblSign;
        private System.Windows.Forms.CheckBox chkshowpassword;
    }
}