using System;

namespace ApniDukan
{
    public class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to ApniDukan ECommerce Application :)");
            Console.WriteLine("----------------------------------------------");

            int option=0;
            do {
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
                        string employeeID= Console.ReadLine();

                        Employee employee = employeeBL.IsEmployeeEmail(employeeID);
                        employee.EmployeeName= employee.EmployeeName.Trim();
                        //employee.EmployeeJoinDate= Convert.ToDateTime(employee.EmployeeJoinDate.ToString().Trim());
                        Console.WriteLine("\n{0,-20} {1,-30} {2,-30} {3,-10}", "       ", "Employee Name","Employee ID","Joined Date");
                        Console.WriteLine(employee.ToString());
                        Console.WriteLine("What You wanna do today Mahesh :)");

                        break;
                     case 2:
                        UserMaster userMaster = new UserMaster();
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
                                userMaster.UserEmail = Console.ReadLine();
                                userBL = new UserBL();
                                UserMaster usermaster2 = userBL.ReadUserByEmailID(userMaster.UserEmail);
                                if (usermaster2 != null)
                                {
                                    Console.WriteLine("\nUser already registered Please LogIn");
                                    Console.WriteLine("\n{0,-10} {1,-15} {2,-15} {3,-30} {4,-20} {5,-20}","ID",
                                        "First Name","Last Name","User Email","User Contact","User JoinedDate");
                                    Console.WriteLine(usermaster2.ToString());
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
            }while (option!=3);

            Console.ReadKey();
        }
    }
}
