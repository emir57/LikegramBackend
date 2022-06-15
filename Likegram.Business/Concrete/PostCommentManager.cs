using Likegram.Business.Abstract;
using Likegram.Business.Constants;
using Likegram.Core.Utilities.Result;
using Likegram.DataAccess.Abstract;
using Likegram.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Likegram.Business.Concrete
{
    public class PostCommentManager : IPostCommentService
    {
        private readonly IPostCommentDal _postCommentDal;

        public PostCommentManager(IPostCommentDal postCommentDal)
        {
            _postCommentDal = postCommentDal;
        }

        public async Task<IResult> Add(PostComment postComment)
        {
            await _postCommentDal.Add(postComment);
            return new SuccessResult(BusinessMessages.SuccessAdd);
        }

        public async Task<IResult> Delete(PostComment postComment)
        {
            await _postCommentDal.Delete(postComment);
            return new SuccessResult(BusinessMessages.SuccessDelete);
        }

        public async Task<IDataResult<List<PostComment>>> GetAll()
        {
            var result = await _postCommentDal.GetAll();
            return new SuccessDataResult<List<PostComment>>(result, BusinessMessages.SuccessList);
        }

        public async Task<IDataResult<PostComment>> GetById(int id)
        {
            var result = await _postCommentDal.Get(x => x.Id == id);
            return new SuccessDataResult<PostComment>(result, BusinessMessages.UnSuccessfulList);
        }

        public async Task<IDataResult<List<PostComment>>> GetListByPostIdAsync(int postId)
        {
            var result = await _postCommentDal.GetCommentsByPostId(postId);
            return new SuccessDataResult<List<PostComment>>(result, BusinessMessages.SuccessList);
        }

        public async Task<IResult> Update(PostComment postComment)
        {
            await _postCommentDal.Update(postComment);
            return new SuccessResult(BusinessMessages.SuccessUpdate);
        }
    }
}
