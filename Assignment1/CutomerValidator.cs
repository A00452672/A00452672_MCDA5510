using CsvHelper.Configuration;
using System;

namespace Assignment1
{
    public class CutomerValidatorClassMap : ClassMap<CustomerDetails>
    {
        public CutomerValidatorClassMap()
        {
            Map(m => m.FirstName).Name("First Name").Validate(x => !String.IsNullOrEmpty(x.Field) && !(x.Field.Contains(",")));
            Map(m => m.LastName).Name("Last Name").Validate(x => !String.IsNullOrEmpty(x.Field) && !(x.Field.Contains(",")));
            Map(m => m.StreetNumber).Name("Street Number").Validate(x => !String.IsNullOrEmpty(x.Field) && !(x.Field.Contains(",")));
            Map(m => m.Street).Name("Street").Validate(x => !String.IsNullOrEmpty(x.Field) && !(x.Field.Contains(",")));
            Map(m => m.City).Name("City").Validate(x => !String.IsNullOrEmpty(x.Field) && !(x.Field.Contains(",")));
            Map(m => m.Province).Name("Province").Validate(x => !String.IsNullOrEmpty(x.Field) && !(x.Field.Contains(",")));
            Map(m => m.Postal).Name("Postal Code").Validate(x => !String.IsNullOrEmpty(x.Field) && !(x.Field.Contains(",")));
            Map(m => m.Country).Name("Country").Validate(x => !String.IsNullOrEmpty(x.Field) && !(x.Field.Contains(",")));
            Map(m => m.PhoneNumber).Name("Phone Number").Validate(x => !String.IsNullOrEmpty(x.Field) && !(x.Field.Contains(",")));
            Map(m => m.emailAddress).Name("email Address").Validate(x => !String.IsNullOrEmpty(x.Field) && !(x.Field.Contains(",")));
        }
    }

}
