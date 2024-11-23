namespace BTES.Forms.Events
{
    partial class FRM_RaateEvent
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LBL_Title = new System.Windows.Forms.Label();
            this.lblEventID = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.txtComent = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.BTN_Close = new System.Windows.Forms.Button();
            this.BTN_Save = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BTES.Properties.Resources.Number_32;
            this.pictureBox1.Location = new System.Drawing.Point(142, 62);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 33);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 108;
            this.pictureBox1.TabStop = false;
            // 
            // LBL_Title
            // 
            this.LBL_Title.AutoSize = true;
            this.LBL_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Title.ForeColor = System.Drawing.Color.Navy;
            this.LBL_Title.Location = new System.Drawing.Point(230, 9);
            this.LBL_Title.Name = "LBL_Title";
            this.LBL_Title.Size = new System.Drawing.Size(194, 39);
            this.LBL_Title.TabIndex = 105;
            this.LBL_Title.Text = "Rate event";
            // 
            // lblEventID
            // 
            this.lblEventID.AutoSize = true;
            this.lblEventID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventID.Location = new System.Drawing.Point(184, 74);
            this.lblEventID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEventID.Name = "lblEventID";
            this.lblEventID.Size = new System.Drawing.Size(26, 18);
            this.lblEventID.TabIndex = 107;
            this.lblEventID.Text = "##";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(26, 71);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(100, 24);
            this.label22.TabIndex = 106;
            this.label22.Text = "Event ID :";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::BTES.Properties.Resources.icons8_location_50;
            this.pictureBox5.Location = new System.Drawing.Point(142, 170);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(31, 33);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 146;
            this.pictureBox5.TabStop = false;
            // 
            // txtRate
            // 
            this.txtRate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRate.Location = new System.Drawing.Point(191, 183);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(142, 23);
            this.txtRate.TabIndex = 144;
            this.txtRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLocation_KeyPress);
            this.txtRate.Validating += new System.ComponentModel.CancelEventHandler(this.txtRate_Validating);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::BTES.Properties.Resources.icons8_title_50;
            this.pictureBox2.Location = new System.Drawing.Point(142, 115);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(31, 33);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 143;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 124);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 24);
            this.label1.TabIndex = 142;
            this.label1.Text = "Username :";
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(191, 124);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(142, 23);
            this.txtUsername.TabIndex = 141;
            this.txtUsername.Validating += new System.ComponentModel.CancelEventHandler(this.txtUsername_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(54, 179);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 24);
            this.label2.TabIndex = 147;
            this.label2.Text = "Rate :";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::BTES.Properties.Resources.icons8_index_64;
            this.pictureBox3.Location = new System.Drawing.Point(142, 239);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(31, 33);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 150;
            this.pictureBox3.TabStop = false;
            // 
            // txtComent
            // 
            this.txtComent.Location = new System.Drawing.Point(191, 239);
            this.txtComent.Multiline = true;
            this.txtComent.Name = "txtComent";
            this.txtComent.Size = new System.Drawing.Size(455, 74);
            this.txtComent.TabIndex = 148;
            this.txtComent.Validating += new System.ComponentModel.CancelEventHandler(this.txtComent_Validating);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(24, 248);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(94, 24);
            this.label13.TabIndex = 149;
            this.label13.Text = "Coment :";
            // 
            // BTN_Close
            // 
            this.BTN_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BTN_Close.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BTN_Close.Image = global::BTES.Properties.Resources.cancel_32;
            this.BTN_Close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTN_Close.Location = new System.Drawing.Point(441, 326);
            this.BTN_Close.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BTN_Close.Name = "BTN_Close";
            this.BTN_Close.Size = new System.Drawing.Size(99, 34);
            this.BTN_Close.TabIndex = 152;
            this.BTN_Close.Text = "Close    ";
            this.BTN_Close.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTN_Close.UseVisualStyleBackColor = true;
            this.BTN_Close.Click += new System.EventHandler(this.BTN_Close_Click);
            // 
            // BTN_Save
            // 
            this.BTN_Save.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BTN_Save.Image = global::BTES.Properties.Resources.confirm_32;
            this.BTN_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTN_Save.Location = new System.Drawing.Point(548, 326);
            this.BTN_Save.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BTN_Save.Name = "BTN_Save";
            this.BTN_Save.Size = new System.Drawing.Size(98, 34);
            this.BTN_Save.TabIndex = 151;
            this.BTN_Save.Text = "Save     ";
            this.BTN_Save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTN_Save.UseVisualStyleBackColor = true;
            this.BTN_Save.Click += new System.EventHandler(this.BTN_Save_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FRM_RaateEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 374);
            this.Controls.Add(this.BTN_Close);
            this.Controls.Add(this.BTN_Save);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.txtComent);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.txtRate);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LBL_Title);
            this.Controls.Add(this.lblEventID);
            this.Controls.Add(this.label22);
            this.Name = "FRM_RaateEvent";
            this.Text = "FRM_RaateEvent";
            this.Load += new System.EventHandler(this.FRM_RaateEvent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LBL_Title;
        private System.Windows.Forms.Label lblEventID;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox txtComent;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button BTN_Close;
        private System.Windows.Forms.Button BTN_Save;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}