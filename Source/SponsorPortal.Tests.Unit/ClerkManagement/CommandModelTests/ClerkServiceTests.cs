using Moq;
using NUnit.Framework;
using SponsorPortal.ClerkManagement.CommandModel;
using SponsorPortal.ClerkManagement.CommandModel.Interfaces;
using SponsorPortal.ClerkManagement.Commands;
using SponsorPortal.ClerkManagement.Events;
using SponsorPortal.TestHelpers;

namespace SponsorPortal.Tests.Unit.ClerkManagement.CommandModelTests
{
    [TestFixture]
    [Category(TestCategory.UnitTests)]
    public class ClerkServiceTests
    {
        [Test]
        public async void WhenHandlingCreateClerkCommand_StoresCreatedClerkEventInRepository()
        {
            var command = new CreateClerkCommand("Mr.Clerk", "Some description");
            var repository = new Mock<IClerkRepository>();
            var service = new ClerkService(repository.Object);
            await service.Handle(command);

            repository.Verify(repo => repo.Store(It.Is<CreatedClerkEvent>(evnt => evnt.Name == command.Name && evnt.Description == command.Description)));
        }
    }
}
