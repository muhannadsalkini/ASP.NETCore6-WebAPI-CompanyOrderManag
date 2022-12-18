using AutoMapper;
using CompanyOrderManag.Dto;
using CompanyOrderManag.Interfaces;
using CompanyOrderManag.Models;
using CompanyOrderManag.Repositories;
using Microsoft.AspNetCore.Mvc;

//System.InvalidOperationException: Unable to resolve service for type
//'CompanyOrderManag.Interfaces.ICompanyRepository' while attempting to activate
//'CompanyOrderManag.Controllers.CompanyController'.

namespace CompanyOrderManag.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : Controller
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        public CompanyController(ICompanyRepository companyRepository, IMapper mapper)
        {
            this._companyRepository = companyRepository;
            this._mapper = mapper;
        }

        // Show all companies
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Company>))] // To make API looks cleaner
        public IActionResult GetCompanies() // Returning a list of Companies
        {
            var companies = _companyRepository.GetCompanies();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(companies);
        }

        // Show a specified company
        [HttpGet("{companyId}")]
        [ProducesResponseType(200, Type = typeof(Company))]
        [ProducesResponseType(400)]
        public IActionResult getCompany(int companyId) // Returning one company by id
        {
            if (!_companyRepository.CompanyExist(companyId))
                return NotFound();

            var company = _companyRepository.GetCompany(companyId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(company);
        }

        // Creat a new company
        [HttpPost] // post
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCompany([FromBody] CompanyDto companyCreate)
        {
            if (companyCreate == null)
                return BadRequest(ModelState);

           // Check if there are a company with the same name
           var company = _companyRepository.GetCompanies()
               .Where(c => c.Name.Trim().ToUpper() == companyCreate.Name.TrimEnd().ToUpper())
               .FirstOrDefault();

            if (company != null)
            {
                ModelState.AddModelError("", "Category already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var companyMap = _mapper.Map<Company>(companyCreate);

            // If an error pccurs while saving
            if (!_companyRepository.CreateCompany(companyMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfuly created");
        }

        // Update an exist company
        [HttpPut("{companyId}")] // put
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCategory(int companyId, [FromBody] CompanyDto companyUpdate)
        {
            if (companyUpdate == null)
                return BadRequest(ModelState);

            if (companyId != companyUpdate.Id)
            {
                ModelState.AddModelError("", "This categoryId dose not exist!");
                return BadRequest(ModelState);
            }

            if (!_companyRepository.CompanyExist(companyId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var categoryMap = _mapper.Map<Company>(companyUpdate);

            if (!_companyRepository.UpdateCompany(categoryMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfuly updated");
        }
    }
}
