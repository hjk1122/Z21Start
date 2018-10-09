using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Z21Start.sysInfo
{
    /// <summary>
    /// 道岔状态
    /// </summary>
    public struct dc
    {
        public subStr ding;
        public subStr fan;

    }
    /// <summary>
    /// 道岔发送数据
    /// </summary>
    public class dcSendData
    {
      
        //道岔定位
        public dc Ding
        {
            get
            {
                dc dc1=new dc();
                dc1.ding.strBegin = GetInfo.GetSendInfo("dcSendDing",1);
                dc1.ding.strEnd = GetInfo.GetSendInfo("dcSendDing",2);
                return dc1;
            }
        }
        public dc Ding1
        {
            get
            {
                dc dc1 = new dc();
                dc1.ding.strBegin = GetInfo.GetSendInfo("dcSendDing1", 1);
                dc1.ding.strEnd = GetInfo.GetSendInfo("dcSendDing1", 2);
                return dc1;
            }
        }
        //道岔反位
        public dc Fan
        {
            get
            {
                dc dc1 = new dc();
                dc1.fan.strBegin = GetInfo.GetSendInfo("dcSendFan", 1);
                dc1.fan.strEnd = GetInfo.GetSendInfo("dcSendFan", 2);
                return dc1;
            }
        }
        public dc Fan1
        {
            get
            {
                dc dc1 = new dc();
                dc1.fan.strBegin = GetInfo.GetSendInfo("dcSendFan1", 1);
                dc1.fan.strEnd = GetInfo.GetSendInfo("dcSendFan1", 2);
                return dc1;
            }
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public sendData DataInit(string data)
        {
            StringBuilder data1 = new StringBuilder();
            StringBuilder data2 = new StringBuilder();
            StringBuilder str1=new StringBuilder();
            sendData sendData=new sendData();
            sendData.dataList = new List<string>();
            //str = "";
            try
            {
                if (data.Length != 8)
                {
                    Exception e1=new Exception("数据长度不是8位");
                    throw e1;
                }
                czData czData=new czData();

                dc dc = new dc();
                //编号为现有数字减一
                string idstring = tools.Tool.HexToDec(data.Substring(4, 2));
                int Id = Int32.Parse(idstring)-1;
                czData.Id = tools.Tool.DecToHex(Id);
                czData.flag = data.Substring(6, 2);
                switch (czData.flag)
                {
                    //定位
                    case "00":
                        {
                            dc = this.Ding;
                            data1.AppendFormat("{0}{1}{2}", dc.ding.strBegin,
                                czData.Id, dc.ding.strEnd);
                            dc = this.Ding1;
                            data2.AppendFormat("{0}{1}{2}", dc.ding.strBegin,
                                czData.Id, dc.ding.strEnd);
                            str1.AppendFormat("道岔[{0}] 状态[定位]", idstring);
                            sendData.dataList.Add(data1.ToString());
                            sendData.dataList.Add(data2.ToString());
                            sendData.msg = str1.ToString();
                            sendData.error = false;
                            break;
                        }
                    //反位
                    case "01":
                        {
                            dc = this.Fan;
                            data1.AppendFormat("{0}{1}{2}", dc.fan.strBegin,
                                czData.Id, dc.fan.strEnd);
                            dc = this.Fan1;
                            data2.AppendFormat("{0}{1}{2}", dc.fan.strBegin,
                                czData.Id, dc.fan.strEnd);
                            str1.AppendFormat("道岔[{0}] 状态[反位]", idstring);
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
    
}
