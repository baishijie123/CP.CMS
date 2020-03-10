using System;
using System.Collections;
namespace QueueLX
{
    /// <summary>
    /// 队列Demo
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * 队列是一种特殊类型的容器，可确保以FIFO（先进先出）方式访问元素。队列集合最适合实现消息传递的组件。我们可以使用以下语法定义Queue集合对象：
             * 
             * Enqueue():在队列的末端添加元素
             * Dequeue():在队列的头部读取和删除一个元素，注意，这里读取元素的同时也删除了这个元素。如果队列中不再有任何元素。就抛出异常
             * Peek():在队列的头读取一个元素，但是不删除它
             * Count：返回队列中的元素个数
             * TrimExcess():重新设置队列的容量，因为调用Dequeue方法读取删除元素后不会重新设置队列的容量。
             * Contains():确定某个元素是否在队列中
             * CopyTo():把元素队列复制到一个已有的数组中
             * ToArray():返回一个包含元素的新数组
            */
            //定义一个队列
            Queue qObj = new Queue();

            //向队列中添加字符串数据
            qObj.Enqueue("Tom");
            qObj.Enqueue("Harry");
            qObj.Enqueue("Maria");
            qObj.Enqueue("john");

            //显示队列中的数据 
            while (qObj.Count != 0)
            {
                Console.WriteLine(qObj.Dequeue());
            }

            Console.ReadKey();
        }
    }
}
