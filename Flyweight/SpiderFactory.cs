namespace Flyweight
{
    public class SpiderFactory
    {
        private readonly Dictionary<string, ISpider> _spiders = new();
        private Lazy<UnknownSpider> _unknownSpider = new Lazy<UnknownSpider>(() => new UnknownSpider());

        public ISpider GetSpider(string spiderType)
        {
            if (_spiders.ContainsKey(spiderType))
            {
                Console.WriteLine($"\n(Re-using the {spiderType})");
                return _spiders[spiderType];
            }

            switch ( spiderType ) 
            {
                case "Daddy-Long-Legs":
                    _spiders.Add(spiderType, new DaddyLongLegs());
                    return _spiders[spiderType];
                case "Red Back Spider":
                    _spiders.Add( spiderType, new RedBack( ) );
                    return _spiders[ spiderType ];
                default:
                    return _unknownSpider.Value;
            }
        }
    }
}
