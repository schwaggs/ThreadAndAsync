using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadAndAsync
{
    // Can use functions in place of lamdas or anonymous functions.
    // Thse are delegates:
    /*
     * A delegate in C# is similar to a function pointer in C or C++. 
     * Using a delegate allows the programmer to encapsulate a reference to a method inside a delegate object. 
     * The delegate object can then be passed to code which can call the referenced method, without having to know 
     * at compile time which method will be invoked.
     */

    class Program
    {
        // Make a global variable that each thread will have a "copy" of.
        [ThreadStatic]
        public static int _field;

        static void Main(string[] args)
        {
            // Threads created with the thread class are created and destroyed
            #region Creating Threads With Thread Class

            // Foreground Thread - Program will not terminate until foreground threads are finished
            //Thread t = new Thread(new ThreadStart(ThreadMethod_0));

            //t.Start();

            //for (int i = 0; i < 4; i++)
            //{
            //    Console.WriteLine("Main Thread {0}", i);
            //    Thread.Sleep(0);
            //}

            //t.Join();

            //Console.ReadLine();

            // Background Thread - Program will close regardless of if the thread has completed
            // Can use join to keep alive until background thread is finished
            //Thread t = new Thread(new ThreadStart(ThreadMethod_1));
            //t.IsBackground = true;
            //t.Start();


            #endregion Creating Threads With Thread Class


            #region Parameterized Thread Start

            //Thread t = new Thread(new ParameterizedThreadStart(ThreadMethod));
            //t.Start(15);

            //t.Join();

            #endregion Parameterized Thread Start


            #region Stopping A Thread

            //bool stopped = false;

            //Thread t = new Thread(new ThreadStart(() =>
            //{
            //    while (!stopped)
            //    {
            //        Console.WriteLine("Running...");
            //        Thread.Sleep(1000);
            //    }

            //    // Here we are still in the thread, before it closes

            //}));

            //t.Start();
            //Console.WriteLine("Press Any Key To Stop Thread");
            //Console.ReadKey();
            //stopped = true;

            #endregion Stopping A Thread


            #region Using The ThreadStaticAttribute

            //Thread t1 = new Thread(new ThreadStart(() =>
            //{

            //    for (int i = 0; i < 10; i++)
            //    {
            //        _field++;
            //        Console.WriteLine("Field t1: {0}", _field);
            //    }

            //}));

            //t1.Start();

            //Thread t2 = new Thread(new ThreadStart(() =>
            //{

            //    for (int i = 0; i < 10; i++)
            //    {
            //        _field++;
            //        Console.WriteLine("Field t2: {0}", _field);
            //    }

            //}));

            //t2.Start();

            #endregion Using The ThreadStaticAttribute


            // Threads created can be put in the thread pool instead of destroying them
            // But cannot manage the thread
            #region Queuing Work to the Thread Pool

            //ThreadPool.QueueUserWorkItem((s)=>
            //{
            //    Console.WriteLine("Working on thread from pool");
            //});

            //Console.ReadLine();

            #endregion Queuing Work to the Thread Pool


            // Tasks are managed thread pool threads
            #region Starting a New Task

            // Using Lambda
            //Task t = Task.Run(() =>
            //{
            //    for (int i = 0; i < 100; i++)
            //    {
            //        Console.Write('*');
            //    }
            //});

            //t.Wait(); // Same as join

            // Using function
            //Task t = Task.Run(action: ThreadMethod);
            //t.Wait();

            #endregion Starting a New Task


            #region Using a Task With Return and Continuation

            // Task with continuation
            //Task<int> t = Task.Run(() =>
            //{
            //    return 42;
            //}).ContinueWith((i) =>
            //{
            //    return i.Result * 2;
            //});

            //// Seperating the continuation
            //t = t.ContinueWith((i) =>
            //{
            //    return i.Result * 2;
            //});

            // Only use a continuation on fault
            //Task<int> t = Task.Run(() =>
            //{
            //    // Uncomment for fault
            //    //throw new Exception();

            //    // Uncomment for completion
            //    return 42;
            //});

            //t.ContinueWith((i) =>
            //{
            //    Console.WriteLine("Faulted");

            //}, TaskContinuationOptions.OnlyOnFaulted);

            //t.ContinueWith((i) =>
            //{
            //    Console.WriteLine("Completed");
            //}, TaskContinuationOptions.OnlyOnRanToCompletion);

            //Console.WriteLine(t.Result);

            #endregion Using a Task With Return and Continuation


            #region Using Task.WaitAll

            //Task[] tasks = new Task[3];

            //tasks[0] = Task.Run(() =>
            //{
            //    Thread.Sleep(1000);
            //    Console.WriteLine("1");
            //    return 1;
            //});

            //tasks[1] = Task.Run(() =>
            //{
            //    Thread.Sleep(1000);
            //    Console.WriteLine("2");
            //    return 1;
            //});

            //tasks[2] = Task.Run(() =>
            //{
            //    Thread.Sleep(1000);
            //    Console.WriteLine("3");
            //    return 1;
            //});

            //Task.WaitAll(tasks);

            #endregion Using Task.WaitAll


            #region Using Task.WaitAny

            //Task<int>[] tasks = new Task<int>[3];

            //tasks[0] = Task.Run(() =>
            //{
            //    Thread.Sleep(2000);
            //    return 1;
            //});

            //tasks[1] = Task.Run(() =>
            //{
            //    Thread.Sleep(1000);
            //    return 2;
            //});

            //tasks[2] = Task.Run(() =>
            //{
            //    Thread.Sleep(3000);
            //    return 3;
            //});

            //// As tasks finish, display the completed tasks result
            //while (tasks.Length > 0)
            //{
            //    int i = Task.WaitAny(tasks);

            //    Task<int> completedTask = tasks[i];
            //    Console.WriteLine(completedTask.Result);

            //    var temp = tasks.ToList();
            //    temp.RemoveAt(i);
            //    tasks = temp.ToArray();
            //}

            #endregion Using Task.WaitAny


            #region Using Parallel.For and Parallel.Foreach

            //// Same order everytime
            //for(int i = 0; i < 10; i ++)
            //{
            //    Console.WriteLine(i);
            //    Thread.Sleep(1000);
            //}

            //Console.WriteLine("Press any key for parallel for loop");
            //Console.ReadLine();

            //// Random order
            //Parallel.For(0, 10, (i) =>
            //{
            //    Console.WriteLine(i);
            //    Thread.Sleep(1000);
            //});

            //Console.WriteLine("Press any key to exit");
            //Console.ReadLine();

            //int[] myArray = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //foreach (int x in myArray)
            //{
            //    Console.WriteLine(x);
            //    Thread.Sleep(1000);
            //}

            //Console.WriteLine("Press any key for aprallel foreach loop");
            //Console.ReadLine();

            //Parallel.ForEach(myArray, (x) =>
            //{
            //    Console.WriteLine(x);
            //    Thread.Sleep(1000);
            //});

            #endregion Using Parallel.For and Parallel.Foreach


            #region Using Async and Await

            // Not directly involved with creating threads
            string result = DownloadContent().Result;
            Console.WriteLine(result);


            #endregion  Using Async and Await

        }

        #region Creating Threads With Thread Class

        public static void ThreadMethod_0()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Thread Process {0}", i);

                // Dont need any more time, release thread time for something else to use
                Thread.Sleep(0);
            }
        }

        public static void ThreadMethod_1()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Thread Process {0}", i);

                // Dont need any more time, release thread time for something else to use
                Thread.Sleep(1000);
            }
        }

        #endregion Creating Threads With Thread Class


        #region Parameterized Thread Start

        public static void ThreadMethod(object o)
        {
            for (int i = 0; i < (int)o; i++)
            {
                Console.WriteLine("Thread {0}", i);
                Thread.Sleep(0);
            }
        }

        #endregion Parameterized Thread Start


        #region Starting a New Task

        public static void ThreadMethod()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.Write('*');
            }
        }

        #endregion Starting a New Task


        #region Using Async and Await

        public static async Task<string> DownloadContent()
        {
            using (HttpClient client = new HttpClient())
            {
                string result = await client.GetStringAsync("http://www.microsoft.com");
                return result;
            }
        }

        #endregion  Using Async and Await
    }
}
