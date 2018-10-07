using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z21Start.sysInfo
{
    public class selectType
    {
        public string GetData(string data, out string str)
        {
            string result = "";
            str = "";
            string czType=data.Substring(2, 2);
            int typeNum = Int32.Parse(tools.Tool.HexToDec(czType));
            switch (typeNum)
            {
                case 208:
                {
                    dcSendData dcSendData=new dcSendData();
                    result = dcSendData.DataInit(data, out str);
                    break;
                }
                case 203:
                {
                    xhdSendData xhdSendData=new xhdSendData();
                    result = xhdSendData.DataInit(data, out str);
                    break;
                }
            }
            return result;
        }
    }
}
