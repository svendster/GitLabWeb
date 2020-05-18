# SeleniumPomExample

This solution is a first pass at a basic Selenium Page Object Model framework as part of a CI/CD pipeline. 

The website currently being tested is the demo site for the nopCommerce ecommerce system: https://demo.nopcommerce.com/.

It currently automates the following E2E flows:
1. Registration
2. Add 2 products to shopping cart and proceed to shopping cart.
3. Add 2 products to wish list and proceed to wish list.

## Details

- OOP principles are used.

> - Locators for page elements used by more than 1 page are inherited

> - The website's persistant navigation elements (header and footer) is inherited by all POM classes from a page class

> - The POM's page class encapsulates some standard assertions so they don't need to be coded. Each page checks the following automatically:
> > 1. Page title in browser tab is correct
> > 2. URL is correct
> > 3. Page header is correct

- Locators for working with product categories are dynamic and keyword-based so that changes to catalog structure won't break any locators.

- A user-friendly report is generated which includes snapshots of any failures:

![Report](https://github.com/svendster/SeleniumPomExample/blob/master/Test_SS.JPG)



