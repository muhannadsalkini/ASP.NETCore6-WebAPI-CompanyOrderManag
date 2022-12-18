using AutoMapper;
using CompanyOrderManag.Dto;
using CompanyOrderManag.Interfaces;
using CompanyOrderManag.Models;
using CompanyOrderManag.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CompanyOrderManag.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        public ProductController(IProductRepository productRepository, ICompanyRepository companyRepository, IMapper mapper)
        {
            this._productRepository = productRepository;
            this._companyRepository = companyRepository;
            this._mapper = mapper;
        }

        // Show all products
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Product>))]
        public IActionResult getProducts() 
        {
            var products = _productRepository.GetProducts();

            if (!ModelState.IsValid) // validation check
                return BadRequest(ModelState);

            return Ok(products);
        }

        // Creat a new product
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateProduct([FromQuery] int companyId, [FromBody] ProductDto productCreate)
        {
            if (productCreate == null)
                return BadRequest(ModelState);

            // Check if there are an existing product with same name
            var product = _productRepository.GetProducts()
                .Where(o => o.Name.Trim().ToUpper() == productCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (product != null)
            {
                ModelState.AddModelError("", "Product already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var productMap = _mapper.Map<Product>(productCreate);

            productMap.Company = _companyRepository.GetCompany(companyId); // Add company to the product

            if (!_productRepository.CreateProduct(productMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfuly created");
        }

    }
}
