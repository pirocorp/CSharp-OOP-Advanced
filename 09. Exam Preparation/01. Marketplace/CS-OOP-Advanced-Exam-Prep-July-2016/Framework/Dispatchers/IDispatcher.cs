namespace CS_OOP_Advanced_Exam_Prep_July_2016.Framework.Dispatchers
{
    using Lifecycle.Request;

    public interface IDispatcher
    {
        string Dispatch(RequestMethod requestMethod, string uri);
    }
}
