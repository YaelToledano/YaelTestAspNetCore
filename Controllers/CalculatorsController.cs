using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YaelTestWebApi.Models;

namespace YaelTestWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorsController : ControllerBase
    {
        private readonly CalculatorContext _context;

        public CalculatorsController(CalculatorContext context)
        {
            _context = context;
        }

        // GET: api/Calculators
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Calculator>>> GetCalculatorHistory()
        {
            return await _context.CalculatorHistory.ToListAsync();
        }

        // GET: api/Calculators/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Calculator>> GetCalculator(int id)
        {
            var calculator = await _context.CalculatorHistory.FindAsync(id);

            if (calculator == null)
            {
                return NotFound();
            }

            return calculator;
        }

        // PUT: api/Calculators/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalculator(int id, Calculator calculator)
        {
            if (id != calculator.id)
            {
                return BadRequest();
            }

            _context.Entry(calculator).State = EntityState.Modified;

            try
            {
                calculator.result = calculate(calculator);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalculatorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Calculators
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Calculator>> PostCalculator(Calculator calculator)
        {
            calculator.result = calculate(calculator);
            _context.CalculatorHistory.Add(calculator);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCalculator), new { id = calculator.id }, calculator);
        }

        // DELETE: api/Calculators/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalculator(int id)
        {
            var calculator = await _context.CalculatorHistory.FindAsync(id);
            if (calculator == null)
            {
                return NotFound();
            }

            _context.CalculatorHistory.Remove(calculator);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private int calculate(Calculator calculator)
        {
            switch (calculator._operator)
            {
                case "+":
                    return calculator.num1 + calculator.num2;
                case "-":
                    return calculator.num1 - calculator.num2;
                case "*":
                    return calculator.num1 * calculator.num2;
                case "/":
                    return calculator.num1 / calculator.num2;
                default:
                    return 0;
            }
        }
        private bool CalculatorExists(int id)
        {
            return _context.CalculatorHistory.Any(e => e.id == id);
        }
    }
}
