using KumpelApp.Api;
using KumpelApp.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace KumpelAppApi.Test
{
    public class KumpelServiceTest
    {
        [Fact]
        public void ShouldGetKumpels()
        {
            //--Assign
            var expectedCount = 3;


            //--Act
            var actual = new KumpelController(new KumpelService()).GetKumpels();

            //--Assert
            Assert.Equal(expectedCount, actual.Count);

        }

        [Fact]
        public void ShouldGetKumpelsMitName()
        {
            //--Assign
            var expectedCount = 1;

            //--Act
            var actual = new KumpelController(new KumpelService()).GetKumpels("Max");

            //--Assert
            Assert.Equal(expectedCount, actual.Count);

        }

        [Fact]
        public void GetKumpelsReturns2WennNameMa()
        {
            //--Assign
            var expectedCount = 2;

            //--Act
            var actual = new KumpelController(new KumpelService()).GetKumpels("Ma");

            //--Assert
            Assert.Equal(expectedCount, actual.Count);

        }

        [Fact]
        public void GetKumpelsReturns2WennNameLowerCase()
        {
            //--Assign
            var expectedCount = 2;

            //--Act
            var actual = new KumpelController(new KumpelService()).GetKumpels("ma");

            //--Assert
            Assert.Equal(expectedCount, actual.Count);

        }

        [Fact]
        public void GetKumpelsReturns2KumpelDurchNummer()
        {
            //--Assign
            var expectedCount = 2;

            //--Act
            var actual = new KumpelController(new KumpelService()).GetKumpels(Telefonnummer: "1");

            //--Assert
            Assert.Equal(expectedCount, actual.Count);

        }

        [Fact]
        public void GetKumpelsReturns1KumpelDurchId()
        {
            //--Assign
            var expectedCount = 1;

            //--Act
            var actual = new KumpelController(new KumpelService()).GetKumpels(Id: 1);

            //--Assert
            Assert.Equal(expectedCount, actual.Count);

        }




    }
}
