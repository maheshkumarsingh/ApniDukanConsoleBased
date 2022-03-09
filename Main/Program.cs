using System;
using System.Collections.Generic;
using BusinessException;
using Employee;
using Product;
namespace ApniDukan
{
    public class Program
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
                        
                        Employee.Employee employee = employeeBL.IsEmployeeEmail(employeeID);
                        employee.EmployeeName= employee.EmployeeName.Trim();
                        Console.WriteLine(employee.ToString());
                        Console.WriteLine("\n\nWhat You wanna do today Mahesh :)" +
                            "\n1) View All Product" +
                            "\n2) Add a new Product" +
                            "\n3) Delete Product" +
                            "\n4) Update Product" +
                            "\n5) View User and Cart");
                        int opt = Convert.ToInt32(Console.ReadLine());

                        switch (opt)
                        {
                            case 1:
                                Console.WriteLine("The products are:");
                                ProductBL productBL = new ProductBL();
                                List<Product.Product> productList = productBL.ReadAllProduct();
                                if(productList != null)
                                    foreach (Product.Product product in productList)
                                        Console.WriteLine(product.ToString());

                                Console.WriteLine("\nHow you want to filter Products" +
                                    "\n1) Based on Category of Items" + 
                                    "\n2) Based on MFG Dates" +  // sql query
                                    "\n3) Based on Price");     //sql query 
                                Console.WriteLine("Write Category Name");
                                string reponse = Console.ReadLine();
                                List<Product.Product> catLsit = productBL.SortProductsByCategory(reponse);
                                foreach (Product.Product cat in catLsit)
                                    Console.WriteLine(cat.ToString());
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
                                    do
                                    {
                                        Console.WriteLine("\nEnter Password");
                                        userLogin.UserPassword= Console.ReadLine();

                                    }while(!userLogin.UserPassword.Equals(userNew.UserPassword));
                                Console.WriteLine("\n\nWelcome Back "+userNew.UserFName+" !!  " +
                                    "what you wanna do today :)" +
                                    "\n\n" +
                                    "\n1) My Profile" +
                                    "\n2) View Products" +
                                    "\n3) View your Cart" +
                                    "\n4) Exit");

                                    int option2 = 0;
                                    try
                                    {
                                        option2 = Convert.ToInt32(Console.ReadLine());
                                    }
                                    catch (Exception ex)
                                    {

                                        throw new ExceptionClass(ex.Message);
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
