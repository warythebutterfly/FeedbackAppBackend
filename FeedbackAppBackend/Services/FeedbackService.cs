using FeedbackAppBackend.EFC;
using FeedbackAppBackend.EFC.Entities;
using FeedbackAppBackend.Formatting;
using FeedbackAppBackend.IServices;
using FeedbackAppBackend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackAppBackend.Services
{
    public class FeedbackService : IFeedbackService
    {
        private FeedbackDbContext _db;
        public FeedbackService(FeedbackDbContext feedbackDbContext)
        {
            _db = feedbackDbContext;
        }
        async Task<FeedbackViewModel> IFeedbackService.CreateFeedback(FeedbackViewModel model)
        {
            try
            {
                var feedback = new Feedback
                {
                    Subject = model.Subject,
                    Text = model.Text,
                    Rating = model.Rating
                };
                _db.Feedbacks.Add(feedback);
                await _db.SaveChangesAsync();
                return model;
            }
            catch (CustomException)
            {
                throw;
            }
        }

        async Task<bool> IFeedbackService.DeleteFeedback(int id)
        {
            try
            {
                var feedbackToBeDeleted = await _db.Feedbacks.FirstOrDefaultAsync(x => x.Id == id);
                if (feedbackToBeDeleted == null || feedbackToBeDeleted.IsDeleted)
                    throw new CustomException("Cannot delete a feedback that doesn't exist");

                feedbackToBeDeleted.IsDeleted = true;
                feedbackToBeDeleted.IsActive = false;
                feedbackToBeDeleted.DeletedOn = DateTime.Now;
                _db.Entry(feedbackToBeDeleted).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return true;
            }
            catch (CustomException)
            {

                throw;
            }
        }

        async Task<List<FeedbackViewModel>> IFeedbackService.GetFeedbacks()
        {
            try
            {

                var feedbacks = await _db.Feedbacks.Where(x => x.IsDeleted != true).OrderByDescending(x => x.CreatedOn).Select(x => new FeedbackViewModel
                {
                    Id = x.Id,
                    Text = x.Text,
                    Subject = x.Subject,
                    Rating = x.Rating
                }).Take(10).ToListAsync();

                if (feedbacks == null || feedbacks.Count == 0)
                    throw new CustomException("No feedbacks at the moment. Please try again later.");

                return feedbacks;
            }
            catch (CustomException)
            {
                throw;
            }
        }

        async Task<FeedbackViewModel> IFeedbackService.UpdateFeedback(FeedbackViewModel model)
        {
            try
            {
                if (model == null || model.Id < 1)
                    throw new CustomException("Feedback Id is not provided.");

                var feedback = await _db.Feedbacks.FirstOrDefaultAsync(x => x.Id == model.Id);

                if (feedback == null)
                    throw new CustomException("This fedback cannot be retrieved at the moment.");


                feedback.Text = model.Text;
                feedback.Subject = model.Subject;
                feedback.Rating = model.Rating;
                feedback.UpdatedOn = DateTime.Now;
                _db.Entry(feedback).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                return new FeedbackViewModel
                {
                    Id = feedback.Id,
                    Subject = feedback.Subject,
                    Text = feedback.Text,
                    Rating = feedback.Rating,

                };

            }
            catch (CustomException)
            {

                throw;
            }

        }
    }
}
