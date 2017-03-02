using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnleashedTest.Global;
using UnleashedTest.Pages;

namespace UnleashedTest
{
    
    public class Program
    {

        static void Main(string[] args)
        {


        }
    }
    [TestFixture]
    class InventoryTest
        { 
        #region To access Path from resource file

        //public static int Browser = Int32.Parse(KeysResource.Browser);
        public static String ExcelPath = UnleashedResources.ExcelPath;
        public static string ScreenShotPath = UnleashedResources.ScreenShotPath;
        // public static string ReportPath = KeysResource.ReportPath;
        #endregion

        [SetUp]
        public void SetUpMethod()
        {
            //Initialize web driver
            CommonMethods.driver = new ChromeDriver();

            CommonMethods.driver.Manage().Window.Maximize();
            //create login page obeject
            Login LogingToPage = new Login();
            LogingToPage.LoginSteps();

            CommonMethods.driver.Manage().Window.Maximize();

        }


        [Test]
        public void AddNewProductTest()
        {
            //Create AddNewProduct object

            AddProductPage NewProduct = new AddProductPage();
            NewProduct.AddNewProduct();

        }
        [Test]
        public void AddNewSalesOrderTest()
        {
            //Create AddNewSalesOrder object

            SalesOrder NewSalesOrder = new SalesOrder();
            NewSalesOrder.AddNewSalesOrder();

        }


        [TearDown]
        public void TearDownMethod()
        {
            String img = SaveScreenShotClass.SaveScreenshot(CommonMethods.driver, "Report");
            CommonMethods.driver.Close();

        }

    
    }   
}
