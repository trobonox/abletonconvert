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

namespace AbletonConvert
{
    static class AbletonConvert
    {
        static void Main(string[] args)
        {
            Console.Title = "AbletonConvert";
            if (args.Length == 0)
            {                
                Console.WriteLine("AbletonConvert [Version 0.1.0]\n(c) 2020 Trobonox. All rights reserved.\n");
                MainLoop();                
            }
            else
            {
                Console.WriteLine("AbletonConvert (c) 2020 Trobonox.");
                Console.WriteLine("\nConverting...");
                var isPathValid = Init(args[0]);
                if (isPathValid)
                    Converter.Convert();
            }    
        }

        static void MainLoop()
        {

            while (true)
            {
                var path = PathPrompt();
                var isPathValid = Init(path);

                if (isPathValid)
                {
                    Console.WriteLine("Converting...");
                    Converter.Convert();
                    break;
                }
            }
        }

        static string PathPrompt()
        {
            Console.WriteLine("Drag the file you want to convert onto this window: ");

            var path = Console.ReadLine().Trim('"');
            return path;
        }

        static bool Init(string path)
        {
            if (File.Exists(path))
            {
                AlsFile.FullPath = path;
                return true;
            }
            else
            {
                Console.WriteLine("Invalid path, please try again.");
                return false;
            }
            
        }
    }
}
