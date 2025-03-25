using DungeonsAndDragonsMonsterManualCSharp.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DungeonsAndDragonsMonsterManualCSharp.Selenium

{
    public class Test
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver("C:\\Users\\zainz\\Desktop\\chromedriver-win64\\chromedriver-win64\\chromedriver.exe");
            driver.Url = "https://localhost:7068/";
        }
    }
}
