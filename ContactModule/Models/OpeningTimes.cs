using Piranha.Extend.Fields;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactModule.Models
{
    [Serializable]
    public class OpeningTimes
    {
        public OpeningTime Monday { get; set; }
        public OpeningTime Tuesday { get; set; }
        public OpeningTime Wednesday { get; set; }
        public OpeningTime Thursday { get; set; }
        public OpeningTime Friday { get; set; }
        public OpeningTime Saturday { get; set; }
        public OpeningTime Sunday { get; set; }
    }

    [Serializable]
    public class OpeningTime
    {
        public StringField Open { get; set; }
        public StringField Close { get; set; }
    }
}
