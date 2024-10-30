using BTES.Business_layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTES.Forms
{
    public partial class FRM_Events : Form
    {
        public FRM_Events()
        {
            InitializeComponent();
        }

        private DataTable Dt_Events = new DataTable();

        private void Referesh()
        {
            if(Dt_Events.Rows.Count > 0)
            {
                LBL_NoRecords.Visible = false;
                CMS_Options.Enabled = true;

                // .....
            }
            else
            {
                LBL_NoRecords.Visible = true;
                CMS_Options.Enabled = false;
            }
        }

        private void FRM_Events_Load(object sender, EventArgs e)
        {
            Referesh();
        }
    }
}
