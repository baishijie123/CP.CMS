using System;
using System.Collections.Generic;
using System.Text;

namespace Dictionary
{
    class Program
    {
        public class emp
        {
            private string name;
            private int salary;

            public emp(string name, int salary)
            {
                this.name = name;
                this.salary = salary;
            }
            public override string ToString()
            {
                StringBuilder sb = new StringBuilder(200);
                sb.AppendFormat("{0},{1}", name, salary);

                return sb.ToString();
            }

           



        }
      
        static void Main(string[] args)
        {
           

            ////定义一个字典集合
            //Dictionary<int, string> dObj = new Dictionary<int, string>(5);
            ////向字典中添加类型
            //dObj.Add(1, "Tom");
            //dObj.Add(2, "John");
            //dObj.Add(3, "Maria");
            //dObj.Add(4, "Max");
            //dObj.Add(5, "Ram");
            ////输出数据
            //for (int i = 1; i <= dObj.Count; i++)
            //{
            //    Console.WriteLine(dObj[i]);
            //}

            //定义一个字典集合 
            Dictionary<string, emp> dObj = new Dictionary<string, emp>(2);
            // 向字典中添加元素
            emp tom = new emp("tom", 2000);
            dObj.Add("tom", tom);   // 键，值 
            emp john = new emp("john", 4000);
            dObj.Add("john", john);
            foreach (Object str in dObj.Values)
            {
                Console.WriteLine(str);
            }
            Console.ReadKey();
           
        }
    }
}
