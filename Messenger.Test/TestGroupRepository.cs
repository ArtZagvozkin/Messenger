using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Messenger.Domain;

namespace Messenger.Test
{
    public class TestGroupRepository
    {
        [Fact]
        public void TestAdd()
        {
            var testHelper = new TestHelper();
            Group group;
            var groupRepository = testHelper.GroupRepository;

            group = new Group
            {
                Id = new Guid("00000000-0000-0000-0000-000000000001"),
                OwnerId = new Guid("00000000-0000-0000-0000-000000000001"),
                //Name = "Общий чат",
                //Type = 1,
                //CreationDate = DateTime.Now,
                Description = "test string"
            };
            groupRepository.AddAsync(group).Wait();

            group = new Group
            {
                Id = new Guid("00000000-0000-0000-0000-000000000002"),
                OwnerId = new Guid("00000000-0000-0000-0000-000000000001"),
                Name = "Отдел ПО",
                Type = 1,
                CreationDate = DateTime.Now,
                Description = ""
            };
            groupRepository.AddAsync(group).Wait();

            group = new Group
            {
                Id = new Guid("00000000-0000-0000-0000-000000000003"),
                OwnerId = new Guid("00000000-0000-0000-0000-000000000001"),
                Name = "Бухгалтерия",
                Type = 1,
                CreationDate = DateTime.Now,
                Description = ""
            };
            groupRepository.AddAsync(group).Wait();

            group = new Group
            {
                Id = new Guid("00000000-0000-0000-0000-000000000004"),
                OwnerId = new Guid("00000000-0000-0000-0000-000000000001"),
                Name = "Отдел тестирования",
                Type = 1,
                CreationDate = DateTime.Now,
                Description = ""
            };
            groupRepository.AddAsync(group).Wait();


            Assert.Equal(new Guid("00000000-0000-0000-0000-000000000001"), groupRepository.GetByIdAsync(new Guid("00000000-0000-0000-0000-000000000001")).Result.Id);
            Assert.Equal("test string", groupRepository.GetByIdAsync(new Guid("00000000-0000-0000-0000-000000000001")).Result.Description);
            Assert.True(groupRepository.GetAllAsync().Result.Count == 4);
            Assert.Equal("Отдел ПО", groupRepository.GetByIdAsync(new Guid("00000000-0000-0000-0000-000000000002")).Result.Name);
            Assert.Equal("Бухгалтерия", groupRepository.GetByIdAsync(new Guid("00000000-0000-0000-0000-000000000003")).Result.Name);



            groupRepository.DeleteAsync(new Guid("00000000-0000-0000-0000-000000000001")).Wait();
            Assert.True(groupRepository.GetByIdAsync(new Guid("00000000-0000-0000-0000-000000000002")).IsCompletedSuccessfully);
        }
    }
}
