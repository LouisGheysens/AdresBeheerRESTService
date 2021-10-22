using API.Mappers;
using API.Model.output;
using BusinessLayer.Model;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers {
    [Route("api/[controller]/gemeente")]
    [ApiController]
    public class AdresbeheerController : ControllerBase {
        private string url = "http://localhost:5000";
        private GemeenteService gemeenteService;
        private StraatService straatService;

        public AdresbeheerController(GemeenteService gemeenteservice, StraatService straatService) {
            this.gemeenteService = gemeenteservice;
            this.straatService = straatService;
        }
        #region Gemeente
        [HttpGet("{id}")]
        public ActionResult<GemeenteRESToutputDTO> GetGemeente(int id) {
            try {
                //Gemeente object opvragen aan de businesslaag
                Gemeente gemeente = gemeenteService.GeefGemeente(id);
                return Ok(MapfromDomain.MapFromGemeenteDomain(url, gemeente, straatService));
            }catch(Exception ex) {
                return NotFound(ex.Message);
            }
        }
        #endregion
        #region Straat
        #endregion
        #region Adres
        #endregion
    }
}
