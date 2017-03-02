using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UnleashedTest.Global
{
    class Login
    {
        //create constructor method
        public  Login()
        {
            PageFactory.InitElements(CommonMethods.driver, this);
        }
        //Define POM
        //Identification of Login field
        [FindsBy(How=How.XPath,Using = ".//*[@id='username']")]
        IWebElement Email { get; set; }
        [FindsBy(How=How.XPath,Using = ".//*[@id='password']")]
        IWebElement Password { get; set; }
        [FindsBy(How=How.XPath,Using = ".//*[@id='btnLogOn']")]
        IWebElement LogOnBtn { get; set; }


        internal void LoginSteps()
        {
            // Populating the data from Excel
            ExcelLib.PopulateInCollection(InventoryTest.ExcelPath, "LoginPage");
            //Luanch the URL
            CommonMethods.driver.Navigate().GoToUrl(ExcelLib.ReadData(2,"URL"));
            Thread.Sleep(1000);
            Email.SendKeys(ExcelLib.ReadData(2, "Email"));
            Thread.Sleep(1000);
            Password.SendKeys(ExcelLib.ReadData(2, "Password"));
            Thread.Sleep(1000);
            LogOnBtn.Click();
            Thread.Sleep(1000);
            String Expectedresult = CommonMethods.driver.FindElement(By.XPath(".//*[@id='StickyBar']/div/div[1]/div")).Text;
            try
            {
                //Verify Login successful/not

                if (Expectedresult == "QA Applicant (Technical Exercise)")

                {
                    SaveScreenShotClass.SaveScreenshot(CommonMethods.driver, "Login Success");
                    Thread.Sleep(1000);
                }
                
                else
                {
                    SaveScreenShotClass.SaveScreenshot(CommonMethods.driver, "Login Fail");
                }
                

            }
            catch (Exception e)
            {
                Console.WriteLine("Homepage not launched,Test failed" + e.Message);
            }
            
            
        }

    }
}
