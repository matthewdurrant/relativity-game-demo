namespace RelativityDemo.Traders
{
    public class CommodityTemplate
    {
        public string Name { get; set; }

        /// <summary>
        /// Modern economics brings you: Planned Obsolescence.
        /// How long before the product becomes unfashionable in a coordinate time frame.
        /// E.g. a TV becomes obsolete after 5 years.
        /// </summary>
        public TimeSpan? ObsolescenceLifeSpan { get; set; }

        /// <summary>
        /// How long before the product becomes unusable in the product's time frame.
        /// E.g. for a piece of nigiri, 10 hours.
        /// Refers to those physical, chemical and biological processes which operate in the item's reference frame.
        /// For example, a piece of sushi flying to Alpha Centauri at relativistic speeds might still be edible if it's moving fast enough.
        /// Every item has a perishable life span, even if it's on the magnitude of the heat death of the universe.
        public TimeSpan PerishableLifeSpan { get; set; }

        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }

        public Commodity GetCommodity(DateTime currentDate)
        {
            Random rand = new Random();
            decimal randomPrice = (decimal)rand.NextDouble();
            decimal price = randomPrice * (MaxPrice - MinPrice) + MinPrice;

            return new Commodity(currentDate)
            {
                Name = Name,
                BasePrice = price,
                ObsolescenceLifeSpan = ObsolescenceLifeSpan,
                PerishableLifeSpan = PerishableLifeSpan
            };
        }
    }

    public class Commodity : CommodityTemplate
    {
        public decimal BasePrice { get; set; }

        public decimal Price {  get
            {
                decimal price = BasePrice;
                if (ObsolescenceLifeSpan is not null)
                    price = price * (decimal)Fashionability.Value;

                if (Perished)
                    price = price * 0.01m;

                return price;
            } 
        }

        public DateTime ManufactureDate { get; set; }
        public DateTime ProperTime { get; set; }
        public DateTime CoordinateTime { get; set; }

        public void UpdateTime(DateTime properTime, DateTime coordinateTime)
        {
            ProperTime = properTime;
            CoordinateTime = coordinateTime;
        }

        /// <summary>
        /// The age of the object from the object's reference frame.
        /// TODO Every object in the game should probably have ProperAge simulation.
        /// ...Even people.
        /// </summary>
        public TimeSpan ProperAge => ProperTime - ManufactureDate;
        public DateTime PerishDate => ManufactureDate.Add(PerishableLifeSpan);
        public TimeSpan RemainingLifespan => PerishDate - ProperTime;
        public bool Perished => PerishableLifeSpan > ProperAge;

        /// <summary>
        /// How fashionable the object is and how much the price should change as a kind of percentage.
        /// E.g. if the ObsolescenceDate is more than (after) the current time, the Fashionability is 110% let's say.
        /// Once coordinate time passes the ObsolescenceDate, Fashionability drops below 100%.
        /// Then the price can be set appropriately.
        /// Some items (e.g. Food) don't have fashionability.
        /// TODO Some items might get fashionable again after a long time. Like antiques.
        /// </summary>
        public DateTime? ObsolescenceDate => (ObsolescenceLifeSpan is null) ? null : ManufactureDate + ObsolescenceLifeSpan;
        public float? Fashionability => (ObsolescenceLifeSpan is null) ? null : ObsolescenceDate.Value.Ticks / CoordinateTime.Ticks;

        public string LineDescription
        {
            get
            {
                string name = ObsolescenceDate is null ? Name : $"{Name} ({ManufactureDate.Year})";
                return $"{name} (₲{Price}) - Expires in {RemainingLifespan.PrettyPrintTimeSpan()}";
            }
        }

        public Commodity(DateTime currentDate)
        {
            ProperTime = currentDate;
            CoordinateTime = currentDate;
            ManufactureDate = currentDate; //TODO This could be random
        }
    }

    public static class CommodityTemplates
    {
        //TODO Put these in a config file
        public static CommodityTemplate Food => new CommodityTemplate { 
            Name = "Food",
            MaxPrice = 150,
            MinPrice = 50,
            ObsolescenceLifeSpan = null, //Food is always in fashion
            PerishableLifeSpan = TimeSpan.FromDays(7)        
        };

        public static CommodityTemplate MachineParts => new CommodityTemplate
        {
            Name = "Machine Parts",
            MaxPrice = 1500,
            MinPrice = 500,
            ObsolescenceLifeSpan = TimeSpan.FromDays(365 * 100),
            PerishableLifeSpan = TimeSpan.FromDays(365 * 120)
        };

        public static CommodityTemplate ConsumerElectronics => new CommodityTemplate
        {
            Name = "Consumer Electronics",
            MaxPrice = 1500,
            MinPrice = 500,
            ObsolescenceLifeSpan = TimeSpan.FromDays(365 * 5),
            PerishableLifeSpan = TimeSpan.FromDays(365 * 30)
        };
    }
}