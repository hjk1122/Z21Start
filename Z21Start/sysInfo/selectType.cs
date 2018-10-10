using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Z21Start.sysInfo
{
    /// <summary>
    /// 要发送的数据
    /// </summary>
    public struct sendData
    {
        public List<string> dataList;
        public string msg;
        public bool error;
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
    public class selectType
    {
        public sendData GetData(string data)
        {
            sendData sendData=new sendData();
            //str = "";
            string czType=data.Substring(2, 2);
            int typeNum = Int32.Parse(tools.Tool.HexToDec(czType));
            switch (typeNum)
            {
                case 208:
                {
                    dcSendData dcSendData=new dcSendData();
                    sendData = dcSendData.DataInit(data);
                    break;
                }
                case 203:
                {
                    xhdSendData xhdSendData=new xhdSendData();
                    sendData = xhdSendData.DataInit(data);
                    break;
                }
                case 1:
                {
                    jcSendData jcSendData=new jcSendData();
                    sendData = jcSendData.DataInit(data);
                    break;
                }
            }
            return sendData;
        }

    }
}
