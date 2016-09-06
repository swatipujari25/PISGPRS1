using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common;
using Communication;
using Logger;

namespace PISGPRS
{
    public partial class ucUploadFile : UserControl
    {
        string currentStatus = string.Empty;
        public delegate void DisplayStatus();
        public DisplayStatus StatusDelegate;

        public ucUploadFile()
        {
            InitializeComponent();
        }

        private void InvokeCurrentStatus()
        {
            try
            {
                lblStatus.Invoke(StatusDelegate);
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        public void ShowStatus()
        {
            try
            {
                lblStatus.Text = currentStatus;
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(currentStatus))
                {
                    currentStatus = "";
                    lblStatus.Text = currentStatus;
                }
                FolderBrowserDialog openFD = new FolderBrowserDialog();
                if (openFD.ShowDialog() == DialogResult.OK)
                {
                    txtDownloadPath.Text = openFD.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                //int bufferSize = 1000;
                //string path = @"D:\Swati\PIS GPRS\12724\HDI";

                //byte[] SendingBuffer = null;

                //FileStream Fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                //int NoOfPackets = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Fs.Length) / bufferSize));

                //int TotalLength = (int)Fs.Length;
                //int CurrentPacketLength = 0, counter = 0;

                

                //for (int i = 0; i < NoOfPackets; i++)
                //{
                //    string pkt = string.Empty;

                //    if (TotalLength > bufferSize)
                //    {
                //        CurrentPacketLength = bufferSize;
                //        TotalLength = TotalLength - CurrentPacketLength;
                //    }
                //    else
                //    {
                //        CurrentPacketLength = TotalLength;
                //        SendingBuffer = new byte[CurrentPacketLength];
                //         Fs.Read(SendingBuffer, 0, CurrentPacketLength);
                //    }


                //    BaseClass.SRPortComm.SendGPRSMessage(ASCIIEncoding.ASCII.GetString( SendingBuffer));
                //}

                Constants.CurrentRequest = Constants.Commands.uploadFile.ToString();
                int bufferSize = 997;
                string path = @"D:\Swati\PIS GPRS\12724\rtinfo";

                byte[] SendingBuffer = new byte[1024];
                //SendingBuffer[0] = "P";
                //SendingBuffer[1] = "I";
                //SendingBuffer[2] = "S";
                ////FileName
                //SendingBuffer[3] = "r";
                //SendingBuffer[4] = "t";
                //SendingBuffer[5] = "i";
                //SendingBuffer[6] = "n";
                //SendingBuffer[7] = "f";
                //SendingBuffer[8] = "o";
                //SendingBuffer[9] = null;
                //SendingBuffer[10] = null;
                //SendingBuffer[11] = null;
                //SendingBuffer[12] = null;
                //SendingBuffer[13] = null;
                //SendingBuffer[14] = null;
                //SendingBuffer[15] = null;
                //SendingBuffer[16] = null;
                //SendingBuffer[17] = null;
                ////File Size
                //SendingBuffer[18] = null;
                //SendingBuffer[19] = null;
                //SendingBuffer[20] = null;
                //SendingBuffer[21] = null;
                ////Packet size
                //SendingBuffer[22] = null;
                //SendingBuffer[23] = null;
                ////Font style
                //SendingBuffer[24] = null;
                ////Start Byte
                //SendingBuffer[1022] = null;
                ////End Byte
                //SendingBuffer[1023] = null;


                FileStream Fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                int NoOfPackets = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Fs.Length) / bufferSize));

                int TotalLength = (int)Fs.Length;
                int CurrentPacketLength = 0, counter = 0;


                for (int i = 0; i < NoOfPackets; i++)
                {
                    string pkt = string.Empty;

                    

                    if (TotalLength > bufferSize)
                    {
                        CurrentPacketLength = bufferSize;
                        TotalLength = TotalLength - CurrentPacketLength;
                    }

                    if (i == 0)
                    {

                    }
                    else
                    {
                        CurrentPacketLength = TotalLength;
                        SendingBuffer = new byte[CurrentPacketLength];
                        Fs.Read(SendingBuffer, 0, CurrentPacketLength);
                    }


                    BaseClass.SRPortComm.SendGPRSMessage(System.Text.Encoding.UTF8.GetString(SendingBuffer));
                }

            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        private void ucUploadFile_Load(object sender, EventArgs e)
        {
            try
            {
                StatusDelegate = new DisplayStatus(ShowStatus);
            }
            catch (Exception ex)
            {
                Logger.Logger.WriteLog(ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        
    }
}
