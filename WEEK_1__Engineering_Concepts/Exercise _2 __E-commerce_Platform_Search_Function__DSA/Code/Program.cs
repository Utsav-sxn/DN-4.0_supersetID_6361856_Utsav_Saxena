/*
    ===========================================
    Author  : Utsav Saxena
    Date  : 19-06-2025 
    ===========================================
*/




// Exercise 2: E-commerce Platform Search Function

////// CODE IMPLEMENTATION IS PRESENT AFTER QnA //////






// Question: Explain Big O notation and how it helps in analyzing algorithms.

/*
    Answer- Big O notation is used to describe time and space complexity of algorithms in terms of their input size (mostly n),
    It determines how an algorithm grow with respect to the input size.
    It helps to choose the best algorithm based on input data or algorithm's efficiency.
    It is used to compare efficiency of different algorithms.
 */



// Question: Describe the best, average, and worst-case scenarios for search operations.

/*
    Answer- For Linear Search , the Worst case complexity is O(n), either item is at the end or it's not present ,
                                the Average case complexity is O(n/2) or we can say O(n), item is somewhere in the middle ,
                                the Best case complexity is O(1), first item.

            For Binary Search , the Worst case complexity is O(log n), item is found in last iteration or not found ,
                                the Average case complexity is also O(log n) , due to halving the search space each time ,
                                the Best caes complexity is O(1), item found in the first iteration (middle element).
 */



// Question: Compare the time complexity of linear and binary search algorithms.

/*
    Answer- average time complexity of Linear search is O(n)
            and for binary search, it is O(log n) but Binary search requires sorted data.
 */



// Question: Discuss which algorithm is more suitable for your platform and why.

/*
    I have a mixed take on this , if we are applying basic Binary search on category section , then only one product out of all in that category will be returned,
    so using linear search is better for search by category function,

    For ProductId and ProductName, we can use Binary Search if the input is sorted and the dataset is large , as it significantly decreases the lookup time. 
 */






using System;
using System.Collections.Generic;

class Product
{
    private int productID;
    private string productName;
    private string category;


    private Product(ProductBuilder builder)
    {
        this.productID = builder.productID;
        this.productName = builder.productName;
        this.category = builder.category;
    }

    // Inner Builder Class for Product Class
    public class ProductBuilder
    {
        internal int productID;
        internal string productName;
        internal string category;

        public ProductBuilder setID(int productID)
        {
            this.productID = productID;
            return this;
        }

        public ProductBuilder setName(string productName)
        {
            this.productName = productName;
            return this;
        }

        public ProductBuilder setCategory(string Category)
        {
            this.category = Category;
            return this;
        }

        public Product Build()
        {
            return new Product(this);
        }
    }


    // Linear Search Algorithm

    static Product linearSearchById(int productID,List<Product> products)
    {
        Console.WriteLine($"Linear Search on ID: {productID}\n");
        foreach (var product in products)
        {
            if(product.productID == productID)
            {
                return product;
            }
        }
        return null;
    }

    static Product linearSearchByName(string productName,List<Product> products)
    {
        Console.WriteLine($"Linear Search on Name: {productName}\n");
        foreach (var product in products)
        {
            if(product.productName == productName)
            {
                return product;
            }
        }
        return null;
    }


    static Product linearSearchByCategory(string Category, List<Product> products,ref List<Product> items)
    {
        Console.WriteLine($"Linear Search on Category: {Category}\n");
        foreach (var product in products)
        {
            if(product.category == Category)
            {
                items.Add(product);
            }
        }
        return null;
    }




    // Binary Search Algorithm

    static Product binarySearchById(int productId ,List<Product> products)
    {
        Console.WriteLine($"Binary Search on ID: {productId}\n");
        int s= 0;
        int e= products.Count-1;
        while (s <= e)
        {
            int m = s + (e - s) / 2;

            if (products[m].productID == productId)
            {
                return products[m];
            }
            else if (products[m].productID < productId)
            {
                s = m + 1;
            }
            else
            {
                e = m - 1;
            }
        }

        return null;
    }

    static Product binarySearchByName(string productName, List<Product> products)
    {
        Console.WriteLine($"Binary Search on Name: {productName}\n");
        int s = 0;
        int e = products.Count - 1;
        while (s <= e)
        {
            int m = s + (e - s) / 2;

            if (products[m].productName == productName)
            {
                return products[m];
            }
            else if (products[m].productName.CompareTo(productName) < 0) // means that the 'products[m].productName' is lexicographically smaller than 'productName' 
            {
                s = m + 1;
            }
            else
            {
                e = m - 1;
            }
        }

        return null;
    }

    static Product binarySearchByCategory(string Category, List<Product> products) // returns the first Matched object of that Category
    {
        Console.WriteLine($"Binary Search on Category: {Category}\n");
        int s = 0;
        int e = products.Count - 1;
        while (s <= e)
        {
            int m = s + (e - s) / 2;

            if (products[m].category == Category)
            {
                return products[m];
            }
            else if (products[m].category.CompareTo(Category) < 0)
            {
                s = m + 1;
            }
            else
            {
                e = m - 1;
            }
        }

        return null;
    }





    // Main class
    static void Main(string[] args)
    {
        Console.WriteLine("Name: Utsav Saxena , Superset ID: 6361856");
        List<Product> products = new List<Product>(); // List of Product class Objects
        // Adding Elements following Builder Design Pattern
        products.Add(
            new ProductBuilder()
            .setID(1)
            .setName("SmartPhones")
            .setCategory("Electronics")
            .Build()
        );
        products.Add(
            new ProductBuilder()
            .setID(2)
            .setName("Laptops")
            .setCategory("Electronics")
            .Build()
        );
        products.Add(
            new ProductBuilder()
            .setID(3)
            .setName("Sneakers")
            .setCategory("Footwears")
            .Build()
        );
        products.Add(
            new ProductBuilder()
            .setID(4)
            .setName("Flipflops")
            .setCategory("Footwears")
            .Build()
        );
        products.Add(
            new ProductBuilder()
            .setID(5)
            .setName("Kurtas")
            .setCategory("Clothings")
            .Build()
        );







        // Implementing LINEAR SEARCH using Product ID
        Product searchResult = linearSearchById(1, products);
        if (searchResult != null)
        {
            Console.WriteLine("Product Info\n Id: " + searchResult.productID + "\n Name: "+ searchResult.productName + "\n Category: "+searchResult.category + "\n");
        }
        else
        {
            Console.WriteLine("Product Id Not Found\n");
        }



        // Implementing LINEAR SEARCH using Product Category
        List<Product> items = new List<Product>();
        linearSearchByCategory("Electronics", products,ref items);
        if (items != null)
        {
            foreach (Product product in items)
            {
                Console.WriteLine("Product Info\n Id: " + product.productID + "\n Name: " + product.productName + "\n Category: " + product.category + "\n");
            }
        }
        else
        {
            Console.WriteLine("Product Category Not Found\n");
        }








        // Implementing BINARY SEARCH using Product Name

        List<Product> productsList = new List<Product>(products); // Cloning Product List
        productsList.Sort((a, b) => a.productName.CompareTo(b.productName)); // Sorting it for Binary Search

        searchResult = binarySearchByName("SmartPhones", productsList);
        if (searchResult != null)
        {
            Console.WriteLine("Product Info\n Id: " + searchResult.productID + "\n Name: " + searchResult.productName + "\n Category: " + searchResult.category + "\n");
        }
        else
        {
            Console.WriteLine("ProductName Not Found\n");
        }




        // Implementing BINARY SEARCH using Product Category
        Console.WriteLine("Enter Category to search product:");
        string cat = Console.ReadLine();
        searchResult = binarySearchByCategory(cat, productsList);
        if (searchResult != null)
        {
            Console.WriteLine("Product Info\n Id: " + searchResult.productID + "\n Name: " + searchResult.productName + "\n Category: " + searchResult.category + "\n");

        }
        else
        {
            Console.WriteLine($"Product Category '{cat}' Not Found\n");
        }
    }

}
