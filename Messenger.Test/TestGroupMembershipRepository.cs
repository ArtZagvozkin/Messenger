using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Messenger.Domain;

namespace Messenger.Test
{
    public class TestGroupMembershipRepository
    {
        [Fact]
        public void TestAdd()
        {
            var testHelper = new TestHelper();
            GroupMembership groupMembership;
            var groupMembershipRepository = testHelper.GroupMembershipRepository;

            groupMembership = new GroupMembership
            {
                Id = new Guid("00000000-0000-0000-0000-000000000001"),
                PersonId = new Guid("00000000-0000-0000-0000-000000000001"),
                GroupId = new Guid("00000000-0000-0000-0000-000000000001"),
                EmpployeeName = "Антон Викторович",
                EntryDate = DateTime.Now
            };
            groupMembershipRepository.AddAsync(groupMembership).Wait();

            groupMembership = new GroupMembership
            {
                Id = new Guid("00000000-0000-0000-0000-000000000002"),
                PersonId = new Guid("00000000-0000-0000-0000-000000000002"),
                GroupId = new Guid("00000000-0000-0000-0000-000000000002"),
                EmpployeeName = "Владимир Сергеевич",
                EntryDate = DateTime.Now
            };
            groupMembershipRepository.AddAsync(groupMembership).Wait();

            groupMembership = new GroupMembership
            {
                Id = new Guid("00000000-0000-0000-0000-000000000003"),
                PersonId = new Guid("00000000-0000-0000-0000-000000000003"),
                GroupId = new Guid("00000000-0000-0000-0000-000000000003"),
                EmpployeeName = "Ярослав Павлович",
                EntryDate = DateTime.Now
            };
            groupMembershipRepository.AddAsync(groupMembership).Wait();


            Assert.Equal(new Guid("00000000-0000-0000-0000-000000000001"), groupMembershipRepository.GetByIdAsync(new Guid("00000000-0000-0000-0000-000000000001")).Result.Id);
            Assert.Equal("Владимир Сергеевич", groupMembershipRepository.GetByIdAsync(new Guid("00000000-0000-0000-0000-000000000002")).Result.EmpployeeName);
            Assert.True(groupMembershipRepository.GetAllAsync().Result.Count == 3);



            groupMembershipRepository.DeleteAsync(new Guid("00000000-0000-0000-0000-000000000001")).Wait();
            Assert.True(groupMembershipRepository.GetByIdAsync(new Guid("00000000-0000-0000-0000-000000000007")).IsCompletedSuccessfully);
        }
    }
}
