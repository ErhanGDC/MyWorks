using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace Words_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!File.Exists("WordLookup.txt")) // Contains about 150,000 words
                new WebClient().DownloadFile(
                "http://www.albahari.com/ispell/allwords.txt", "WordLookup.txt");
            var wordLookup = new HashSet<string>(
            File.ReadAllLines("WordLookup.txt"),
            StringComparer.InvariantCultureIgnoreCase);

            //We’ll then use our word lookup to create a test “document” comprising an array of
            //a million random words. After building the array, we’ll introduce a couple of spelling
            //mistakes:

            var random = new Random();
            string[] wordList = wordLookup.ToArray();
            string[] wordsToTest = Enumerable.Range(0, 1000000)
            .Select(i => wordList[random.Next(0, wordList.Length)])
            .ToArray();
            wordsToTest[12345] = "woozsh"; // Introduce a couple
            wordsToTest[23456] = "wubsie"; // of spelling mistakes.

            var query = wordsToTest
            .AsParallel()
            .Select((word, index) => new IndexedWord { Word = word, Index = index })
            .Where(iword => !wordLookup.Contains(iword.Word))
            .OrderBy(iword => iword.Index);
            foreach (var mistake in query)
                Console.WriteLine(mistake.Word + " - index = " + mistake.Index);


            // The following query multiplies each element by its position.
            // Given an input of Enumerable.Range(0,999), it should output squares.
            int i1 = 0;
            var query1 = from n in Enumerable.Range(0, 999).AsParallel() select n * i1++;
            //var query = Enumerable.Range(0, 999).AsParallel().Select((n, i) => n * i); Correct One

            
            // The ForAll method runs a delegate over every output element of a ParallelQuery. It
            //hooks right into PLINQ’s internals, bypassing the steps of collating and enumerating
            //the results. To give a trivial example:
            "abcdef".AsParallel().Select(c => char.ToUpper(c)).ForAll(Console.Write);
        }
    }
    struct IndexedWord { public string Word; public int Index; }
}
