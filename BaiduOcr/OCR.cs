using System.IO;
using Newtonsoft.Json.Linq;

namespace BaiDuAPI
{
    public static class OCR
    {
        private const string APP_ID = "11471399";
        private const string API_KEY = "46fC8hRNOEyGxPL3CmgNw0qZ";
        private const string SECRET_KEY = "UTvyps5CDhsTWaDux3cbKuEcBA4Tk4MW";

        #region 图片识别文字

        /// <summary>
        /// 图片识别文字
        /// </summary>
        /// <param name="filePath">图片的路径</param>
        /// <returns>返回JSON格式的数组</returns>
        public static JObject Recogniz(string filePath)
        {
            var client = new Baidu.Aip.Ocr.Ocr(API_KEY, SECRET_KEY);
            //client.Timeout = 60000;  // 修改超时时间

            byte[] image = File.ReadAllBytes(filePath);
            // 调用通用文字识别, 图片参数为本地图片，可能会抛出网络等异常，请使用try/catch捕获
            //return client.TableRecognitionRequest(image);
            //return client.TableRecognitionRequest(image);
            return client.Form(image);
        }

        #endregion
    }
}