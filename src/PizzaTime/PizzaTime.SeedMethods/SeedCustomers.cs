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
        private readonly Random _random;
        private readonly Generator _generator;
        private readonly Func<Random, string> GenerateZipCode = r => r.Next(10000, 99999).ToString();
        private readonly Func<Random, string> GenerateAreaCode = r => r.Next(0, 999).ToString().PadRight(3, '0');
        private readonly Func<Generator, string> GenerateMaleFirstName = g => { g.SetParts(WordBank.MaleFirstNames); return g.Generate(); };
        private readonly Func<Generator, string> GenerateFemaleFirstName = g => { g.SetParts(WordBank.FirstNames); return g.Generate(); };
        private readonly Func<Generator, string> GenerateLastName = g => { g.SetParts(WordBank.LastNames); return g.Generate(); };
        private readonly Func<Generator, string> GenerateStreetName = g => { g.SetParts(WordBank.Nouns, RoadSuffixes); return g.Generate(); };

        private static readonly WordBank RoadSuffixes = new WordBank(Word.Noun, "RoadSuffixes", new WordRepository(new string[] { "Road", "Street", "Plaza", "Way", "Avenue", "Drive", "Lane", "Grove", "Gardens", "Place" }));


        public SeedCustomers()
        {
            _generator = new Generator(" ", Casing.PascalCase);
            _random = new Random();                        
        }

        public async Task<IEnumerable<Customer>> Seed()
        {
            var customers = new List<Customer>();

            for (int i = 0; i < AmountToSeed; i++)
            {
                customers.Add(SeedFemaleCustomer());
                customers.Add(SeedMaleCustomer());
            }
            return customers;
        }

        private Customer SeedFemaleCustomer()
        {
            var areaCode = GenerateAreaCode(_random);
            var firstName = GenerateFemaleFirstName(_generator);
            var lastName = GenerateLastName(_generator);
            return new Customer(firstName, lastName, $"{GenerateAreaCode(_random)}-{_random.Next(0, 9999999).ToString().PadRight(7, '0')}") 
            {
                Address = $"{GenerateAreaCode(_random)} {GenerateStreetName(_generator)}",
                ZipCode = GenerateZipCode(_random)
            };
        }

        private Customer SeedMaleCustomer()
        {
            var areaCode = GenerateAreaCode(_random);
            var firstName = GenerateMaleFirstName(_generator);
            var lastName = GenerateLastName(_generator);
            return new Customer(firstName, lastName, $"{GenerateAreaCode(_random)}-{_random.Next(0, 9999999).ToString().PadRight(7, '0')}")
            {
                Address = $"{GenerateAreaCode(_random)} {GenerateStreetName(_generator)}",
                ZipCode = GenerateZipCode(_random)
            };
        }
    }
}
