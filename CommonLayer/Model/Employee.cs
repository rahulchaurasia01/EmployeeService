/*
 *  Purpose: Its a Getter Setter to Store the Employee Data.
 * 
 *  Author: Rahul Chaurasia
 *  Date: 9/1/2020
 */

using System.ComponentModel.DataAnnotations;

namespace CommonLayer.Model
{
    public class Employee
    {

        public int ID { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage ="Your FirstName Should only contains Alphabet and Should be in PascalCase")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Your LastName Should only contains Alphabet and Should be in PascalCase")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression("^[M|m]ale$|^[F|f]emale$", ErrorMessage = "Your Gender Should be Male Or Female and in PascalCase")]
        public string Gender { get; set; }

        [Required]
        public string Specialization { get; set; }

        [Required]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Your Salary Should Contains Only Number")]
        public int Salary { get; set; }


    }
}
