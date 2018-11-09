namespace CS_OOP_Advanced_Exam_Prep_July_2016.Models.Products
{
    public class SmallProduct : Product
    {
        private const double SIZE_MODIFIER = 0.5;

        public SmallProduct(int id, string name, int size) 
            : base(id, name, size)
        {
        }

        public override int Size
        {
            get => base.Size;
            set => base.Size = (int)(SIZE_MODIFIER * value);
        }
    }
}