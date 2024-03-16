using System;
using System.Runtime.InteropServices;


namespace WindowsTools.utils
{
    public class SystemResources
    {
        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetPhysicallyInstalledSystemMemory(out long totalMemoryInKilobytes);

        private static int GetThreadCount()
        {
            return Environment.ProcessorCount;
        }

        private static int GetTotalRamMegaBytes()
        {
            try
            {
                if (GetPhysicallyInstalledSystemMemory(out var totalMemoryInKilobytes))
                {
                    return (int)(totalMemoryInKilobytes / 1024);
                }
                else
                {
                    throw new InvalidOperationException("No se pudo obtener la memoria RAM instalada.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener la memoria RAM: " + ex.Message);
                return 0;
            }
        }
        
        public static int CalculateMaxThreads()
        {
            var processorCount = GetThreadCount();
            var totalRamMb = GetTotalRamMegaBytes();

            const int memoryPerThreadMb = 200;

            var remainingRamMb = totalRamMb - (processorCount * memoryPerThreadMb);

            var maxThreads = Math.Max(30, Math.Min(150, remainingRamMb / memoryPerThreadMb + processorCount));

            return maxThreads;
        }
    }
}