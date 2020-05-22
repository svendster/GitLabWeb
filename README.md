# SeleniumPomFrameworkForShoppingCart

This a basic Selenium Page Object Model framework as part of a CI/CD pipeline that I'm working on for fun and to try different things out. It's a work in progress.

The website being tested is NopCommerce, a leading .NET ecommerce & shopping cart solution. Eventually I'll Dockerize the website provisioning, but at the moment the code tests the demo site at https://demo.nopcommerce.com/.

It currently automates the following E2E flows:
1. Registration
2. Add 2 products to shopping cart and proceed to shopping cart.
3. Add 2 products to wish list and proceed to wish list.

## Details

- OOP & DRY (don't repeat yourself) principles are used.

> - Each page's POM class is very small and each to manage, concerning itself only with that page's few unique  elements.

> - The website's persistant navigation elements (header and footer) are inherited by all POM classes from a base page class.

> - The POM's base page class encapsulates some standard assertions so they don't need to be coded explicitly in tests. Each page's POM class includes a single method for doing the following assertions automatically after going to the page:
> > 1. Page title in browser tab is correct
> > 2. URL is correct
> > 3. Page header is correct

- Locators for working with product categories are dynamic and keyword-based so that changes to catalog structure won't break any locators. You'd just update the keywords being used.

- Since NUNit doesn't generate reports like some frameworks (e.g., TestNG), the ExtentReports library is used to generate a user-friendly report which includes full snapshots of any failures. See example below:

![Report](https://github.com/svendster/SeleniumPomExample/blob/master/Test_SS.JPG)



