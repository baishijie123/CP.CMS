using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace Sempel5
{

    public class TestClass<T>
    {
        T[] obj = new T[5]; // 定义一个长度为5的泛性类型的数组
        int count = 0;

        public void Add(T item)
        {
            if (count + 1 < 6)
            {
                obj[count] = item;

            }
            count++;
        }

        public T this[int index]
        {
            get { return obj[index]; }
            set { obj[index] = value; }
        }
    }


    class Program
    {
        static void Swap<T>(ref T a,ref T b)
        {
            T temp;
            temp = a;
            a = b;
            b = temp;
        }

        static void Main(string[] args)
        {
            ///--- 泛型演示
            //TestClass<int> intobj = new TestClass<int>();
            //intobj.Add(1);
            //intobj.Add(2);
            //intobj.Add(3);
            //intobj.Add(4);
            //intobj.Add(5);
            //for (int i = 0; i < 8; i++)
            //{
            //    Console.WriteLine(intobj[i]);   //没有拆箱
            //}

            ///--
            ///

            //交换两个整形数据
            string a = "4022..", b = "602..";
            Console.WriteLine("Before swap: {0}, {1}", a, b);

            Swap<string>(ref a, ref b);

            Console.WriteLine("After swap: {0}, {1}", a, b);


            Console.WriteLine("Hello World!");
            //test_insert();
            //test_mult_insert();
            //test_del();
            //test_mult_del();
            //test_update();
            //test_mult_update();
            //test_select_one();
            //test_select_list();
            //test_select_content_with_comment();
            Console.ReadKey();
        }



        /// <summary>
        /// 测试插入单条数据
        /// </summary>
        static void test_insert()
        {
            var content = new Content
            {
                title = "标题1",
                content = "内容1",

            };
            using (var conn = new SqlConnection("Data Source=.;User ID=sa;Password=bsj;Initial Catalog=TB;Pooling=true;Max Pool Size=100;"))
            {
                string sql_insert = @"INSERT INTO [Content]
                (title, [content], status, add_time, modify_time)
VALUES   (@title,@content,@status,@add_time,@modify_time)";
                var result = conn.Execute(sql_insert, content);
                Console.WriteLine($"test_insert：插入了{result}条数据！");
            }
        }
        /// <summary>
        /// 测试一次批量插入两条数据
        /// </summary>
        static void test_mult_insert()
        {
            List<Content> contents = new List<Content>() {
               new Content
            {
                title = "批量插入标题1",
                content = "批量插入内容1",

            },
               new Content
            {
                title = "批量插入标题2",
                content = "批量插入内容2",

            },
        };

            using (var conn = new SqlConnection("Data Source=.;User ID=sa;Password=bsj;Initial Catalog=TB;Pooling=true;Max Pool Size=100;"))
            {
                string sql_insert = @"INSERT INTO [Content]
                (title, [content], status, add_time, modify_time)
VALUES   (@title,@content,@status,@add_time,@modify_time)";
                var result = conn.Execute(sql_insert, contents);
                Console.WriteLine($"test_mult_insert：插入了{result}条数据！");
            }
        }

        /// <summary>
        /// 测试删除单条数据
        /// </summary>
        static void test_del()
        {
            var content = new Content
            {
                id = 2,

            };
            using (var conn = new SqlConnection("Data Source=.;User ID=sa;Password=bsj;Initial Catalog=TB;Pooling=true;Max Pool Size=100;"))
            {
                string sql_insert = @"DELETE FROM [Content]
WHERE   (id = @id)";
                var result = conn.Execute(sql_insert, content);
                Console.WriteLine($"test_del：删除了{result}条数据！");
            }
        }

        /// <summary>
        /// 测试一次批量删除两条数据
        /// </summary>
        static void test_mult_del()
        {
            List<Content> contents = new List<Content>() {
               new Content
            {
                id=3,

            },
               new Content
            {
                id=4,

            },
        };

            using (var conn = new SqlConnection("Data Source=.;User ID=sa;Password=bsj;Initial Catalog=TB;Pooling=true;Max Pool Size=100;"))
            {
                string sql_insert = @"DELETE FROM [Content]
WHERE   (id = @id)";
                var result = conn.Execute(sql_insert, contents);
                Console.WriteLine($"test_mult_del：删除了{result}条数据！");
            }
        }
        /// <summary>
        /// 测试修改单条数据
        /// </summary>
        static void test_update()
        {
            var content = new Content
            {
                id = 5,
                title = "标题5",
                content = "内容5",

            };
            using (var conn = new SqlConnection("Data Source=.;User ID=sa;Password=bsj;Initial Catalog=TB;Pooling=true;Max Pool Size=100;"))
            {
                string sql_insert = @"UPDATE  [Content]
SET         title = @title, [content] = @content, modify_time = GETDATE()
WHERE   (id = @id)";
                var result = conn.Execute(sql_insert, content);
                Console.WriteLine($"test_update：修改了{result}条数据！");
            }
        }

        /// <summary>
        /// 测试一次批量修改多条数据
        /// </summary>
        static void test_mult_update()
        {
            List<Content> contents = new List<Content>() {
               new Content
            {
                id=6,
                title = "批量修改标题6",
                content = "批量修改内容6",

            },
               new Content
            {
                id =7,
                title = "批量修改标题7",
                content = "批量修改内容7",

            },
        };

            using (var conn = new SqlConnection("Data Source=.;User ID=sa;Password=bsj;Initial Catalog=TB;Pooling=true;Max Pool Size=100;"))
            {
                string sql_insert = @"UPDATE  [Content]
SET         title = @title, [content] = @content, modify_time = GETDATE()
WHERE   (id = @id)";
                var result = conn.Execute(sql_insert, contents);
                Console.WriteLine($"test_mult_update：修改了{result}条数据！");
            }
        }

        /// <summary>
        /// 查询单条指定的数据
        /// </summary>
        static void test_select_one()
        {
            using (var conn = new SqlConnection("Data Source=.;User ID=sa;Password=bsj;Initial Catalog=TB;Pooling=true;Max Pool Size=100;"))
            {
                string sql_insert = @"select * from [dbo].[content] where id=@id";
                var result = conn.QueryFirstOrDefault<Content>(sql_insert, new { id = 5 });

                Console.WriteLine($"test_select_one：查到的数据为： result.content{ result.content}--result.id{result.id}");
            }
        }

        /// <summary>
        /// 查询多条指定的数据
        /// </summary>
        static void test_select_list()
        {
            using (var conn = new SqlConnection("Data Source=.;User ID=sa;Password=bsj;Initial Catalog=TB;Pooling=true;Max Pool Size=100;"))
            {
                string sql_insert = @"select * from [dbo].[content] where id in @ids";
                var result = conn.Query<Content>(sql_insert, new { ids = new int[] { 6, 7 } });

                foreach (var item in result)
                {
                    Console.WriteLine($"test_select_one：查到的数据为：item.content{ item.content}--item.id{item.id}");
                }


            }
        }
        /// <summary>
        /// 两表关联查询
        /// </summary>

        static void test_select_content_with_comment()
        {
            using (var conn = new SqlConnection("Data Source=.;User ID=sa;Password=bsj;Initial Catalog=TB;Pooling=true;Max Pool Size=100;"))
            {

                string sql_insert = @"select * from content where id=@id;
select * from comment where content_id=@id;";
                using (var result = conn.QueryMultiple(sql_insert, new { id = 5 }))
                {
                    var content = result.ReadFirstOrDefault<ContentWithCommnet>();
                    content.comments = result.Read<Comment>();
                    // 疑惑：content.comments的count 值如何让获取

                    Console.WriteLine($"test_select_content_with_comment:内容5的评论数量{ content.comments}");
                }

            }
        }

    }
}
