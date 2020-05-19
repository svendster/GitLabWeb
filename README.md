# SeleniumPomFrameworkForShoppingCart

This a basic Selenium Page Object Model framework as part of a CI/CD pipeline that I'm working on for fun and to try different things out. It's a work in progress.

The website being tested is NopCommerce, a leading .NET ecommerce & shopping cart solution. My goal is to Dockerize the website provisioning, but at the moment the code tests the demo site at https://demo.nopcommerce.com/.

It currently automates the following E2E flows:
1. Registration
2. Add 2 products to shopping cart and proceed to shopping cart.
3. Add 2 products to wish list and proceed to wish list.

## Details

- OOP principles are used.

> - Locators for page elements used by more than 1 page are inherited from a parent class.

> - The website's persistant navigation elements (header and footer) is inherited by all POM classes from a base page class.

> - The POM's page class encapsulates some standard assertions so they don't need to be coded explicitly in tests. When you instantiated each page's POM class, the following checks are done automatically:
> > 1. Page title in browser tab is correct
> > 2. URL is correct
> > 3. Page header is correct

- Locators for working with product categories are dynamic and keyword-based so that changes to catalog structure won't break any locators.

- Since NUNit doesn't generate reports like some frameworks (e.g., TestNG), code was added to generate a user-friendly report which includes full snapshots of any failures. See example below:

![Report](https://github.com/svendster/SeleniumPomExample/blob/master/Test_SS.JPG)



