using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafy_7
{
    class Program
    {
        static void Main(string[] args)
        {

            if (File.Exists(".\\" + args[0]))
            {
                Stack<StackItem> stack = new Stack<StackItem>();
                string data = File.ReadAllText(".\\" + args[0]);

                data = data.Replace(" ", "");

                // string data = "(a(b3)2)"; //abbbabbb

                for (int i = 0; i < data.Length;)
                {
                    if (data[i] == '(')
                    {
                        stack.Push(new StackItem(i + 1));
                        i++;
                    }
                    else if (data[i] == ')')
                    {
                        StackItem temp = stack.Pop();
                        temp.repeatNow++;
                        if (temp.repeat > temp.repeatNow)
                        {
                            i = temp.startIndex;
                            stack.Push(temp);
                        }
                        else i++;
                    }
                    else if (data[i] > 47 && data[i] < 58)
                    {
                        StackItem temp = stack.Pop();
                        if (temp.repeatNow == 0) temp.repeat = (temp.repeat * 10) + Int32.Parse(data[i].ToString());
                        stack.Push(temp);
                        i++;
                    }
                    else { Console.Write(data[i]); i++; }
                }
            }
            else Console.WriteLine("Nie ma takiego pliku");
        }
    }
}