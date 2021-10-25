using System;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using FileHelpers;

namespace Assignment1
{
    [DelimitedRecord(",")]
    public class CustomerDetails
    {
        [Name("First Name")]
        public String FirstName { get; set; }

        [Name("Last Name")]
        public String LastName { get; set; }

        [Name("Street Number")]
        public String StreetNumber { get; set; }

        [Name("Street")]
        public String Street { get; set; }

        [Name("City")]
        public String City { get; set; }

        [Name("Province")]
        public String Province { get; set; }

        [Name("Postal Code")]
        public String Postal { get; set; }

        [Name("Country")]
        public String Country { get; set; }

        [Name("Phone Number")]
        public String PhoneNumber { get; set; }

        [Name("email Address")]
        public String emailAddress { get; set; }

    }
}
