using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Messenger.Domain;

namespace Messenger.Test
{
    public class TestFileRepository
    {
        [Fact]
        public void TestAdd()
        {
            var testHelper = new TestHelper();
            File file;
            var fileRepository = testHelper.FileRepository;

            file = new File
            {
                Id = new Guid("00000000-0000-0000-0000-000000000001"),
                OwnerId = new Guid("00000000-0000-0000-0000-000000000001"),
                Name = "file1",
                Type = "jpeg",
                UploadDate = DateTime.Now,
                Source = "D:\\file1"
            };
            fileRepository.AddAsync(file).Wait();
            file = new File
            {
                Id = new Guid("00000000-0000-0000-0000-000000000002"),
                OwnerId = new Guid("00000000-0000-0000-0000-000000000002"),
                Name = "file2",
                Type = "png",
                UploadDate = DateTime.Now,
                Source = "D:\\file2"
            };
            fileRepository.AddAsync(file).Wait();
            file = new File
            {
                Id = new Guid("00000000-0000-0000-0000-000000000003"),
                OwnerId = new Guid("00000000-0000-0000-0000-000000000003"),
                Name = "file3",
                Type = "jpeg",
                UploadDate = DateTime.Now,
                Source = "D:\\file3"
            };
            fileRepository.AddAsync(file).Wait();


            Assert.Equal(new Guid("00000000-0000-0000-0000-000000000001"), fileRepository.GetByIdAsync(new Guid("00000000-0000-0000-0000-000000000001")).Result.Id);
            Assert.Equal("D:\\file2", fileRepository.GetByIdAsync(new Guid("00000000-0000-0000-0000-000000000002")).Result.Source);
            Assert.True(fileRepository.GetAllAsync().Result.Count == 3);



            fileRepository.DeleteAsync(new Guid("00000000-0000-0000-0000-000000000001")).Wait();
            Assert.True(fileRepository.GetByIdAsync(new Guid("00000000-0000-0000-0000-000000000007")).IsCompletedSuccessfully);
        }
    }
}
