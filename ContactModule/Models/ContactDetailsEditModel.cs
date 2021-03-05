using Piranha.Manager.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactModule.Models
{
    public class ContactDetailsEditModel
    {
        public StatusMessage Status { get; set; }

        public Profile Profile { get; set; }

        public ContactInfo ContactInfo { get; set; }

        public OpeningTimes OpeningTimes { get; set; }
    }
}
