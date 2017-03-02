using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnleashedTest.Global;
using static NUnit.Core.NUnitFramework;

namespace UnleashedTest.Pages
{
    class AddProductPage
    {
        //create constructor method
        public AddProductPage()
        {
            PageFactory.InitElements(CommonMethods.driver, this);

        }
        //Define POM
        //Inventory menu identification
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-nav']/div[1]/ul/li[3]/a/span[1]")]
        IWebElement Invetory { set; get; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-nav']/div[1]/ul/li[3]/ul/li[2]/a")]
        IWebElement Product { set; get; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-nav']/div[1]/ul/li[3]/ul/li[2]/ul/li[1]/a/span")]
        IWebElement AddProduct { set; get; }
        // Identification of Add Product elements
        [FindsBy(How = How.XPath, Using = ".//*[@id='Product_ProductCode']")]
        IWebElement ProductCode { set; get; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='Product_ProductDescription']")]
        IWebElement ProductDesc { set; get; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='Product_Barcode']")]
        IWebElement Barcode { set; get; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='Product_UnitOfMeasureId']")]
        IWebElement UnitOfMesureClick { set; get; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='Product_UnitOfMeasureId']/option[3]")]
        IWebElement UnitOfMesure { set; get; }
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='Product_ProductGroupId']")]
        IWebElement ProductGrpClick { set; get; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='Product_ProductGroupId']/option[3]")]
        IWebElement ProductGrp { set; get; }
        //Dimension
        [FindsBy(How = How.XPath, Using = ".//*[@id='Product_PackSize']")]
        IWebElement PackSize { set; get; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='Product_Weight']")]
        IWebElement ProductWeight { set; get; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='Product_Width']")]
        IWebElement ProductWidth { set; get; }
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='Product_Height']")]
        IWebElement ProductHeight { set; get; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='Product_Depth']")]
        IWebElement ProductDepth { set; get; }
        //Type
        [FindsBy(How = How.XPath, Using = ".//*[@id='tabsDetails']/div[2]/table/tbody/tr[1]/td[2]/div/label/div")]
        IWebElement NeverDimishing { set; get; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='tabsDetails']/div[2]/table/tbody/tr[4]/td[2]/div/label/div/i")]
        IWebElement Obsolete { set; get; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='Product_Notes']")]
        IWebElement Notes { set; get; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='btnSave']")]
        IWebElement SaveBtn { set; get; }
        //Product view POM definitions
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-nav']/div[1]/ul/li[3]/ul/li[2]/ul/li[2]/a")]
        IWebElement ProductView{ set; get; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='ProductFilter']")]
        IWebElement ProductCodeFilter { set; get; }
        
        internal void AddNewProduct()
        {
            ExcelLib.PopulateInCollection(InventoryTest.ExcelPath, "ProductPage");

            Thread.Sleep(2000);
            //Select Invenotory menu
            Invetory.Click();
            Thread.Sleep(2000);
            //Select Product menu
            Product.Click();
            Thread.Sleep(2000);
            //Select Add New Product from menu
            AddProduct.Click();
            Thread.Sleep(2000);
            
            //sending product code
            ProductCode.SendKeys(ExcelLib.ReadData(2, "ProductCode"));
            Thread.Sleep(1000);
            //sending product desc
            ProductDesc.SendKeys(ExcelLib.ReadData(2, "ProductDesc"));
            Thread.Sleep(1000);
            //sending barcode
            Barcode.SendKeys(ExcelLib.ReadData(2, "Barcode"));
            Thread.Sleep(1000);
            //sending Unitof measure
            //UnitOfMesureClick.Click();
            //Thread.Sleep(2000);
            //UnitOfMesure.SendKeys(ExcelLib.ReadData(2, "UnitOfMesure"));

            var UnitOfMesure = CommonMethods.driver.FindElement(By.Id("Product_UnitOfMeasureId"));
            var selectUnitOfMesure = new SelectElement(UnitOfMesure);
            Thread.Sleep(1000);
            selectUnitOfMesure.SelectByText(ExcelLib.ReadData(2, "UnitOfMesure"));
            
            
            //sending Product group
            //ProductGrp.SendKeys(ExcelLib.ReadData(2, "ProductGroup"));

            var ProductGrpList = CommonMethods.driver.FindElement(By.Id("Product_ProductGroupId"));
            var selectProGrpVal = new SelectElement(ProductGrpList);
            Thread.Sleep(1000);
            selectProGrpVal.SelectByText(ExcelLib.ReadData(2, "ProductGroup"));
            Thread.Sleep(1000);
            //sending Pack size
            PackSize.SendKeys(ExcelLib.ReadData(2, "PackSize"));
            Thread.Sleep(1000);
            //Sending Weight
            ProductWeight.SendKeys(ExcelLib.ReadData(2, "ProductWeight"));
            Thread.Sleep(1000);
            //Sending Product width
            ProductWidth.SendKeys(ExcelLib.ReadData(2, "ProductWidth"));
            Thread.Sleep(1000);
            //sending Product Height
            ProductHeight.SendKeys(ExcelLib.ReadData(2, "ProductHeight"));
            Thread.Sleep(1000);
            //sending ProductDepth
            ProductDepth.SendKeys(ExcelLib.ReadData(2, "ProductDepth"));
            Thread.Sleep(1000);

            ////select Types
            //NeverDimishing.Click();
            //Thread.Sleep(1000);
            ////CommonMethods.driver.SwitchTo().Alert().Dismiss();
            //Obsolete.Click();
            //Thread.Sleep(1000);
            ////CommonMethods.driver.SwitchTo().Alert().Dismiss();

            //Sending Notes
            Notes.SendKeys(ExcelLib.ReadData(2, "Notes"));
            //savedata
            SaveBtn.Click();
            Thread.Sleep(2000);
            ProductView.Click();
            Thread.Sleep(1000);
            ProductCodeFilter.SendKeys(ExcelLib.ReadData(2, "ProductCode"));
            Thread.Sleep(1000);
            //press enter
            ProductCodeFilter.SendKeys(Keys.Enter);
            Thread.Sleep(4000);
               

            try
            {
                //verify record is added
                if (ExcelLib.ReadData(2, "ProductCode") == CommonMethods.driver.FindElement(By.XPath(".//*[@id='ProductList_tccell0_2']/div/a")).Text)
                {
                    if (ExcelLib.ReadData(2, "ProductDesc") == CommonMethods.driver.FindElement(By.XPath(".//*[@id='ProductList_tccell0_3']/div/a")).Text)
                    {
                        if (ExcelLib.ReadData(2, "ProductGrp") == CommonMethods.driver.FindElement(By.XPath(".//*[@id='ProductList_tccell0_3']/div/a")).Text)
                       
                            SaveScreenShotClass.SaveScreenshot(CommonMethods.driver, "Found Added Product ");
                        
                    }

                }
                else
                {
                    SaveScreenShotClass.SaveScreenshot(CommonMethods.driver, "No record found ");

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Can not find added Product,Test failed" + e.Message);
            }
        }
    }
}
