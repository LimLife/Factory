using System.Collections.Generic;
using ProductProduce;

namespace BlackFabricStorage
{   
    public class BlackStorageFinifshProduct : StorageFinishProduct
    {
        public bool IsFull => _blackItem.Count > _capasity;
        public bool IsEmpty => _blackItem.Count == 0;
        private int _capasity => _config.CapacityStorage;

        private Stack<BlackProduct> _blackItem;
        private StorageProduct _storage;
        private ConfigStorage _config;
        public BlackStorageFinifshProduct()
        {
            _blackItem = new Stack<BlackProduct>();
        }
        public void SetView(StorageProduct storage, ConfigStorage config)
        {
            _config = config;
            _storage = storage;
        }
        public override IItem GetItem()
        {
            var item = _blackItem.Pop();
            _storage.Message($"На складе : {_blackItem.Count}");
            _storage.SetVolume((byte)_blackItem.Count);          
            return item;
        }
        public override void GiveProduct(IItem black)
        {
            _storage.Message($"На складе : {_blackItem.Count}");
            _storage.SetVolume((byte)_blackItem.Count);
            _blackItem.Push((BlackProduct)black);
        }
    }
}
