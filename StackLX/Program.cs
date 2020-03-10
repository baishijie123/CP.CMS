using System;
using System.Collections;
/// <summary>
///堆栈Demoo
///Stack集合是LIFO的抽象（后进先出）。我们可以使用以下语法定义Stack集合对象：
///Stack qObj = new Stack();
///Contains() 如果在集合中找到特定元素，则返回true。
///Clear()  删除集合的所有元素。
///Peek() 预览堆栈中的最新元素。
///Push()  它将元素推入堆栈。
///Pop()  返回并删除堆栈的顶部元素。
/// </summary>
namespace StackLX
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] iArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //定义一个堆栈
            Stack sObj = new Stack(iArray);
            Console.WriteLine("Total items=" + sObj.Count);
            //显示集合数据
            for (int i = 0; i < sObj.Count; ++i)
            {
                Console.WriteLine(sObj.Peek());
            }
            Console.ReadKey();
        }
    }
}
