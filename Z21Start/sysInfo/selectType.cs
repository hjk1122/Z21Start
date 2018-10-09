using System;
using System.Collections.Generic;
using System.Linq;
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
            }
            return sendData;
        }
    }
}
