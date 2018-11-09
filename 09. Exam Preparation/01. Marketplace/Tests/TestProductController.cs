namespace Tests
{
    using CS_OOP_Advanced_Exam_Prep_July_2016.Constants;
    using CS_OOP_Advanced_Exam_Prep_July_2016.Controllers;
    using CS_OOP_Advanced_Exam_Prep_July_2016.Models.Products;
    using CS_OOP_Advanced_Exam_Prep_July_2016.Providers.Data;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class TestProductController
    {
        private ProductController productController;
        private Mock<IDataProvider> dbMoq;

        [SetUp]
        public void SetUp()
        {
            this.dbMoq = new Mock<IDataProvider>();
            this.productController = new ProductController(this.dbMoq.Object);
        }

        [Test]
        public void TestEdit_NoProductReturned_ShouldReturnNoProductMessage()
        {
            this.dbMoq.Setup(b => b.EditProduct(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()))
                .Returns(() => null);

            var result = this.productController.EditProduct(6, "Pesho", 32);

            Assert.That(result, Is.EqualTo(string.Format(Messages.ProductNotFound, 6)));
        }

        [Test]
        public void TestEdit_ProductReturned_ShouldReturnProductEditedSuccessMessage()
        {
            this.dbMoq.Setup(b => b.EditProduct(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()))
                .Returns(() => new BigProduct(6, "Pesho", 88));

            var result = this.productController.EditProduct(6, "Pesho", 44);

            Assert.That(result, Is.EqualTo(string.Format(Messages.ProductEditedSuccessfully, 6)));
        }
    }
}