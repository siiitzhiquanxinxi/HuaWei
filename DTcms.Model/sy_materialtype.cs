using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTcms.Model
{
    /// <summary>
	/// sy_materialtype:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class sy_materialtype
    {
        public sy_materialtype()
        { }
        #region Model
        private int _materialtypeid;
        private string _materialtypename;
        private string _code;
        /// <summary>
        /// auto_increment
        /// </summary>
        public int MaterialTypeID
        {
            set { _materialtypeid = value; }
            get { return _materialtypeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MaterialTypeName
        {
            set { _materialtypename = value; }
            get { return _materialtypename; }
        }
        /// <summary>
		/// 
		/// </summary>
		public string Code
        {
            set { _code = value; }
            get { return _code; }
        }
        #endregion Model

    }
}
