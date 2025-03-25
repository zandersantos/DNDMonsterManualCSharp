using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System;

namespace DungeonsAndDragonsMonsterManualCSharp
{
    [TestFixture]
    public class SeleniumTest
    {
        [Test]
        public void OpenWebsiteTest()
        {
            IWebDriver driver = new ChromeDriver(@"C:\Users\zainz\Desktop\chromedriver.exe");
            try
            {
                driver.Url = "https://localhost:7068";
                Assert.That(driver.Title.Contains("Home - Dungeons and Dragons Monster Manual"), Is.True);

                // Print success message to console
                Console.WriteLine("It works! Website Opened and the Title is correct!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Test failed: {ex.Message}");
                throw;
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}