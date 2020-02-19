using CodenameGenerator;
using PizzaTime.Core.Customers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaTime.SeedMethods
{
    public class SeedCustomers
    {
        public int AmountToSeed { get; set; }
        private readonly Generator _generator;
        private readonly Random _random;
        private readonly string _areaCode;
        private readonly string _zipCode;

        private WordBank RoadSuffixes = new WordBank(Word.Noun, "RoadSuffixes", new WordRepository(new string[] { "Road", "Street", "Plaza", "Way", "Avenue", "Drive", "Lane", "Grove", "Gardens", "Place" }));


        public SeedCustomers()
        {
            _generator = new Generator();
            _random = new Random();
            _zipCode = _random.Next(10000, 99999).ToString();
            _areaCode = _random.Next(0, 999).ToString().PadRight(3, '0');            
        }

        public async Task<IEnumerable<Customer>> Seed()
        {
            var customers = new List<Customer>();

            for (int i = 0; i < AmountToSeed; i++)
            {
                customers.Add(SeedCustomer());
            }
            return customers;
        }

        private Customer SeedCustomer()
        {
            _generator.SetParts(WordBank.FirstNames);
            _generator.Casing = Casing.PascalCase;
            var firstName = _generator.Generate();
            _generator.SetParts(WordBank.LastNames);
            _generator.Casing = Casing.PascalCase;
            var lastName = _generator.Generate();
            _generator.SetParts(WordBank.Nouns, RoadSuffixes);
            _generator.Casing = Casing.PascalCase;
            return new Customer(firstName, lastName, $"{_areaCode}-{_random.Next(0, 9999999).ToString().PadRight(7, '0')}") 
            {
                Address = $"{_areaCode} {_generator.Generate()}",
                ZipCode = _zipCode
            };
        }
    }
}
