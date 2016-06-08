using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YXP.API.Entity.TranstarAuction
{
    /// <summary>
    ///	配置类
    /// generated  2013/4/23 17:04:51
    /// </summary>
    [Serializable]
    public sealed class AuctionAppSetting
    {
        #region Private Members

        private int _id;
        private string _key;
        private string _value;
        #endregion



        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }



        #endregion




    }
}
