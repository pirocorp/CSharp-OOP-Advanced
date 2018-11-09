namespace CS_OOP_Advanced_Exam_Prep_July_2016.Models.Shops
{
    using System.Collections.Generic;
    using Products;

    public abstract class Shop : IShop
    {
        private readonly IList<IProduct> products;
        private readonly IShop successor;
        private readonly int capacity;
        private int usedCapacity;

        protected Shop(IShop successor, int capacity)
        {
            this.successor = successor;
            this.capacity = capacity;
            this.usedCapacity = 0;
            this.products = new List<IProduct>();
        }

        public IEnumerable<IProduct> Products => this.products;

        public IShop AddProduct(IProduct product)
        {
            if (product.Size + this.usedCapacity > this.capacity
                && this.successor != null)
            {
                return this.successor.AddProduct(product);
            }

            this.usedCapacity += product.Size;
            this.products.Add(product);

            return this;
        }
    }
}