﻿using Academic_Blog.PayLoad.Request.Comment;
using Academic_Blog.PayLoad.Response;
using Academic_Blog.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace Academic_Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ILogger<CommentsController> _logger;
        private readonly ICommentSerivce _commentService;
        public CommentsController(ICommentSerivce commentService, ILogger<CommentsController> logger)
        {
            _logger = logger;
            _commentService = commentService;
        }

        // GET: api/Comments
        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> GetComments()
        {
            var response = await _commentService.GetComments();
            return Ok(response);
        }
        [HttpPost]
        [Authorize]
        [EnableQuery]
        public async Task<IActionResult> CreateComment(CreateCommentRequest request)
        {
            var response = await _commentService.CreateComment(request);
            if (response == null)
            {
                return BadRequest(new ErrorResponse()
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Error = "Insert failed",
                    TimeStamp = DateTime.Now,
                });
            }
            return Ok(response);
        }
        [HttpDelete("{id}")]
        [Authorize]
        [EnableQuery]
        public async Task<IActionResult> DeleteComment([FromRoute] Guid id)
        {
            var isSuccess = await _commentService.DeleteComments(id);
            if (!isSuccess)
            {
                return BadRequest(new ErrorResponse()
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Error = "Delete fail",
                    TimeStamp = DateTime.Now,
                });
            }
            return Ok("Success");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComment(Guid id, UpdateCommentRequest request)
        {
            var isSuccess = await _commentService.UpdateComment(id, request);
            if (!isSuccess)
            {
                return BadRequest(new ErrorResponse
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Error = "Insert fail",
                    TimeStamp = DateTime.Now,
                });
            }
            return Ok(new { Message = "Successfully" });
        }

        /*  // GET: api/Comments/5
          [HttpGet("{id}")]
          public async Task<ActionResult<Comment>> GetComment(Guid id)
          {
            if (_context.Comments == null)
            {
                return NotFound();
            }
              var comment = await _context.Comments.FindAsync(id);

              if (comment == null)
              {
                  return NotFound();
              }

              return comment;
          }

          // PUT: api/Comments/5
          // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
         
          // POST: api/Comments
          // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

          // DELETE: api/Comments/5
        

          private bool CommentExists(Guid id)
          {
              return (_context.Comments?.Any(e => e.Id == id)).GetValueOrDefault();
          }
        */
    }
}
