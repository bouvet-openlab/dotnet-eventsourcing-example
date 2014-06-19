namespace SponsorPortal.ApplicationForm
{
    public class ApplicationFormDTO
    {
        public string Organization { get; private set; }
        public string Email { get; private set; }
        public double Amount { get; private set; }
        public string Title { get; private set; }
        public string Text { get; private set; }

        public ApplicationFormDTO(string organization, string email, double amount, string title, string text)
        {
            Organization = organization;
            Email = email;
            Amount = amount;
            Title = title;
            Text = text;
        }
    }
}