namespace CS_OOP_Advanced_Exam_Prep_July_2016.Framework.Parser
{
    using System.Collections.Generic;
    using Strategies;

    public class AttributeParser : IParser
    {
        public void Parse<TKey, TValue>(IAttributeParserStrategy<TKey, TValue> strategy, IDictionary<TKey, TValue> result)
        {
            strategy.Parse(result);
        }
    }
}