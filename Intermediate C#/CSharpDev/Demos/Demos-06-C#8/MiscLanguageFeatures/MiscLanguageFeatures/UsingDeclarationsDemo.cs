using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MiscLanguageFeatures
{
    public class UsingDeclarationsDemo
    {
        public static void DoDemo()
        {
            Console.WriteLine("\nUsingDeclarationsDemo");
            Console.WriteLine("------------------------------------------------------");

            UsingBlocks1("infile.txt");
            UsingDeclarations1("infile.txt");

            UsingBlocks2("infile.txt", "outfile1.txt");
            UsingDeclarations2("infile.txt", "outfile2.txt");
        }

        private static void UsingBlocks1(string inFilename)
        {
            using (var reader = new StreamReader(inFilename))
            {
                var contents = reader.ReadToEnd();
                Console.WriteLine(contents);
            } // Dispose() method called at end of "using" block.
        }

        private static void UsingDeclarations1(string inFilename)
        {
            using var reader = new StreamReader(inFilename);
            var contents = reader.ReadToEnd();
            Console.WriteLine(contents);
        } // Dispose() method called when "using" variable goes out of scope.

        private static void UsingBlocks2(string inFilename, string outFilename)
        {
            using (var reader = new StreamReader(inFilename))
            using (var writer = new StreamWriter(outFilename))
            {
                var contents = reader.ReadToEnd();
                writer.Write(contents);
            } // Dispose() methods called at end of "using" block.
        }

        private static void UsingDeclarations2(string inFilename, string outFilename)
        {
            using var reader = new StreamReader(inFilename);
            using var writer = new StreamWriter(outFilename);

            var contents = reader.ReadToEnd();
            writer.Write(contents);
        } // Dispose() methods called when "using" variables go out of scope.
    }
}
