using System;
using System.Text;

namespace Encrypy
{
    /// <summary>
    /// 静态类 加密工具
    /// </summary>
    public static class Encrypt
    {
        #region 256 和 512 加密

        /// <summary>
        /// SHA256 加密方式
        /// </summary>
        /// <param name="str">要加密的文本内容</param>
        /// <returns></returns>
        public static string Sha256(string str)
        {
            System.Security.Cryptography.SHA256 s256 = new System.Security.Cryptography.SHA256Managed();
            byte[] byte1;
            byte1 = s256.ComputeHash(Encoding.Default.GetBytes(str));
            s256.Clear();
            return Convert.ToBase64String(byte1);
        }

        /// <summary>
        /// SHA512加密方式
        /// </summary>
        /// <param name="str">要加密的文本内容</param>
        /// <returns></returns>
        public static string Sha512(string str)
        {
            System.Security.Cryptography.SHA512 s512 = new System.Security.Cryptography.SHA512Managed();
            byte[] byte1;
            byte1 = s512.ComputeHash(Encoding.Default.GetBytes(str));
            s512.Clear();
            return Convert.ToBase64String(byte1);
        }
        #endregion
    }
}
