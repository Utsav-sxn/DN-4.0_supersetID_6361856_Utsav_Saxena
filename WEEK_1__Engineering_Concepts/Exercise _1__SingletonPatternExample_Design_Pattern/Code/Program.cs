/*
    ===========================================
    Author  : Utsav Saxena
    Date  : 19-06-2025 
    ===========================================
*/

// Exercise 1: Implementing the Singleton Pattern

using System;

class Logger
{
    static int instanceCount = 0;
    private static readonly Logger loggerObject = new Logger(); // Using Eager initialization

    // Whenever a new object is created, count is increased
    private Logger()
    {
        instanceCount++;
    }

    // Using getter to get an instance of the class
    public static Logger GetInstance()
    {
        Console.WriteLine("Number of instances created is " + instanceCount);
        return loggerObject;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Name: Utsav Saxena , Superset ID: 6361856");

        // Calling getInstance method multiple times to initiate the instances of Logger class
        Logger l1 = GetInstance();
        Logger l2 = GetInstance();
        Logger l3 = GetInstance();

        // Checking whether all the objects are reffering to the same instance or not
        if (l1 == l2 && l2 == l3 && l1 == l3)
        {
            Console.WriteLine("Pointing to the same instance!");
        }
        else
        {
            Console.WriteLine("Pointing to different instances!");
        }
    }
}
