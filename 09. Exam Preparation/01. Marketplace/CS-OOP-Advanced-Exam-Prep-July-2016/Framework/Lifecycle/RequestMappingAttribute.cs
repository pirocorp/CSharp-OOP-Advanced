namespace CS_OOP_Advanced_Exam_Prep_July_2016.Framework.Lifecycle
{
    using System;
    using Request;

    public class RequestMappingAttribute : Attribute
    {
        private readonly string value;

        private readonly RequestMethod method;

        public RequestMappingAttribute(string value, RequestMethod method = RequestMethod.ADD)
        {
            this.value = value;
            this.method = method;
        }

        public string Value => this.value;

        public RequestMethod Method => this.method;
    }
}
