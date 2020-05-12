# Pre-requisites:

1. Visual Studio installed on your machine.
   * [Install it from here](https://visualstudio.microsoft.com/downloads/)
2. Chrome Webdriver is on your machine and is in the PATH. Here are some resources from the internet that'll help you.
   * https://splinter.readthedocs.io/en/0.1/setup-chrome.html
   * https://stackoverflow.com/questions/38081021/using-selenium-on-mac-chrome
   * https://www.youtube.com/watch?time_continue=182&v=dz59GsdvUF8

# Steps to run this example

1. Git clone this repo
    * `git clone https://github.com/applitools/tutorial-selenium-csharp-basic.git`
2. Open the folder `tutorial-selenium-csharp-basic`
3. Get your API key to set it in code (or in the APPLITOOLS_API_KEY environment variable).
    * You can get your API key by logging into Applitools > Person Icon > My API Key.
4. Double click the `ApplitoolsTutorial.sln`. This will open the project in Visual Studio.

   **MAKE SURE YOU HAVE THE _APPLITOOLS_API_KEY_ ENVIRONMENT VARIABLE SET BEFORE YOU START VISUAL STUDIO**
5. Set your ApiKey in string 'config.ApiKey = ' (or comment the string and set APPLITOOLS_API_KEY environment variable)
6. Navigate to Test Explorer and hit Run
