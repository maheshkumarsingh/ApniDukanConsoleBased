using BusinessLayer;
using Entities;
using System;
using System.Collections.Generic; 
using Utilities;
using System.Linq;
namespace ServiceLayer
{
    public class MainClass
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to ApniDukan ECommerce Application :)");
            Console.WriteLine("----------------------------------------------");

            int option = 0;
            do
            {
                Console.WriteLine("\n 1) Employee\n 2) User \n 3) Exit");
                try
                {
                    option = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException ex)
                {

                    Console.WriteLine(ex.Message);
                }
                switch (option)
                {
                    case 1:
                        EmployeeBL employeeBL = new EmployeeBL();
                        Console.WriteLine("Enter Employee I'D");
                        string employeeID = Console.ReadLine();
                        
                        Employee employee = employeeBL.IsEmployeeEmail(employeeID);
                        Console.WriteLine(employee.ToString());
                        Console.WriteLine("\n\nWhat You wanna do today " +employee.EmployeeName.Trim()+" :) "+
                            "\n1) View All Product" +
                            "\n2) Add a new Product" +
                            "\n3) Update Product" +
                            "\n4) Delete Product" +
                            "\n5) View All Users");
                        int opt = Convert.ToInt32(Console.ReadLine());

                        switch (opt)
                        {
                            case 1:
                                ProductBL productBL = new ProductBL();
                                Console.WriteLine("The products are:");
                                List<Product> productList = productBL.ReadAllProduct();
                                if(productList != null)
                                    foreach (Product product in productList)
                                        Console.WriteLine(product.ToString());
                                Console.WriteLine("\n\nFilter The Products based on Options:");

                                Console.WriteLine("\n1) Based on Categories" +
                                    "\n2) Based on Price(Low to High)" +
                                    "\n3) Based on MFG Dates" +
                                    "\n4) Based on Particluar Categories        " +
                                    "Home     Smartphone      Medicine        Food        Clothes");
                                int option2 = Convert.ToInt32(Console.ReadLine());

                                switch (option2)
                                {
                                    case 1:
                                        IEnumerable<Product> orderByCategoryList = productBL.SortProductsByCategory(productList);
                                        foreach (Product item in orderByCategoryList)
                                            Console.WriteLine(item.ToString());
                                        break;
                                    case 2:
                                        IEnumerable<Product> orderByPriceList = productBL.SortProductsByPrice(productList);
                                        foreach (Product item in orderByPriceList)
                                            Console.WriteLine(item.ToString());
                                        break;
                                    case 3:
                                        IEnumerable<Product> orderByMFGDate = productBL.SortProductsByMFGDate(productList);
                                        foreach (Product item in orderByMFGDate)
                                            Console.WriteLine(item.ToString());
                                        break;
                                    case 4:
                                   
                                        Console.WriteLine("Home     Smartphone      Medicine        Food        Clothes");
                                        string response = Console.ReadLine();
                                        IEnumerable<Product> orderByParticularCategoryList = productBL.SortProductsByCategory(response,productList);
                                        foreach (Product item in orderByParticularCategoryList)
                                            Console.WriteLine(item.ToString());
                                        break;
                                    default:
                                        break;
                                }

                                break;
                            case 2:
                                Console.WriteLine("\n\nHere You are to add a new Product");
                                Product productAdd = new Product();
                                ProductBL productBLAdd = new ProductBL();
                                Console.WriteLine("\nEnter Category of the Products     " +
                                    "Home        Food        Medicine        Smartphone      Clothes");
                                productAdd.ProductType = Console.ReadLine();
                                Console.WriteLine("\nEnter Product Name");
                                productAdd.ProductName = Console.ReadLine();
                                Console.WriteLine("Enter Product Price");
                                productAdd.ProductPrice = Convert.ToInt64(Console.ReadLine());
                                Console.WriteLine("Enter Product Manufacture Date in YYYY/MM/DD format");
                                productAdd.ProductMFGDate = Convert.ToDateTime(Console.ReadLine());
                                Console.WriteLine("Enter Product Expiry Date in YYYY/MM/DD format");
                                productAdd.ProductExpiryDate = Convert.ToDateTime(Console.ReadLine());
                                if (productBLAdd.AddProduct(productAdd)>=1)
                                {
                                    Console.WriteLine("\n\nProduct Added Successfully");
                                    Console.WriteLine("\n"+productAdd.ToString());
                                }
                                else
                                    Console.WriteLine("\n\nCheck The Datas intered");
                                break;
                            case 3:
                                Console.WriteLine("\n\nHere You are to Update the price of products!!!");
                                Product productUpdate = new Product();
                                ProductBL productBLUpdate = new ProductBL();
                                Console.WriteLine("\nThe products are:");
                                List<Product> productListForUpdate = productBLUpdate.ReadAllProduct();
                                if (productListForUpdate != null)
                                    foreach (Product product in productListForUpdate)
                                        Console.WriteLine(product.ToString());
                                Console.WriteLine("\n\nEnter Product Id to Update the Price");
                                productUpdate.ProductID = Convert.ToInt16(Console.ReadLine());
                                Console.WriteLine("\nNow Enter new Price");
                                productUpdate.ProductPrice = Convert.ToInt64(Console.ReadLine());
                                if (productBLUpdate.UpdateProductByID(productUpdate.ProductID, productUpdate.ProductPrice)>=1)
                                {
                                    Console.WriteLine("Updated Successfully :)");
                                    productUpdate = productBLUpdate.SearchProductByID(productUpdate.ProductID);
                                    Console.WriteLine("\n\n");
                                    Console.WriteLine(productUpdate.ToString());
                                }
                                else
                                {
                                    Console.WriteLine("Check DAO!!");
                                }
                                break;
                            case 4:
                                Console.WriteLine("\n\nEnter Product ID to delete a Product" +
                                    ". BTW it is not recommended");
                                int id = Convert.ToInt32(Console.ReadLine());
                                ProductBL productBLDelete = new ProductBL();
                                if(productBLDelete.DeleteProductByID(id)>=1)
                                    Console.WriteLine("Product Deleted Successfully");
                                productBLDelete.ReadAllProduct();
                                break;
                            case 5:
                                Console.WriteLine("\n\nAll Users are: ");
                                UserBL userBL1 = new UserBL();
                                List<User> userList = userBL1.ReadAllUser();
                                foreach (User user1 in userList)
                                    Console.WriteLine(user1.ToString());

                                break;
                            default:
                                break;
                        }

                        break;
                    case 2:
                        User user = new User();
                        UserBL userBL;
                        Console.WriteLine("\nHello! How'z you buddy" +
                            "\n 1) Sign Up" +
                            "\n 2) Log In");
                        int option1 = 0;
                        try
                        {
                            option1 = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException ex)
                        {

                            Console.WriteLine(ex.Message);
                        }
                        switch (option1)
                        {
                            case 1:
                                Console.WriteLine("\nPlease fill following credentials" +
                                    " to Sign Up" +
                                    "\n\nEnter UserEmailID:");
                                user.UserEmail = Console.ReadLine();
                                userBL = new UserBL();
                                User User2 = userBL.ReadUserByEmailID(user.UserEmail);
                                if (User2 != null && userBL.CheackUserCredential(user.UserEmail)==true)
                                {
                                    Console.WriteLine("\nUser already registered Please LogIn");
                                    Console.WriteLine(User2.ToString());
                                }
                                else
                                {
                                    Console.WriteLine("\nEnter Password :)");
                                    string pass = Console.ReadLine();
                                    do
                                    {
                                        Console.WriteLine("\nConfirm Password :(");
                                        user.UserPassword = Console.ReadLine();
                                        
                                    }while (!pass.Equals(user.UserPassword));

                                    Console.WriteLine("\nEnter First Name");
                                    user.UserFName = Console.ReadLine();
                                    Console.WriteLine("\nEnter Last Name");
                                    user.UserLName = Console.ReadLine();

                                    Console.WriteLine("Enter Contact Number");
                                    user.UserConatct = Convert.ToInt64(Console.ReadLine());
                                    user.UserJoinedDate = DateTime.Now;
                                    Console.WriteLine("\nSaving your data!!");
                                    int result = userBL.InsertUser(user);
                                    if (result>=1)
                                        Console.WriteLine("\nData Saved:)" +
                                            "\nPlease LogIn Now");
                                    else
                                        Console.WriteLine("Error Occured");
                                }
                                break;
                             case 2:
                                User userLogin = new User();
                                UserBL userBLlogin = new UserBL();
                                Console.WriteLine("\nWelcome to Login Page :)");
                                Console.WriteLine("\nPlease Enter your Email ID");
                                userLogin.UserEmail = Console.ReadLine();
                                User userNew = userBLlogin.ReadUserByEmailID(userLogin.UserEmail);
                                if (userBLlogin.CheackUserCredential(userLogin.UserEmail)==true)
                                {
                                    if (userNew!=null)
                                    {
                                        do
                                        {
                                            Console.WriteLine("\nEnter Password");
                                            userLogin.UserPassword= Console.ReadLine();

                                        } while (!userLogin.UserPassword.Equals(userNew.UserPassword));
                                Console.WriteLine("\n\nWelcome Back "+userNew.UserFName+" !!  " +
                                    "what you wanna do today :)" +
                                    "\n\n" +
                                    "\n1) My Profile" +
                                    "\n2) View Products" +
                                    "\n3) View your Cart" +
                                    "\n4) Exit");
                                    }
                                    else
                                        Console.WriteLine("User Doesnot Exit Please Sign Up");

                                    int option2 = 0;
                                    try
                                    {
                                        option2 = Convert.ToInt32(Console.ReadLine());
                                    }
                                    catch (Exception ex)
                                    {

                                        throw new BusinessException(ex.Message);
                                    }

                                    switch (option2)
                                    {
                                        case 1:
                                            Console.WriteLine("\nYour Profile is :) ");
                                            userLogin = userBLlogin.ReadUserByEmailID(userNew.UserEmail);
                                            Console.WriteLine(userLogin.ToString());
                                            Console.WriteLine("\nUpdate my profile Yes/No");
                                            string response = Console.ReadLine();
                                            if(response.ToLower() =="yes")
                                            {

                                            }
                                            break;
                                        case 2:
                                            ProductBL productBL = new ProductBL();
                                            Console.WriteLine("The products are:");
                                            List<Product> productList = productBL.ReadAllProduct();
                                            if (productList != null)
                                                foreach (Product product in productList)
                                                    Console.WriteLine(product.ToString());
                                            CartBL cartBL = new CartBL();
                                            Cart cart = new Cart();
                                            cart.UserMailID =  userLogin.UserEmail; 
                                            
                                            Console.WriteLine("\nEnter Product ID to Add the product into Your Cart");
                                            int pid = Convert.ToInt32(Console.ReadLine());
                                            cart.ProductObj = productBL.SearchProductByID(pid);
                                            cart.CartCreatedDate = DateTime.Now;
                                            if (cartBL.InsertIntoCart(cart)>=1)
                                            {
                                                Console.WriteLine("Inserted Into Carted");
                                                Console.WriteLine("Do You want to view Cart");
                                                Console.WriteLine(cart.ToString());
                                            }
                                            else Console.WriteLine("\nFailed to add product into cart");
                                            break;
                                        case 3:
                                            Console.WriteLine("\nYour Cart looks like this");
                                            CartBL cartBL1 = new CartBL();
                                            List<Cart> cartList = cartBL1.ReadCartByUserEmailID(userLogin.UserEmail);
                                            Int64 total = 0;
                                            foreach (Cart cart1 in cartList)
                                            {
                                                Console.WriteLine(cart1.ToString());
                                                total += cart1.ProductObj.ProductPrice;
                                            }
                                            int option3 = 0;
                                            Console.WriteLine("\nTotal Amount of all products is: {0}",total);
                                            do
                                            {
                                            Console.WriteLine("\n\nNow what you want to do!!" +
                                                "\n1) Add more Products" +
                                                "\n2) Remove Product from Cart" +
                                                "\n3) Place Order with the products you have in Cart");
                                            option3 = Convert.ToInt32(Console.ReadLine());
                                                switch (option3)
                                                {
                                                    case 1:
                                                        Console.WriteLine("\n\nAll products are displayed here: ");
                                                        ProductBL productBL2 = new ProductBL();
                                                        Console.WriteLine("The products are:");
                                                        List<Product> productList1 = productBL2.ReadAllProduct();
                                                        if (productList1 != null)
                                                            foreach (Product product in productList1)
                                                                Console.WriteLine(product.ToString());
                                                        CartBL cartBL2 = new CartBL();
                                                        Cart cart1 = new Cart();
                                                        cart1.UserMailID =  userLogin.UserEmail;

                                                        Console.WriteLine("\nEnter Product ID to Add the product into Your Cart");
                                                        int pid1 = Convert.ToInt32(Console.ReadLine());
                                                        cart1.ProductObj = productBL2.SearchProductByID(pid1);
                                                        cart1.CartCreatedDate = DateTime.Now;
                                                        if (cartBL2.InsertIntoCart(cart1)>=1)
                                                        {
                                                            Console.WriteLine("\nInserted Into Carted");
                                                            Console.WriteLine("\nYou want to view Cart");
                                                            Console.WriteLine(cart1.ToString());
                                                        }
                                                        else Console.WriteLine("\nFailed to add product into cart");
                                                        break;
                                                        case 2:

                                                    default:
                                                        break;
                                                }
                                            } while (option3!=3);
                                            

                                            break;

                                        default:
                                            break;
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
            } while (option!=3);

            Console.ReadKey();
        }
    }
}
