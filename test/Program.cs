using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using MachineCode;
using Encrypy;
using BaiDuAPI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            JObject result = OCR.Recogniz(@"C:\Users\Administrator\Desktop\三墩新天地\IMG_0617.JPG");

            //JSON转义
            var  txt = (from obj in (JArray)result.Root["words_result"] select (string)obj["words"]);
            //   let phrase = (JObject)obj["phrase"]
            //select (string)obj["words"]);

            //读取数据
            foreach (object str in txt)
            {
                Console.WriteLine(str);
            }
            Console.ReadKey();
        }
    }
}
