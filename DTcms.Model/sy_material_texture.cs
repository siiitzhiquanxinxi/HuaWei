using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTcms.Model
{
    /// <summary>
	/// sy_material_texture:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class sy_material_texture
    {
        public sy_material_texture()
        { }
        #region Model
        private int _id;
        private string _materialid;
        private string _texture;
        private decimal? _coefficient;
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
        public string MaterialID
        {
            set { _materialid = value; }
            get { return _materialid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Texture
        {
            set { _texture = value; }
            get { return _texture; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Coefficient
        {
            set { _coefficient = value; }
            get { return _coefficient; }
        }
        #endregion Model

    }
}
