using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace YXP.API.WindowsService
{
    partial class CarSync : ServiceBase
    {
        public CarSync()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {

                this.CarTimer.Enabled = true;
                this.CarTimer.Interval = 1000;
                this.CarTimer.Tick += ChaKeCarSourceToYXP;
                this.CarTimer.Start();
            }
            catch (Exception ex)
            {

            }
            // TODO:  在此处添加代码以启动服务。
        }

        protected override void OnStop()
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
            // TODO:  在此处添加代码以执行停止服务所需的关闭操作。
        }
        /// <summary>
        /// 查客车源同步至优信拍
        /// </summary>
        private void ChaKeCarSourceToYXP(object sender, EventArgs e)
        {

        }
    }
}
