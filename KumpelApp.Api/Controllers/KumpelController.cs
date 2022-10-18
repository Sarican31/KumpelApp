using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Runtime.CompilerServices;



namespace KumpelApp.Api.Controllers
{
   
    [Route("api/kumpel")]
    [ApiController]
    public class KumpelController : ControllerBase
    {
        private readonly KumpelService service;

        public KumpelController(KumpelService service)
        {
            this.service = service;
        }




        [HttpGet]
        public List<Kumpel> GetKumpels([FromQuery] string name = null, string Telefonnummer = null, long Id = default)
        {
            if (name != null)
            {
                return service.GetKumpels().Where(x => x.Spitzname.StartsWith(name, StringComparison.InvariantCultureIgnoreCase)).ToList();
            }

            else if (Telefonnummer != null)
            {
                return service.GetKumpels().Where(y => y.Telefonnummer.StartsWith(Telefonnummer)).ToList();
            }

            else if (Id != default)
            {
                return service.GetKumpels().Where(z => z.Id == Id).ToList();
            }

            else
            {
                return service.GetKumpels();
            }
        }




        [HttpPost]
        public void AddKumpel(string name, string telefonnummer)
        {
            var kumpel = new Kumpel
            {
                Spitzname = name,
                Telefonnummer = telefonnummer,
                Id = GetKumpels().Max(x => x.Id) + 1
            };
            GetKumpels().Add(kumpel);
        }


        

        [HttpPut]
        public ActionResult UpdateKumpel(long kumpelId, string name, string number)
        {
            var kumpelUpdateId = GetKumpels().FirstOrDefault(x => x.Id == kumpelId);
            if (kumpelUpdateId == null)
            {
                return NotFound();
            }

            kumpelUpdateId.Spitzname = name;
            kumpelUpdateId.Id = kumpelId;
            kumpelUpdateId.Telefonnummer = number;
            return NoContent();
        }




        [HttpDelete]
        public ActionResult DeleteKumpel(long kumpelId)
        {
            var kumpelDeleteId = GetKumpels().FirstOrDefault(x => x.Id == kumpelId);
            if (kumpelDeleteId == null)
            {
                return NotFound();
            }

            GetKumpels().Remove(kumpelDeleteId);
            return NoContent();
        }
    }

}