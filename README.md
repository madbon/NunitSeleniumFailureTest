Failure Test:
Open the website (https://www.automationexercise.com/) in a web browser.
Navigate to the product page or section where the quantity can be updated.
Locate the quantity input field and ensure it is editable.
Input a negative value (e.g., -1) into the quantity field.
Press the "Add to Cart".
Observe the website's response.

Expected Results:

-The website should display an error message or provide feedback indicating that a negative quantity is not allowed.
-The website should not update the quantity of the product to a negative value.
-The website should retain the previous valid quantity value.

Application
1. Visual Studio

Framework Used
- .NET 6.0 (Long Term Support)

Project Type
- NUnit Test Project

Packages Used
- Selenium.WebDriver
- NUnit Testing Framework

How to use
1.  Open Visual Studio and Click Clone a repository.
2. Insert https://github.com/madbon/NunitSeleniumFailureTest.git to the repository location.
3. Click the Clone button.
4. Click Test Menu > Run All Tests.

Available Tests
- AddToCart
- VerifyCartDisplayed
- CheckIfCanAddNegativeQuantity
- NavigateToSelectedProduct
- ClickAddToCartByProductId

