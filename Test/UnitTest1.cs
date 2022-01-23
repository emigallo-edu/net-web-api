using Clase2.DAOs;
using Clase2.DTOs;
using NUnit.Framework;
using System;

namespace Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Given_NewCustomerModel_When_SaveIt_Then_ShouldInsert()
        {
            // Given
            CustomerDAO dao = new CustomerDAO();

            CustomerDTO model = new CustomerDTO()
            {
                Id = 33,
                Name = "Una Empresa S.A.",
                LastSync = null
            };

            // When
            Boolean result = dao.SaveCustomerInDB(model);

            // Then
            Assert.IsTrue(result);
        }
    }
}