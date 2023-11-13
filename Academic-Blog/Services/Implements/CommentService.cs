using Academic_Blog.Domain;
using Academic_Blog.Domain.Models;
using Academic_Blog.Enums;
using Academic_Blog.PayLoad.Request.Comment;
using Academic_Blog.PayLoad.Response.Comment;
using Academic_Blog.Repository.Interfaces;
using Academic_Blog.Services.Interfaces;
using Academic_Blog.Utils;
using AutoMapper;

namespace Academic_Blog.Services.Implements
{
    public class CommentService : BaseService<CommentService>, ICommentSerivce
    {
        private HashSet<Comment> _comments = new HashSet<Comment>();
        public CommentService(IUnitOfWork<AcademicBlogContext> unitOfWork, ILogger<CommentService> logger, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, logger, mapper, httpContextAccessor)
        {
        }

        public async Task<CommentResponse> CreateComment(CreateCommentRequest request)
        {
            Comment comment = _mapper.Map<Comment>(request);
            var account = await GetUserFromJwt();
            if (account.Status.Equals(AccountStatusEnum.BANNED.GetDescriptionFromEnum<AccountStatusEnum>()))
            {
                throw new BadHttpRequestException("You in banned time", StatusCodes.Status400BadRequest);
            }
            var blog = await _unitOfWork.GetRepository<Blog>().SingleOrDefaultAsync(predicate: x => x.Id == request.BlogId);
            if (!blog.Status.Equals(BlogStatus.APPROVED.GetDescriptionFromEnum<BlogStatus>()))
            {
                throw new BadHttpRequestException("blog is not active", StatusCodes.Status400BadRequest);
            }
            comment.ReplyToId = request.ReplyToId;
            comment.CommentorId = account.Id;
            comment.CreateTime = DateTime.Now;
            comment.BlogId = request.BlogId;
            comment.Id = Guid.NewGuid();
            comment.Content = request.Content;
            CommentResponse response = null;
            try
            {
                await _unitOfWork.GetRepository<Comment>().InsertAsync(comment);
                bool isSuccessful = await _unitOfWork.CommitAsync() > 0;

                if (isSuccessful)
                {
                    response = _mapper.Map<CommentResponse>(comment);
                }
            }
            catch(Exception e)
            {
                string a = e.Message;
            }
   
            return response;
        }

        public async Task<bool> DeleteComments(Guid id)
        {
            var comments =  await GetComments(id);
            var userId = GetUserIdFromJwt();
            var comment = await _unitOfWork.GetRepository<Comment>().SingleOrDefaultAsync(predicate: x => x.Id == id);
            if (comment.CommentorId != userId)
            {
                throw new BadHttpRequestException("This Comment is not belongs of you", StatusCodes.Status400BadRequest);
            }
            if (comment == null)
            {
                return false;
            }
            _unitOfWork.GetRepository<Comment>().DeleteRangeAsync(comments);
            var isSuccess = await _unitOfWork.CommitAsync() > 0;
            return true;   
        }
        private async Task<List<Comment>> GetComments(Guid id)
        {
            var comment = await _unitOfWork.GetRepository<Comment>().SingleOrDefaultAsync(predicate: x => x.Id == id);
            var commentsRelated = await _unitOfWork.GetRepository<Comment>().GetListAsync(predicate: x => x.ReplyToId == id);
            _comments.Add(comment);
            foreach(Comment commentR in commentsRelated) {
                _comments.Add(commentR);
                 await GetComments(commentR.Id);
            }
            return _comments.ToList();
        }
        public async Task<List<Comment>> GetComments()
        {
            List<Comment> comments = (await _unitOfWork.GetRepository<Comment>().GetListAsync(predicate : x => x.Id == x.Id)).ToList();
            return comments;
        }

        public async Task<bool> UpdateComment(Guid id, UpdateCommentRequest request)
        {
            var comment = await _unitOfWork.GetRepository<Comment>().SingleOrDefaultAsync(predicate: x => x.Id == id);
            if(comment == null)
            {
                throw new BadHttpRequestException("id is not found", StatusCodes.Status400BadRequest);
            }
            var userId = GetUserIdFromJwt();
            if (comment.CommentorId != userId)
            {
                throw new BadHttpRequestException("This Comment is not belongs of you", StatusCodes.Status400BadRequest);
            }
            comment.Content = request.Content;
            comment.CreateTime = DateTime.Now;
            _unitOfWork.GetRepository<Comment>().UpdateAsync(comment);
            var isSucess = await _unitOfWork.CommitAsync() > 0;
            return isSucess;
        }
    }
}
