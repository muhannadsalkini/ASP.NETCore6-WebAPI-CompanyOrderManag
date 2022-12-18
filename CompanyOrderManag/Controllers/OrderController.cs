using AutoMapper;
using CompanyOrderManag.Dto;
using CompanyOrderManag.Interfaces;
using CompanyOrderManag.Models;
using CompanyOrderManag.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.CodeAnalysis.MSBuild;
using System.ComponentModel.Design;

namespace CompanyOrderManag.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public OrderController(IOrderRepository orderRepository, ICompanyRepository companyRepository, IProductRepository productRepository, IMapper mapper)
        {
            this._orderRepository = orderRepository;
            this._companyRepository = companyRepository;
            this._productRepository = productRepository;
            _mapper = mapper;
        }

        // Show all orders
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Order>))]
        public IActionResult getOrders()
        {
            var orders = _orderRepository.GetOrders();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(orders);
        }

        // Creat a new order
        [HttpPost] // post
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateOrder([FromQuery] int productId, [FromQuery] int CompanyId, [FromBody] OrderDto orderCreate)
        {
            if (orderCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Company company = _companyRepository.GetCompany(CompanyId);

            DateTime CurrentTime = DateTime.Now;

            // Cheack if the current time is in company Order-Release time
            if (CurrentTime.Hour < company.PomationStartTime.Hour || CurrentTime.Hour > company.PromationEndTime.Hour)
            {
                ModelState.AddModelError("", "Company not receving orders at time");
                return BadRequest(ModelState);
            }
            
            // Check the company satate
            if (company.state == false)
            {
                ModelState.AddModelError("", "Company is closed!");
                return BadRequest(ModelState);
            }

            var orderMap = _mapper.Map<Order>(orderCreate);
            orderMap.Company = _companyRepository.GetCompany(CompanyId);
            orderMap.Product = _productRepository.GetProduct(productId);

            // If thre are an error occurs while saving
            if (!_orderRepository.CreateOrder(orderMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfuly created");
        }

    }
}
