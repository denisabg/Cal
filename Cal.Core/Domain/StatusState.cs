using System;

namespace Cal.Core.Domain
{
    public class StatusState
    {
        public Guid Id { get; set; }
        public DateTime DateStamp { get; set; }
        public State State { get; set; }
        

        public StatusState()
        {
            this.Id = Guid.NewGuid();
            this.DateStamp = DateTime.UtcNow;
        }

    }
}
