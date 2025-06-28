using NUnit.Framework;
using Moq;
using CustomerCommLib;
using System.Security.Cryptography.X509Certificates;
using System.Globalization;


namespace CustomerComms.Tests
{
    [TestFixture]
    public class CustomerCommTests
    {
        private Mock<IMailSender> _mockMailSender;
        private CustomerComm _customerComm;

        [OneTimeSetUp]
        public void Setup()
        {
            // Arrange: Setup mock to return true for any input
            _mockMailSender = new Mock<IMailSender>();
            _mockMailSender
                .Setup(m => m.SendMail(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(true);

            _customerComm = new CustomerComm(_mockMailSender!.Object);
        }


        [Test]
        [TestCase("cogni@zant.com", "Hello there!")]
        [TestCase("jbl@abc.com", "Hey there....")]
        public void sendEmailtoCustomerTest(string email,string message)
        {
            bool result = _customerComm.SendMailToCustomer(email,message);
            Assert.That(result, Is.True);
        }
    }
}
