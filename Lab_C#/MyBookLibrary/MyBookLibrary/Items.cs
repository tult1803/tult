using System;

namespace MyBookLibrary
{
    class Items
    {
        public string Code { set; get; }
        public string Name { set; get; }
        public float Price { set; get; }

        public Items(string id, string name, float price)
        {
            Code = id; Name = name; Price = price;
        }

        public Items()
        {
        }
    }
}
