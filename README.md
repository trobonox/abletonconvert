# AbletonConvert
![Build](https://github.com/trobonox/abletonconvert/workflows/Build/badge.svg)
![Codacy Badge](https://img.shields.io/codacy/grade/7aaa8befa9f34ac79f9834597e5f6b4a)
![License](https://img.shields.io/github/license/trobonox/abletonconvert)
![Release](https://img.shields.io/github/v/release/trobonox/abletonconvert)


AbletonConvert is a Tool that allows you to use Ableton Live 10.1.x Files in Version 10.0.x. This is especially useful for people who want to get better performance in Ableton Projects which don't use the new features of Live 10.1. A good example are Launchpad Covers with complex Lightshows, which get a performance boost in 10.0.x.

## Getting started
Prerequisites: to run the Tool, you need to make sure that you have the .NET Core SDK/Runtime installed. You can download it here: https://dotnet.microsoft.com/download/.

-  Download the latest release: https://github.com/trobonox/AbletonConvert/releases
-  Unpack the .zip/.tar.gz
-  Open the folder you just unpacked
-  Double click **AbletonConvert** (.exe on Windows, Unix Executable on Linux - not the .dll)
-  You will get a prompt for the file path: navigate to the file you want to convert and either drag and drop it onto the converter window, or paste the full path in manually
-  Press Enter and wait until the conversion process is done. (You should get a message saying "Done.")
-  You will find the converted file in the same folder as the original file. On Linux the converted file may be found in a different folder (usually one folder above original file).

After the conversion process is done, you should be able to open the .als file in Live 10.0.x without getting any errors. (Searching for missing media files may be needed).

## Support
Have any problems? Here's some stuff to help you out:
-  If you think you found a bug or want to suggest a feature: open an **Issue**
-  I can occasionally offer further support on my Discord server: https://discord.gg/ggNQkqAeRN

## Build from Source
To build this tool, follow these instructions:
1. Download and install [.NET Core SDK](https://www.microsoft.com/net/download)
2. Clone this repo
3. On Windows, you can run /build/build.cmd and get the output in /src/bin/release
4. On Linux you can manually build using `dotnet publish` or `dotnet build` (script for Linux will be published when available).


## Contributing
Thank you for being interested in contributing to the project!
Everyone is welcome to contribute, but before you start coding anything, please discuss the changes you'd like to make via issue or Discord.
Please also include a brief description that includes these points:
-  What do you want to add/change? Use a clear and descriptive title.
-  Describle the new feature/bugfix briefly. If your contribution is a bugfix, please explain which behavior you expected to see.
-  How well does your implementation work? Did you test it successfully before submitting it?
-  Provide short information about your OS and development environment.
-  _optional, but recommended:_ Additional context that might help me understand what you want to contribute. 

## License
``` 
Copyright 2020 Trobonox (trobonox.dev@gmail.com)

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at
```
-  http://www.apache.org/licenses/LICENSE-2.0

```
Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
```

## Misc
**For warranty and liability terms, please refer to chapters "Disclaimer of Warranty" and "Limitation of Liability" of the Apache License 2.0.**

Notice of Non-Affiliation and Disclaimer: **I am not affiliated, associated, authorized, endorsed by, or in any way officially connected with Ableton AG, or any of its subsidiaries or its affiliates. The official Ableton website can be found at https://ableton.com.**

**The name Ableton® as well as related names, marks, emblems and images are registered trademarks of Ableton AG.**

Links to other websites: **Links to websites of third parties are provided to you as an additional service. These websites are completely independent and outside the control of Trobonox. Trobonox is not liable for the content of any of these third-party websites that are accessed from the github repository, and assumes no responsibility for the content, data protection provisions or use of such websites.**

