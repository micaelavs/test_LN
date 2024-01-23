using proyectoApi.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace proyectoApi.Models
{
    public partial class Contact: IEntity
    {
        public Contact()
        {
            
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Profile { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public string Address { get; set; }
        public int IdCity { get; set; }
        public City City { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }

    }


    [MetadataType(typeof(ContactMetadata))]
    public partial class Contact
    {
        public class ContactMetadata
        {
            [Key]
            [Column(Order = 1)]
            public int Id { get; set; }

            [ForeignKey("City")]
            [Required]
            public int IdCity { get; set; }

            [StringLength(50)]
            public string Name { get; set; }

            [StringLength(50)]
            public string Company { get; set; }

            [StringLength(50)]
            public string Profile { get; set; }

            [StringLength(50)]
            public string Image { get; set; }
           
            [StringLength(50)]
            public string Email { get; set; }
            
            public DateTime Birthdate { get; set; }

            public PhoneNumber PhoneNumber { get; set; }

            [StringLength(50)]
            public string Address { get; set; }
        }
    }
}