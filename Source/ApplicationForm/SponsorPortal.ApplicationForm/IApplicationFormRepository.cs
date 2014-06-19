namespace SponsorPortal.ApplicationForm
{
    public interface IApplicationFormRespository
    {
        ApplicationForm CreateNewApplication(string organization, string email, double amount, string title, string text);
        ApplicationForm GetApplicationForm();
        void Store(CreatedNewApplicationFormEvent evnt);
    }
}
