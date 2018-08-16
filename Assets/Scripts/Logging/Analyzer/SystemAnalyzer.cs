using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using UnityEngine;

namespace NoMansBlocks.Logging {
    /// <summary>
    /// Builds a small snapshot of the system the code is 
    /// running on. This can be useful for things such as 
    /// log reports, or reproducing issues later on.
    /// </summary>
    public class SystemAnalyzer {
        #region Publics
        /// <summary>
        /// Analyze the system and collect some meta data about it.
        /// This helps with recreating issues or determining problems
        /// later on.
        /// </summary>
        /// <returns>The system info collected</returns>
        public SystemInfo GetSystemInfo() {
            //First figure out the cpu info
            CpuInfo cpuInfo = new CpuInfo {
                Architecture = Environment.Is64BitOperatingSystem ? "64-Bit" : "32-Bit",
                CoreCount    = Environment.ProcessorCount,
                Model        = UnityEngine.SystemInfo.processorType,
                Frequency    = UnityEngine.SystemInfo.processorFrequency
            };

            GpuInfo gpuInfo = new GpuInfo {
                Make       = UnityEngine.SystemInfo.graphicsDeviceVendor,
                Model      = UnityEngine.SystemInfo.graphicsDeviceName,
                MemorySize = UnityEngine.SystemInfo.graphicsMemorySize
            };

            return new SystemInfo {
                Cpu          = cpuInfo,
                Gpu          = gpuInfo,
                ComputerName = UnityEngine.SystemInfo.deviceName,
                Model        = UnityEngine.SystemInfo.deviceModel
            };
        }
        #endregion
    }
}
