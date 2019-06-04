using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
namespace InterfaceHardware
{
    public class BrandCommand
    {
        #region Basic
        //航成板
        /// <summary>
        /// LED灯的开关命令(32命令)
        /// </summary>
        /// <param name="Command"></param>
        /// <param name="Box"></param>
        /// <param name="LED"></param>
        /// <returns></returns>
        public static byte[] HCRule(byte Command, byte Box,byte LED, byte CardAddr)
        {
            byte[] a = HCRule(Command, Box, CardAddr);
            if (Command == 0x32)
                a[5] = LED;
            a[18] = 0;
            for (int i = 1; i < 18; i++)
            {
                a[18] += a[i];
            }
            return a;
        }
        /// <summary>
        /// 门的开关及状态查询
        /// </summary>
        /// <param name="Command"></param>
        /// <param name="Box"></param>
        /// <returns></returns>
        public static byte[] HCRule(byte Command, byte Box, byte CardAddr)
        {
            byte[] a = new byte[20];
            a[0] = 0x02;
            a[1] = Command;//命令
            a[2] = CardAddr;//柜号
            a[3] = Box;//抽屉
            a[4] = 0;
            for (int i = 4; i < 18; i++)
            {
                a[i] = 0;
            }
            for (int i = 1; i < 18; i++)
            {
                a[18] += a[i];
            }
            a[19] = 0x03;
            return a;
        }
        public struct ResultData
        {
            public byte State;                           //反馈的状态
            public byte Box;                             //柜子(抽屉)
            public byte Command;                         //命令
            public byte CardAddr;                        //板地址
        }
        /// <summary>
        /// 反馈校验及反馈状态
        /// </summary>
        /// <param name="Result"></param>
        /// <returns></returns>
        public static ResultData HCResultAnalyse(byte[] Result)
        {
            ResultData res = new ResultData();
            if (Result.Length == 20)
            {
                byte rebyte = 0;
                for (int i = 1; i < 18; i++)
                {
                    rebyte += Result[i];
                }
                if (rebyte == Result[18])
                {
                    res.Box = Result[3];
                    res.State= Result[17];
                    res.Command = Result[1];
                    res.CardAddr = Result[2];
                    return res;
                }
                else
                {
                    return res;
                }
            }
            else
            {
                return res;
            }
        }

        //思恩板
        public static byte[] SNRule(byte Command, byte Box,byte CardAddr)
        {
            byte[] a = new byte[5];
            a[0] = Command;
            a[1] = CardAddr;//板地址
            a[2] = Box;//抽屉
            if (Command== 0X80)
                a[3] = 0x33;
            else if(Command == 0X8A)
                a[3]= 0x11;
            else if (Command == 0X81)
                a[3] = 0x99;
            else if (Command == 0X91)
                a[3] = 0xFE;
            int s = a[0] ^ a[1] ^ a[2] ^ a[3];
            a[4] = (byte)s;
            return a;
        }
        public static ResultData SNResultAnalyse(byte[] Result)
        {
            ResultData res = new ResultData();
            if (Result.Length == 5)
            {
                int s = Result[0] ^ Result[1] ^ Result[2] ^ Result[3];
                if ((byte)s == Result[4])
                {
                    res.Box = Result[2];
                    res.State = Result[3];
                    res.Command = Result[0];
                    res.CardAddr = Result[1];
                    return res;
                }
                else
                {
                    return res;
                }
            }
            else
            {
                return res;
            }
        }
        #endregion

        public static byte[] AutoCommand(byte Command, byte Box, byte CardAddr=0x01)
        {
            if (ConfigurationManager.AppSettings["Brand"].Trim() == "HC")
            {
                if (CardAddr == 0x01)
                    CardAddr += 0x30;
                return HCRule(Command, Box, CardAddr);
            }
            else
            {
                return SNRule(Command, Box, CardAddr);
            } 
        }
        /// <summary>
        /// 打开所有柜子（管理员使用）
        /// </summary>
        /// <param name="CardAddr"></param>
        /// <returns></returns>
        public static byte[] OpenALL(byte CardAddr = 0x01)
        {
            if (ConfigurationManager.AppSettings["Brand"].Trim() == "HC")
            {
                if (CardAddr == 0x01)
                    CardAddr += 0x30;
                return HCRule(0x34, 0x00, CardAddr);
            }
            else
            {
                return SNRule(0x8A, 0x00, CardAddr);
            }
        }
        /// <summary>
        /// 获取指定柜子的柜门状态
        /// </summary>
        /// <param name="Box"></param>
        /// <param name="CardAddr"></param>
        /// <returns></returns>
        public static byte[] GetState(byte Box, byte CardAddr = 0x01)
        {
            if (ConfigurationManager.AppSettings["Brand"].Trim() == "HC")
            {
                if(CardAddr==0x01)
                CardAddr += 0x30;
                return HCRule(0x30, Box, CardAddr);
            }
            else
            {
                return SNRule(0x80, Box, CardAddr);
            }
        }
        /// <summary>
        /// 打开指定柜子
        /// </summary>
        /// <param name="Box"></param>
        /// <param name="CardAddr"></param>
        /// <returns></returns>
        public static byte[] OpenBox(byte Box, byte CardAddr = 0x01)
        {
            if (ConfigurationManager.AppSettings["Brand"].Trim() == "HC")
            {
                if (CardAddr == 0x01)
                    CardAddr += 0x30;
                return HCRule(0x47, Box, CardAddr);
            }
            else
            {
                return SNRule(0x8A, Box, CardAddr);
            }
        }
        /// <summary>
        /// LED控制命令
        /// </summary>
        /// <param name="Box"></param>
        /// <param name="LED">0x30全灭，0x31红灯常亮，0x32绿灯常亮</param>
        /// <returns></returns>
        public static byte[] LEDControl(byte Box,byte LED, byte CardAddr = 0x01)
        {
            if (ConfigurationManager.AppSettings["Brand"].Trim() == "HC")
            {
                if (CardAddr == 0x01)
                    CardAddr += 0x30;
                return HCRule(0x32, Box,LED, CardAddr);
            }
            else
            {
                byte[] a = new byte[5];
                return a;
            }
        }

    }
}
