using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace KeyboardMouseSimulator
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("请输入重复操作的次数(等待5秒后开始)：\n");
            Console.WriteLine("Please input repeat operation times(it willl begin after 5 seconds)：\n");
            int count = Convert.ToInt32(Console.ReadLine());
            Thread.Sleep(5000);
            string modelName="model.txt";
            if (!File.Exists(modelName))
            {
                Console.WriteLine(string.Format("请在当前程序目录下创建模型文件：{0}！\n按回车退出",modelName));
                Console.WriteLine(string.Format("Please create model file under current application's directory：{0}！\nPress Enter key to exit", modelName));
                Console.ReadKey();
                return;
            }
            string[] lines = File.ReadAllLines(modelName,Encoding.GetEncoding("gb2312"));
            KMSimulator kms = new KMSimulator();
            for (int index = 0; index < count;index++ )
            {
                int lineIndex = 0;
                foreach (string line in lines)
                {
                    lineIndex++;
                    if(!String.IsNullOrEmpty(line.Trim()))
                    {
                        if (line.Contains("###"))
                        {
                            string action = line.Split(new string[] { "###" }, 2, StringSplitOptions.None)[0].Trim();
                            string actionValue = line.Split(new string[] { "###" }, 2, StringSplitOptions.None)[1].Trim();
                            try
                            {
                                if (action == "LeftClick" || action == "单击" || action == "左键")
                                {
                                    if (actionValue.Contains(","))
                                    {
                                        kms.LeftClick(Convert.ToInt32(actionValue.Split(',')[0]), Convert.ToInt32(actionValue.Split(',')[1]));
                                    }
                                    else if (actionValue.Contains("，"))
                                    {
                                        kms.LeftClick(Convert.ToInt32(actionValue.Split('，')[0]), Convert.ToInt32(actionValue.Split('，')[1]));
                                    }
                                    else
                                    {
                                        Console.WriteLine(string.Format("{0} 缺少值的分隔符 ',' 在这一行：{1}！\n", actionValue, line));
                                        Console.WriteLine(string.Format("{0} miss value split char ',' in line：{1}！\n", actionValue, line));
                                    }
                                }
                                else if (action == "DoubleClick" || action == "双击")
                                {
                                    if (actionValue.Contains(","))
                                    {
                                        kms.DoubleLeftClick(Convert.ToInt32(actionValue.Split(',')[0]), Convert.ToInt32(actionValue.Split(',')[1]));
                                    }
                                    else if (actionValue.Contains("，"))
                                    {
                                        kms.DoubleLeftClick(Convert.ToInt32(actionValue.Split('，')[0]), Convert.ToInt32(actionValue.Split('，')[1]));
                                    }
                                    else
                                    {
                                        Console.WriteLine(string.Format("{0} 缺少值的分隔符 ',' 在这一行：{1}！\n", actionValue, line));
                                        Console.WriteLine(string.Format("{0} miss value split char ',' in line：{1}！\n", actionValue, line));
                                    }
                                }
                                else if (action == "RightClick" || action == "右键")
                                {
                                    if (actionValue.Contains(","))
                                    {
                                        kms.RightClick(Convert.ToInt32(actionValue.Split(',')[0]), Convert.ToInt32(actionValue.Split(',')[1]));
                                    }
                                    else if (actionValue.Contains("，"))
                                    {
                                        kms.RightClick(Convert.ToInt32(actionValue.Split('，')[0]), Convert.ToInt32(actionValue.Split('，')[1]));
                                    }
                                    else
                                    {
                                        Console.WriteLine(string.Format("{0} 缺少值的分隔符 ',' 在这一行：{1}！\n", actionValue, line));
                                        Console.WriteLine(string.Format("{0} miss value split char ',' in line：{1}！\n", actionValue, line));
                                    }
                                }
                                else if (action == "Move" || action == "移动")
                                {
                                    if (actionValue.Contains(","))
                                    {
                                        kms.Move(Convert.ToInt32(actionValue.Split(',')[0]), Convert.ToInt32(actionValue.Split(',')[1]));
                                    }
                                    else if (actionValue.Contains("，"))
                                    {
                                        kms.Move(Convert.ToInt32(actionValue.Split('，')[0]), Convert.ToInt32(actionValue.Split('，')[1]));
                                    }
                                    else
                                    {
                                        Console.WriteLine(string.Format("{0} 缺少值的分隔符 ',' 在这一行：{1}！\n", actionValue, line));
                                        Console.WriteLine(string.Format("{0} miss value split char ',' in line：{1}！\n", actionValue, line));
                                    }
                                }
                                else if (action == "Drag" || action == "拖动")
                                {
                                    if (actionValue.Contains(","))
                                    {
                                        kms.Drag(Convert.ToInt32(actionValue.Split(',')[0]), Convert.ToInt32(actionValue.Split(',')[1]),
                                            Convert.ToInt32(actionValue.Split(',')[2]), Convert.ToInt32(actionValue.Split(',')[3]));
                                    }
                                    else if (actionValue.Contains("，"))
                                    {
                                        kms.Drag(Convert.ToInt32(actionValue.Split(',')[0]), Convert.ToInt32(actionValue.Split(',')[1]),
                                            Convert.ToInt32(actionValue.Split(',')[2]), Convert.ToInt32(actionValue.Split(',')[3]));
                                    }
                                    else
                                    {
                                        Console.WriteLine(string.Format("{0} 缺少值的分隔符 ',' 在这一行：{1}！\n", actionValue, line));
                                        Console.WriteLine(string.Format("{0} miss value split char ',' in line：{1}！\n", actionValue, line));
                                    }
                                }
                                else if (action == "Input" || action == "输入")
                                {
                                    kms.Input(actionValue);
                                }
                                else if (action == "Sleep" || action == "延迟")
                                {
                                    Thread.Sleep(Convert.ToInt32(actionValue));
                                }
                            }
                            catch (Exception exc)
                            {
                                Console.WriteLine(string.Format("{0} 解析 在这一行出错：{1}！\n错误：{2}", actionValue, line, exc.ToString()));
                                Console.WriteLine(string.Format("{0} meet error in line：{1}！\nerror: {2}", actionValue, line, exc.ToString()));
                            }
                        }
                        else
                        {
                            Console.WriteLine(string.Format("第{0}行必须包含分隔符\"###\",出错在这一行：{1}！\n", lineIndex, line));
                            Console.WriteLine(string.Format("The {0} line need contains \"###\" meet error in line：{1}！\n", lineIndex, line));
                        }
                    }
                    Console.WriteLine("Done" + lineIndex);
                }
            }
            Console.WriteLine("已完成所有操作，请输入回车退出本程序\n");
            Console.WriteLine("We have completed all operations, please press Enter key to exit current Application.\n");
            Console.ReadKey();
        }
    }
}
