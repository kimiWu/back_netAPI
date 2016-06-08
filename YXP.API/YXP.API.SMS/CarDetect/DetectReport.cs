using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace YXP.API.SMS.CarDetect
{
    public class HuoYanProvider
    {

        public void GetCarSource(int tvaid, int carId)
        {
            CarDetect.DetectReportSoapClient client = new DetectReportSoapClient();
            CarDetect.DetectReportAuth dr = new DetectReportAuth { AuthKey = AppSettings.GetAppSettingValue("HuoYanKey") };
            client.GetCarSourceById(dr, tvaid, carId);
        }
    }
}
