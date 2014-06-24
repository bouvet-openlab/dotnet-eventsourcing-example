﻿using System;
using SponsorPortal.Helpers;
using SponsorPortal.Infrastructure;

namespace SponsorPortal.ApplicationForm.Contracts
{
    public class ClerkAssignedToApplicationFormEvent : EventBase
    {
        public Guid ApplicationFormId { get; private set; }
        public string ClerkId { get; private set; }

        public ClerkAssignedToApplicationFormEvent(Guid applicationFormId, string clerkId) : base(AggregateRoots.ApplicationForm)
        {
            if (String.IsNullOrEmpty(clerkId)) throw new ArgumentNullException("clerkId");
            ApplicationFormId = applicationFormId;
            ClerkId = clerkId;
        }
    }
}
