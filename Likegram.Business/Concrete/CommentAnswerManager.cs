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
    public class CommentAnswerManager : ICommentAnswerService
    {
        private readonly ICommentAnswerDal _commentAnswerDal;

        public CommentAnswerManager(ICommentAnswerDal commentAnswerDal)
        {
            _commentAnswerDal = commentAnswerDal;
        }

        public async Task<IResult> Add(CommentAnswer commentAnswer)
        {
            await _commentAnswerDal.Add(commentAnswer);
            return new SuccessResult(BusinessMessages.SuccessAdd);
        }

        public async Task<IDataResult<int>> CommentAnswersCount(int commentId)
        {
            var answers = await _commentAnswerDal.GetAll(a => a.PostCommentId == commentId);
            return new SuccessDataResult<int>(answers.Count);
        }

        public async Task<IResult> Delete(CommentAnswer commentAnswer)
        {
            await _commentAnswerDal.Delete(commentAnswer);
            return new SuccessResult(BusinessMessages.SuccessDelete);
        }

        public async Task<IDataResult<List<CommentAnswer>>> GetAll()
        {
            var result = await _commentAnswerDal.GetAll();
            return new SuccessDataResult<List<CommentAnswer>>(result, BusinessMessages.SuccessList);
        }

        public async Task<IDataResult<CommentAnswer>> GetById(int id)
        {
            var result = await _commentAnswerDal.Get(x => x.Id == id);
            return new SuccessDataResult<CommentAnswer>(result, BusinessMessages.UnSuccessfulList);
        }

        public async Task<IDataResult<List<CommentAnswer>>> GetListByCommentIdAsync(int commentId)
        {
            var result = await _commentAnswerDal.GetAllByCommentIdAsync(commentId);
            return new SuccessDataResult<List<CommentAnswer>>(result, BusinessMessages.SuccessList);
        }

        public async Task<IResult> Update(CommentAnswer commentAnswer)
        {
            await _commentAnswerDal.Update(commentAnswer);
            return new SuccessResult(BusinessMessages.SuccessUpdate);
        }
    }
}
