using Applitools;
using Applitools.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Drawing;
using System;
using Configuration = Applitools.Selenium.Configuration;


namespace ApplitoolsTutorial
{

	public class BasicDemo
	{
		public static void Main(String[] args)
		{

			// Use Chrome browser
			IWebDriver driver = new ChromeDriver();

			// Initialize the Runner for your test.
			EyesRunner runner = new ClassicRunner();

			// Initialize the eyes SDK
			Eyes eyes = new Eyes(runner);

			SetUp(eyes);

			try
			{

				TestDemoApp(driver, eyes);

			}
			finally
			{

				TearDown(driver, runner);

			}

		}


		private static void SetUp(Eyes eyes)
		{

			// Initialize the eyes configuration.
			Configuration config = new Configuration();

			// Add this configuration if your tested page includes fixed elements.
			//config.setStitchMode(StitchMode.CSS);


			// You can get your api key from the Applitools dashboard
			//config.SetApiKey("APPLITOOLS_API_KEY");

			// set new batch
			config.SetBatch(new BatchInfo("Demo batch"));

			// set the configuration to eyes
			eyes.SetConfiguration(config);
		}

		private static void TestDemoApp(IWebDriver driver, Eyes eyes)
		{
			try
			{
				// Set AUT's name, test name and viewport size (width X height)
				// We have set it to 800 x 600 to accommodate various screens. Feel free to
				// change it.
				eyes.Open(driver, "Demo App", "Smoke Test", new Size(800, 600));

				// Navigate the browser to the "ACME" demo app.
				driver.Url = "https://demo.applitools.com";

				// To see visual bugs after the first run, use the commented line below instead.
				// driver.get("https://demo.applitools.com/index_v2.html");

				// Visual checkpoint #1 - Check the login page. using the fluent API
				// https://applitools.com/docs/topics/sdk/the-eyes-sdk-check-fluent-api.html?Highlight=fluent%20api
				eyes.Check(Target.Window().Fully().WithName("Login Window"));

				// This will create a test with two test steps.
				driver.FindElement(By.Id("log-in")).Click();

				// Visual checkpoint #2 - Check the app page.
				eyes.Check(Target.Window().Fully().WithName("App Window"));

				// End the test.
				eyes.CloseAsync();

			}
			catch (Exception e)
			{
				// If the test was aborted before eyes.close was called, ends the test as
				// aborted.
				eyes.AbortAsync();
			}
		}

		private static void TearDown(IWebDriver driver, EyesRunner runner)
		{
			driver.Quit();

			// Wait and collect all test results
			// we pass false to this method to suppress the exception that is thrown if we
			// find visual differences
			TestResultsSummary allTestResults = runner.GetAllTestResults(false);

			// Print results
			Console.WriteLine(allTestResults);
		}
	}
}
