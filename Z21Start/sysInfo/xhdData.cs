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
        public xhd Green1
        {
            get
            {
                xhd xhd1 = new xhd();
                xhd1.Green.strBegin = GetInfo.GetSendInfo("xhdSendGreen1", 1);
                xhd1.Green.strEnd = GetInfo.GetSendInfo("xhdSendGreen1", 2);
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
        public xhd Red1
        {
            get
            {
                xhd xhd1 = new xhd();
                xhd1.Red.strBegin = GetInfo.GetSendInfo("xhdSendRed1", 1);
                xhd1.Red.strEnd = GetInfo.GetSendInfo("xhdSendRed1", 2);
                return xhd1;
            }
        }

        public sendData DataInit(string data)
        {
            StringBuilder data1 = new StringBuilder();
            StringBuilder data2 = new StringBuilder();
            StringBuilder str1 = new StringBuilder();
            sendData sendData = new sendData();
            sendData.dataList=new List<string>();
            //str = "";
            try
            {
                if (data.Length != 8)
                {
                    Exception e1 = new Exception("数据长度不是8位");
                    throw e1;
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
                            data1.AppendFormat("{0}{1}{2}", xhd.Green.strBegin,
                                czData.Id, xhd.Green.strEnd);
                            xhd = this.Green1;
                            data2.AppendFormat("{0}{1}{2}", xhd.Green.strBegin,
                                czData.Id, xhd.Green.strEnd);
                            str1.AppendFormat("信号灯[{0}] 状态[绿]", idstring);
                            sendData.dataList.Add(data1.ToString());
                            sendData.dataList.Add(data2.ToString());
                            sendData.msg = str1.ToString();
                            sendData.error = false;
                            break;
                        }
                    //红色
                    case "00":
                        {
                            xhd = this.Red;
                            data1.AppendFormat("{0}{1}{2}", xhd.Red.strBegin,
                                czData.Id, xhd.Red.strEnd);
                            xhd = this.Red1;
                            data2.AppendFormat("{0}{1}{2}", xhd.Red.strBegin,
                                czData.Id, xhd.Red.strEnd);
                            str1.AppendFormat("信号灯[{0}] 状态[红]", idstring);
                            sendData.dataList.Add(data1.ToString());
                            sendData.dataList.Add(data2.ToString());
                            sendData.msg = str1.ToString();
                            sendData.error = false;
                            break;
                        }
                }


            }
            catch (Exception e1)
            {
                sendData.dataList = null;
                sendData.msg = e1.Message;
                sendData.error = true;
                MessageBox.Show(e1.Message, "错误");
            }

            //str = str1.ToString();
            return sendData;
            
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
