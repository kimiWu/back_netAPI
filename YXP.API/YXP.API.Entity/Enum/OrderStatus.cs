using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YXP.API.Entity.Enum
{
    public enum OrderStatus
    {
        WaitDistribution = 1,//待分派
        Assigned = 2,//已分派
        ReAssigned = 5,//重派
        Delayed = 6,//延时
        complete = 3,//完成的订单
        cancel = 4,//取消的订单
        Start = 7//检测中
    }
}
