﻿using System;
namespace DTcms.Model
{
    /// <summary>
    /// temp_camlist:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class temp_camlist
    {
        public temp_camlist()
        { }
        #region Model
        private int _id;
        private int _fk_id;
        private string _partnum;
        private string _toolname;
        private string _toolnum;
        private decimal? _worktime;
        private string _toollevel;
        private int? _toolreadystate;
        private string _toolbarcode;
        private string _tooldiam;
        private string _toolhandle;
        private string _toollong;
        private string _toolradius;
        private string _toolbladelength;
        private string _remark;
        /// <summary>
        /// auto_increment
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FK_Id
        {
            set { _fk_id = value; }
            get { return _fk_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PartNum
        {
            set { _partnum = value; }
            get { return _partnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ToolName
        {
            set { _toolname = value; }
            get { return _toolname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ToolNum
        {
            set { _toolnum = value; }
            get { return _toolnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? WorkTime
        {
            set { _worktime = value; }
            get { return _worktime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ToolLevel
        {
            set { _toollevel = value; }
            get { return _toollevel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ToolReadyState
        {
            set { _toolreadystate = value; }
            get { return _toolreadystate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ToolBarCode
        {
            set { _toolbarcode = value; }
            get { return _toolbarcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ToolDiam
        {
            set { _tooldiam = value; }
            get { return _tooldiam; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ToolHandle
        {
            set { _toolhandle = value; }
            get { return _toolhandle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ToolLong
        {
            set { _toollong = value; }
            get { return _toollong; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ToolRadius
        {
            set { _toolradius = value; }
            get { return _toolradius; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ToolBladeLength
        {
            set { _toolbladelength = value; }
            get { return _toolbladelength; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model

    }
}

