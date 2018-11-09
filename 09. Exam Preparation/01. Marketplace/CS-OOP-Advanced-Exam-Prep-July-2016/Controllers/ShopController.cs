namespace CS_OOP_Advanced_Exam_Prep_July_2016.Controllers
{
    using System;
    using Constants;
    using Framework.Lifecycle;
    using Framework.Lifecycle.Component;
    using Framework.Lifecycle.Controller;
    using Framework.Lifecycle.Request;
    using Providers.Data;

    [Controller]
    public class ShopController
    {
        [Inject]
        private IDataProvider dataProvider;

        [RequestMapping(value: "/shop/{type}/{productId}", method: RequestMethod.ADD)]
        public string AddProduct(
            [UriParameter("type")]string type,
            [UriParameter("productId")]int productId)
        {
            try
            {
                var result = this.dataProvider.AddProductToShop(type, productId);

                if (result == null)
                {
                    return string.Format(Messages.ProductNotFound, productId);
                }

                return string.Format(Messages.ProductMovedSuccessfully, productId, result.GetType().Name);
            }
            catch (InvalidOperationException ioe)
            {
                return ioe.Message;
            }
        }

        [RequestMapping(value: "/shop/{type}", method: RequestMethod.GET)]
        public string GetProducts(
            [UriParameter("type")] string shopType)
        {
            var products = this.dataProvider.GetProductsByShop(shopType);

            var result = string.Join(Environment.NewLine, products);

            if (string.IsNullOrWhiteSpace(result.Trim()))
            {
                return Messages.ProductsNotFound;
            }

            return result;
        }
    }
}