using AutoMapper;
using CompanyOrderManag.Dto;
using CompanyOrderManag.Interfaces;
using CompanyOrderManag.Models;
using CompanyOrderManag.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CompanyOrderManag.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public OrderController(IOrderRepository orderRepository, ICompanyRepository companyRepository, IMapper mapper)
        {
            this._orderRepository = orderRepository;
            this._companyRepository = companyRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Order>))]
        public IActionResult getOrders()
        {
            var orders = _orderRepository.GetOrders();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(orders);
        }

        [HttpPost] // post
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateOrder([FromQuery] int orderId, [FromQuery] int CompanyId, [FromBody] OrderDto orderCreate)
        {
            if (orderCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Company company = _companyRepository.GetCompany(CompanyId);

            DateTime CurrentTime = DateTime.Now;
            DateTime CurrentDate = DateTime.Today;

            if(CurrentTime < CurrentDate + company.PomationStartTime || CurrentTime > CurrentDate + company.PromationEndTime)
            {
                ModelState.AddModelError("", "Cannot Order at " + CurrentTime.Hour);
                return BadRequest(ModelState);
            }

            if (company.state == false)
            {
                ModelState.AddModelError("", "Company is closed!");
                return BadRequest(ModelState);
            }

            var orderMap = _mapper.Map<Order>(orderCreate);

            // If an error pccurs while saving
            if (!_orderRepository.CreateOrder(orderId, CompanyId, orderMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfuly created");
        }

    }
}
