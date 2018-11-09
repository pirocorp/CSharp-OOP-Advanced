namespace CS_OOP_Advanced_Exam_Prep_July_2016.Models.Shops
{
    using Framework.Lifecycle.Order;

    [Order(3)]
    public class Store : Shop
    {
        private const int CAPACITY = 15;

        public Store(IShop successor) 
            : base(successor, CAPACITY)
        {
        }
    }
}