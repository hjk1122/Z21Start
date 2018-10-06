using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Z21Start.sysInfo
{
    public class GetInfo
    {
        /// <summary>
        /// 返回＊.exe.config文件中appSettings配置节的value项
        /// </summary>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static string GetAppConfig(string strKey)
        {
            foreach (string key in ConfigurationManager.AppSettings)
            {
                if (key == strKey)
                {
                    return ConfigurationManager.AppSettings[strKey];
                }
            }
            return null;
        }
        /// <summary>
        /// 获得要发送的数据
        /// </summary>
        /// <param name="strKey"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        public static string GetSendInfo(string strKey, int flag)
        {
            string result = "";
            try
            {
                string[] str = GetAppConfig(strKey).Split('_');
                switch (flag)
                {
                    case 1:
                        {
                            result = str[0].ToString().Trim();
                            break;
                        }
                    case 2:
                        {
                            result = str[1].ToString().Trim();
                            break;
                        }
                    default:
                        {
                            result = "-1";
                            break;
                        }
                }
            }
            catch (Exception e)
            {
                result = "-1";
            }

            return result;
        }
    }
}
