using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;



namespace NZWalks.API.Controllers
{
    //http://localhost:portnumber/api/regions
    [Route("api/[controller]")]
    [ApiController]
  
    public class RegionController : ControllerBase
    {
        private readonly NZWalksDBContext dBContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionController(NZWalksDBContext dBContext,IRegionRepository regionRepository,IMapper mapper)
        {
            this.dBContext = dBContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }
        //GET ALL REGIONS
        //GET:http://localhost:portnumber/api/regions?filterOn=Name&filterQuery=Track&sortBy=Name&isAscending=true
        [HttpGet]
       // [Authorize(Roles ="Reader")]
        public async Task<IActionResult> GetAll([FromQuery]string? filterOn, [FromQuery] string? filterQuery, [FromQuery] string? sortBy, [FromQuery]bool?isAscending) 
        {
            // Get Data from Database - Domain Model
            var regionsDomain= await regionRepository.GetAllAsync(filterOn,filterQuery,sortBy,isAscending ?? true);
            //var regions=dBContext.Regions.ToList();-->Alternative Instance.
             
           //Return DTOs
            return Ok(mapper.Map<List<RegionDTO>> (regionsDomain));
        }

        //GET SINGLE REGION (Get Region By Id)
        //GET:http://localhost:portnumber/api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")]
       // [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetById(Guid id)
        {
            // var regions=dBContext.Regions.Find(id);
            //Get Region Domain Model from Database
            var regionsDomain = await regionRepository.GetByIdAsync(id);
            
            if (regionsDomain == null)
            {
                return NotFound();
            }

            //Return DTO back to client
                return Ok(mapper.Map<RegionDTO> (regionsDomain));

        }
       
        //POST To Create New Region
        //POST:http://localhost:portnumber/api/regions
        [HttpPost]
      //  [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            if (ModelState.IsValid)
            {
                //Map/Convert DTO to Domain Model
                var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);

                //Use Domain Model to create Region
                // await dBContext.Regions.AddAsync(regionDomainModel);
                //await dBContext.SaveChangesAsync();
                regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);


                //Map Domain Model back to DTO
                var regionDto = mapper.Map<RegionDTO>(regionDomainModel);

                return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        //Update region
        //PUT:http://localhost:portnumber/api/region/{id}
        [HttpPut]
        [Route("{id:Guid}")]
       // [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDTO updateRegionRequestDTO)
        {
            //Map DTO to Domain Model
            var regionDomainModel = mapper.Map<Region>(updateRegionRequestDTO);
            //Check if request exists
           // var regionDomainModel=await dBContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
           regionDomainModel = await regionRepository.UpdateAsync(id,regionDomainModel);
            if (regionDomainModel == null)
            {
                return NotFound();
            }

            //Convert Domain Model to Dto
           
            return Ok(mapper.Map<RegionDTO>(regionDomainModel));

        }
        //Delete
        //Delete:http://localhost:portnumber/api/regions/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
       // [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            //var regionDomainModel= await dBContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            var regionDomainModel = await regionRepository.DeleteAsync(id);
            if (regionDomainModel == null)
            {
                return NotFound();
            }
           
            //var regionRto = mapper.Map<RegionDTO>(regionDomainModel);
            return Ok(mapper.Map<RegionDTO>(regionDomainModel));
        }

    }
}

