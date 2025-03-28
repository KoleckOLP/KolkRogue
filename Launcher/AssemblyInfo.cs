using System;
using System.IO;
using System.Reflection;

namespace Launcher
{
    public static class AssemblyInfo
    {
        private static DateTime? _Date;

        static AssemblyInfo()
        {
            _Date = GetLinkerTime(Assembly.GetExecutingAssembly());
        }

        /// <summary>
        /// Gets the linker date from the assembly header.
        /// </summary>
        public static DateTime Date
        {
            get { return _Date.GetValueOrDefault(DateTime.MinValue); }
        }

        /// <summary>
        /// Gets the linker date of the assembly.
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        /// <remarks>https://blog.codinghorror.com/determining-build-date-the-hard-way/</remarks>
        private static DateTime? GetLinkerTime(Assembly assembly)
        {
            try
            {
                var filePath = assembly.Location;
                const int c_PeHeaderOffset = 60;
                const int c_LinkerTimestampOffset = 8;
                var buffer = new byte[2048];

                using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);

                    if (bytesRead < c_PeHeaderOffset + 4)
                    {
                        return null; // Invalid PE file.
                    }

                    var offset = BitConverter.ToInt32(buffer, c_PeHeaderOffset);

                    if (offset > bytesRead - 4)
                    {
                        return null; // Invalid PE file.
                    }

                    var secondsSince1970 = BitConverter.ToInt32(buffer, offset + c_LinkerTimestampOffset);
                    var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                    var linkTimeUtc = epoch.AddSeconds(secondsSince1970);
                    return linkTimeUtc.ToLocalTime();
                }
            }
            catch (Exception)
            {
                return null; // Handle exceptions gracefully.
            }
        }
    }
}