using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTcms.Model
{
    /// <summary>
    /// u_printlog:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class u_printlog
    {
        public u_printlog()
        { }
        #region Model
        private int _id;
        private string _legalpersonname;
        private string _legalpersonidcardnum;
        private string _agentname;
        private string _agentidcardnum;
        private string _companyname;
        private string _socialnum;
        private DateTime? _printzhengbendate;
        private DateTime? _printfubendate;
        private byte[] _picidcardface;
        private byte[] _picfinger;
        private byte[] _picfacergb;
        private byte[] _picfaceir;
        private byte[] _pictakeaway;
        private string _rgbscore;
        private string _irscore;
        private string _comparescore;
        private int? _bussinesstype;
        private string _remark;
        private int? _printertype;
        private DateTime? _uploaddatetime1;
        private DateTime? _uploaddatetime2;
        private string _county;
        private string _point;
        private string _area;
        private string _machineid;
        private string _sessionid;
        private DateTime? _createsessiondate;
        private int? _iszhengbenlightcheck;
        private int? _isfubenlightcheck;
        private int? _iszhengbentcpip;
        private int? _isfubentcpip;
        private int? _iszhengbenprintcheck;
        private int? _isfubenprintcheck;
        private int? _iszhengbensuccessed;
        private int? _isfubensuccessed;
        private int? _fubencount;
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
        public string legalpersonName
        {
            set { _legalpersonname = value; }
            get { return _legalpersonname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string legalpersonIdCardNum
        {
            set { _legalpersonidcardnum = value; }
            get { return _legalpersonidcardnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string agentName
        {
            set { _agentname = value; }
            get { return _agentname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string agentIdCardNum
        {
            set { _agentidcardnum = value; }
            get { return _agentidcardnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string companyName
        {
            set { _companyname = value; }
            get { return _companyname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string socialNum
        {
            set { _socialnum = value; }
            get { return _socialnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? printZhengbendate
        {
            set { _printzhengbendate = value; }
            get { return _printzhengbendate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? printFubenDate
        {
            set { _printfubendate = value; }
            get { return _printfubendate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public byte[] PicIDcardFace
        {
            set { _picidcardface = value; }
            get { return _picidcardface; }
        }
        /// <summary>
        /// 
        /// </summary>
        public byte[] PicFinger
        {
            set { _picfinger = value; }
            get { return _picfinger; }
        }
        /// <summary>
        /// 
        /// </summary>
        public byte[] PicFaceRGB
        {
            set { _picfacergb = value; }
            get { return _picfacergb; }
        }
        /// <summary>
        /// 
        /// </summary>
        public byte[] PicFaceIR
        {
            set { _picfaceir = value; }
            get { return _picfaceir; }
        }
        /// <summary>
        /// 
        /// </summary>
        public byte[] PicTakeAway
        {
            set { _pictakeaway = value; }
            get { return _pictakeaway; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RGBScore
        {
            set { _rgbscore = value; }
            get { return _rgbscore; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IRScore
        {
            set { _irscore = value; }
            get { return _irscore; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CompareScore
        {
            set { _comparescore = value; }
            get { return _comparescore; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? BussinessType
        {
            set { _bussinesstype = value; }
            get { return _bussinesstype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PrinterType
        {
            set { _printertype = value; }
            get { return _printertype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? UploadDatetime1
        {
            set { _uploaddatetime1 = value; }
            get { return _uploaddatetime1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? UploadDatetime2
        {
            set { _uploaddatetime2 = value; }
            get { return _uploaddatetime2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string County
        {
            set { _county = value; }
            get { return _county; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Point
        {
            set { _point = value; }
            get { return _point; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Area
        {
            set { _area = value; }
            get { return _area; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MachineId
        {
            set { _machineid = value; }
            get { return _machineid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SessionId
        {
            set { _sessionid = value; }
            get { return _sessionid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateSessionDate
        {
            set { _createsessiondate = value; }
            get { return _createsessiondate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IsZhengbenLightCheck
        {
            set { _iszhengbenlightcheck = value; }
            get { return _iszhengbenlightcheck; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IsFubenLightCheck
        {
            set { _isfubenlightcheck = value; }
            get { return _isfubenlightcheck; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IsZhengbenTCPIP
        {
            set { _iszhengbentcpip = value; }
            get { return _iszhengbentcpip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IsFubenTCPIP
        {
            set { _isfubentcpip = value; }
            get { return _isfubentcpip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IsZhengbenPrintCheck
        {
            set { _iszhengbenprintcheck = value; }
            get { return _iszhengbenprintcheck; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IsFubenPrintCheck
        {
            set { _isfubenprintcheck = value; }
            get { return _isfubenprintcheck; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IsZhengbenSuccessed
        {
            set { _iszhengbensuccessed = value; }
            get { return _iszhengbensuccessed; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IsFubenSuccessed
        {
            set { _isfubensuccessed = value; }
            get { return _isfubensuccessed; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FubenCount
        {
            set { _fubencount = value; }
            get { return _fubencount; }
        }
        #endregion Model

    }
}