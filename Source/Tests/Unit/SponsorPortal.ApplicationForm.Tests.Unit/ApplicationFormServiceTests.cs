using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

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
        public void HandlesCreateNewApplicationFormCommand_CreatesEventForNewApplicationForm()
        {
            var service = new ApplicationFormService(_applicationFormRepository.Object);
            var applicationForm = new ApplicationFormDTO("organization", "mail@mail.com", 123, "title", "text");
            var command = new CreateNewApplicationFormCommand(applicationForm);
            
            service.Handle(command);
            
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
