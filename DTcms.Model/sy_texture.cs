using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTcms.Model
{
    /// <summary>
	/// sy_texture:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class sy_texture
    {
        public sy_texture()
        { }
        #region Model
        private int _id;
        private string _texture;
        /// <summary>
        /// auto_increment
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Texture
        {
            set { _texture = value; }
            get { return _texture; }
        }
        #endregion Model

    }
}
