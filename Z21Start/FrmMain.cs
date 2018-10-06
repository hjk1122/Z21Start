using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//本段代码中需要新增加的命名空间
using System.Net.Sockets;
using System.Net;
using System.Threading;
using Z21Start.subForm;
using Z21Start.sysInfo;
using Z21Start.tools;

namespace Z21Start
{
    public partial class FrmMain : Form
    {
        private string localIP = "";
        private int localPort = 0;
        private string remoteIP = "";
        private int remotePort = 0;
        private  string strHex1 = "";
        //private Thread thrSend = null;
        public string StrHex
        {
            get { return strHex1; }
            set { strHex1 = value; }
        }
        public FrmMain()
        {
            InitializeComponent();
            this.txtLocalIP.Text = GetInfo.GetAppConfig("localIP");
            this.txtLocalPort.Text = GetInfo.GetAppConfig("localPort");
            this.txtRemoteIP.Text = GetInfo.GetAppConfig("remoteIP");
            this.txtRemotePort.Text = GetInfo.GetAppConfig("remotePort");
        }

        /// <summary>
        /// 用于UDP发送的网络服务类
        /// </summary>
        private UdpClient udpcSend;

        /// <summary>
        /// 用于UDP接收的网络服务类
        /// </summary>
        private UdpClient udpcRecv;


        /// <summary>
        /// 将数据发送到z21系统
        /// </summary>
        private void Send(string str)
        {
            Thread thrSend = null;
            try
            {
                //判断线程是否正常运行
                //if (thrSend.IsAlive == false)
                //{
                //    thrSend = new Thread(SendMessage);
                //}
                thrSend = new Thread(SendMessage);
                remoteIP = this.txtRemoteIP.Text.Trim();
                remotePort = int.Parse(this.txtRemotePort.Text);
                IPEndPoint localIpep = new IPEndPoint(IPAddress.Parse(localIP), localPort+1); // 本机IP，指定的端口号
                udpcSend = new UdpClient(localIpep);
                //this.SendMessage(str);
                thrSend.Start(str);
            }
            catch (Exception e1)
            {
                //MessageBox.Show(e1.Message, "错误");
                //ShowMessage(this.txtSendMsg, string.Format("错误：{0}", e1.Message));
                throw e1;
            }
            //finally
            //{
            //    //thrSend.Abort();
            //}
        }

        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="obj"></param>
        private void SendMessage(object obj)
        {
            try
            {
                //转换为16进制
                string message = (string) obj;
                //byte[] sendbytes = Encoding.UTF8.GetBytes(message);
                //16进制字符串转换为8位字节数组
                byte[] sendbytes = Tool.strToHexByte(message);
                //IPEndPoint remoteIpep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8848); // 发送到的IP地址和端口号
                IPEndPoint remoteIpep = new IPEndPoint(IPAddress.Parse(remoteIP), remotePort); // 发送到的IP地址和端口号
                udpcSend.Send(sendbytes, sendbytes.Length, remoteIpep);
                udpcSend.Close();
                //ResetTextBox(txtSendMsg);
                ShowMessage(this.txtSendMsg, string.Format("{0} 发送成功!",message));

            }
            catch (Exception e1)
            {
                ShowMessage(this.txtSendMsg, string.Format("错误：{0}", e1.Message));
                throw e1;
            }
        }

        /// <summary>
        /// 开关：在监听UDP报文阶段为true，否则为false
        /// </summary>
        bool IsUdpcRecvStart = false;

        /// <summary>
        /// 线程：不断监听UDP报文
        /// </summary>
        Thread thrRecv;

        /// <summary>
        /// 按钮：接收数据开关
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRecv_Click(object sender, EventArgs e)
        {
            try
            {
                localIP = this.txtLocalIP.Text.Trim();
                localPort = int.Parse(this.txtLocalPort.Text);
                remoteIP = this.txtRemoteIP.Text.Trim();
                remotePort = int.Parse(this.txtRemotePort.Text);

                if (!IsUdpcRecvStart) // 未监听的情况，开始监听
                {
                    //IPEndPoint localIpep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8848); // 本机IP和监听端口号
                    IPEndPoint localIpep = new IPEndPoint(IPAddress.Parse(localIP), localPort); // 本机IP和监听端口号
                    udpcRecv = new UdpClient(localIpep);
                    thrRecv = new Thread(ReceiveMessage);
                    thrRecv.Start("正在接收数据...");
                    IsUdpcRecvStart = true;
                    ShowMessage(txtRecvMsg, "UDP监听器已成功启动");
                }
                else // 正在监听的情况，终止监听
                {
                    thrRecv.Abort(); // 必须先关闭这个线程，否则会异常
                    udpcRecv.Close();
                    IsUdpcRecvStart = false;
                    ShowMessage(txtRecvMsg, "UDP监听器已成功关闭");
                }

            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "错误");
            }
        }

        /// <summary>
        /// 接收数据
        /// </summary>
        /// <param name="obj"></param>
        private void ReceiveMessage(object obj)
        {
            try
            {
                ShowMessage(txtRecvMsg, string.Format(obj.ToString()));
                IPEndPoint remoteIpep = new IPEndPoint(IPAddress.Any, 0);
                while (true)
                {
                    try
                    {
                        byte[] bytRecv = udpcRecv.Receive(ref remoteIpep);
                        //string message = Encoding.Unicode.GetString(bytRecv, 0, bytRecv.Length);
                        string message = Tool.byteToHexStr(bytRecv);
                        ShowMessage(txtRecvMsg, string.Format("{0}[{1}]", remoteIpep, message));
                        this.Send(message);
                    }
                    catch (Exception ex)
                    {
                        ShowMessage(txtRecvMsg, "错误:"+ex.Message);
                        break;
                    }
                }
            }
            catch (Exception e1)
            {
                throw e1;
            }
        }

        // 向RichTextBox中添加文本
        delegate void ShowMessageDelegate(RichTextBox txtbox, string message);

        private void ShowMessage(RichTextBox txtbox, string message)
        {
            if (txtbox.InvokeRequired)
            {
                ShowMessageDelegate showMessageDelegate = ShowMessage;
                txtbox.Invoke(showMessageDelegate, new object[] {txtbox, message});
            }
            else
            {
                txtbox.Text += message + "\r\n";
            }
        }

        // 清空指定RichTextBox中的文本
        delegate void ResetTextBoxDelegate(RichTextBox txtbox);
        /// <summary>
        /// 清空指定RichTextBox中的文本
        /// </summary>
        /// <param name="txtbox"></param>
        private void ResetTextBox(RichTextBox txtbox)
        {
            if (txtbox.InvokeRequired)
            {
                ResetTextBoxDelegate resetTextBoxDelegate = ResetTextBox;
                txtbox.Invoke(resetTextBoxDelegate, new object[] {txtbox});
            }
            else
            {
                txtbox.Text = "";
            }
        }

        /// <summary>
        /// 关闭程序，强制退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnSetXHD_Click(object sender, EventArgs e)
        {
            FrmSetXHD frmSetXhd=new FrmSetXHD();
            frmSetXhd.Show();
        }
    }
}