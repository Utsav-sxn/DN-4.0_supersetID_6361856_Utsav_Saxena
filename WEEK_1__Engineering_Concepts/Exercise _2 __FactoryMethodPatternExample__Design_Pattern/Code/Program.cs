/*
    ===========================================
    Author  : Utsav Saxena
    Date  : 19-06-2025 
    ===========================================
*/


// Exercise 2: Implementing the Factory Method Pattern


using System;

// Abstract class for Word document
abstract class WordDocument { }

// Child class of Word document
class WordChildClass : WordDocument
{
    public WordChildClass()
    {
        Console.WriteLine("Created a Word document");
    }
}


// Abstract class for PDF document
abstract class PdfDocument { }

// Child class of PDF document
class PdfChildClass : PdfDocument
{
    public PdfChildClass()
    {
        Console.WriteLine("Created a PDF document");
    }
}


// Abstract class for Excel document
abstract class ExcelDocument { }

// Child class of Excel document
class ExcelChildClass : ExcelDocument
{
    public ExcelChildClass()
    {
        Console.WriteLine("Created an Excel document");
    }
}


// Abstract Factory Class
abstract class DocumentFactory<T>
{
    public abstract T CreateDocument();
}


// Concrete Factories
class WordFactory : DocumentFactory<WordDocument>
{
    public override WordDocument CreateDocument()
    {
        return new WordChildClass();
    }
}

class PdfFactory : DocumentFactory<PdfDocument>
{
    public override PdfDocument CreateDocument()
    {
        return new PdfChildClass();
    }
}

class ExcelFactory : DocumentFactory<ExcelDocument>
{
    public override ExcelDocument CreateDocument()
    {
        return new ExcelChildClass();
    }
}



class FactoryMethodPatternExample
{
    static void Main(string[] args)
    {
        Console.WriteLine("Name: Utsav Saxena , Superset ID: 6361856");

        DocumentFactory<WordDocument> wordFactory = new WordFactory(); // Creating instance of Factory 
        WordDocument wordDoc = wordFactory.CreateDocument(); // calling Create method for wordDoc through factory object

        DocumentFactory<PdfDocument> pdfFactory = new PdfFactory();
        PdfDocument pdfDoc = pdfFactory.CreateDocument();

        DocumentFactory<ExcelDocument> excelFactory = new ExcelFactory();
        ExcelDocument excelDoc = excelFactory.CreateDocument();
    }
}
