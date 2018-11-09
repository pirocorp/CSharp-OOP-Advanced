namespace CS_OOP_Advanced_Exam_Prep_July_2016.Models.Products
{
    using Constants;
    using Shops;

    public abstract class Product : IProduct
    {
        private readonly int id;
        private string name;
        private int size;
        private IShop shop;

        protected Product(int id, string name, int size)
        {
            this.id = id;
            this.Name = name;
            this.Size = size;
            this.Shop = null;
        }

        public int Id => this.id;

        public string Name
        {
            get => this.name;
            set => this.name = value;
        }

        public virtual int Size
        {
            get => this.size;
            set => this.size = value;
        }

        public IShop Shop
        {
            get => this.shop;
            set => this.shop = value;
        }

        public override int GetHashCode()
        {
            return this.Id;
        }

        public override string ToString()
        {
            return string.Format(Messages.ProductToString, this.GetType().Name, this.Id, this.Size, this.Name);
        }
    }
}