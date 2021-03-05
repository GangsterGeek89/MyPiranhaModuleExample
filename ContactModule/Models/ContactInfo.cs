using Piranha.Extend.Fields;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactModule.Models
{
    [Serializable]
    public class ContactInfo
    {
        public StringField Email { get; set; }
        public StringField UkPhone { get; set; }
        public StringField UsaPhone { get; set; }
        public StringField Address { get; set; }
    }
}
