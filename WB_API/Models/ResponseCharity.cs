using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WB_API.Models
{
    public class ResponseCharity
    {
        public ResponseCharity(Charity charity)
        {
            CharityId = charity.CharityId;
            CharityName = charity.CharityName;
            CharityDescription = charity.CharityDescription;
            CharityLogo = charity.CharityLogo;
        }

        public int CharityId { get; set; }
        public string CharityName { get; set; }
        public string CharityDescription { get; set; }
        public byte[] CharityLogo { get; set; }
    
    }
}