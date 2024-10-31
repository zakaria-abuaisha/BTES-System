namespace BTES
{
    partial class frmMain
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BTN_Logout = new System.Windows.Forms.Button();
            this.BTN_Login = new System.Windows.Forms.Button();
            this.BTN_Tickets = new System.Windows.Forms.Button();
            this.BTN_Event = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CMS_Options = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.purchaseTicketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PNL_Form = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.CMS_Options.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(82)))), ((int)(((byte)(160)))));
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.BTN_Tickets);
            this.panel1.Controls.Add(this.BTN_Event);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(265, 645);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.BTN_Logout);
            this.panel3.Controls.Add(this.BTN_Login);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 568);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(265, 77);
            this.panel3.TabIndex = 0;
            // 
            // BTN_Logout
            // 
            this.BTN_Logout.BackColor = System.Drawing.Color.Transparent;
            this.BTN_Logout.FlatAppearance.BorderSize = 0;
            this.BTN_Logout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Logout.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Logout.ForeColor = System.Drawing.Color.White;
            this.BTN_Logout.Image = global::BTES.Properties.Resources.logout_main_white;
            this.BTN_Logout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTN_Logout.Location = new System.Drawing.Point(19, 13);
            this.BTN_Logout.Name = "BTN_Logout";
            this.BTN_Logout.Size = new System.Drawing.Size(211, 56);
            this.BTN_Logout.TabIndex = 5;
            this.BTN_Logout.Text = "Logout";
            this.BTN_Logout.UseVisualStyleBackColor = false;
            this.BTN_Logout.Visible = false;
            // 
            // BTN_Login
            // 
            this.BTN_Login.BackColor = System.Drawing.Color.Transparent;
            this.BTN_Login.FlatAppearance.BorderSize = 0;
            this.BTN_Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Login.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Login.ForeColor = System.Drawing.Color.White;
            this.BTN_Login.Image = global::BTES.Properties.Resources.logout_main_white;
            this.BTN_Login.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTN_Login.Location = new System.Drawing.Point(19, 13);
            this.BTN_Login.Name = "BTN_Login";
            this.BTN_Login.Size = new System.Drawing.Size(211, 56);
            this.BTN_Login.TabIndex = 4;
            this.BTN_Login.Text = "Login";
            this.BTN_Login.UseVisualStyleBackColor = false;
            // 
            // BTN_Tickets
            // 
            this.BTN_Tickets.BackColor = System.Drawing.Color.Transparent;
            this.BTN_Tickets.FlatAppearance.BorderSize = 0;
            this.BTN_Tickets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Tickets.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Tickets.ForeColor = System.Drawing.Color.White;
            this.BTN_Tickets.Image = global::BTES.Properties.Resources.icons8_ticket_50__1_;
            this.BTN_Tickets.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTN_Tickets.Location = new System.Drawing.Point(32, 195);
            this.BTN_Tickets.Name = "BTN_Tickets";
            this.BTN_Tickets.Size = new System.Drawing.Size(211, 56);
            this.BTN_Tickets.TabIndex = 2;
            this.BTN_Tickets.Text = " Tickets";
            this.BTN_Tickets.UseVisualStyleBackColor = false;
            this.BTN_Tickets.Click += new System.EventHandler(this.BTN_Tickets_Click);
            // 
            // BTN_Event
            // 
            this.BTN_Event.BackColor = System.Drawing.Color.Transparent;
            this.BTN_Event.FlatAppearance.BorderSize = 0;
            this.BTN_Event.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Event.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Event.ForeColor = System.Drawing.Color.White;
            this.BTN_Event.Image = global::BTES.Properties.Resources.icons8_event_48;
            this.BTN_Event.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTN_Event.Location = new System.Drawing.Point(32, 124);
            this.BTN_Event.Name = "BTN_Event";
            this.BTN_Event.Size = new System.Drawing.Size(211, 56);
            this.BTN_Event.TabIndex = 0;
            this.BTN_Event.Text = "Event";
            this.BTN_Event.UseVisualStyleBackColor = false;
            this.BTN_Event.Click += new System.EventHandler(this.BTN_Event_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.label2.Location = new System.Drawing.Point(135, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Event System";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(114, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Booking Ticket";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BTES.Properties.Resources.ticket_5408974__1_;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(105, 87);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // CMS_Options
            // 
            this.CMS_Options.BackColor = System.Drawing.Color.Gray;
            this.CMS_Options.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.purchaseTicketToolStripMenuItem});
            this.CMS_Options.Name = "contextMenuStrip1";
            this.CMS_Options.Size = new System.Drawing.Size(211, 34);
            // 
            // purchaseTicketToolStripMenuItem
            // 
            this.purchaseTicketToolStripMenuItem.BackColor = System.Drawing.SystemColors.GrayText;
            this.purchaseTicketToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Historic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.purchaseTicketToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.purchaseTicketToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Gray;
            this.purchaseTicketToolStripMenuItem.Name = "purchaseTicketToolStripMenuItem";
            this.purchaseTicketToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.purchaseTicketToolStripMenuItem.Text = "Purchase Ticket";
            // 
            // PNL_Form
            // 
            this.PNL_Form.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PNL_Form.Location = new System.Drawing.Point(265, 0);
            this.PNL_Form.Name = "PNL_Form";
            this.PNL_Form.Size = new System.Drawing.Size(1202, 645);
            this.PNL_Form.TabIndex = 1;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(145)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(1467, 645);
            this.Controls.Add(this.PNL_Form);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BTES";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.CMS_Options.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BTN_Event;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button BTN_Login;
        private System.Windows.Forms.Button BTN_Tickets;
        private System.Windows.Forms.Button BTN_Logout;
        private System.Windows.Forms.ContextMenuStrip CMS_Options;
        private System.Windows.Forms.ToolStripMenuItem purchaseTicketToolStripMenuItem;
        private System.Windows.Forms.Panel PNL_Form;
    }
}

