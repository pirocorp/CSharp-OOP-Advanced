namespace Tests
{
    using CS_OOP_Advanced_Exam_Prep_July_2016.Providers.Data;
    using NUnit.Framework;

    [TestFixture]
    public class TestDatabase
    {
        private IDataProvider dataProvider;

        [SetUp]
        public void SetUp()
        {
            this.dataProvider = DatabaseUtils.CreateDataProvider();
        }

        [Test]
        public void TestEditBigProduct_ValidSize_ChangeSuccessfully()
        {
            this.dataProvider.AddProduct(25, "pesho", "BigProduct");
            var product = this.dataProvider.EditProduct(1, 44, "pesho");

            Assert.That(product.Size, Is.EqualTo(88));
        }

        [Test]
        public void TestEditSmallProduct_ValidSize_ChangeSuccessfully()
        {
            this.dataProvider.AddProduct(25, "pesho", "SmallProduct");
            var product = this.dataProvider.EditProduct(1, 44, "pesho");

            Assert.That(product.Size, Is.EqualTo(22));
        }

        [Test]
        public void TestEditBigProduct_ValidName_ChangeSuccessfully()
        {
            this.dataProvider.AddProduct(25, "pesho", "BigProduct");
            var product = this.dataProvider.EditProduct(1, 25, "gosho");

            Assert.That(product.Name, Is.EqualTo($"gosho"));
        }

        [Test]
        public void TestEditSmallProduct_ValidName_ChangeSuccessfully()
        {
            this.dataProvider.AddProduct(25, "pesho", "SmallProduct");
            var product = this.dataProvider.EditProduct(1, 25, "gosho");

            Assert.That(product.Name, Is.EqualTo($"gosho"));
        }

        [Test]
        public void TestEditProduct_ValidData_IdNotChanged()
        {
            var oldProduct = this.dataProvider.AddProduct(25, "pesho", "SmallProduct");
            var product = this.dataProvider.EditProduct(1, 25, "gosho");

            Assert.That(product.Id, Is.EqualTo(oldProduct.Id));
        }

        [Test]
        public void TestEditProduct_ValidData_SameReferences()
        {
            var oldProduct = this.dataProvider.AddProduct(25, "pesho", "SmallProduct");
            var product = this.dataProvider.EditProduct(1, 25, "gosho");

            Assert.That(product, Is.SameAs(oldProduct));
        }

        [Test]
        public void TestEditProduct_InvalidId_Null()
        {
            var product = this.dataProvider.EditProduct(1, 25, "gosho");

            Assert.That(product, Is.Null);
        }
    }
}