﻿using System;
using System.Threading.Tasks;
using SponsorPortal.ApplicationForm.Contracts;

namespace SponsorPortal.ApplicationForm
{
    public interface IApplicationFormRespository
    {
        ApplicationForm CreateNewApplication(string organization, string email, double amount, string title, string text);
        ApplicationForm GetApplicationForm(Guid applicationFormId);
        Task Store(CreatedNewApplicationFormEvent evnt);
    }
}
