using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MachineCode;
using Encrypy;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {

            string cpu =HardWareInfo.Cpu();
            string harddisk = HardWareInfo.HardDisk();

            string str = Encrypy.Encrypt.Sha256(cpu);
        }
    }
}
