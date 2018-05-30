using System.Management;

namespace MachineCode
{
    /// <summary>
    /// 静态类 获取硬件信息
    /// </summary>
    public class HardWareInfo
    {
        private string _CpuInfo = " ";
        private string _HDid = " ";
        private string _MoAddress = " ";
        private string _RegisterCode = " ";
        private const string _const = "500lr";

        #region 字段赋值
        public string registerCode
        {
            get { return _RegisterCode; }
        }
        /// <summary>
        /// CPU信息
        /// </summary>
        public string CpuInfo
        {
            get { return _CpuInfo; }
            set { _CpuInfo = value; }
        }

        /// <summary>
        /// 硬盘信息
        /// </summary>
        public string HDid
        {
            get { return _HDid; }
            set { _HDid = value; }
        }

        /// <summary>
        /// 网卡信息
        /// </summary>
        public string MoAddress
        {
            get { return _MoAddress; }
            set { _MoAddress = value; }
        }

        #endregion

        #region 构造函数
        public HardWareInfo()
        {
            
        }
        #endregion

        #region 获取cpu序列号 硬盘ID 网卡硬地址 
        /// <summary> 
        /// 获取cpu序列号 
        /// </summary> 
        /// <returns> string </returns> 
        public static string Cpu()
        {
            ManagementClass cimobject = new ManagementClass("Win32_Processor");
            ManagementObjectCollection moc = cimobject.GetInstances();
            string cpu = "";
            foreach (ManagementObject mo in moc)
            {
                cpu = mo.Properties["ProcessorId"].Value.ToString();
            }

            return cpu;
        }

        /// <summary> 
        /// 获取硬盘ID SerialNumber是序列号 Model是型号之类的信息
        /// </summary> 
        /// <returns> string </returns> 
        public static string HardDisk()
        {
            ManagementClass cimobject1 = new ManagementClass("Win32_DiskDrive");
            ManagementObjectCollection moc1 = cimobject1.GetInstances();
            string harddisk = "";
            foreach (ManagementObject mo in moc1)
            {
                //_HDid = (string)mo.Properties["Model"].Value;
                harddisk = ((string)mo.Properties["SerialNumber"].Value).Trim();
                break;
            }

            return harddisk;
        }

        /// <summary> 
        /// 获取网卡硬件地址 
        /// </summary> 
        /// <returns> string </returns> 
        public static string NetWorkCard()
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc2 = mc.GetInstances();
            string networkcard = "";
            foreach (ManagementObject mo in moc2)
            {
                if ((bool)mo["IPEnabled"] == true)
                {
                    networkcard = mo["MacAddress"].ToString();
                    break;
                }
                mo.Dispose();
            }

            return networkcard;
            //string mac = null;
            //ManagementObjectSearcher query = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration");
            //ManagementObjectCollection queryCollection = query.Get();
            //foreach (ManagementObject mo in queryCollection)
            //{
            //    if (mo["IPEnabled"].ToString() == "True")
            //        mac = mo["MacAddress"].ToString();
            //}
            //return (mac);
        }
        #endregion

    
    }
} 

