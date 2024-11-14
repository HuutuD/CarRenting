using CarRentingSystemMVC.Data;
using CarRentingSystemMVC.Data.Models;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Repositories;

namespace CarRentingAPI.Controllers
{
    [Route("odata/[controller]")]
    [ApiController]
    public class RentalHistoriesController : ODataController
    {
        private readonly IRentalRepository _rentalRepository;

        public RentalHistoriesController(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        // GET: api/RentalHistory
        [EnableQuery]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentalHistoryDTO>>> GetRentalHistories()
        {
            var rentalHistory = await _rentalRepository.GetRentalHistoriesAsync();
            if (rentalHistory == null || !rentalHistory.Any())
            {
                return BadRequest();
            }
            return Ok(rentalHistory);
        }
    }
}
