﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObligatoriskOppgave1;

namespace ObligatoriskOppgave1Test
{
    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        public void TestAllFields()
        {
            var p = new Person
            {
                Id = 17,
                FirstName = "Ola",
                LastName = "Nordmann",
                BirthYear = 2000,
                DeathYear = 3000,
                Father = new Person() {Id = 23, FirstName = "Per"},
                Mother = new Person() {Id = 29, FirstName = "Lise"},
            };

            var actualDescription = p.GetDescription();
            var expectedDescription = "Ola Nordmann (Id=17) Født: 2000 Død: 3000 Far: Per (Id=23) Mor: Lise (Id=29)";

            Assert.AreEqual(expectedDescription, actualDescription);
        }

        [TestMethod]
        public void TestNoFields()
        {
            var p = new Person
            {
                Id = 1,
            };

            var actualDescription = p.GetDescription();
            var expectedDescription = "(Id=1)";

            Assert.AreEqual(expectedDescription, actualDescription);
        }

        [TestMethod]
        public void TestFirstLastNameFather()
        {
            var p = new Person
            {
                Id = 54,
                FirstName = "Anna",
                LastName = "Nordmann",
                Father = new Person() {Id = 23, FirstName = "Per"},
            };

            var actualDescription = p.GetDescription();
            var expectedDescription = "Anna Nordmann (Id=54) Far: Per (Id=23)";

            Assert.AreEqual(expectedDescription, actualDescription);
        }
    }
}