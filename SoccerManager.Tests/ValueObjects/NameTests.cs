using NUnit.Framework;
using SoccerManager.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerManager.Tests.ValueObjects
{
    [TestFixture]
    public class NameTests
    {
        [Test]
        [TestCase("99999999999")]
        [TestCase("")]
        [TestCase(" ")]
        public void NameContructor_WhenCPFIsEmptyInvalid_ReturnInvalid(string cpf)
        {
            var name = new Name("Juliano", "Hubel","91069652",cpf);

            Assert.That(name.Invalid, Is.True);
        }

        [Test]
        [TestCase("07910968906")]
        [TestCase("49207093073")]
        [TestCase("91546681078")]
        [TestCase("51354900006")]
        public void NameContructor_WhenCPFIsValid_ReturnValid(string cpf)
        {
            var name = new Name("Juliano", "Hubel", "91069652", cpf);

            Assert.That(name.Valid, Is.True);
        }
    }
}
