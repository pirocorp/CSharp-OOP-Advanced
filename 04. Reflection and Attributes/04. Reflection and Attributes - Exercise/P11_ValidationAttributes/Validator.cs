namespace ValidationAttributes
{
    using System.Linq;
    using System.Reflection;

    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            var objType = obj.GetType();
            var propertyInfos = objType.GetProperties();
             
            foreach (var propertyInfo in propertyInfos)
            {
                var allMyAttributes = propertyInfo.GetCustomAttributes<MyValidationAttribute>().ToList();

                var propertyObj = propertyInfo.GetValue(obj);

                foreach (var myValidationAttribute in allMyAttributes)
                {
                    var isValid = myValidationAttribute.IsValid(propertyObj);

                    if (!isValid)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
