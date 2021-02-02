using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public Address(string street, string number, string neighborhood, string city, string state, string country, string zipCode)
        {
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;

            AddNotifications(new Contract()
                .Requires()
                .IsNull(Street,"Street","Rua não pode ser nulo")
                .IsNull(Number,"Number","Numero não pode ser nulo")
                .IsNull(Neighborhood,"Neighborhood","Bairro não pode ser nulo")
                .IsNull(City,"City","Cidade não pode ser nulo")
                .IsNull(State,"State","Estado não pode ser nula")
                .IsNull(Country,"Country","País não pode ser nulo")
                .IsNull(ZipCode,"ZipCode","CEP não pode ser nulo")
            );
        }

        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }
    }
}