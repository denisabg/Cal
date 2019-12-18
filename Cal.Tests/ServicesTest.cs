using System.Linq;
using System.Threading.Tasks;
using Cal.Core.Abstraction;
using Cal.Core.Domain;
using Cal.Core.Services;
using Xunit;

namespace Cal.Tests
{
    public class ServicesTest
    {

        [Fact]
        public async Task BookMarkServiceTest()
        {
            IBookmarkService service = new BookmarkService();

            var items = Repository.Data;


            foreach (var item in items)
            {
                var markUp = new BookmarkContext(item);

                await service.UpdateAsync(markUp);

            }


            var fetch = await service.FetchAsync();

            Assert.NotNull(fetch);

            Assert.True(fetch.Length > 1);

            var foo = fetch.LastOrDefault();

            if (foo != null)

                foo.State = new State
                {
                    IsSorryOn = !foo.State.IsSorryOn,
                    SystemCode = 2
                };

            Assert.NotNull(foo);

        }
    }
}
