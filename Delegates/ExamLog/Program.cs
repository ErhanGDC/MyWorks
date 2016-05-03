using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamLog
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.WriteLine("Starting application");
            Debug.Indent();
            int i = 1 + 2;
            Debug.Assert(i == 3);
            Debug.WriteLineIf(i > 0, "i is greater than 0");

            TraceSource traceSource = new TraceSource("myTraceSource", SourceLevels.All);
            traceSource.TraceInformation("Tracing application..");
            traceSource.TraceEvent(TraceEventType.Critical, 0, "Critical trace");
            traceSource.TraceData(TraceEventType.Information, 1,
            new object[] { "a", "b", "c" });
            traceSource.Flush();
            traceSource.Close();

            DoTrace();

            Console.ReadLine();
        }
        public static void DoTrace()
        {
            Stream outputFile = File.Create("tracefile.txt");
            TextWriterTraceListener textListener =
            new TextWriterTraceListener(outputFile);
            TraceSource traceSource = new TraceSource("myTraceSource",
            SourceLevels.All);
            traceSource.Listeners.Clear();
            traceSource.Listeners.Add(textListener);
            traceSource.TraceInformation("Trace output");
            traceSource.Flush();
            traceSource.Close();
        }
    }
}
