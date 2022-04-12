using System.Collections.Generic;
namespace BlackFabricStorage
{
    public class BlackStorageFinifshProduct : StorageFinishProduct
    {
        // прокинуть ссылку через скриптебл оьжект через мэйн итем

        public bool IsFull => _blackItem.Count > _capasity;
        public bool IsEmpty => _blackItem.Count == 0;
        private int _capasity => _config.CapacityStorage;

        private Stack<BlackItem> _blackItem;
        private StorageProduct _storage;
        private ConfigStorage _config;
        public BlackStorageFinifshProduct()
        {
            _blackItem = new Stack<BlackItem>();
        }
        public void SetView(StorageProduct storage, ConfigStorage config)
        {
            _config = config;
            _storage = storage;
        }
        public override IItem GetItem()
        {
            var item = _blackItem.Pop();
            _storage.Message($"На складе : {_blackItem.Count}  Продукта {item.GetType()}");
            _storage.SetVolume((byte)_blackItem.Count);
            return item;
        }
        public override void GiveProduct(BlackItem black)
        {
            _storage.Message($"На складе : {_blackItem.Count}");
            _storage.SetVolume((byte)_blackItem.Count);
            _blackItem.Push(black);
        }
    }
}
