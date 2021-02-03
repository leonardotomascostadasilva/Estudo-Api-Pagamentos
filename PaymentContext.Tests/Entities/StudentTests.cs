﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentTests
    {
        private readonly Name _name;
        private readonly Document _document;
        private readonly Address _address;
        private readonly Email _email;
        private readonly Student _student;
        private readonly Subscription _subscription;

        public StudentTests()
        {
            _name = new Name("Leonardo", "Silva");
            _document = new Document("34708261020", EDocumentType.CPF);
            _email = new Email("leo@mail.com");
            _address = new Address("Rua 1", "1234", "bairro", "Test", "PR", "BR", "1234567");
            _student = new Student(_name, _document, _email);

            _subscription = new Subscription(null);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscription()
        {
            var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Leonardo",
                _document, _address, _email);
            _subscription.AddPayment(payment);

            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadSubscriptionHasNoPayment()
        {
            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadAddSubscription()
        {
            var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Leonardo",
                _document, _address, _email);
            _subscription.AddPayment(payment);

            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Valid);
        }
    }
}