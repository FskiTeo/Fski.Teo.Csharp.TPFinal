using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fiminski.RG.DAL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fiminski.RG.DAL.Model;
using Moq;
using Fiminski.RG.DAL.DAL;

namespace Fiminski.RG.DAL.Service.Tests
{
    [TestClass()]
    public class EspionnageServiceTests
    {
        [TestMethod()]
        public void GetEspionsByVilleWhereVilleHasNoEspionsTest()
        {
            var mockDbContext = new Mock<IApplicationDBContext>();
            mockDbContext.Setup(db => db.GetAllEspions()).Returns(new List<Espion>());

            var service = new EspionnageService(mockDbContext.Object);

            // Act
            var result = service.GetEspionsByVille("Paris");

            // Assert
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod()]
        public void GetEspionsByVilleWhenVilleHasOneEspionTest()
        {
            // Arrange
            var espions = new List<Espion>
            { 
                new Espion("James Bond", "007", [new Mission("Paris", 2024)]),
                new Espion("Ethienne Divina", "Tortue Geniale", [new Mission("Londres", 2013)])
            };

            var mockDbContext = new Mock<IApplicationDBContext>();
            mockDbContext.Setup(db => db.GetAllEspions()).Returns(espions);

            var service = new EspionnageService(mockDbContext.Object);

            // Act
            var result = service.GetEspionsByVille("Paris");

            // Assert
            Assert.AreEqual(0, result.Count);
            Assert.AreEqual("James Bond", result.First().Name);
        }

        [TestMethod()]
        public void GetEspionsByVilleWhenVilleHasManyEspionsTest()
        {
            // Arrange
            var espions = new List<Espion>
            {
                new Espion("James Bond", "007", [new Mission("Paris", 2024)]),
                new Espion("Ethienne Divina", "Tortue Geniale", [new Mission("Londres", 2013)]),
                new Espion("Mario Balotelli", "Le Pro", [new Mission("Paris", 2021), new Mission("New York", 2022)])
            };

            var mockDbContext = new Mock<IApplicationDBContext>();
            mockDbContext.Setup(db => db.GetAllEspions()).Returns(espions);

            var service = new EspionnageService(mockDbContext.Object);

            // Act
            var result = service.GetEspionsByVille("Paris");

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(result[0].Name, "James Bond");
            Assert.AreEqual(result[1].Name, "Mario Balotelli");
        }
    }
}