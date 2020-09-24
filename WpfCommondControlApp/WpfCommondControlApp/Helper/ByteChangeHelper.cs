using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCommondControlApp.Helper
{
    /// <summary>
    /// 描述：
    /// 作者：liufuwentao
    /// 时间：2020/7/25 17:57:46
    /// </summary>
    public class ByteChangeHelper
    {
        public short bytesToShort(byte[] bytes)
        {
            short converted = BitConverter.ToInt16(bytes, 0);
            return converted;
        }
        public byte[] shortToBytes(short value)
        {
            byte[] numberBytes = BitConverter.GetBytes(value);
            return numberBytes;
        }

    }
}
