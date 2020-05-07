using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrimeService.Tests;
using PrimeService.Tests.Pom;
using FluentAssertions;

namespace PrimeService.Tests.TestCases
{
    [TestFixture]
    public class SanityTests : ReportsGenerationClass
    {



        [Test]
        [Category("Sanity")]
        public void Registration_Flow()
        {
            // Go to Homepage
            Homepage homepage = new Homepage(GetDriver());
            homepage.GoToPage();
            homepage.CheckThatRightPageWasLoaded();
            
            RegistrationPage registrationPage = homepage.ClickHeaderRegisterLink();
            registrationPage.CheckThatRightPageWasLoaded();
            registrationPage.EnterRegistrationEmail($"{DateTime.Now.Ticks.ToString()}@kjjlkljkll.com");
            registrationPage.EnterRegistrationPassword("password");
            registrationPage.EnterRegistrationFirstName("John");
            registrationPage.EnterRegistrationLastName("Doe");
            RegistrationResultsPage registrationResultsPage = registrationPage.ClickRegister();
            registrationResultsPage.CheckThatRightPageWasLoaded();

            registrationResultsPage.RegistrationIsCompleteMessageWasDisplayed().Should().BeTrue();

            Homepage homepage2 = registrationResultsPage.ClickContinueAfterRegister();
            homepage2.CheckThatRightPageWasLoaded();
        }


      
     
        [Test]
        [Category("Sanity")]
        public void Wish_List_flow___2_products()
        {
            // Go to Homepage
            Homepage homepage = new Homepage(GetDriver());
            homepage.GoToPage();
            homepage.CheckThatRightPageWasLoaded();

            //Confirm Wish List is empty
            homepage.GetCartQuantity().Should().Be(0);

            // Go to Computers / Desktops
            ProductCategoryPage productCategoryPage1 = homepage.GoToProductCategoryPage("Computers");
            productCategoryPage1.CheckThatRightPageWasLoaded();

            ProductSubcategoryPage productSubcategoryPage1 = productCategoryPage1.GetProductSubcategoryPageByHeaderDynamic("Desktops");
            productSubcategoryPage1.CheckThatRightPageWasLoaded();

            // Add product 1 (Lenovo IdeaCentre 600 All-in-One PC) to cart
            productSubcategoryPage1.ClickAddToWishList("Lenovo IdeaCentre 600 All-in-One PC");
            productSubcategoryPage1.CheckThatRightPageWasLoaded();
            //Confirm Wish List was updated
            productSubcategoryPage1.GetWishListQuantity(TimeSpan.FromSeconds(3)).Should().Be(1);

            //Go to Apparel / Accessories
            ProductCategoryPage productCategoryPage2 = productSubcategoryPage1.GoToProductCategoryPage("Apparel");
            productCategoryPage2.CheckThatRightPageWasLoaded();
            ProductSubcategoryPage productSubcategoryPage2 = productCategoryPage2.GetProductSubcategoryPageByHeaderDynamic("Accessories");
            productSubcategoryPage2.CheckThatRightPageWasLoaded();

            // Add product 2 (Ray Ban Aviator Sunglasses) to cart
            productSubcategoryPage2.ClickAddToWishList("Ray Ban Aviator Sunglasses");
            productSubcategoryPage2.CheckThatRightPageWasLoaded();
            
            //Confirm Wish List was updated
            productSubcategoryPage2.GetWishListQuantity(TimeSpan.FromSeconds(2)).Should().Be(2);
        }

        [Test]
        [Category("Sanity")]
        public void Shopping_Cart_flow__2_products()
        {
            // Go to Homepage
            Homepage homepage = new Homepage(GetDriver());
            homepage.GoToPage();
            homepage.CheckThatRightPageWasLoaded();
            
            // Check cart total
            homepage.GetCartQuantity().Should().Be(0);

            // Go to Computers / Desktops
            ProductCategoryPage productCategoryPage1 = homepage.GoToProductCategoryPage("Computers");
            productCategoryPage1.CheckThatRightPageWasLoaded();
            ProductSubcategoryPage productSubcategoryPage1 = productCategoryPage1.GetProductSubcategoryPageByHeaderDynamic("Desktops");
            productSubcategoryPage1.CheckThatRightPageWasLoaded();
            
            // Add product 1 (Lenovo IdeaCentre 600 All-in-One PC) to cart
            productSubcategoryPage1.ClickAddToCartDynamic("Lenovo IdeaCentre 600 All-in-One PC");
            productSubcategoryPage1.CheckThatRightPageWasLoaded();
            productSubcategoryPage1.GetCartQuantity(TimeSpan.FromSeconds(2)).Should().Be(1);
            
            //Go to Apparel / Accessories
            ProductCategoryPage productCategoryPage2 = productSubcategoryPage1.GoToProductCategoryPage("Apparel");
            productCategoryPage2.CheckThatRightPageWasLoaded();
            ProductSubcategoryPage productSubcategoryPage2 = productCategoryPage2.GetProductSubcategoryPageByHeaderDynamic("Accessories");
            productSubcategoryPage2.CheckThatRightPageWasLoaded();

            // Add product 2 (Ray Ban Aviator Sunglasses) to cart
            productSubcategoryPage2.ClickAddToCartDynamic("Ray Ban Aviator Sunglasses");
            productSubcategoryPage2.CheckThatRightPageWasLoaded();
            productSubcategoryPage2.GetCartQuantity(TimeSpan.FromSeconds(2)).Should().Be(2);

            // Go to Shopping Cart
            ShoppingCartPage shoppingCartPage = productSubcategoryPage2.ViewShoppingCartByClickingLink();
            shoppingCartPage.CheckThatRightPageWasLoaded();

            //Validate Shopping Cart
            shoppingCartPage.GetShoppingCartSubtotal().Should().Be("$525.00");
            shoppingCartPage.GetShoppingCartTotal().Should().Be("$525.00");
            
            //Go to Checkout
            shoppingCartPage.ClickTermsOfServiceCheckbox();
            shoppingCartPage.ClickCheckoutButton();
        }

    }
}
