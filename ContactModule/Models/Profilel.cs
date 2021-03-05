using Piranha.Extend.Fields;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactModule.Models
{
    [Serializable]
    public class Profile
    {
        public ImageField Image { get; set; }

        public StringField Name { get; set; }

        public StringField Aka { get; set; }

        public StringField Intro { get; set; }
    }
}
