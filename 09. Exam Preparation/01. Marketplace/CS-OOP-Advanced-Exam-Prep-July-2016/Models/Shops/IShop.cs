namespace CS_OOP_Advanced_Exam_Prep_July_2016.Models.Shops
{
    using System.Collections.Generic;
    using Products;

    public interface IShop
    {
        IEnumerable<IProduct> Products { get; }

        IShop AddProduct(IProduct product);
    }
}
