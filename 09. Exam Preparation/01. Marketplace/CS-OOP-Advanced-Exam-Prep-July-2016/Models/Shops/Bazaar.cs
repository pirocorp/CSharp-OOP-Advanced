namespace CS_OOP_Advanced_Exam_Prep_July_2016.Models.Shops
{
    using Framework.Lifecycle.Order;

    [Order(2)]
    public class Bazaar : Shop
    {
        private const int CAPACITY = 30;

        public Bazaar(IShop successor) 
            : base(successor, CAPACITY)
        {
        }
    }
}