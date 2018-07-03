using System.IO;
using Newtonsoft.Json.Linq;

namespace BaiDuAPI
{
    public class OCR
    {
        private const string APP_ID = "11471399";
        private const string API_KEY = "46fC8hRNOEyGxPL3CmgNw0qZ";
        private const string SECRET_KEY = "UTvyps5CDhsTWaDux3cbKuEcBA4Tk4MW";

        #region 图片识别文字

        /// <summary>
        /// 图片识别文字
        /// </summary>
        /// <param name="filePath">图片的路径</param>
        /// <param name="type">识别的类型</param>
        /// <returns>返回JSON格式的数组</returns>
        public JObject Recognition(string filePath, string type)
        {
            var client = new Baidu.Aip.Ocr.Ocr(API_KEY, SECRET_KEY);
            //client.Timeout = 60000;  // 修改超时时间
            byte[] image = File.ReadAllBytes(filePath);
            JObject result = null;

            switch (type)
            {
                // 调用通用文字识别, 图片参数为本地图片，可能会抛出网络等异常，请使用try/catch捕获
                case "通用文字识别":
                    result = client.GeneralBasic(image);
                    break;
            }
            return result;
        }

        #endregion
    }
}