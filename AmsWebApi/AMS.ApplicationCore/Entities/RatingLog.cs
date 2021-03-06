﻿using Web.ApplicationCore.Entities.Security;

namespace Web.ApplicationCore.Entities
{
    public class RatingLog : BaseEntity
    {
        public Employee Employee { get; set; }
        public Employee ReportingManager { get; set; }
        public Designation Designation { get; set; }
        public ReviewCycle ReviewCycle { get; set; }
        public float Rating { get; set; }
        public string Feedback { get; set; }
    }
}