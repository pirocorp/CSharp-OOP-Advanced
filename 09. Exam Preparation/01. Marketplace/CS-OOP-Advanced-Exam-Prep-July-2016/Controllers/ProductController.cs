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
    public class ProductController
    {
        [Inject]
        private IDataProvider dataProvider;

        public ProductController()
        {
            
        }

        public ProductController(IDataProvider dataProvider)
            :this()
        {
            this.dataProvider = dataProvider;
        }

        [RequestMapping(value:"/product/{size}/{name}/{type}", method: RequestMethod.ADD)]
        public string AddProduct(
            [UriParameter("size")]int size,
            [UriParameter("name")]string name,
            [UriParameter("type")]string type)
        {
            var product = this.dataProvider.AddProduct(size, name, type);

            return string.Format(Messages.ProductRegisteredSuccessfully, product.Id);
        }

        [RequestMapping(value: "/product/{size}/{name}/{type}", method: RequestMethod.GET)]
        public string GetProductBySizeNameType(
            [UriParameter("size")]int size,
            [UriParameter("name")]string name,
            [UriParameter("type")]string type)
        {
            var resultCollection = this.dataProvider.GetProductsBySizeNameType(size, name, type);

            if (resultCollection == null)
            {
                return Messages.ProductsNotFound;
            }

            return string.Join(Environment.NewLine, resultCollection);
        }

        [RequestMapping(value: "/product/{size}/{name}", method: RequestMethod.GET)]
        public string GetProductBySizeName(
            [UriParameter("size")]int size,
            [UriParameter("name")]string name)
        {
            var resultCollection = this.dataProvider.GetProductsBySizeName(size, name);

            if (resultCollection == null)
            {
                return Messages.ProductsNotFound;
            }

            return string.Join(Environment.NewLine, resultCollection);
        }

        [RequestMapping(value: "/product/{id}", method: RequestMethod.GET)]
        public string GetProductById(
            [UriParameter("id")]int id)
        {
            var result = this.dataProvider.GetProductById(id);

            if (result == null)
            {
                return string.Format(Messages.ProductNotFound, id);
            }

            return result.ToString();
        }

        [RequestMapping(value: "/product/{id}/{newName}/{newSize}", method: RequestMethod.EDIT)]
        public string EditProduct([UriParameter("id")] int id,
            [UriParameter("newName")] string newName,
            [UriParameter("newSize")] int newSize)
        {
            var product = this.dataProvider.EditProduct(id, newSize, newName);

            if (product == null)
            {
                return string.Format(Messages.ProductNotFound, id);
            }

            return string.Format(Messages.ProductEditedSuccessfully, id);
        }
    }
}