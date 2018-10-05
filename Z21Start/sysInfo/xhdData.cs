using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Z21Start.sysInfo
{
    public struct subStr
    {
        public string strBegin;
        public string strEnd;

    }
    public struct xhd
    {
        public subStr Green;
        public subStr Red;

    }
    /// <summary>
    /// 信号灯发送数据
    /// </summary>
    public class xhdSendData
    {
        public xhd Green
        {
            get
            {
                xhd xhd1=new xhd();
                xhd1.Green.strBegin = "090040005300";
                xhd1.Green.strEnd = "89b1";
                return xhd1;
            }
        }
        public xhd Red
        {
            get
            {
                xhd xhd1 = new xhd();
                xhd1.Green.strBegin = "090040005300";
                xhd1.Green.strEnd = "88b0";
                return xhd1;
            }
        }
    }
    /// <summary>
    /// 信号灯返回数据
    /// </summary>
    public class xhdRecvData
    {
        public xhd Green
        {
            get
            {
                xhd xhd1 = new xhd();
                xhd1.Green.strBegin = "090040004300";
                xhd1.Green.strEnd = "022a";
                return xhd1;
            }
        }
        public xhd Red
        {
            get
            {
                xhd xhd1 = new xhd();
                xhd1.Green.strBegin = "090040004300";
                xhd1.Green.strEnd = "0129";
                return xhd1;
            }
        }
    }
}
