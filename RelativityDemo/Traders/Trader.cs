using System.ComponentModel;

namespace RelativityDemo.Traders
{
    public class Trader
    {
        public string Name { get; set; }
        public int YearOfBirth { get; set; }
        public List<Commodity> Commodities { get; set; }
        public bool Dead { get; internal set; }
        public string Description { get; internal set; }

        public DateTime ProperTime { get; set; }

        public int Age => ProperTime.Year - YearOfBirth;

        private Random random = new();
        public Trader(DateTime currentDate)
        {
            List<string> firstNames = new List<string>()
            { "Ahmed", "Hiroshi", "Mateo", "Tariq", "Juan", "Luca", "Sven", "Dinesh", "Ali", "Kai", "Amina", "Mei-Ling", "Isabella", "Sofia", "Priya", "Fatima", "Maya", "Ingrid", "Anika", "Amara" };
            List<string> lastNames = new List<string>()
            { "Smith", "Patel", "García", "Kim", "Müller", "Singh", "Yamamoto", "Santos", "Petrov", "Ibrahim", "" };

            Name = $"{firstNames.Random()} {lastNames.Random()}".Trim();

            int age = random.Next(18, 55);
            YearOfBirth = currentDate.Year - age;

            Description = "A humble trader of commodities.";

            Commodities = new()
            {
                CommodityTemplates.Food.GetCommodity(currentDate),
                CommodityTemplates.MachineParts.GetCommodity(currentDate),
                CommodityTemplates.ConsumerElectronics.GetCommodity(currentDate)
            };        
        }

        public string GetGreeting()
        {
            List<string> Greetings = new()
            {
                "Hey there! How can I help you today?",
                "Good day, dear customer. How may I assist you this afternoon?",
                "いらっしゃいませ!",
                "Bonjour, monsieur/madame. Comment puis-je vous aider aujourd'hui?",
                "¡Hola! ¿En qué puedo servirte hoy?",
                "Namaste. Kaise madad kar sakta hoon main aapko aaj?",
                "Ciao! Come posso aiutarti oggi?",
                "Здравстввуйте. Чем могу помочь сегодня?",
                "您好! 有什么我可以帮助您的吗?",
                "G'day! What can I do for ya, mate?"
            };

            return Greetings[random.Next(Greetings.Count)];
        }

        public void Refresh(DateTime currentDate)
        {
            //Note - assuming traders (and their items) never move relativatistically
            ProperTime = currentDate;
            foreach (var item in Commodities)
            {
                item.UpdateTime(currentDate, currentDate);
            }

            if (Age > 75)
            {
                Dead = true;
            }
        }

        internal void Connect(IShipTerminal terminal)
        {
            terminal.WriteLine("Connected to trader.");
            terminal.WriteLine($"A warm welcome to you from {Name}.");
            terminal.WriteLine(Description);
            if (Dead)
            {
                terminal.WriteError($"† {Name} died at age {Age} †.");
            }
            if (!Dead)
            {
                terminal.WriteLine();
                terminal.WriteLine(GetGreeting());
                terminal.WriteLine("Commodities available:");
                foreach (var commodity in Commodities)
                {
                    terminal.WriteLine(commodity.LineDescription);
                }
            }
        }
    }
}