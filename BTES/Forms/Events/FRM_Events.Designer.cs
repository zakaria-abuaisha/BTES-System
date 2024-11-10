namespace BTES.Forms.Events
{
    partial class FRM_Events
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
            this.CMS_Options = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.purchaseTicketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LBL_NoRecords = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvEvent = new System.Windows.Forms.DataGridView();
            this.BTN_AddEvent = new System.Windows.Forms.Button();
            this.CMS_Options.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvent)).BeginInit();
            this.SuspendLayout();
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
            this.purchaseTicketToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.purchaseTicketToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.purchaseTicketToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Gray;
            this.purchaseTicketToolStripMenuItem.Name = "purchaseTicketToolStripMenuItem";
            this.purchaseTicketToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.purchaseTicketToolStripMenuItem.Text = "Purchase Ticket";
            this.purchaseTicketToolStripMenuItem.Click += new System.EventHandler(this.purchaseTicketToolStripMenuItem_Click);
            // 
            // LBL_NoRecords
            // 
            this.LBL_NoRecords.AutoSize = true;
            this.LBL_NoRecords.BackColor = System.Drawing.Color.Transparent;
            this.LBL_NoRecords.Font = new System.Drawing.Font("Segoe UI Semibold", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_NoRecords.Location = new System.Drawing.Point(189, 380);
            this.LBL_NoRecords.Name = "LBL_NoRecords";
            this.LBL_NoRecords.Size = new System.Drawing.Size(750, 54);
            this.LBL_NoRecords.TabIndex = 66;
            this.LBL_NoRecords.Text = "Sorry, There Are Not Events For Now  :-(";
            this.LBL_NoRecords.Visible = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(442, 39);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(175, 65);
            this.lblTitle.TabIndex = 65;
            this.lblTitle.Text = "Events";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvEvent
            // 
            this.dgvEvent.AllowUserToAddRows = false;
            this.dgvEvent.AllowUserToDeleteRows = false;
            this.dgvEvent.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(171)))), ((int)(((byte)(237)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvEvent.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEvent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEvent.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvEvent.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvEvent.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(82)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEvent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEvent.ColumnHeadersHeight = 40;
            this.dgvEvent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvEvent.ContextMenuStrip = this.CMS_Options;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEvent.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvEvent.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvEvent.EnableHeadersVisualStyles = false;
            this.dgvEvent.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(199)))), ((int)(((byte)(206)))));
            this.dgvEvent.Location = new System.Drawing.Point(13, 150);
            this.dgvEvent.MultiSelect = false;
            this.dgvEvent.Name = "dgvEvent";
            this.dgvEvent.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.CornflowerBlue;
            this.dgvEvent.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEvent.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvEvent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEvent.ShowCellToolTips = false;
            this.dgvEvent.Size = new System.Drawing.Size(1063, 455);
            this.dgvEvent.TabIndex = 64;
            this.dgvEvent.SelectionChanged += new System.EventHandler(this.dgvEvent_SelectionChanged);
            // 
            // BTN_AddEvent
            // 
            this.BTN_AddEvent.FlatAppearance.BorderSize = 0;
            this.BTN_AddEvent.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BTN_AddEvent.Image = global::BTES.Properties.Resources.icons8_add_event_48;
            this.BTN_AddEvent.Location = new System.Drawing.Point(1001, 82);
            this.BTN_AddEvent.Name = "BTN_AddEvent";
            this.BTN_AddEvent.Size = new System.Drawing.Size(75, 62);
            this.BTN_AddEvent.TabIndex = 67;
            this.BTN_AddEvent.UseVisualStyleBackColor = true;
            this.BTN_AddEvent.Visible = false;
            this.BTN_AddEvent.Click += new System.EventHandler(this.BTN_AddEvent_Click);
            // 
            // FRM_Events
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(145)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(1089, 645);
            this.Controls.Add(this.BTN_AddEvent);
            this.Controls.Add(this.LBL_NoRecords);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvEvent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRM_Events";
            this.Text = "FRM_Events";
            this.Load += new System.EventHandler(this.FRM_Events_Load);
            this.CMS_Options.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip CMS_Options;
        private System.Windows.Forms.ToolStripMenuItem purchaseTicketToolStripMenuItem;
        private System.Windows.Forms.Button BTN_AddEvent;
        private System.Windows.Forms.Label LBL_NoRecords;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvEvent;
    }
}