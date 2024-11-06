namespace BTES.Forms
{
    partial class FRM_Login
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.CMS_Options = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RefundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PNL_Login = new System.Windows.Forms.Panel();
            this.BTN_Login = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.TXT_Password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TXT_Username = new System.Windows.Forms.TextBox();
            this.CMS_Options.SuspendLayout();
            this.PNL_Login.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(335, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(400, 65);
            this.label1.TabIndex = 56;
            this.label1.Text = "Log in As Admin";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CMS_Options
            // 
            this.CMS_Options.BackColor = System.Drawing.Color.Gray;
            this.CMS_Options.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RefundToolStripMenuItem});
            this.CMS_Options.Name = "contextMenuStrip1";
            this.CMS_Options.Size = new System.Drawing.Size(140, 34);
            // 
            // RefundToolStripMenuItem
            // 
            this.RefundToolStripMenuItem.BackColor = System.Drawing.SystemColors.GrayText;
            this.RefundToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Historic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefundToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.RefundToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RefundToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Gray;
            this.RefundToolStripMenuItem.Name = "RefundToolStripMenuItem";
            this.RefundToolStripMenuItem.Size = new System.Drawing.Size(139, 30);
            this.RefundToolStripMenuItem.Text = "Refund";
            // 
            // PNL_Login
            // 
            this.PNL_Login.Controls.Add(this.BTN_Login);
            this.PNL_Login.Controls.Add(this.label3);
            this.PNL_Login.Controls.Add(this.TXT_Password);
            this.PNL_Login.Controls.Add(this.label2);
            this.PNL_Login.Controls.Add(this.TXT_Username);
            this.PNL_Login.Location = new System.Drawing.Point(267, 182);
            this.PNL_Login.Name = "PNL_Login";
            this.PNL_Login.Size = new System.Drawing.Size(566, 371);
            this.PNL_Login.TabIndex = 59;
            // 
            // BTN_Login
            // 
            this.BTN_Login.BackColor = System.Drawing.Color.Transparent;
            this.BTN_Login.FlatAppearance.BorderSize = 0;
            this.BTN_Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Login.Font = new System.Drawing.Font("Tahoma", 15.25F);
            this.BTN_Login.ForeColor = System.Drawing.Color.White;
            this.BTN_Login.Image = global::BTES.Properties.Resources.logout_main_white;
            this.BTN_Login.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTN_Login.Location = new System.Drawing.Point(171, 260);
            this.BTN_Login.Name = "BTN_Login";
            this.BTN_Login.Size = new System.Drawing.Size(249, 69);
            this.BTN_Login.TabIndex = 65;
            this.BTN_Login.Text = "  Login";
            this.BTN_Login.UseVisualStyleBackColor = false;
            this.BTN_Login.Click += new System.EventHandler(this.BTN_Login_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(75, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 37);
            this.label3.TabIndex = 64;
            this.label3.Text = "Password : ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TXT_Password
            // 
            this.TXT_Password.Font = new System.Drawing.Font("Segoe UI Emoji", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_Password.Location = new System.Drawing.Point(66, 202);
            this.TXT_Password.Name = "TXT_Password";
            this.TXT_Password.PasswordChar = '*';
            this.TXT_Password.Size = new System.Drawing.Size(434, 39);
            this.TXT_Password.TabIndex = 63;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(75, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 37);
            this.label2.TabIndex = 62;
            this.label2.Text = "UserName :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TXT_Username
            // 
            this.TXT_Username.Font = new System.Drawing.Font("Segoe UI Emoji", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_Username.Location = new System.Drawing.Point(66, 93);
            this.TXT_Username.Name = "TXT_Username";
            this.TXT_Username.Size = new System.Drawing.Size(434, 39);
            this.TXT_Username.TabIndex = 61;
            // 
            // FRM_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(145)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(1089, 645);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PNL_Login);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRM_Login";
            this.Text = "Login";
            this.CMS_Options.ResumeLayout(false);
            this.PNL_Login.ResumeLayout(false);
            this.PNL_Login.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip CMS_Options;
        private System.Windows.Forms.ToolStripMenuItem RefundToolStripMenuItem;
        private System.Windows.Forms.Panel PNL_Login;
        private System.Windows.Forms.Button BTN_Login;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TXT_Password;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TXT_Username;
    }
}