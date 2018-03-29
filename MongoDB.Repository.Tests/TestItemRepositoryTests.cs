using FluentAssertions;
using System;
using Xunit;

namespace MongoDB.Repository.Tests
{
    public class TestItemRepositoryTests : IDisposable
    {
        private readonly BaseRepository<TestItem> _repository;

        public TestItemRepositoryTests()
        {
            var settings = new MongoDbSettings
            {
                ConnectionString = "mongodb://localhost:27017",
                DatabaseName = "example",
            };
            var context = new MongoDbContext(settings);
            _repository = new BaseRepository<TestItem>(context);
        }

        [Fact]
        public void CountsCorrectlyTest()
        {
            _repository.Add(new TestItem());
            _repository.Add(new TestItem());
            _repository.Add(new TestItem());
            _repository.Add(new TestItem());

            var result = _repository.Count();
            result.Should().Be(4);
        }

        [Fact]
        public void CountsCorrectlyWithDeleteTest()
        {
            var id1 = "5abcd75161b6204868c5f408";
            var id2 = "5abcd7651cb6946358bc7f0d";

            _repository.Add(new TestItem { Id = id1 });
            _repository.Add(new TestItem { Id = id2 });
            _repository.Add(new TestItem());
            _repository.Add(new TestItem());
            _repository.Add(new TestItem());

            _repository.Delete(id1);
            _repository.Delete(id2);

            var result = _repository.Count();
            result.Should().Be(3);
        }

        public void Dispose()
        {
            _repository.DeleteAll();
        }
    }
}
