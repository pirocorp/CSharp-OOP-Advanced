namespace CS_OOP_Advanced_Exam_Prep_July_2016.Providers.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Constants;
    using Framework.Lifecycle.Component;
    using Framework.Lifecycle.Order;
    using Models.Products;
    using Models.Shops;
    using TypeProvider;

    [Component]
    public class MarketDataProvider : IDataProvider
    {
        private readonly IDictionary<int, IProduct> productsById;
        private readonly IDictionary<int, IDictionary<string, IDictionary<string, ISet<IProduct>>>> productsBySizeNameType;
        private readonly IDictionary<int, IDictionary<string, ISet<IProduct>>> productsBySizeName;
        private readonly IDictionary<string, IShop> shops;
        [Inject]
        private readonly ITypeProvider typeProvider;

        public MarketDataProvider()
        {
            this.productsById = new Dictionary<int, IProduct>();
            this.productsBySizeNameType = new Dictionary<int, IDictionary<string, IDictionary<string, ISet<IProduct>>>>();
            this.productsBySizeName = new Dictionary<int, IDictionary<string, ISet<IProduct>>>();
            this.shops = new Dictionary<string, IShop>();
        }

        public MarketDataProvider(IDictionary<string, IShop> shops, ITypeProvider typeProvider)
            :this()
        {
            this.shops = shops;
            this.typeProvider = typeProvider;
        }

        public IProduct AddProduct(int size, string name, string type)
        {
            var currentProductType = this.typeProvider.GetSubClasses(typeof(IProduct)).FirstOrDefault(c => c.Name == type);
            var productId = this.productsById.Count + 1;
            var product = (IProduct) Activator.CreateInstance(currentProductType, productId, name, size);

            this.productsById[productId] = product;
            this.AddProductToNestedStructures(type, product);

            return product;
        }

        public IEnumerable<IProduct> GetProductsBySizeNameType(int size, string name, string type)
        {
            if (this.productsBySizeNameType.ContainsKey(size) &&
                this.productsBySizeNameType[size].ContainsKey(name) &&
                this.productsBySizeNameType[size][name].ContainsKey(type))
            {
                return this.productsBySizeNameType[size][name][type];
            }

            return null;
        }

        public IEnumerable<IProduct> GetProductsBySizeName(int size, string name)
        {
            if (this.productsBySizeName.ContainsKey(size) &&
                this.productsBySizeName[size].ContainsKey(name))
            {
                return this.productsBySizeName[size][name];
            }

            return null;
        }

        public IProduct GetProductById(int id)
        {
            this.productsById.TryGetValue(id, out var result);

            return result;
        }

        public IProduct EditProduct(int id, int newSize, string newName)
        {
            var currentProduct = this.GetProductById(id);

            if (currentProduct == null)
            {
                return null;
            }

            this.productsBySizeName[currentProduct.Size][currentProduct.Name].Remove(currentProduct);
            this.productsBySizeNameType[currentProduct.Size][currentProduct.Name][currentProduct.GetType().Name].Remove(currentProduct);

            currentProduct.Size = newSize;
            currentProduct.Name = newName;

            this.AddProductToNestedStructures(currentProduct.GetType().Name, currentProduct);

            return currentProduct;
        }

        public IShop AddProductToShop(string shopType, int productId)
        {
            var product = this.GetProductById(productId);

            if (product == null)
            {
                return null;
            }

            if (product.Shop != null)
            {
                throw new InvalidOperationException(string.Format(Messages.ProductAlreadyInShop, productId, product.Shop.GetType().Name));
            }

            var shop = this.shops[shopType];
            product.Shop = shop;

            return shop.AddProduct(product);
        }

        public IEnumerable<IProduct> GetProductsByShop(string shopType)
        {
            return this.shops[shopType].Products;
        }

        private void Initialize()
        {
            var shopTypes = this.typeProvider.GetClassesByAttribute(typeof(OrderAttribute))
                .Where(c => typeof(IShop).IsAssignableFrom(c))
                .OrderBy(c => c.GetCustomAttribute<OrderAttribute>().Order);

            IShop successor = null;

            foreach (var shopType in shopTypes)
            {
                var shop = (IShop) Activator.CreateInstance(shopType, successor);
                this.shops.Add(shopType.Name, shop);
                successor = shop;
            }
        }

        private void AddProductToNestedStructures(string type, IProduct product)
        {
            if (!this.productsBySizeName.ContainsKey(product.Size))
            {
                this.productsBySizeName[product.Size] = new Dictionary<string, ISet<IProduct>>();
                this.productsBySizeNameType[product.Size] = new Dictionary<string, IDictionary<string, ISet<IProduct>>>();
            }

            if (!this.productsBySizeName[product.Size].ContainsKey(product.Name))
            {
                this.productsBySizeName[product.Size][product.Name] = new HashSet<IProduct>();
                this.productsBySizeNameType[product.Size][product.Name] = new Dictionary<string, ISet<IProduct>>();
            }

            if (!this.productsBySizeNameType[product.Size][product.Name].ContainsKey(type))
            {
                this.productsBySizeNameType[product.Size][product.Name][type] = new HashSet<IProduct>();
            }

            this.productsBySizeName[product.Size][product.Name].Add(product);
            this.productsBySizeNameType[product.Size][product.Name][type].Add(product);
        }
    }
}