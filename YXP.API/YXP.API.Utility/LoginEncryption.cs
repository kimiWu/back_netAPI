using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace YXP.API.Utility
{
    public class LoginEncryption
    {
        private static readonly object _syncLock = new object();
        private static LoginEncryption _instance;
        public static LoginEncryption Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new LoginEncryption();
                        }
                    }
                }
                return _instance;
            }
        }
        /// <summary>
        /// 获取8位随机密钥
        /// </summary>
        /// <returns></returns>
        public string GetUserKey()
        {
            string seriel = getRandomizer(8, true, false, false, true);//生成6个字母和数字
            return seriel;
        }
        /// <summary>
        /// 将用户id进行加密发送至优信拍 注：算法为自定义，author:wangliang
        /// 算法内容为：(当前用户ID + 10)*3-25 拆为数字对应出给定的字母 随机加入80位数字组成的串中。
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public string GetReqEncryptionString(int userid)
        {
            if (userid > 0)
            {
                string seriel = getRandomizer(20, true, false, false, false);//生成20个数字
                string numstr = ((userid + 10) * 3 - 25).ToString();
                string n = string.Empty;
                int j = 0;
                foreach (char a in numstr)
                {
                    int i = new Random().Next(0, 2);
                    j += 2;
                    string m = string.Empty;
                    switch (a)
                    {
                        case '0':
                            m = "v";
                            break;
                        case '1':
                            m = "x";
                            break;
                        case '2':
                            m = "r";
                            break;
                        case '3':
                            m = "w";
                            break;
                        case '4':
                            m = "b";
                            break;
                        case '5':
                            m = "q";
                            break;
                        case '6':
                            m = "j";
                            break;
                        case '7':
                            m = "l";
                            break;
                        case '8':
                            m = "o";
                            break;
                        case '9':
                            m = "n";
                            break;
                        default:
                            m = "a";
                            break;
                    }
                    seriel = seriel.Insert(i + j, m);//在串中随机插入生成的字母
                }
                return seriel;
            }
            return string.Empty;
        }
        /// <summary>
        /// 解密算法为：去掉数字提取字母，用字母对应生成相应数字，数字运算(接收id + 25)/3-10 得到用户id
        /// </summary>
        /// <param name="enstr"></param>
        /// <returns></returns>
        public int GetResEncryptionString(string enstr)
        {
            string str = Regex.Replace(enstr, @"[0-9]*", "");//移除数字
            string n = string.Empty;
            foreach (char a in str)
            {
                string m = string.Empty;
                switch (a)
                {
                    case 'v':
                        m = "0";
                        break;
                    case 'x':
                        m = "1";
                        break;
                    case 'r':
                        m = "2";
                        break;
                    case 'w':
                        m = "3";
                        break;
                    case 'b':
                        m = "4";
                        break;
                    case 'q':
                        m = "5";
                        break;
                    case 'j':
                        m = "6";
                        break;
                    case 'l':
                        m = "7";
                        break;
                    case 'o':
                        m = "8";
                        break;
                    case 'n':
                        m = "9";
                        break;
                    default:
                        m = "0";
                        break;
                }
                n += m;
            }
            int enint = 0;
            int.TryParse(n, out enint);
            if (!string.IsNullOrEmpty(enstr) && enint > 0)
            {
                return (enint + 25) / 3 - 10;
            }
            return 0;
        }

        /// <summary>  
        /// 自定义随机字符串(其中可包含数字,符号,大小写字母)的生成方法.  
        /// </summary>  
        /// <param name="intLength">需要位数</param>  
        /// <param name="booNumber">是否生成数字</param>  
        /// <param name="booSign">是否生成符号</param>  
        /// <param name="booSmallword">是否生成小写字母</param>  
        /// <param name="booBigword">是否生成大写字母</param>  
        /// <returns></returns>  
        public string getRandomizer(int intLength, bool booNumber, bool booSign, bool booSmallword, bool booBigword)
        {
            //定义  
            Random ranA = new Random();
            int intResultRound = 0;
            int intA = 0;
            //string strB = "";
            StringBuilder strBuilder = new StringBuilder();
            while (intResultRound < intLength)
            {
                //生成随机数A，表示生成类型  
                //1=数字，2=符号，3=小写字母，4=大写字母  
                intA = ranA.Next(1, 5);
                //如果随机数A=1，则运行生成数字  
                //生成随机数A，范围在0-10  
                //把随机数A，转成字符  
                //生成完，位数+1，字符串累加，结束本次循环  
                if (intA == 1 && booNumber)
                {
                    intA = ranA.Next(0, 10);
                    //strB = intA.ToString() + strB;
                    //intResultRound = intResultRound + 1;
                    strBuilder.Append(intA);
                    Interlocked.Increment(ref intResultRound);
                    continue;
                }
                //如果随机数A=2，则运行生成符号  
                //生成随机数A，表示生成值域  
                //1：33-47值域，2：58-64值域，3：91-96值域，4：123-126值域  
                if (intA == 2 && booSign == true)
                {
                    intA = ranA.Next(1, 5);

                    //如果A=1  
                    //生成随机数A，33-47的Ascii码  
                    //把随机数A，转成字符  
                    //生成完，位数+1，字符串累加，结束本次循环  
                    if (intA == 1)
                    {
                        intA = ranA.Next(33, 48);
                        //strB = ((char)intA).ToString() + strB;
                        //intResultRound = intResultRound + 1;
                        strBuilder.Append(((char)intA).ToString());
                        Interlocked.Increment(ref intResultRound);
                        continue;
                    }

                    //如果A=2  
                    //生成随机数A，58-64的Ascii码  
                    //把随机数A，转成字符  
                    //生成完，位数+1，字符串累加，结束本次循环  
                    if (intA == 2)
                    {
                        intA = ranA.Next(58, 65);
                        //strB = ((char)intA).ToString() + strB;
                        //intResultRound = intResultRound + 1;
                        strBuilder.Append(((char)intA).ToString());
                        Interlocked.Increment(ref intResultRound);
                        continue;
                    }

                    //如果A=3  
                    //生成随机数A，91-96的Ascii码  
                    //把随机数A，转成字符  
                    //生成完，位数+1，字符串累加，结束本次循环  
                    if (intA == 3)
                    {
                        intA = ranA.Next(91, 97);
                        //strB = ((char)intA).ToString() + strB;
                        //intResultRound = intResultRound + 1;
                        strBuilder.Append(((char)intA).ToString());
                        Interlocked.Increment(ref intResultRound);
                        continue;
                    }

                    //如果A=4  
                    //生成随机数A，123-126的Ascii码  
                    //把随机数A，转成字符  
                    //生成完，位数+1，字符串累加，结束本次循环  
                    if (intA == 4)
                    {
                        intA = ranA.Next(123, 127);
                        //strB = ((char)intA).ToString() + strB;
                        //intResultRound = intResultRound + 1;
                        strBuilder.Append(((char)intA).ToString());
                        Interlocked.Increment(ref intResultRound);
                        continue;
                    }
                }
                //如果随机数A=3，则运行生成小写字母  
                //生成随机数A，范围在97-122  
                //把随机数A，转成字符  
                //生成完，位数+1，字符串累加，结束本次循环  
                if (intA == 3 && booSmallword == true)
                {
                    intA = ranA.Next(97, 123);
                    //strB = ((char)intA).ToString() + strB;
                    //intResultRound = intResultRound + 1;
                    strBuilder.Append(((char)intA).ToString());
                    Interlocked.Increment(ref intResultRound);
                    continue;
                }

                //如果随机数A=4，则运行生成大写字母  
                //生成随机数A，范围在65-90  
                //把随机数A，转成字符  
                //生成完，位数+1，字符串累加，结束本次循环  
                if (intA == 4 && booBigword == true)
                {
                    intA = ranA.Next(65, 89);
                    //strB = ((char)intA).ToString() + strB;
                    //intResultRound = intResultRound + 1;
                    strBuilder.Append(((char)intA).ToString());
                    Interlocked.Increment(ref intResultRound);
                    continue;
                }
            }
            //return strB;
            return strBuilder.ToString();
        }
    }
}
