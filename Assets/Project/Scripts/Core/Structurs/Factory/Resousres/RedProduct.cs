using System;

namespace ProductProduce
{
    public class RedProduct : IItem
    {
        public Type Type => GetType();

        public ItemsType ItemType => ItemsType.Red;

        public RedProduct(in BlackProduct black)
        {
            // anyting operation
        }
    }

}
