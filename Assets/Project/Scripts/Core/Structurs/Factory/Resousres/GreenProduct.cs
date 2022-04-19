using System;

namespace ProductProduce
{
    public class GreenProduct : IItem
    {
        public Type Type => GetType();

        public ItemsType ItemType => ItemsType.Green;

        public GreenProduct(in BlackProduct black ,in RedProduct red)
        {
            // anyting operation
        }
    }

}
