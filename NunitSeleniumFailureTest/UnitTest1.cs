using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace NunitSeleniumFailureTest
{
    public class Tests
    {
        private IWebDriver driver;
        WebDriverWait wait;
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://automationexercise.com");
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test, Order(0)]
        public void AddToCart()
        {
            Thread.Sleep(3000); // to have time to manually to close ads
            IWebElement productMenu = wait.Until(e => e.FindElement(By.CssSelector(".shop-menu ul.nav li:nth-child(2) a")));
            productMenu.Click();

            ClickAddToCartByProductId("1");

            Thread.Sleep(3000); // to have time to manually to close ads
            IWebElement cartMenu = wait.Until(e => e.FindElement(By.CssSelector(".shop-menu ul.nav li:nth-child(3) a")));
            cartMenu.Click();
        }

        [Test, Order(1)]
        public void VerifyCartDisplayed()
        {
            Thread.Sleep(3000);
            IWebElement cartMenu = wait.Until(e => e.FindElement(By.CssSelector(".shop-menu ul.nav li:nth-child(3) a")));
            cartMenu.Click();

            bool cartInfoTable = driver.FindElement(By.CssSelector("#cart_info_table")).Displayed;

            Assert.IsTrue(cartInfoTable, "Cart does not load properly");
        }

        [Test, Order(2)]
        public void CheckIfCanAddNegativeQuantity()
        {
            NavigateToSelectedProduct("1");
        }

        public void NavigateToSelectedProduct(string productId)
        {
            Thread.Sleep(3000);
            IWebElement viewProduct = wait.Until(e => e.FindElement(By.CssSelector("#cart_info_table tbody tr#product-" + productId + " td.cart_description h4 a")));
            viewProduct.Click();

            Thread.Sleep(3000);
            IWebElement quantityInput = wait.Until(e => e.FindElement(By.CssSelector("#quantity")));
            quantityInput.Clear();
            Thread.Sleep(1000);
            quantityInput.SendKeys("-3");

            Thread.Sleep(3000);
            IWebElement addToCartButton = wait.Until(e => e.FindElement(By.CssSelector(".cart")));
            addToCartButton.Click();
            Console.WriteLine("Failure: Negative value must not be added to cart!");

            IWebElement closeButton = wait.Until(e => e.FindElement(By.CssSelector("#cartModal .modal-dialog.modal-confirm .modal-content .modal-footer button.close-modal")));
            Thread.Sleep(3000);
            closeButton.Click();

            Thread.Sleep(3000);
            IWebElement cartMenu = wait.Until(e => e.FindElement(By.CssSelector(".shop-menu ul.nav li:nth-child(3) a")));
            cartMenu.Click();
        }


        public void ClickAddToCartByProductId(string productId)
        {

            Thread.Sleep(3000);
            IWebElement addToCartItem = wait.Until(e => e.FindElement(By.CssSelector($"a[data-product-id='{productId}'].add-to-cart")));
            addToCartItem.Click();
            Thread.Sleep(3000);
            IWebElement closeButton = wait.Until(e => e.FindElement(By.CssSelector("#cartModal .modal-dialog.modal-confirm .modal-content .modal-footer button.close-modal")));
            Thread.Sleep(3000);
            closeButton.Click();

        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
        }
    }
}