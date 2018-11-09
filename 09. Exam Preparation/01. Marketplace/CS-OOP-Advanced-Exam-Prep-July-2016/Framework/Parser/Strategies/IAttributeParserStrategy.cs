namespace CS_OOP_Advanced_Exam_Prep_July_2016.Framework.Parser.Strategies
{
    using System.Collections.Generic;

    public interface IAttributeParserStrategy<TKey, TValue>
    {
        void Parse(IDictionary<TKey, TValue> result);
    }
}