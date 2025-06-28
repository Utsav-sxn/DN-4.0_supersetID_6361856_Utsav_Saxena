/*
 ================================================
    Author - Utsav Saxena
    Date - 27-06-2025
 ================================================
 */



using System;
using NUnit.Framework;
using CalcLibrary;

namespace CalcLibrary.Tests
{
    [TestFixture] // Marking the class which contains Test Cases
    public class CalculatorTests
    {
        private SimpleCalculator _calculator = null;

        [SetUp] // Instantiating the object of SimpleCalculator class
        public void SetUp(){
            _calculator = new SimpleCalculator();
        }

        

        [Test]

        // Test Cases For Addition Method
        [TestCase(10.5,-6,4.5)]
        [TestCase(1.2,7.8,9.0)]
        [TestCase(0,0,0)]
        [TestCase(double.MaxValue, double.MaxValue, double.PositiveInfinity)]
        [TestCase(double.NaN,10,double.NaN)]
        public void Add_Testing(double a, double b, double expected){
            double result = _calculator.Addition(a,b);
            Assert.That(result, Is.EqualTo(expected));
        }



        [TearDown] // Release Resources
        public void TearDown(){
            _calculator = null;
        }
    }
}