using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SponsorPortal.Infrastructure;

namespace SponsorPortal.EventStore
{
    class EventSubscriptionManager
    {
        private readonly List<EventSubscriptionEntry> _eventSubscriptions;

        public EventSubscriptionManager()
        {
            _eventSubscriptions = new List<EventSubscriptionEntry>();
        }

        public void Subscribe<TEvent>(string streamId, Action<TEvent> subscription) where TEvent : IEvent
        {
            var eventType = typeof (TEvent).Name;

            if (_eventSubscriptions.All(sub => sub.StreamId != streamId))
            {
                var entry = new EventSubscriptionEntry(streamId);    
                //entry.Subscriptions.Add(eventType, new List<Action<object>>{ subscription });
            }
            
        }

    }

    class EventSubscriptionEntry
    {
        public string StreamId { get; set; }
        public Dictionary<string, List<object>> Subscriptions { get; set; }

        public EventSubscriptionEntry(string streamId)
        {
            if (streamId == null) throw new ArgumentNullException("streamId");
            StreamId = streamId;

            Subscriptions = new Dictionary<string, List<object>>();
        }
    }
}
