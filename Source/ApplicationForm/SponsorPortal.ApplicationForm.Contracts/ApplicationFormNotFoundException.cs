using System;

namespace SponsorPortal.ApplicationForm.Contracts
{
    public class ApplicationFormNotFoundException : Exception
    {
        public ApplicationFormNotFoundException(string msg) : base(msg)
        {
            
        }
       
    }
}
