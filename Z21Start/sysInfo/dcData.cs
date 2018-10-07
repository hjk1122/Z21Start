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

                dc dc = new dc();
                //编号为现有数字减一
                string idstring = tools.Tool.HexToDec(data.Substring(4, 2));
                int Id = Int32.Parse(tools.Tool.HexToDec(data.Substring(4, 2)))-1;
                czData.Id = tools.Tool.DecToHex(Id);
                czData.flag = data.Substring(6, 2);
                switch (czData.flag)
                {
                    //定位
                    case "00":
                        {
                            dc = this.Ding;
                            result.AppendFormat("{0}{1}{2}", dc.ding.strBegin,
                                czData.Id, dc.ding.strEnd);
                            str1.AppendFormat("道岔[{0}] 状态[定位]", idstring);
                            break;
                        }
                    //反位
                    case "01":
                        {
                            dc = this.Fan;
                            result.AppendFormat("{0}{1}{2}", dc.fan.strBegin,
                                czData.Id, dc.fan.strEnd);
                            str1.AppendFormat("道岔[{0}] 状态[反位]", idstring);
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
    
}
