using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Z21Start.sysInfo
{
    /// <summary>
    /// 机车速度
    /// </summary>
    //public struct jc
    //{
    //    public subStr Min;
    //    public subStr Max;
    //}

    /// <summary>
    /// 机车发送数据
    /// </summary>
    public class jcSendData
    {
        //public string str = "";
        /// <summary>
        /// 获得机车数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public subStr GetjcData(string key)
        {
            subStr subStr=new subStr();
            subStr.strBegin = GetInfo.GetSendInfo(key, 1);
            subStr.strEnd = GetInfo.GetSendInfo(key, 2);
            return subStr;
        }

        private string GetStringDouByte(string str)
        {
            string result = "";
            switch (str.Length)
            {
                case 1:
                    {
                        result = "000" + str;
                        break;
                    }
                case 2:
                {
                    result = "00" + str;
                    break;
                }
                case 3:
                {
                    result = "0" + str;
                    break;
                }
                case 4:
                {
                    result = str;
                    break;
                }
            }

            return result;
        }
        public sendData DataInit(string data)
        {
            StringBuilder data1 = new StringBuilder();
            StringBuilder data2 = new StringBuilder();
            StringBuilder str1 = new StringBuilder();
            sendData sendData = new sendData();
            sendData.dataList = new List<string>();
            //str = "";
            try
            {
                if (data.Length != 8)
                {
                    Exception e1 = new Exception("数据长度不是8位");
                    throw e1;
                }

                czData czData = new czData();

                subStr subStr=new subStr();
                
                string idstring = tools.Tool.HexToDec(data.Substring(4, 2));
                int Id = Int32.Parse(idstring);
                czData.Id = this.GetStringDouByte(idstring);
                //判断前进或后退
                czData.flag = data.Substring(6, 1);
                switch (czData.flag)
                {
                    //前进(最小速度)
                    case "f":
                    case "F":
                    {
                        subStr = this.GetjcData("jcSendFMin");
                        data1.AppendFormat("{0}{1}{2}{3}", subStr.strBegin,
                            czData.Id,"8", subStr.strEnd);
                        str1.AppendFormat("机车[{0}] 状态[前进]", Id);
                        sendData.dataList.Add(data1.ToString());
                        sendData.msg = str1.ToString();
                        sendData.error = false;
                        break;
                    }
                    //后退
                    case "b":
                    case "B":
                    {
                        subStr = this.GetjcData("jcSendBMin");
                        data1.AppendFormat("{0}{1}{2}{3}", subStr.strBegin,
                            czData.Id, "0", subStr.strEnd);
                        str1.AppendFormat("机车[{0}] 状态[后退]", Id);
                        sendData.dataList.Add(data1.ToString());
                        sendData.msg = str1.ToString();
                        sendData.error = false;
                        break;
                    }
                    //停止
                    case "0":
                    {
                        subStr = this.GetjcData("jcStop");
                        data1.AppendFormat("{0}{1}{2}", subStr.strBegin,
                            czData.Id, subStr.strEnd);
                        subStr = this.GetjcData("jcStop");
                        data2.AppendFormat("{0}{1}{2}", subStr.strBegin,
                            czData.Id, subStr.strEnd);
                        str1.AppendFormat("机车[{0}] 状态[停车]", Id);
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