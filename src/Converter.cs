/*
 Copyright 2020 Trobonox (trobonox.dev@gmail.com)

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AbletonConvert
{
    static class Converter
    {
        static string newPath = AlsFile.FullPath + " - copy";

        public static void Convert()
        {
            var CopyCreated = CreateCopy();
            if (CopyCreated)
            {
                UnpackGzip();
                EditFileContent();
                RepackAndClean();
                Console.WriteLine("Done.");
            }
        }

        private static bool CreateCopy()
        {
            try
            {
                File.Copy(AlsFile.FullPath, newPath + ".gz");
                return true;
            }
            catch (IOException)
            {
                Console.WriteLine("Error (File may already be unpacked)");
                return false;
            }
        }

        private static void UnpackGzip()
        {
            string directoryName = Path.GetDirectoryName(AlsFile.FullPath);
            DirectoryInfo directorySelected = new DirectoryInfo(directoryName);

            foreach (FileInfo fileToDecompress in directorySelected.GetFiles("*.gz"))
            {
                Gzip.Decompress(fileToDecompress);
            }
        }

        static void EditFileContent()
        {
            ChangeHeader();
            RemoveNoteId();
            RemoveDelayDevice();
        }

        private static void ChangeHeader()
        {
            string[] lines;
            
            lines = File.ReadAllLines(newPath);
            lines[1] = "<Ableton MajorVersion=\"5\" MinorVersion=\"10.0_370\" SchemaChangeCount=\"2\" Creator=\"Ableton Live 10.0.1\" Revision=\"24db47c40277255afc4229905992e7654e23ec0f\">";
            lines[3] = "        <NextPointeeId Value=\"37798\" />";
            lines[4] = "        <OverwriteProtectionNumber Value=\"2560\" />";                
           
            File.WriteAllLines(newPath, lines);
        }

        public static void RemoveNoteId()
        {
            string[] lines = File.ReadAllLines(newPath);
            var counter = 0;
            foreach (string line in lines)
            {
                var newLine = Regex.Replace(line, "NoteId=\"\\d*\"", "");
                lines[counter] = newLine;
                counter++;                
            }
            File.WriteAllLines(newPath, lines);
        }

        //kinda big, might need a refactor or something (help wanted)
        public static void RemoveDelayDevice()
        {
            string[] lines = File.ReadAllLines(newPath);

            string delayIdPattern = "<Delay Id=\"\\d\">";
            string deviceChainPattern = "</DeviceChain>";

            int flag = 0;
            int lineToDeleteStart = 0;
            int lineToDeleteEnd = 0;

            int lineNum = 0;

            foreach (string line in lines)
            {
                var startMatchFound = Regex.IsMatch(line, delayIdPattern);
                var endMatchFound = Regex.IsMatch(line, deviceChainPattern);

                if (startMatchFound && flag == 0)
                {
                    lineToDeleteStart = lineNum - 2;
                    flag = 1;
                }

                if (endMatchFound && flag == 1)
                {
                    lineToDeleteEnd = lineNum;
                    flag = 0;
                }

                lineNum++;
            }

            int i = lineToDeleteStart;
            if (lineToDeleteStart != 0)
            {
                while (i <= lineToDeleteEnd)
                {
                    lines[i] = "";
                    if (i == lineToDeleteEnd)
                        break;
                    i++;
                }
            }

            lines = lines.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            File.WriteAllLines(newPath, lines);
        }

        public static void RepackAndClean()
        {
            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(AlsFile.FullPath);
            string directoryName = Path.GetDirectoryName(AlsFile.FullPath);
            FileInfo fileToBeGZipped = new FileInfo(newPath);

            File.Delete(newPath + " - copy.gz");                        
            Gzip.Compress(fileToBeGZipped);           
            File.Move(newPath + ".gz", directoryName + "\\" +  fileNameWithoutExtension + " - converted.als");

            CleanTemporaryFiles();
        }

        public static void CleanTemporaryFiles()
        {
            File.Delete(newPath);
        }
    }
}
