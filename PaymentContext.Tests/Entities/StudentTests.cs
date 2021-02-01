using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void AdicionarUmaAssinatura()
        {
            var subscription = new Subscription(null);
            var student = new Student("Leonardo", "Silva", "1234512341", "leo@mail.com");
            student.AddSubscription(subscription);
        }
    }
}
