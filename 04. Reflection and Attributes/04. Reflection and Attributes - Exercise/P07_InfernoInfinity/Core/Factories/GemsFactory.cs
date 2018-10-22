namespace P07_InfernoInfinity.Core.Factories
{
    using System;
    using Interfaces;
    using Models.Gems.GemMutators;

    public class GemsFactory : Factory<IGem>
    {
        public override IGem Create(params string[] inputParameters)
        {
            var tokens = inputParameters[0].Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            var gemType = tokens[1];

            var qualityLevelString = tokens[0];
            var qualityLevel = Enum.Parse<QualityLevel>(qualityLevelString);

            return base.Create(gemType, new object[]{ qualityLevel });
        }
    }
}