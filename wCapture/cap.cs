using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using PvDotNet;
using PvGUIDotNet;

namespace wCapture
{
    public partial class cap : Form
    {
        public cap()
        {
            InitializeComponent();
        }

        private const UInt16 cBufferCount = 16;

        private PvDevice mDevice = null;
        private PvStream mStream = null;
        private PvPipeline mPipeline = null;

        private Thread mThread = null;
        private bool mIsStopping = false;
        public PvBufferWriter mWriter = new PvBufferWriter();
        PvBufferFormatType FT = 0;


        private void btnConnect_Click(object sender, EventArgs e)
        {
            btnConnect.Enabled = false;
            PvDeviceFinderForm ConnectForm = new PvDeviceFinderForm();          //创建查找设备窗口
            if ((ConnectForm.ShowDialog() == DialogResult.OK) && (ConnectForm.Selected != null))
            {
                try
                {
                    PvDeviceInfo lDeviceInfo = ConnectForm.Selected as PvDeviceInfo;            //获得所选设备参数

                    // Create and connect device.
                    mDevice = PvDevice.CreateAndConnect(lDeviceInfo);                           //连接设备

                    // Create and Open stream.
                    mStream = PvStream.CreateAndOpen(lDeviceInfo);                              //打开设备数据流


                    // Create pipeline.
                    mPipeline = new PvPipeline(mStream);                                        //创建数据流管道
                }
                catch (PvException ex)
                {

                    MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
            
            btnConfigure.Enabled = true;
        }


        private void btnConfigure_Click(object sender, EventArgs e)
        {
            btnConfigure.Enabled = false;
            try
            {
                // Perform GigE Vision only configuration
                PvDeviceGEV lDGEV = mDevice as PvDeviceGEV;
                if (lDGEV != null)
                {
                    // Negotiate packet size    自动协议数据包大小
                    lDGEV.NegotiatePacketSize();

                    // Set stream destination.  设置数据流目的地址
                    PvStreamGEV lSGEV = mStream as PvStreamGEV;
                    lDGEV.SetStreamDestination(lSGEV.LocalIPAddress, lSGEV.LocalPort);
                }

                // Read payload size, set buffer size the pipeline will use to allocate buffers. 读取有效负载大小，设置管道缓冲区大小
                mPipeline.BufferSize = mDevice.PayloadSize;

                // Set buffer count. Use more buffers (at expense of using more memory) to eliminate missing block IDs.
                mPipeline.BufferCount = cBufferCount;
            }
            catch (PvException ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
            }
            btnStartstream.Enabled = true;
        }


        private void btnStartstream_Click(object sender, EventArgs e)
        {
            btnStartstream.Enabled = false;
            mIsStopping = false;
            //mDevice.Parameters.SetIntegerValue("TLParamsLocked", 1);  参数锁

            mPipeline.Start();

            // Start display thread.                                
            mThread = new Thread(new ParameterizedThreadStart(ThreadProc));
            cap lP1 = this;
            object[] lParameters = new object[] { lP1 };
         
            mThread.Start(lParameters);

            // Enables streaming before sending the AcquisitionStart command.
            mDevice.StreamEnable();

            // Start acquisition on the device.
            mDevice.Parameters.ExecuteCommand("AcquisitionStart");

           


            //refreshTimer.Start();
            btnStopstream.Enabled = true;
        }

        private static void ThreadProc(object aParameters)
        {
            object[] lParameters = (object[])aParameters;
            cap lThis = (cap)lParameters[0];
            uint size;
            string path;
            PvBuffer lBuffer = null;



            for (; ;)
            {

                if (lThis.mIsStopping)
                {
                    // Signaled to terminate thread, return.
                    return;
                }
                // Retrieve next buffer from acquisition pipeline.
                PvResult lResult = lThis.mPipeline.RetrieveNextBuffer(ref lBuffer);
                if (lResult.IsOK)
                {
                    // Operation result of buffer is OK, display.
                    if (lBuffer.OperationResult.IsOK)
                    {
                        lThis.displayControl.Display(lBuffer);
                    }


                    if (lThis.chbSave.Checked == true)   //存图功能 ，建议另外新建一个线程做处理。
                    {
                        size = lBuffer.Image.Width * lBuffer.Image.Height * 3; //估计单张图片所占内存

                        
                        path =  lBuffer.BlockID.ToString() + ".bmp";
                        lThis.mWriter.Store(lBuffer, path, lThis.FT, ref size);
                        Thread.Sleep(100);

                    }

                    // We got a buffer (good or not) we must release it back.
                    lThis.mPipeline.ReleaseBuffer(lBuffer);
                }



            }
        }

        private void btnStopstream_Click(object sender, EventArgs e)
        {
            //mDevice.Parameters.SetIntegerValue("TLParamsLocked", 0);
            //refreshTimer.Stop();
            btnStopstream.Enabled = false;
            mIsStopping = false;
            // Stop acquisition. 让相机停止抓取图像
            mDevice.Parameters.ExecuteCommand("AcquisitionStop"); //ExecuteCommand("AcquisitionStop");

            // Disable streaming after sending the AcquisitionStop command. 禁用数据流
            mDevice.StreamDisable();

            // Stop the pipeline.
            mPipeline.Stop();

            // Stop display thread.
            mIsStopping = true;
            mThread.Join();
            mThread = null;
            btnDisconnect.Enabled = true;
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            btnDisconnect.Enabled = false;
            if (mStream != null)
            {
                // Close and release stream
                mStream.Close();
                mStream = null;
            }

            if (mDevice != null)
            {
                // Disconnect and release device
                mDevice.Disconnect();
                mDevice = null;
            }
            btnConnect.Enabled = true;
        }

        private void refresh_timer_Tick(object sender, EventArgs e)
        {
            PvGenParameterArray lStreamParams = mStream.Parameters;
            lStreamParams.InvalidateCache();
        }
    }
}