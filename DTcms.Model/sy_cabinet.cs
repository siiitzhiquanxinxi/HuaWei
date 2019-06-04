using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTcms.Model
{
    /// <summary>
	/// sy_cabinet:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class sy_cabinet
    {
        public sy_cabinet()
        { }
        #region Model
        private string _cabinetno;
        private string _ip;
        private string _port;
        private string _cardaddr;
        private string _location;
        private string _manager;
        private string _phone;
        /// <summary>
        /// 
        /// </summary>
        public string CabinetNo
        {
            set { _cabinetno = value; }
            get { return _cabinetno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IP
        {
            set { _ip = value; }
            get { return _ip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Port
        {
            set { _port = value; }
            get { return _port; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CardAddr
        {
            set { _cardaddr = value; }
            get { return _cardaddr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Location
        {
            set { _location = value; }
            get { return _location; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Manager
        {
            set { _manager = value; }
            get { return _manager; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        #endregion Model

    }
}
