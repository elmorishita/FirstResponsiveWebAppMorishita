using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FirstResponsiveWebAppMorishita.Models
{
    public class FutureResponse
    {
        
        // Attributes from the user
        [Required(ErrorMessage = "Please enter a name.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Please your birthyear (YYYY).")]
        [Range(1900, 2023, ErrorMessage = "Year must be between 1900 - 2023")]
        public int BirthYear { get; set; }
        [Required(ErrorMessage = "Please your birthdate (YYYY/MM/DD).")]
        public DateTime BirthDay { get; set; }
        
        // Calculates the users age in years based on their birthdate from 12/31 of this year
        public double AgeThisYear()
        {
            int December = 12;
            int thirtyFirst = 31;
            var today = DateTime.Today;
            var thisYear = today.Year;
            var aYear = 365;

            // Creates datetime object
            DateTime dt = new DateTime(thisYear, December, thirtyFirst);

            // Calculates age effective 12/31 of this year
            var totalDays = (dt - BirthDay).TotalDays; // gets the difference in days
            var differenceInYears = Math.Truncate(totalDays / aYear);
            return differenceInYears;
        }

        // Calculates the users current age in years based on their birthday from today's date.
        public int CurrentAge()
        {
            // Today's date.
            var today = DateTime.Today;

            // Calculate the age.
            var age = today.Year - BirthYear;

            // considers a leap year
            if (BirthDay.Date > today.AddYears(-age)) age--;

            return age;
        }
    }
}
