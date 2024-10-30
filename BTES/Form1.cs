using BTES.Business_layer;
using BTES.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTES
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            frmAddEvent frm = new frmAddEvent();
            frm.ShowDialog();
        }
    }
}
