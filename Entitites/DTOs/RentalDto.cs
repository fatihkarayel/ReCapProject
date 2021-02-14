using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entitites.DTOs
{
    public class RentalDto:IDto
    {
        public int Id { get; set; }
        public string CarName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }

    }
}
