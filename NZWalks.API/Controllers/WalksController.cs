using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Data;
using NZWalks.API.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.CustomActionFilter;
using AutoMapper;
using NZWalks.API.Repositories;
using System.Text.Json;

namespace NZWalks.API.Controllers
{
    //http://localhost:portnumber/api/walks
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;
        private readonly ILogger<WalksController> logger;

        public WalksController(IMapper mapper, IWalkRepository walkRepository,ILogger<WalksController> logger)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
            this.logger = logger;
        }

        //CREATE Walk
        //POST:/api/walks
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateWalksRequestDto createWalksRequestDto)
        {
            //Map DTO to Domain Model
            var walkDomainModel = mapper.Map<Walk>(createWalksRequestDto);

            await walkRepository.CreateAsync(walkDomainModel);

            //Map Domain Model to DTO

            return Ok(mapper.Map<WalksDTO>(walkDomainModel));
        }

        //GET All Walk
        //GET:/api/walks?filterOn=Name&filterQuery=Track&sortBy=Name&isAscending=true
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]string? filterOn, [FromQuery]string? filterQuery, [FromQuery] string? sortBy, [FromQuery]bool?isAscending)
        {
            logger.LogInformation("GetAllRegions Action Method was invoked");

            logger.LogWarning("This is a Warning log");

            logger.LogError("This is a Error log");

            var walksDomainModel = await walkRepository.GetAllAsync(filterOn,filterQuery,sortBy,isAscending ?? true);

            //Map Domain Model to DTO

            logger.LogInformation($"Finished GetAllRegions request with data:{JsonSerializer.Serialize(walksDomainModel)} ");

            return Ok(mapper.Map<List<WalksDTO>>(walksDomainModel));
        }

        //GET WALK BY ID
        //GET:/api/walks{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walksDomainModel= await walkRepository.GetByIdAsync(id);
            if (walksDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalksDTO>(walksDomainModel));
        }

        //PUT:UPDATE THE WALKS BY ID
        //PUT:http://localhost:portnumber/api/walks{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalksRequestDTO updateWalksRequestDTO)
        {
            var walksDomainModel =mapper.Map<Walk>(updateWalksRequestDTO);

            walksDomainModel=await walkRepository.UpdateAsync(id, walksDomainModel);
            if (walksDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<WalksDTO>(walksDomainModel));
        }

        //DELETE A WALK BY ID
        //DELETE:/api/walks/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
           var DeletewalkDomainModel= await walkRepository.DeleteAsync(id);
            if (DeletewalkDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalksDTO>(DeletewalkDomainModel));
        }
    }
}
