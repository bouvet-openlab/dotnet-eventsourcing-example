using Moq;
using NUnit.Framework;
using SponsorPortal.ApplicationForm.Contracts;
using SponsorPortal.TestDataBuilders;

namespace SponsorPortal.ApplicationForm.Tests.Unit
{
    [TestFixture]
    public class ApplicationFormServiceTests
    {
        private Mock<IApplicationFormRespository> _applicationFormRepository;

        [SetUp]
        public void Setup()
        {
            _applicationFormRepository = new Mock<IApplicationFormRespository>();
        }

        [Test]
        public async void HandlesCreateNewApplicationFormCommand_CreatesEventForNewApplicationForm()
        {
            var service = new ApplicationFormService(_applicationFormRepository.Object);
            var applicationForm = new ApplicationFormDTOBuilder().Build();
            var command = new CreateNewApplicationFormCommand(applicationForm);
            
            await service.Handle(command);
            
            _applicationFormRepository.Verify(repo => repo.Store(It.Is<CreatedNewApplicationFormEvent>(evnt => HasSameContent(applicationForm, evnt))));
        }

        private bool HasSameContent(ApplicationFormDTO expected, CreatedNewApplicationFormEvent actual)
        {
            return expected.Organization == actual.Organization
                   && expected.Email == actual.Email
                   && expected.Amount == actual.Amount
                   && expected.Text == actual.Text
                   && expected.Title == actual.Title;
        }
    }

}
