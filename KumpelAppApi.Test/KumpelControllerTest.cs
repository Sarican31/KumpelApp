using KumpelApp.Api;
using KumpelApp.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace KumpelAppApi.Test
{
    public class KumpelControllerTest
    {
        [Fact]
        public void AddKumpelFuegtKumpelHinzu()
        {
            //--Assign
            var expectedCount = 4;
            var service = new KumpelService();
            var sut = new KumpelController(service);
            var spitzname = "Felix";
            var telefonnummer = "5555";

            //--Act
            sut.AddKumpel(spitzname, telefonnummer);

            //--Assert
            Assert.Equal(expectedCount, sut.GetKumpels().Count);
            Assert.Contains(sut.GetKumpels(), x => x.Spitzname == spitzname);
            Assert.Contains(sut.GetKumpels(), x => x.Telefonnummer == telefonnummer);
        }


        [Fact]
        public void UpdateKumpelKomplett()
        {
            //--Assign
            var service = new KumpelService();
            var kC = new KumpelController(service);

            //--Act
            kC.UpdateKumpel(1, "Sarah", "444");

            //--Assert
            Assert.Contains(service.GetKumpels(), x => x.Id == 1);
            Assert.Contains(service.GetKumpels(), x => x.Spitzname == "Sarah");
            Assert.Contains(service.GetKumpels(), x => x.Telefonnummer == "444");

        }



        [Fact]
        public void DeleteKumpelDurchId()
        {
            //--Assign
            var service = new KumpelService();
            var kC = new KumpelController(service);
            var expectedCount = 2;

            //--Act
            kC.DeleteKumpel(1);

            //--Assert
            Assert.Equal(expectedCount, service.GetKumpels().Count);
        }

    }
}
