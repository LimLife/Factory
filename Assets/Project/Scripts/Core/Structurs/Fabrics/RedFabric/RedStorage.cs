namespace RedFabricStorage
{
    public class RedStorage : StorageResuorses
    {
        public bool IsFull => _red.BlackResourses.Count > _capacity;
        public bool IsEmpty => _red.BlackResourses.Count == 0;

        private readonly BlackItem _black;
        private readonly RedFabricData _red;

        private int _capacity => _config.CapacityStorage;

        private StorageResourses _resourses;
        private ConfigStorage _config; 

        public RedStorage()
        {
            _red = new RedFabricData();
        }
        public void Initialize(StorageResourses storage, ConfigStorage config)
        {
            _resourses = storage;
            _config = config;
        }
        public override bool GiveResourses(IItem item)
        {
            if (item.Type == _black.Type)
            {
                Message($"Количество ресурсов {_red.BlackResourses.Count}");
                _resourses.SetVolume((byte)_red.BlackResourses.Count);

                _red.GiveResourses((BlackItem)item);
            }

            return false;
        }

        public override void GetResourses(BlackItem black)
        {
            Message($"Количество ресурсов {_red.BlackResourses.Count}");
            _resourses.SetVolume((byte)_red.BlackResourses.Count);

            _red.GetResourses(black);
        }
        private void Message(string msg)
        {
            _resourses.Message(msg);
        }
    }
}


