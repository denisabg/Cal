using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cal.Core.Abstraction;
using Cal.Core.Domain;

namespace Cal.Core.Services
{
    public class BookmarkService : IBookmarkService
    {
        private readonly IDictionary<Guid, StatusState> _inMemoryRepository = 
            new ConcurrentDictionary<Guid, StatusState>();


        public async Task<StatusState> UpdateAsync(BookmarkContext state)
        {
            var updateState = new StatusState
            {
                Id = state.Id,
                DateStamp = DateTime.Now.ToUniversalTime(),
                State = new State
                {
                    IsSorryOn = state.Status.IsSorryOn,
                    SystemCode = state.Status.SystemCode
                }
            };
            return await Task.FromResult(UpdateState(updateState));
        }


        public async Task<StatusState[]> FetchAsync()
        {
            return await Task.FromResult(GetAll().OrderBy(x=>x.Id).ToArray());
        }


        private IEnumerable<StatusState> GetAll()
        {
            if (_inMemoryRepository.Count >= 1) 
                return _inMemoryRepository.Values;
            foreach (var item in Repository.Data)
            {
                _inMemoryRepository.Add(item.Id, item);

            }
            return _inMemoryRepository.Values;

        }


        private StatusState UpdateState(StatusState state)
        {
            if (state.Id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(state));
            }

            if (_inMemoryRepository.ContainsKey(state.Id))
            {
                _inMemoryRepository.Remove(state.Id);
            }

            _inMemoryRepository.Add(state.Id, state);

            return _inMemoryRepository[state.Id];
        }

    }
}
