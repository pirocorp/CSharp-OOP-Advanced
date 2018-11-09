namespace Tests
{
    using CS_OOP_Advanced_Exam_Prep_July_2016.Models.Products;
    using NUnit.Framework;

    [TestFixture]
    public class TestProductModel
    {
        [Test]
        public void TestBigProductChangeSize_ValidSize_ExpectedChangedSuccessfully()
        {
            var product = new BigProduct(1, "pesho", 33);
            product.Size = 66;

            Assert.That(product.Size, Is.EqualTo(132));
        }

        [Test]
        public void TestSmallProductChangeSize_ValidSize_ExpectedChangedSuccessfully()
        {
            var product = new SmallProduct(1, "pesho", 11);
            product.Size = 66;

            Assert.That(product.Size, Is.EqualTo(33));
        }

        [Test]
        public void TestBigProductChangeName_ValidName_ExpectedChangedSuccessfully()
        {
            var product = new BigProduct(1, "pesho", 33);
            product.Name = "Gosho";

            Assert.That(product.Name, Is.EqualTo("Gosho"));
        }

        [Test]
        public void TestSmallProductChangeName_ValidName_ExpectedChangedSuccessfully()
        {
            var product = new SmallProduct(1, "pesho", 33);
            product.Name = "Gosho";

            Assert.That(product.Name, Is.EqualTo("Gosho"));
        }
    }
}