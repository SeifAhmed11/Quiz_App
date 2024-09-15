#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizAPI.Models;

namespace QuizAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly QuizDbContext _context;

        public QuestionController(QuizDbContext context)
        {
            _context = context;
        }

        // GET: api/Question
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestions()
        {
            var random5Qns = await (_context.Questions
                 .Select(x => new
                 {
                     QnId = x.QuId, // Updated from QnId to QuId
                     QnInWords = x.QuInWords, // Fixed property name
                     ImageName = x.QuImageName, // Fixed property name
                     Options = new string[] { x.Option1, x.Option2, x.Option3, x.Option4 }
                 })
                 .OrderBy(y => Guid.NewGuid())
                 .Take(5)
                 ).ToListAsync();

            return Ok(random5Qns);
        }

        // PUT: api/Question/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestion(int id, Question question)
        {
            if (id != question.QuId) // Updated from QnId to QuId
            {
                return BadRequest();
            }

            _context.Entry(question).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionExists(id))
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

        // POST: api/Question/GetAnswers
        [HttpPost]
        [Route("GetAnswers")]
        public async Task<ActionResult<Question>> RetrieveAnswers(int[] qnIds)
        {
            var answers = await (_context.Questions
                .Where(x => qnIds.Contains(x.QuId)) // Updated from QnId to QuId
                .Select(y => new
                {
                    QnId = y.QuId, // Updated from QnId to QuId
                    QnInWords = y.QuInWords, // Fixed property name
                    ImageName = y.QuImageName, // Fixed property name
                    Options = new string[] { y.Option1, y.Option2, y.Option3, y.Option4 },
                    Answer = y.Answer
                })).ToListAsync();
            return Ok(answers);
        }

        // DELETE: api/Question/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }

            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuestionExists(int id)
        {
            return _context.Questions.Any(e => e.QuId == id); // Updated from QnId to QuId
        }

    }
}