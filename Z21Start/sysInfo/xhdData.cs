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
    /// <summary>
    /// 信号灯状态
    /// </summary>
    public struct xhd
    {
        public subStr Green;
        public subStr Red;

    }
    /// <summary>
    /// 操作数据
    /// </summary>
    public struct czData
    {
        //操作对象编号
        public string Id;
        //操作状态
        public string flag;
    }
    /// <summary>
    /// 信号灯发送数据
    /// </summary>
    public class xhdSendData
    {
        //public string str = "";
        public xhd Green
        {
            get
            {
                xhd xhd1=new xhd();
                xhd1.Green.strBegin = GetInfo.GetSendInfo("xhdSendGreen",1);
                xhd1.Green.strEnd = GetInfo.GetSendInfo("xhdSendGreen",2);
                return xhd1;
            }
        }
        public xhd Red
        {
            get
            {
                xhd xhd1 = new xhd();
                xhd1.Red.strBegin = GetInfo.GetSendInfo("xhdSendRed",1);
                xhd1.Red.strEnd = GetInfo.GetSendInfo("xhdSendRed",2);
                return xhd1;
            }
        }

        public string DataInit(string data,out string str)
        {
            StringBuilder result = new StringBuilder();
            StringBuilder str1=new StringBuilder();
            str = "";
            try
            {
                if (data.Length != 8)
                {
                    result.Append("-1");
                    return result.ToString();
                }
                czData czData=new czData();
                
                xhd xhd = new xhd();
                //编号为现有数字减一
                string idstring = tools.Tool.HexToDec(data.Substring(4, 2));
                int Id = Int32.Parse(idstring) - 1;
                czData.Id = tools.Tool.DecToHex(Id);
                czData.flag = data.Substring(6, 2);
                switch (czData.flag)
                {
                    //绿色
                    case "01":
                        {
                            xhd = this.Green;
                            result.AppendFormat("{0}{1}{2}", xhd.Green.strBegin,
                                czData.Id, xhd.Green.strEnd);
                            str1.AppendFormat("信号灯[{0}] 状态[绿]", idstring);
                            break;
                        }
                    //红色
                    case "00":
                        {
                            xhd = this.Red;
                            result.AppendFormat("{0}{1}{2}", xhd.Red.strBegin,
                                czData.Id, xhd.Red.strEnd);
                            str1.AppendFormat("信号灯[{0}] 状态[红]", idstring);
                            break;
                        }
                }


            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "错误");
            }

            str = str1.ToString();
            return result.ToString();
            
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
