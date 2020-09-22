using ContactRecord.Api.Controllers.V1;
using ContactRecord.Application.Exceptions;
using ContactRecord.Application.Interfaces;
using ContactRecord.Application.Services;
using ContactRecord.Core.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.Controllers
{
    public class ContactRecordControllerShould
    {
        private readonly Mock<IContactRecordRepository> _contactRecordRepositoryMock;
        private readonly IContactRecordService _contactRecordServiceMock;

        public ContactRecordControllerShould()
        {
            _contactRecordRepositoryMock = new Mock<IContactRecordRepository>();
            _contactRecordServiceMock = new ContactRecordService(_contactRecordRepositoryMock.Object);
        }

        [Fact]
        public async Task Delete_ThrowsGivenInvalidId()
        {
            var contactRecordController = new ContactRecordController(_contactRecordServiceMock);

            await Assert.ThrowsAsync<ContactRecordNotFoundException>(async () => await contactRecordController.Delete(9999));
        }
    }
}
