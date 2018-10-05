using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Z21Start.sysInfo;
using Z21Start.tools;

namespace Z21Start.subForm
{
    public partial class FrmSetXHD : Form
    {
        public FrmSetXHD()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder result=new StringBuilder();
                int num = Int32.Parse(this.txtNum.Text.Trim());
                string strHex = Tool.DecToHex(num);
                xhdSendData xhdSendData=new xhdSendData();
                xhd xhd=new xhd();
                switch (this.cboColor.Text)
                {
                    case "绿色":
                    {
                        xhd = xhdSendData.Green;
                        result.AppendFormat("{0}{1}{2}", xhd.Green.strBegin,
                            strHex, xhd.Green.strBegin);
                        break;
                    }
                    case "红色":
                    {
                        xhd = xhdSendData.Red;
                        result.AppendFormat("{0}{1}{2}", xhd.Red.strBegin,
                            strHex, xhd.Red.strBegin);
                        break;
                    }
                }

                (this.ParentForm as Form2).StrHex = result.ToString();
                this.Close();

            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "错误");
            }
        }
    }
}
