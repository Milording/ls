using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace ABBYY_LS.Tests
{
    /// <summary>
    /// Class for logging in file.
    /// </summary>
    public static class LogFile
    {
        /// <summary>
        /// Creates a log message.
        /// </summary>
        /// <param name="testResult">Test of current context.</param>
        public static void LogMessage(TestContext testResult)
        {
            var message = string.Format("[{0:s}] [{1}] {2}", DateTime.Now, testResult.Test.FullName,
                testResult.Result.FailCount > 0 ? testResult.Result.Message : "Success");
            writeFile(message);
        }

        /// <summary>
        /// Writes a message in file.
        /// </summary>
        /// <param name="message">Information message.</param>
        private static void writeFile(string message)
        {
            using (var file = File.Open("log.txt", FileMode.Append))
            using (var writer = new StreamWriter(file))
            {
                writer.WriteLine(message);
            }
        }
    }
}
