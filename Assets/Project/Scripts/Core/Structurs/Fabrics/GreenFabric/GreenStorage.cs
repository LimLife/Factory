using System.Collections.Generic;
namespace GreenFabricStorage
{
    public class GreenStorage : StorageResuorses
    {
        public bool IsEmpty => _red.Count == 0 || _black.Count == 0;

        private RedItem _redItem;

        private BlackItem _blackItem;
        private List<RedItem> _red;
        private List<BlackItem> _black;

        private StorageResourses _resuorses;
        private ConfigStorage _config;

        private int _capacity => _config.CapacityStorage;
        public GreenStorage()
        {
            _red = new List<RedItem>();
            _black = new List<BlackItem>();
        }
        public void Initialize(StorageResourses storage, ConfigStorage config)
        {
            _resuorses = storage;
            _config = config;
        }
        public override void GetResourses(BlackItem black, RedItem red) // return struct future
        {
            _red.Remove(red);
            _black.Remove(black);
        }
        public bool CheckCapacity(IItem item) // 2 copy method 
        {
            if (item.Type == _redItem.Type)
                if (_red.Count < _capacity)
                    return true;

            if (item.Type == _blackItem.Type)
                if (_black.Count < _capacity)
                    return true;

            return false;
        }
        public override bool GiveResourses(IItem item)
        {
            if (item.Type == _redItem.Type)
            { 
                _red.Add((RedItem)item);
                Message($"Ресурса Красного {_red.Count}");
                _resuorses.SetVolume((byte)_red.Count);
            }    

            if (item.Type == _blackItem.Type)
                _black.Add((BlackItem)item);
            // future adding 

            return false;
        }

        private void Message(string msg)
        {
            _resuorses.Message(msg);
        }
    }
}


