using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 代码测试.ExcelHelper
{
    /// <summary>
    /// 描述：
    /// 作者：liufuwentao
    /// 时间：2020/7/25 17:57:46
    /// </summary>
    public class TestResult
    {
        private long iD;
        private string sN;
        private DateTime testTime;
        private string allItemResult;
        private string powerOnTest;
        private string versionTest;
        private string cVBSTest;
        private string cameraTest;
        private string lEDTest;
        private string loudspeakerTest;
        private string dDRTest;
        private string nandTest;
        private string gsensorTest;
        private string miniLCD5VTest;
        private string serialTest;
        private string rigidLineLeftTest;
        private string rigidLineRightTest;
        private string rigidLineBrakeTest;
        private string rigidLineSpeedTest;
        private string canBusTest0Test;
        private string canBusTest1Test;
        private string voltageTest;

        private string sDCardTest;
        private string modeKeyTest;
        private string seatVibrationOnTest;
        public long ID
        {
            get
            {
                return this.iD;
            }
            set
            {
                this.iD = value; 
            }
        }
        public string SN
        {
            get
            {
                return sN;
            }
            set
            {
                this.sN = value; 
            }
        }
        public DateTime TestTime
        {
            get
            {
                return this.testTime;
            }
            set
            {
                this.testTime = value; 
            }
        }
        public string AllItemResult
        {
            get
            {
                return this.allItemResult;
            }
            set
            {
                this.allItemResult = value; 
            }
        }
        public string PowerOnTest
        {
            get
            {
                return this.powerOnTest;
            }
            set
            {
                this.powerOnTest = value; 
            }
        }
        public string VersionTest
        {
            get
            {
                return this.versionTest;
            }
            set
            {
                this.versionTest = value; 
            }
        }
        public string CVBSTest
        {
            get
            {
                return this.cVBSTest;
            }
            set
            {
                this.cVBSTest = value;
                
            }
        }

        public string CameraTest
        {
            get
            {
                return this.cameraTest;
            }
            set
            {
                this.cameraTest = value;
                
            }
        }
        public string LEDTest
        {
            get
            {
                return this.lEDTest;
            }
            set { this.lEDTest = value;  }
        }
        public string LoudspeakerTest
        {
            get
            {
                return this.loudspeakerTest;
            }
            set
            {
                this.loudspeakerTest = value; 
            }
        }
        public string DDRTest
        {
            get
            {
                return this.dDRTest;
            }
            set
            {
                this.dDRTest = value; 
            }
        }
        public string NandTest
        {
            get
            {
                return this.nandTest;
            }
            set
            {
                this.nandTest = value; 
            }
        }
        public string GsensorTest
        {
            get
            {
                return this.gsensorTest;
            }
            set
            {
                this.gsensorTest = value; 
            }
        }
        public string MiniLCD5VTest
        {
            get
            {
                return this.miniLCD5VTest;
            }
            set
            {
                this.miniLCD5VTest = value; 
            }
        }
        public string SerialTest
        {
            get
            {
                return this.serialTest;
            }
            set
            {
                this.serialTest = value; 
            }
        }
        public string RigidLineLeftTest
        {
            get
            {
                return this.rigidLineLeftTest;
            }
            set
            {
                this.rigidLineLeftTest = value; 
            }
        }
        public string RigidLineRightTest
        {
            get
            {
                return this.rigidLineRightTest;
            }
            set
            {
                this.rigidLineRightTest = value; 
            }
        }
        public string RigidLineBrakeTest
        {
            get
            {
                return this.rigidLineBrakeTest;
            }
            set
            {
                this.rigidLineBrakeTest = value; 
            }
        }
        public string RigidLineSpeedTest
        {
            get
            {
                return this.rigidLineSpeedTest;
            }
            set
            {
                this.rigidLineSpeedTest = value; 
            }
        }
        public string CanBusTest0Test
        {
            get
            {
                return this.canBusTest0Test;
            }
            set
            {
                this.canBusTest0Test = value; 
            }
        }
        public string CanBusTest1Test
        {
            get
            {
                return this.canBusTest1Test;
            }
            set
            {
                this.canBusTest1Test = value; 
            }
        }
        public string VoltageTest
        {
            get
            {
                return this.voltageTest;
            }
            set
            {
                this.voltageTest = value; 
            }
        }
        /// <summary>
        /// SD卡测试
        /// </summary>
        public string SDCardTest
        {
            get
            {
                return this.sDCardTest;
            }
            set
            {
                this.sDCardTest = value; 
            }
        }
        /// <summary>
        /// 模式按键测试
        /// </summary>
        public string ModeKeyTest
        {
            get
            {
                return this.modeKeyTest;
            }
            set
            {
                this.modeKeyTest = value; 
            }
        }
        /// <summary>
        /// 座椅震动测试
        /// </summary>
        public string SeatVibrationOnTest
        {
            get
            {
                return this.seatVibrationOnTest;
            }
            set
            {
                this.seatVibrationOnTest = value; 
            }
        }

        /// <summary>
        /// 反射获取属性值的方法
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetValue(string name)
        {
            try
            {
                return Convert.ToString(this.GetType().GetProperty(name).GetValue(this, null));
            }
            catch (Exception e)
            {
                return null;
            }
            
        }
    }
}
