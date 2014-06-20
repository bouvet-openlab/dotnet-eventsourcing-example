using System.Threading.Tasks;

namespace SponsorPortal.ApplicationForm
{
    public interface IApplicationFormRespository
    {
        ApplicationForm CreateNewApplication(string organization, string email, double amount, string title, string text);
        ApplicationForm GetApplicationForm();
        Task Store(CreatedNewApplicationFormEvent evnt);
    }
}
