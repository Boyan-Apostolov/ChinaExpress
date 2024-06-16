# China Express

ASP.NET razor pages project for Semester 2 @ Fontys ICT. A web shop application for buying cheap items. The functionalities include: 

User Side
- Browsing the products
- Presonalized Recommendations
- Product Reviews
- Discount Codes
- Referral Codes (+ Game to win them)
- Periodic Statistics

Code side
- Optimized SQL Queries (DB-side filtering & paging)
- SQL Transactions for secure order management
- Memory Cache for faster statistics page loading
- Followed SOLID principles
- Design and Abstract Factory Strategy Patterns

### Developers:
- [Boyan Apostolov](https://github.com/Boyan-Apostolov)
    - The development was done on the [Fontys Git Server]( (https://git.fhict.nl/I522311))
# 🛠 Built with:

-   [ASP.NET Core](https://github.com/dotnet/aspnetcore)
-   [Bootstrap](https://github.com/twbs/bootstrap)
-   [jQuery](https://jquery.com/)
-   [Chart.Js](https://www.chartjs.org/)
-   [SweetAlert2](https://github.com/sweetalert2/sweetalert2)
-   [Google Email API](https://developers.google.com/gmail/api/guides)
-   [Pixabay API](https://pixabay.com/api/docs/)
-   [IP-Data API](https://ipdata.co/)

# Seeded Users:
| **User with role** |Email                 |Password         |
|-------------------|--------------------------|--------------|
|Employee			|admin@admin.com           |admin         | 
|Client             |user@chinaexpress.nl      |123456        | 
|Client	     	    |ref@ref.com               |123123        |

# Permissions by Role:

| **Permissions**            | Employee | Client | Guest |
| -------------------------- | -------- | ------ | ----- |
| Lading page                | ✅       | ✅      | ✅    |
| Login                      | ❌       | ❌      | ✅    |
| Register                   | ❌       | ❌      | ✅    |
| Products/Filter page       | ✅       | ✅      | ✅    |
| Product info               | ✅       | ✅      | ✅    |
| Reviews (read-only)        | ✅       | ✅      | ✅    |
| Reviews (creation)         | ✅       | ✅      | ❌    |
| Cart Page                  | ✅       | ✅      | ❌    |
| Order History Page         | ✅       | ✅      | ❌    |
| Add product to cart        | ✅       | ✅      | ❌    |
| Referrals Page             | ✅       | ✅      | ❌    |
| Statistics Page            | ✅       | ❌      | ❌    |
| Coupon Game Page           | ✅       | ❌      | ❌    |

# Pages:

**Landing page**

The landing page of our web app. The users can view some of the products as well as easily filter for categories
![Landing page](https://i.ibb.co/RQtfBxK/SCR-20240610-kffb.png)

**Login page**

The user needs to provide an email and password to login

![Login/page](https://i.ibb.co/6BFwZhr/SCR-20240610-kjxt.png)

**Products / Filter page**

Paginated and filtered page of all products on the platform. The users can apply filters to the products.
![All Users page](https://i.ibb.co/h7wq5jf/SCR-20240610-kjht.png)

**Product Details page**

Information about the product, as well as an add to cart button. The user can choose a personalization features like color/size which will be save in the order. The users can also see the product reviews
![Product details](https://i.ibb.co/HY8djg6/SCR-20240610-kkqu.png)

**Cart page**

The client can views the products added to their cart and apply a dicount code.
![Cart page](https://i.ibb.co/6HYZL7q/SCR-20240610-kmzt.png)

**Orders page**

On the Orders page, the user can see their previous orders, as well as view the current status of the order
![Orders page](https://i.ibb.co/QPz6xYf/SCR-20240610-kntj.png)

**Add review page**

The users can add reviews with stars and descriptions to the bought products.
![Add review page](https://i.ibb.co/PNbtCgd/SCR-20240610-ktph.png)


**Referrals page**

The users can aquire points by referring friends to register or just by using the platform and buying products. These points can be exchanged for discount codes.
![Referrals page](https://i.ibb.co/TB6nmQH/SCR-20240610-mkwh.png)


**Statistics page**

Only the adnin can access this page. It give an overview of the platform as well as statistics about the most popular products
![Statistics page 1](https://i.ibb.co/gzHx8QC/SCR-20240610-mlqa.png)
![Statistics page 2](https://i.ibb.co/Yfvr4MM/SCR-20240610-mmpw.png)


**Add review page**

The users can add reviews with stars and descriptions to the bought products.
![Add review page](https://i.ibb.co/PNbtCgd/SCR-20240610-ktph.png)


**Products Page (desktop)**
This page is available on the desktop version of the app. It allows employees to add and edit existing products
![Products Page](https://i.ibb.co/pjSG9xL/SCR-20240610-moah.png)


**Orders Page (desktop)**
This page is available on the desktop version of the app. It allows employees to view details of the order as well as to change its status after sending the items.
![Orders Page](https://i.ibb.co/TM7sLnx/SCR-20240610-mqia.png)

# Testing:
The aplication has undergone extensive testing with MsTest Library.

![test](https://i.ibb.co/VSM94Yd/SCR-20240613-lcut.png)

# UML Class diagram
![UML](https://i.ibb.co/2WF68ZL/UML-Diagram-final-page-0001.jpg)

# Project Architecture
![Project Architecture](https://i.ibb.co/WF3kGV2/project-architecture-2024-06-11-08-54-05.png)

# Database diagram
![UML](https://i.ibb.co/9tMvZhR/Database-Diagram-pages-to-jpg-0002.jpg)
