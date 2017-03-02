using OpenQA.Selenium.Chrome;
using UnleashedTest.Global;
using UnleashedTest.Pages;
using TechTalk.SpecFlow;

namespace UnleashedTest.SpecFlow
{
    [Binding]
    public sealed class StepDefinitionForUnleashedcs
    {
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef
        [Given(@"I have logged in to the Unleashed Invetory Management System")]
        public void GivenIHaveLoggedInToTheUnleashedInvetoryManagementSystem()
        {
            //Initialize web driver
            CommonMethods.driver = new ChromeDriver();

            CommonMethods.driver.Manage().Window.Maximize();
            //create login page obeject
            Login LogingToPage = new Login();
            LogingToPage.LoginSteps();

            CommonMethods.driver.Manage().Window.Maximize();
        }

        [Then(@"I should be able to add New Product in to the Inventory")]
        public void ThenIShouldBeAbleToAddNewProductInToTheInventory()
        {
            //Create AddNewProduct object

            AddProductPage NewProduct = new AddProductPage();
            NewProduct.AddNewProduct();
        }
        [Then(@"I should be able to add New Sales Order in to the Inventory")]
        public void ThenIShouldBeAbleToAddNewSalesOrderInToTheInventory()
        {
            //Create AddNewSalesOrder object

            SalesOrder NewSalesOrder = new SalesOrder();
            NewSalesOrder.AddNewSalesOrder();
        }


    }
}
