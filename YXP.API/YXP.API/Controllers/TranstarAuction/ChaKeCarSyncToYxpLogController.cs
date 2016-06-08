using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YXP.API.Business.TranstarAuction;
using YXP.API.Utility;

namespace YXP.API.Controllers.TranstarAuction
{
    public class ChaKeCarSyncToYxpLogController : ApiController
    {
        ///TranstarAuction/ChaKeCarSyncToYxpLog/SyncCarTaskId?PlatformId=10&Token=cf8967d33a6286900c6d7e20e87e11b7&publishId=1056&taskId=5
        /// <summary>
        /// 查客新增修改车源调用接口同步ID
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        [HttpGet]
        public ApiResultModel SyncCarTaskId(int taskId)
        {
            ApiResultModel arm = new ApiResultModel();
            try
            {
                ChaKeCarSyncToYxpLogBLL bll = new ChaKeCarSyncToYxpLogBLL();
                bll.InsertTaskId(taskId);

                arm.Code = 1;
                arm.Data = "";
                arm.Message = "保存成功";
            }
            catch (Exception ex)
            {
                arm.Code = 0;
                arm.Data = "";
                arm.Message = "调用失败:" + ex.Message;
            }

            return arm;
        }

    }
}