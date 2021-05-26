using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VictimsHelp.BLL.Contracts;
using VictimsHelp.PL.ViewModels.Psychologist;

namespace VictimsHelp.PL.Controllers.Api
{
    [Authorize]
    [Route("api/psychologists")]
    [ApiController]
    public class PsychologistApiController : ControllerBase
    {
        private readonly IPsychologistService _psychologistService;
        private readonly IMapper _mapper;

        public PsychologistApiController(
            IPsychologistService psychologistService,
            IMapper mapper)
        {
            _psychologistService = psychologistService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var psychologists = await _psychologistService.GetAllAsync();

            var models = _mapper.Map<IEnumerable<PsychologistViewModel>>(psychologists);

            return Ok(models);
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> Details(string email)
        {
            var psychologist = await _psychologistService.GetByEmailAsync(email);

            if (psychologist is null)
            {
                return NotFound();
            }

            var model = _mapper.Map<PsychologistViewModel>(psychologist);

            return Ok(model);
        }

        [HttpPost("declaration/{psychologistEmail}/{clientEmail}")]
        public async Task<IActionResult> SignDeclaration(string psychologistEmail, string clientEmail)
        {
            var result = await _psychologistService.SignDeclarationAsync(psychologistEmail, clientEmail);

            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
