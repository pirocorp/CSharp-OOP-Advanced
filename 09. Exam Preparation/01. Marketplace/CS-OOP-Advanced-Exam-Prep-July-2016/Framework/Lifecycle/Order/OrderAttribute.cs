namespace CS_OOP_Advanced_Exam_Prep_July_2016.Framework.Lifecycle.Order
{
    using System;

    public class OrderAttribute : Attribute
    {
        public OrderAttribute(long order)
        {
            this.Order = order;
        }

        public long Order { get; set; }
    }
}