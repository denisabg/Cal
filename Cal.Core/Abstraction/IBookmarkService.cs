using System;
using System.Threading.Tasks;
using Cal.Core.Domain;

namespace Cal.Core.Abstraction
{
    public interface IBookmarkService
    {
        Task<StatusState> UpdateAsync(BookmarkContext item);
        Task<StatusState[]> FetchAsync();
    }

    public class BookmarkContext
    {
        public Guid Id { get; set; }
        public State Status { get; set; }

        public BookmarkContext(StatusState item)
        {
            Id = item.Id;
            Status = new State
            {
                SystemCode = item.State.SystemCode,
                IsSorryOn = item.State.IsSorryOn
            };
        }
    }
}