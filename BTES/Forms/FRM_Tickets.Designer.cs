namespace BTES.Forms
{
    partial class FRM_Tickets
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvEvent = new System.Windows.Forms.DataGridView();
            this.CMS_Options = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RefundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LBL_NoRecords = new System.Windows.Forms.Label();
            this.PNL_Login = new System.Windows.Forms.Panel();
            this.BTN_Login = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.TXT_Password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TXT_Username = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvent)).BeginInit();
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
            this.label1.Location = new System.Drawing.Point(281, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(430, 65);
            this.label1.TabIndex = 52;
            this.label1.Text = "Purchased Tickets";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvEvent
            // 
            this.dgvEvent.AllowUserToAddRows = false;
            this.dgvEvent.AllowUserToDeleteRows = false;
            this.dgvEvent.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.dgvEvent.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEvent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEvent.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvEvent.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvEvent.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvEvent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEvent.ColumnHeadersHeight = 30;
            this.dgvEvent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvEvent.ContextMenuStrip = this.CMS_Options;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(133)))), ((int)(((byte)(147)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEvent.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvEvent.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvEvent.EnableHeadersVisualStyles = false;
            this.dgvEvent.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(199)))), ((int)(((byte)(206)))));
            this.dgvEvent.Location = new System.Drawing.Point(18, 151);
            this.dgvEvent.Name = "dgvEvent";
            this.dgvEvent.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEvent.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.dgvEvent.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvEvent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEvent.ShowCellToolTips = false;
            this.dgvEvent.Size = new System.Drawing.Size(959, 455);
            this.dgvEvent.TabIndex = 53;
            this.dgvEvent.Visible = false;
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
            // LBL_NoRecords
            // 
            this.LBL_NoRecords.AutoSize = true;
            this.LBL_NoRecords.BackColor = System.Drawing.Color.WhiteSmoke;
            this.LBL_NoRecords.Font = new System.Drawing.Font("Segoe UI Semibold", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_NoRecords.Location = new System.Drawing.Point(167, 366);
            this.LBL_NoRecords.Name = "LBL_NoRecords";
            this.LBL_NoRecords.Size = new System.Drawing.Size(631, 54);
            this.LBL_NoRecords.TabIndex = 54;
            this.LBL_NoRecords.Text = "There Are No Purchased Tickets !!";
            this.LBL_NoRecords.Visible = false;
            // 
            // PNL_Login
            // 
            this.PNL_Login.Controls.Add(this.BTN_Login);
            this.PNL_Login.Controls.Add(this.label3);
            this.PNL_Login.Controls.Add(this.TXT_Password);
            this.PNL_Login.Controls.Add(this.label2);
            this.PNL_Login.Controls.Add(this.TXT_Username);
            this.PNL_Login.Location = new System.Drawing.Point(218, 179);
            this.PNL_Login.Name = "PNL_Login";
            this.PNL_Login.Size = new System.Drawing.Size(566, 371);
            this.PNL_Login.TabIndex = 55;
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
            // FRM_Tickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(145)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(989, 645);
            this.Controls.Add(this.PNL_Login);
            this.Controls.Add(this.LBL_NoRecords);
            this.Controls.Add(this.dgvEvent);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRM_Tickets";
            this.Text = "FRM_Tickets";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvent)).EndInit();
            this.CMS_Options.ResumeLayout(false);
            this.PNL_Login.ResumeLayout(false);
            this.PNL_Login.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvEvent;
        private System.Windows.Forms.Label LBL_NoRecords;
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