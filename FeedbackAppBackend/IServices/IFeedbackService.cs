using FeedbackAppBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackAppBackend.IServices
{
    public interface IFeedbackService
    {
        Task<List<FeedbackViewModel>> GetFeedbacks();
        Task<FeedbackViewModel> CreateFeedback(FeedbackViewModel model);
        Task<FeedbackViewModel> UpdateFeedback(FeedbackViewModel model);
        Task<bool> DeleteFeedback(int id);
    }
}
