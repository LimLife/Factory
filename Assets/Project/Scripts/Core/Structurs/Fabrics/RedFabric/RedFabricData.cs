using System.Collections.Generic;
using System;
namespace RedFabricStorage
{
    public class RedFabricData
    {
        private BlackItem _item;
        public Type Type => _item.Type;
        public List<BlackItem> BlackResourses { get; private set; }
       
        public RedFabricData()
        {
            BlackResourses = new List<BlackItem>();
        }
        public void GiveResourses(BlackItem black)
        {
            BlackResourses.Add(black);
        }
        public void GetResourses(BlackItem black)
        {
            BlackResourses.Remove(black);
        }    
    }
}


