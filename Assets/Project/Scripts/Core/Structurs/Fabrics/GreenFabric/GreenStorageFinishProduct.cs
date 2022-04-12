using System.Collections.Generic;
namespace GreenFabricStorage
{
    public class GreenStorageFinishProduct : StorageFinishProduct
    {
        public bool IsFull => _green.Count == 10;
        public bool IsEmpty => _green.Count == 0;

        private Stack<GreenItem> _green;

        public GreenStorageFinishProduct()
        {          
            _green = new Stack<GreenItem>();
        }
        public override IItem GetItem()
        {
            var item = _green.Pop();
            return item;
        }
        public override void GiveProduct(GreenItem red)
        {
           _green.Push(red);
        }
    }
}