using SponsorPortal.Infrastructure;

namespace SponsorPortal.ApplicationForm
{
    public class ApplicationForm : AggregateRoot
    {
        public static CreatedNewApplicationFormEvent CreateNew(string organization, string email, double amount, string title, string text)
        {
            return new CreatedNewApplicationFormEvent(new ApplicationForm(), organization, email, amount, title, text);
        }

        public override string Identifier
        {
            get { return "ApplicationForm"; }
        }
    }
}
