using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WB_API.Models
{
    public class ResponseRegistration
    {
        public ResponseRegistration(Registration registration)
        {
            id = registration.RegistrationId;
            runnerId = registration.RunnerId;
            registDT = registration.RegistrationDateTime;
            charityId = registration.CharityId ?? 0;

        }

        public int id { get; set; }
        public int runnerId { get; set; }
        public DateTime registDT { get; set; }
        public int charityId { get; set; }
    }
}