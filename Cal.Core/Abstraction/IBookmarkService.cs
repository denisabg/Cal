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
        public Guid Id { get; }
        public State Status { get; }

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