using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*******************************************************************
            *                         作者：张潇                               *
            *              邮箱:robert.zhangxiao@gmail.com                     *
            *                         使用语言：C#                             *
            *                   初次提交日期： 2020/08/03                      *
            *******************************************************************/

            String path = @"C:\Users\Administrator\Desktop\技术音频工程师-A卷-7天\技术音频测试题（A卷）\submit\1\input";
            DirectoryInfo folder = new DirectoryInfo(path);
            var lstString = new List<string>();
            foreach (FileInfo file in folder.GetFiles("*.h", SearchOption.AllDirectories))
            {   
                /* 获取指定目录path中所有子文件（包括子目录中的文件）地址。
                ** 通过判断文件地址中是否含有".h"文件后缀可以过滤得到所有的头文件并以文本形式进行按行读取。
                */

                string[] lines = System.IO.File.ReadAllLines(file.FullName);
                foreach (string line in lines)
                {
                    string pattern = @"^class.*?[a-zA-Z]$";
                    Match match = Regex.Match(line, pattern);

                    if (match.Success)
                    {

                /* 首先通过正则化提取所有类的名字（不包括内部类和前置声明类）。
                ** 将匹配后的结果前后添加tag字符以方便后期输出至html文件中并保存至原先定义好的字符串列表lines中。
                */

                        lstString.Add("<p>" + line.Replace("class", "") + "</p>");
                    }
                }

            }
            

            lstString =
               lstString
               .Where(w => w.ToCharArray().Length > 0) 
               //忽略空值
               .Select(s => new { OriginalString = s, GetAsciiofFirstChar = (int)s.ToCharArray().Take(1).Single() }) 
               //找到第一个字母的ASCII值
               .OrderBy(o => o.GetAsciiofFirstChar) 
               //通过以知的第一个字母的ASCII值进行排序
               .Select(s => s.OriginalString) 
               //对输入的字符串进行排序
               .Union(lstString.Where(s => s.ToCharArray().Length == 0)) 
               //返回结果
               .ToList(); //将IEnumerable转成列表输出

            /* 将原字符串列表进行ASCII排序。
            ** 此部分排序代码原理笔者参考：C#, A., & Team), N. (2020). Ascii Sort on a Collection in C# - DotNetFunda.com. Retrieved 3 August 2020, from https://www.dotnetfunda.com/articles/show/3219/ascii-sort-on-a-collection-in-csharp
            */

            string path_2 = @"C:\Users\Administrator\Desktop\技术音频工程师-A卷-7天\技术音频测试题（A卷）\submit\1\output\report.html";
            var result = String.Join("\n", lstString);
            System.IO.File.WriteAllText(path_2, string.Empty);
            File.WriteAllText(path_2, Regex.Replace(File.ReadAllText(path_2), @"", result));
            //读取html文件，最后将处理后的字符串列表输出至指定文件路径。
            
        }
    }
}