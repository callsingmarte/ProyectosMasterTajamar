﻿using System.ComponentModel.DataAnnotations;

namespace IdentityUniversityCoreApp.Models
{
    public enum LetterGrade
    {
        A, B, C, D, F, I, W, P
    }

    public class Enrollment
    {
        public int EnrollmentId {  get; set; }
        public int StudentId { get; set; }
        public virtual Student? Student { get; set; }
        public int  CourseId { get; set; }
        public virtual Course? Course { get; set; }
        [DisplayFormat(NullDisplayText = "No grade")]
        public LetterGrade? LetterGrade { get; set; }
    }
}
