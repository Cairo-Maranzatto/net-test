using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        public SalesController(ISaleRepository saleRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CreateSaleResponse>>> GetAll()
        {
            var sales = await _saleRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<CreateSaleResponse>>(sales));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CreateSaleResponse>> GetById(Guid id)
        {
            var sale = await _saleRepository.GetByIdAsync(id);
            if (sale == null)
                return NotFound();

            return Ok(_mapper.Map<CreateSaleResponse>(sale));
        }

        [HttpGet("customer/{customerId}")]
        public async Task<ActionResult<IEnumerable<CreateSaleResponse>>> GetByCustomerId(string customerId)
        {
            var sales = await _saleRepository.GetByCustomerIdAsync(customerId);
            return Ok(_mapper.Map<IEnumerable<CreateSaleResponse>>(sales));
        }

        [HttpGet("branch/{branchId}")]
        public async Task<ActionResult<IEnumerable<CreateSaleResponse>>> GetByBranchId(string branchId)
        {
            var sales = await _saleRepository.GetByBranchIdAsync(branchId);
            return Ok(_mapper.Map<IEnumerable<CreateSaleResponse>>(sales));
        }

        [HttpPost]
        public async Task<ActionResult<CreateSaleResponse>> Create([FromBody] CreateSaleRequest request)
        {
            var sale = _mapper.Map<Sale>(request);
            
            foreach (var item in request.Items)
            {
                sale.AddItem(item.ProductId, item.ProductName, item.Quantity, item.UnitPrice);
            }

            sale.Validate();
            await _saleRepository.AddAsync(sale);

            var response = _mapper.Map<CreateSaleResponse>(sale);
            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }

        [HttpPost("{id}/cancel")]
        public async Task<IActionResult> Cancel(Guid id)
        {
            var sale = await _saleRepository.GetByIdAsync(id);
            if (sale == null)
                return NotFound();

            sale.Cancel();
            await _saleRepository.UpdateAsync(sale);

            return NoContent();
        }

        [HttpPost("{id}/items/{productId}/cancel")]
        public async Task<IActionResult> CancelItem(Guid id, string productId)
        {
            var sale = await _saleRepository.GetByIdAsync(id);
            if (sale == null)
                return NotFound();

            sale.CancelItem(productId);
            await _saleRepository.UpdateAsync(sale);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _saleRepository.DeleteAsync(id);
            return NoContent();
        }
    }
} 