using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YXP.API.Entity.Bank
{
    [Serializable]
    public class Bankdict_Bank
    {
        public Bankdict_Bank()
        {
            this._bankid = "000";
            this._bankname = String.Empty;
            this._logo = String.Empty;
        }

        #region Model
        private string _bankid;
        private string _bankname;
        private string _logo;
        /// <summary>
        ///  
        /// </summary>
        public string Bankid
        {
            get { return _bankid; }
            set { _bankid = value; }
        }
        /// <summary>
        ///  
        /// </summary>
        public string Bankname
        {
            get { return _bankname; }
            set { _bankname = value; }
        }
        /// <summary>
        ///  
        /// </summary>
        public string Logo
        {
            get { return _logo; }
            set { _logo = value; }
        }
        #endregion
    }

    [Serializable]
    public class bankdict_code
    {
        public bankdict_code()
        {
            this._bankcode = "000";
            this._bankfullname = String.Empty;
            this._cityid = "000";
            this._bankid = "000";
            this._nickname = String.Empty;
            this._address = String.Empty;
            this._tel = String.Empty;
            this._email = String.Empty;
        }

        #region Model
        private string _bankcode;
        private string _bankfullname;
        private string _cityid;
        private string _bankid;
        private string _nickname;
        private string _address;
        private string _tel;
        private string _email;
        /// <summary>
        ///  
        /// </summary>
        public string Bankcode
        {
            get { return _bankcode; }
            set { _bankcode = value; }
        }
        /// <summary>
        ///  
        /// </summary>
        public string Bankfullname
        {
            get { return _bankfullname; }
            set { _bankfullname = value; }
        }
        /// <summary>
        ///  
        /// </summary>
        public string Cityid
        {
            get { return _cityid; }
            set { _cityid = value; }
        }
        /// <summary>
        ///  
        /// </summary>
        public string Bankid
        {
            get { return _bankid; }
            set { _bankid = value; }
        }
        /// <summary>
        ///  
        /// </summary>
        public string Nickname
        {
            get { return _nickname; }
            set { _nickname = value; }
        }
        /// <summary>
        ///  
        /// </summary>
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        /// <summary>
        ///  
        /// </summary>
        public string Tel
        {
            get { return _tel; }
            set { _tel = value; }
        }
        /// <summary>
        ///  
        /// </summary>
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        #endregion
    }


}
