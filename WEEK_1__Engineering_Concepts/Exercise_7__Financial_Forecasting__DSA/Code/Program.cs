/*
    ===========================================
    Author  : Utsav Saxena
    Date  : 19-06-2025 
    ===========================================
*/



// Exercise 7: Financial Forecasting

////// CODE IMPLEMENTATION IS PRESENT AFTER QnA //////






// Question: Explain the concept of recursion and how it can simplify certain problems.

/*
    Answer- Recursion is a technique in programming where the function calls itself until the Base Condition is fulfilled.
    It simplifies certain problems as it breaks the problems into smaller chunks which are easier to solve as we have to solve one part and others will be solved recursively. 
 */



// Question: Discuss the time complexity of your recursive algorithm.

/*
    Answer- Each call performs a multiplication and function call (O(1)),
    And recursion calls are equal to the time period (i.e. if time period is 10, then 10 recursive calls are made)
    So the time complexity becomes T(n) = T(n-1) + O(1);
    Which is Linear , i.e. O(n).
 */



// Question: Explain how to optimize the recursive solution to avoid excessive computation

/*
    Answer- We can avoid excessive computation and optimize the recursive solution using Dynamic Programming (recursion + memoization) , which means we store the previously computed values, and return where ever needed.
 */





using System;

// Used different classes for different purposes , following the Single Responsibility principle and Decoupling
class RecursivePrediction
{
    public static double PredictFutureValue(double amt, float rate, int time)
    {
        if (time == 0) return amt;

        return (1 + rate) * PredictFutureValue(amt, rate, time - 1);
    }
}


// Using Builder design pattern for constructing FinancialForecasting class's Object
class FinancialForecastingBuilder
{
    internal double amount;
    internal float rate;
    internal int timePeriod;

    public FinancialForecastingBuilder SetAmount(double amount)
    {
        this.amount = amount;
        return this;
    }

    public FinancialForecastingBuilder SetRate(float rate)
    {
        this.rate = rate;
        return this;
    }

    public FinancialForecastingBuilder SetTimePeriod(int timePeriod)
    {
        this.timePeriod = timePeriod;
        return this;

    }

    public FinancialForecasting Build()
    {
        return new FinancialForecasting(this);
    }
}





class FinancialForecasting
{
    private double amount;
    private float rate;
    private int timePeriod;

    internal FinancialForecasting(FinancialForecastingBuilder builder)
    {
        this.amount = builder.amount;
        this.rate = builder.rate;
        this.timePeriod = builder.timePeriod;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Name: Utsav Saxena, Superset ID: 6361856");
        Console.WriteLine("Enter initial amount");
        double amount = Convert.ToDouble(Console.ReadLine());
        if (amount < 0) { // Applying basic checks on inputs
            Console.WriteLine("Invalid value of Amount (using default amount: 1000)");
            amount = 1000;
        }

        Console.WriteLine("Enter Rate (not in percentage)");
        float rate = Convert.ToSingle(Console.ReadLine());
        if(rate > 1) {
            Console.WriteLine("Invalid value of rate (using default rate: 0.12)");
            rate = 0.12F;
        }

        Console.WriteLine("Enter Time Period (years)");
        int timePeriod = Convert.ToInt32(Console.ReadLine());
        if (timePeriod < 0)
        {
            Console.WriteLine("Invalid value of Time (using default Time: 10 (years))");
            timePeriod = 10;
        }

        FinancialForecasting forecast = new FinancialForecastingBuilder() // using builder class
               .SetAmount(amount)
               .SetRate(rate)
               .SetTimePeriod(timePeriod)
               .Build();


        double predictedVal = RecursivePrediction.PredictFutureValue(forecast.amount,forecast.rate,forecast.timePeriod); // calling static Prediction method of RecursivePrediction class
        Console.WriteLine($"The predicted value is: {predictedVal}\n");

    }
}

