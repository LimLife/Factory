using System.Collections.Generic;
using ProductProduce;
namespace RedFabricStorage
{
    public class RedStorage : StorageResuorses
    {
        public bool IsFull => _blackResourses.Count > _capacity;
        public bool IsEmpty => _blackResourses.Count == 0;

        private readonly Stack<BlackProduct> _blackResourses;
        private int _capacity => _config.CapacityStorage;

        private StorageResourses _resourses;
        private ConfigStorage _config;

        public RedStorage()
        {
            _blackResourses = new Stack<BlackProduct>();
        }
        public void Initialize(StorageResourses storage, ConfigStorage config)
        {
            _resourses = storage;
            _config = config;
        }
        public override void GiveResourses(IItem item)
        {
            _blackResourses.Push((BlackProduct)item);

            Message($"Количество ресурсов {_blackResourses.Count}");
            _resourses.SetVolume((byte)_blackResourses.Count);          
        }
        public override Resorses GetResourses()
        {
            var item = _blackResourses.Pop();
            Message($"Количество ресурсов {_blackResourses.Count}");
            _resourses.SetVolume((byte)_blackResourses.Count);
            return new Resorses(in item);
        }
        private void Message(string msg)
        {
            _resourses.Message(msg);
        }
    }
}


