using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using SponsorPortal.ApplicationManagement.QueryModel.ApplicationFormAggregate;

namespace SponsorPortal.TestDataBuilders
{
    public class QueryApplicationFormBuilder : TestDataBuilder<ApplicationForm>
    {
        private Guid _id;
        private string _organization;
        private string _email;
        private double _amount;
        private string _title;
        private string _text;
        private ApplicationStatus _status;
        private DateTime _createdTimestamp;
        private DateTime _updatedTimestamp;
        private string _clerkName;
        private ImmutableList<HistoryEntry> _history;
        

        public QueryApplicationFormBuilder()
        {
            _id = Guid.NewGuid();
            _organization = "My Company";
            _email = "person@company.com";
            _amount = 10000;
            _title = "Request for money";
            _text = "Need money for stuff";
            _status = ApplicationStatus.NotProcessed;
            _createdTimestamp = DateTime.Now;
            _updatedTimestamp = DateTime.Now;
            _clerkName = "Mr.Clerk";
            _history = CreateDefaultHistory();
        }

        private ImmutableList<HistoryEntry> CreateDefaultHistory()
        {
            return new List<HistoryEntry>
            {
                new HistoryEntry
                {
                    Timestamp = DateTime.Now.Subtract(new TimeSpan(1,0,0,0)),
                    User = _clerkName,
                    Text = "Application was created"
                }
            }.ToImmutableList();
        } 

        public QueryApplicationFormBuilder WithId(Guid id)
        {
            _id = id;
            return this;
        }

        public QueryApplicationFormBuilder WithOrganization(string organization)
        {
            _organization = organization;
            return this;
        }

        public QueryApplicationFormBuilder WithEmail(string email)
        {
            _email = email;
            return this;
        }

        public QueryApplicationFormBuilder WithAmount(double amount)
        {
            _amount = amount;
            return this;
        }

        public QueryApplicationFormBuilder WithTitle(string title)
        {
            _title = title;
            return this;
        }

        public QueryApplicationFormBuilder WithText(string text)
        {
            _text = text;
            return this;
        }

        public QueryApplicationFormBuilder WithStatus(ApplicationStatus status)
        {
            _status = status;
            return this;
        }

        public QueryApplicationFormBuilder WithCreatedTimestamp(DateTime timestamp)
        {
            _createdTimestamp = timestamp;
            return this;
        }

        public QueryApplicationFormBuilder WithUpdatedTimestamp(DateTime timestamp)
        {
            _updatedTimestamp = timestamp;
            return this;
        }

        public QueryApplicationFormBuilder WithClerkName(string name)
        {
            _clerkName = name;
            return this;
        }

        public QueryApplicationFormBuilder WithHistory(IEnumerable<HistoryEntry> entries)
        {
            _history = entries.ToImmutableList();
            return this;
        }

        public override ApplicationForm Build()
        {
            return new ApplicationForm(_id, _organization, _email, _amount, _title, _text, _status, _createdTimestamp, _updatedTimestamp, _clerkName, _history);   
        }
    }
}
