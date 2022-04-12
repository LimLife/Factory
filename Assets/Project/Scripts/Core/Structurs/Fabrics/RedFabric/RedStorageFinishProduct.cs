using System.Collections.Generic;
namespace RedFabricStorage
{
    public class RedStorageFinishProduct : StorageFinishProduct
    {
        public bool IsFull => _red.Count == _config.CapacityStorage; 
        public bool IsEmpty => _red.Count == 0;
             
        private Stack<RedItem> _red;

        private StorageProduct _storage;
        private ConfigStorage _config;

        public void Initialize(StorageProduct product, ConfigStorage config)
        {
            _storage = product;
            _config = config;
        }
        public RedStorageFinishProduct()
        {
            _red = new Stack<RedItem>();
        }
        public override IItem GetItem()
        {
            var item = _red.Pop();
            Message($"На скаладе {_red.Count}");
            _storage.SetVolume((byte)_red.Count);
            return item;
        }
        public override void GiveProduct(RedItem red)
        {
            Message($"На скаладе {_red.Count}");
            _storage.SetVolume((byte)_red.Count);
            _red.Push(red);
        }
        private void Message(string msg)
        {
            _storage.Message(msg);
        }
    }
}
