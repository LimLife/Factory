using System.Collections.Generic;
using ProductProduce;
using System;
namespace RedFabricStorage
{
    public class RedFabricData
    {
        private BlackItem _item;
        public Type Type => _item.Type;
        public List<BlackProduct> BlackResourses { get; private set; }
       
        public RedFabricData()
        {
            BlackResourses = new List<BlackProduct>();
        }
        public void GiveResourses(BlackProduct black)
        {
            BlackResourses.Add(black);
        }
        public void GetResourses(BlackProduct black)
        {
            BlackResourses.Remove(black);
        }    
    }
}


