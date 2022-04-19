using System.Collections.Generic;
using ProductProduce;
namespace GreenFabricStorage
{
    public class GreenStorageFinishProduct : StorageFinishProduct
    {
        public bool IsFull => _green.Count == _config.CapacityStorage;
        public bool IsEmpty => _green.Count == 0;

        private Stack<GreenProduct> _green;

        private StorageProduct _storage;
        private ConfigStorage _config;
        public GreenStorageFinishProduct()
        {
            _green = new Stack<GreenProduct>();
        }
        public void Initialize(StorageProduct storage, ConfigStorage config)
        {
            _storage = storage;
            _config = config;
        }
        public override IItem GetItem()
        {
            Message($"Колличество : {_green.Count}");
            _storage.SetVolume((byte)_green.Count);
            return _green.Pop();
        }
        public override void GiveProduct(IItem green)
        {
            _green.Push((GreenProduct)green);
            Message($"Колличество : {_green.Count}");
            _storage.SetVolume((byte)_green.Count);
        }
        private void Message(string msg)
        {
            _storage.Message(msg);
        }
    }
}