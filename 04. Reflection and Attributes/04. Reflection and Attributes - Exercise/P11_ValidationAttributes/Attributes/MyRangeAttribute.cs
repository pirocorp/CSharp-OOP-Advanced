namespace ValidationAttributes.Attributes
{
    using System;

    public class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;
        private int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            var intObj = Convert.ToInt32(obj);

            if (intObj >= this.minValue && intObj <= this.maxValue)
            {
                return true;
            }

            return false;
        }
    }
}
