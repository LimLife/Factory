using System.Collections.Generic;
using ProductProduce;
namespace GreenFabricStorage
{
    public class GreenStorage : StorageResuorses
    {
        public bool IsEmpty => _red.Count == 0 || _black.Count == 0;
        public bool IsFull => _red.Count >= _capacity || _black.Count >= _capacity; //one factory produce only one resources

        private Stack<RedProduct> _red;
        private Stack<BlackProduct> _black;

        private StorageResourses _resuorses;
        private ConfigStorage _config;

        private int _capacity => _config.CapacityStorage;
        public GreenStorage()
        {
            _red = new Stack<RedProduct>();
            _black = new Stack<BlackProduct>();
        }
        public void Initialize(StorageResourses storage, ConfigStorage config)
        {
            _resuorses = storage;
            _config = config;
        }
        public override Resorses GetResourses()
        {
            var red = _red.Pop();
            var black = _black.Pop();
            return new Resorses(black, red);
        }
        public override void GiveResourses(IItem item)
        {
            switch (item.ItemType)
            {
                case ItemsType.Red:
                    _red.Push((RedProduct)item);
                    Message($"Ресурса Красного {_red.Count}");
                    _resuorses.SetVolume((byte)_red.Count);
                    break;
                case ItemsType.Black:
                    _black.Push((BlackProduct)item);
                    Message($"Ресурса Черного {_black.Count}");
                    _resuorses.SetVolume((byte)_black.Count);
                    break;
            }
        }
        private void Message(string msg)
        {
            _resuorses.Message(msg);
        }
    }
}




