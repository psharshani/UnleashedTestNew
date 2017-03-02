using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnleashedTest.Global;

namespace UnleashedTest.Pages
{
    class SalesOrder
    {
        public SalesOrder()
        {
            PageFactory.InitElements(CommonMethods.driver, this);

        }
        //POM Definitions

        //Sales Order menu identification
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-nav']/div[1]/ul/li[5]/a/span[1]")]
        IWebElement SalesMenu { get; set; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-nav']/div[1]/ul/li[5]/ul/li[2]/a/span[1]")]
        IWebElement OrdersMenu { get; set; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-nav']/div[1]/ul/li[5]/ul/li[2]/ul/li[1]/a/span")]
        IWebElement AddSalesOrder { get; set; }
        //AddSalesOrder 
        [FindsBy(How = How.XPath, Using = ".//*[@id='SelectedCustomerCode']")]
        IWebElement CustCode { get; set; }
        
        [FindsBy(How = How.ClassName, Using = "ui-menu-item")]
        IWebElement CustCodSelect { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='CustomerRef']")]
        IWebElement CustRef { get; set; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='DiscountRateDisplay']")]
        IWebElement Discount { get; set; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='SaleTaxes']")]
        IWebElement Tax { get; set; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='WarehouseList']")]
        IWebElement Warehouse { get; set; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='DeliveryMethodList']")]
        IWebElement DeliveryMethod { get; set; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='DeliveryName']")]
        IWebElement DeliveryName { get; set; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='DeliveryStreetAddress']")]
        IWebElement DeliveryAdd { get; set; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='DeliverySuburb']")]
        IWebElement DeliverySub { get; set; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='DeliveryCity']")]
        IWebElement DeliveryCity { get; set; }
        [FindsBy(How=How.XPath,Using = ".//*[@id='DeliveryRegion']")]
        IWebElement Region { get; set; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='DeliveryRegion']")]
        IWebElement DeliveryRegion { get; set; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='DeliveryPostCode']")]
        IWebElement PostCode { get; set; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='DeliveryCountry']")]
        IWebElement DeliveryCountry { get; set; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='SalesPersonSelection']")]
        IWebElement SalesPerson { get; set; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='SalesGroupList']")]
        IWebElement SalesGrp { get; set; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='OrderDate']]")]
        IWebElement OrderDate { get; set; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='ui-datepicker-div']/table/tbody/tr[3]/td[4]/a")]
        IWebElement OrderDateSelect { get; set; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='RequiredDate']")]
        IWebElement RequiredDate { get; set; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='ui-datepicker-div']/table/tbody/tr[4]/td[1]/a")]
        IWebElement RequiredDateSelect { get; set; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='InvoiceLayoutId']")]
        IWebElement InvoiceLayout { get; set; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='PackingSlipLayoutId']")]
        IWebElement PackingSliplayout { get; set; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='ProductAddLine']")]
        IWebElement ProductLineAdd { get; set; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='QtyAddLine']")]
        IWebElement Qty { get; set; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='PriceAddLine']")]
        IWebElement Price { get; set; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='DiscountRateAddLine']")]
        IWebElement DiscountLine { get; set; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='btnAddOrderLine']")]
        IWebElement AddOrderLineBtn { get; set; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='ddbSave']/dl/dt/a[1]")]
        IWebElement SaveSalesOrderBtn { get; set; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-nav']/div[1]/ul/li[5]/ul/li[2]/ul/li[2]/a/span")]
        IWebElement ViewSalesOrder { get; set; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='OrderNumberFilter']")]
        IWebElement OrderNoFilter { get; set; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='CustomerFilter']")]
        IWebElement CustFilter { get; set; }
        [FindsBy(How = How.XPath, Using = ".//*[@id='OrderNumberDisplay']")]
        IWebElement SalesOrderNoDisplay { get; set; }
        
        internal void AddNewSalesOrder()
        {
            ExcelLib.PopulateInCollection(InventoryTest.ExcelPath, "SalesOrderPage");
            //Navigate through Add Sales Order
            SalesMenu.Click();
            Thread.Sleep(1000);
            OrdersMenu.Click();
            Thread.Sleep(1000);
            AddSalesOrder.Click();
            Thread.Sleep(3000);

            //Add New Sales Order

            CustCode.Click();
            CustCode.SendKeys(ExcelLib.ReadData(2, "CustCode"));
            Thread.Sleep(2000);
            CustCodSelect.Click();
            Thread.Sleep(3000);
            CustRef.SendKeys(ExcelLib.ReadData(2, "CustRef")); 
            Thread.Sleep(1000);
            Discount.Clear();
            Thread.Sleep(1000);
            Discount.SendKeys(ExcelLib.ReadData(2,"Discount"));
            Thread.Sleep(1000);

            Tax.SendKeys(ExcelLib.ReadData(2, "TaxRate"));
            Thread.Sleep(2000);

            //var TaxRate = CommonMethods.driver.FindElement(By.Id("SaleTaxes"));
            //var selectTaxRate = new SelectElement(TaxRate);
            //Thread.Sleep(3000);
            //selectTaxRate.SelectByText(ExcelLib.ReadData(2, "TaxRate"));

            //Warehouse.SendKeys(ExcelLib.ReadData(2,"Warehouse"));
            //Thread.Sleep(1000);
            var warehouse = CommonMethods.driver.FindElement(By.Id("WarehouseList"));
            var selectWarehouse = new SelectElement(warehouse);
            Thread.Sleep(1000);
            selectWarehouse.SelectByText(ExcelLib.ReadData(2, "Warehouse"));


            //DeliveryMethod.SendKeys(ExcelLib.ReadData(2,"DeliveryMethod"));
            //Thread.Sleep(1000);
            var deliverymethod = CommonMethods.driver.FindElement(By.Id("DeliveryMethodList"));
            var selectDM = new SelectElement(deliverymethod);
            Thread.Sleep(1000);
            selectDM.SelectByText(ExcelLib.ReadData(2, "DeliveryMethod"));

            DeliveryName.SendKeys(ExcelLib.ReadData(2, "DeliveryName"));
            Thread.Sleep(1000);
            DeliveryAdd.SendKeys(ExcelLib.ReadData(2, "StreetAddress"));
            Thread.Sleep(1000);
            DeliverySub.SendKeys(ExcelLib.ReadData(2, "Suburb"));
            Thread.Sleep(1000);
            DeliveryCity.SendKeys(ExcelLib.ReadData(2, "City"));
            Thread.Sleep(1000);
            Region.SendKeys(ExcelLib.ReadData(2, "Region"));
            Thread.Sleep(1000);
            PostCode.SendKeys(ExcelLib.ReadData(2, "PostCode"));
            Thread.Sleep(1000);
            DeliveryCountry.SendKeys(ExcelLib.ReadData(2, "Country"));
            Thread.Sleep(1000);

            SalesPerson.SendKeys(ExcelLib.ReadData(2, "SalesPerson"));
            Thread.Sleep(2000);
            //var sp = CommonMethods.driver.FindElement(By.Id("SalesPersonSelection"));
            //var selectsp = new SelectElement(sp);
            //Thread.Sleep(1000);
            //selectsp.SelectByText(ExcelLib.ReadData(2, "SalesPerson"));

            //SalesGrp.SendKeys(ExcelLib.ReadData(2, "SalesOrderGrp"));
            //Thread.Sleep(1000);
            var salesgroup = CommonMethods.driver.FindElement(By.Id("SalesGroupList"));
            var selectsalesgrp = new SelectElement(salesgroup);
            Thread.Sleep(1000);
            selectsalesgrp.SelectByText(ExcelLib.ReadData(2, "SalesOrderGrp"));

            OrderDate.SendKeys(ExcelLib.ReadData(2, "OrderDate"));
            Thread.Sleep(1000);
            OrderDateSelect.Click();
            Thread.Sleep(1000);
            RequiredDate.SendKeys(ExcelLib.ReadData(2, "ReqDate"));
            Thread.Sleep(1000);
            RequiredDateSelect.Click();

            //InvoiceLayout.SendKeys(ExcelLib.ReadData(2, "SalesOrderTemp"));
            //Thread.Sleep(1000);
            
            var SalesorderTemp = CommonMethods.driver.FindElement(By.Id("InvoiceLayoutId"));
            var selectSalesorderTemp = new SelectElement(SalesorderTemp);
            Thread.Sleep(1000);
            selectSalesorderTemp.SelectByText(ExcelLib.ReadData(2, "SalesOrderTemp"));

            //PackingSliplayout.SendKeys(ExcelLib.ReadData(2, "PackingSlipTemp"));
            //Thread.Sleep(1000);
            var PackingTemp = CommonMethods.driver.FindElement(By.Id("InvoiceLayoutId"));
            var selectPackingTemp = new SelectElement(PackingTemp);
            Thread.Sleep(1000);
            selectPackingTemp.SelectByText(ExcelLib.ReadData(2, "PackingSlipTemp"));

            ProductLineAdd.SendKeys(ExcelLib.ReadData(2, "ProductLine"));
            Thread.Sleep(1000);
            Qty.SendKeys(ExcelLib.ReadData(2, "Qty"));
            Thread.Sleep(1000);
            Price.SendKeys(ExcelLib.ReadData(2, "LinePrice"));
            Thread.Sleep(1000);
            DeliverySub.SendKeys(ExcelLib.ReadData(2, "LineDiscount"));
            Thread.Sleep(1000);

            //Add sales order line to Order
            AddOrderLineBtn.Click();
            Thread.Sleep(1000);
            //Save Sales Order
            SaveSalesOrderBtn.Click();
            Thread.Sleep(1000);

            ViewSalesOrder.Click();
            Thread.Sleep(1000);
            //to filter data either can give cutomernumber or order number
            OrderNoFilter.SendKeys(SalesOrderNoDisplay.Text);
            Thread.Sleep(1000);
            OrderNoFilter.SendKeys(Keys.Enter);
            //filter byCust num
            CustFilter.SendKeys(ExcelLib.ReadData(2, "CustCode"));
            Thread.Sleep(1000);
            CustFilter.SendKeys(Keys.Enter);

            IList SalesOrderList = CommonMethods.driver.FindElements(By.XPath(".//*[@id='SalesOrderList_tccell0_"));
            int SalesOrderListCount = SalesOrderList.Count;
            
            //.//*[@id='SalesOrderList_tccell1_1']/a
            //.//*[@id='SalesOrderList_tccell2_1']/a
            
            //Verify added  Sales Order
            try
            {
                for (int i = 0; i <= SalesOrderListCount; i++)
                {
                    //Check whether the Salesorder is equal with grid table data
                    if (SalesOrderNoDisplay.Text == CommonMethods.driver.FindElement(By.XPath(".//*[@id='SalesOrderList_tccell["+i+"]_1']/a ")).Text)
                    {
                        //Check whether the Salesorder is equal to actual
                        if(ExcelLib.ReadData(2,"CustCode") ==CommonMethods.driver.FindElement(By.XPath(".//*[@id='SalesOrderList_tccell["+i+"]_4']/a")).Text)
                        {
                            SaveScreenShotClass.SaveScreenshot(CommonMethods.driver, "Found Added Sales Order");
                            Thread.Sleep(2000);
                        }  

                     }
                    else
                    {
                        SaveScreenShotClass.SaveScreenshot(CommonMethods.driver, "Sales Order not found");
                        Thread.Sleep(2000);
                    }
                }
            }
               
           catch(Exception e)
            {
                Console.WriteLine("Can not find added Product,Test failed" + e.Message);
            }




        }



                
    }

}
