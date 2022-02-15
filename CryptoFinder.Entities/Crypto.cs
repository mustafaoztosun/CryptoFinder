using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//Entities Layer : The layer in which it holds the classes corresponding
//to the tables in the database.
namespace CryptoFinder.Entities
{
    //The requirement of the relevant fields was provided with the "Required" rule.
    public class Crypto
    {
        //The Id field is written to be the Primary Key and to start from Id 1.
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //It was written because we want it to be a maximum of 50 characters.
        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        // //It was written because we want it to be a maximum of 50 characters.
        [StringLength(50)]
        [Required]
        public string Country { get; set; }
        // //It was written because we want it to be a maximum of 50 characters.
        [StringLength(50)]
        [Required]
        public string Address { get; set; }
    }
}
