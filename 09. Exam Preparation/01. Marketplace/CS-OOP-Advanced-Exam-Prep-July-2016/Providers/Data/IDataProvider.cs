namespace CS_OOP_Advanced_Exam_Prep_July_2016.Providers.Data
{
    using System.Collections.Generic;
    using Models.Products;
    using Models.Shops;

    public interface IDataProvider
    {
        IProduct AddProduct(int size, string name, string type);

        IEnumerable<IProduct> GetProductsBySizeNameType(int size, string name, string type);

        IEnumerable<IProduct> GetProductsBySizeName(int size, string name);

        IProduct GetProductById(int id);

        IProduct EditProduct(int id, int newSize, string newName);

        IShop AddProductToShop(string shopType, int productId);

        IEnumerable<IProduct> GetProductsByShop(string shopType);
    }
}
