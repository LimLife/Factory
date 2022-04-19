using System;

namespace ProductProduce
{
    public class BlackProduct : IItem
    {
        public Type Type => GetType();

        public ItemsType ItemType => ItemsType.Black;

        public int Coast = 5; // Test      
       
    }

}
