using System.Collections.Generic;

namespace Cal.Core.Domain
{
    public static class Repository
    {
        public static IEnumerable<StatusState> Data { get; } = new []
        {
            new StatusState
            {

                State = new State
                {
                    SystemCode = 1,
                    IsSorryOn = false
                }
            },
            new StatusState
            {

                State = new State
                {
                    SystemCode = 1,
                    IsSorryOn = false
                }
            },
            new StatusState
            {

                State = new State
                {
                    SystemCode = 1,
                    IsSorryOn = false
                }
            },
            new StatusState
            {

                State = new State
                {
                    SystemCode = 1,
                    IsSorryOn = true
                }
            },
            new StatusState
            {
                State = new State
                {
                    SystemCode = 1,
                    IsSorryOn = false
                }
            },
            new StatusState
            {
                State = new State
                {
                    SystemCode = 2,
                    IsSorryOn = true
                }
            },
            new StatusState
            {
                State = new State
                {
                    SystemCode = 2,
                    IsSorryOn = false
                }
            },
            new StatusState
            {
                State = new State
                {
                    SystemCode = 2,
                    IsSorryOn = true
                }
            },
            new StatusState
            {
                State = new State
                {
                    SystemCode = 2,
                    IsSorryOn = false
                }
            },
            new StatusState
            {
                State = new State
                {
                    SystemCode = 2,
                    IsSorryOn = true
                }
            }
        };
    };
}
