//Selenium Testing

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTests
{
    public class Test
    {
        public static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver("C:\\Users\\zainz\\Desktop\\chromedriver-win64\\chromedriver.exe");

            driver.Url = "https://localhost:7068/";

            driver.Quit();
        }
    }
}