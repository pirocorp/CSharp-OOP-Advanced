namespace Easter.Models.Workshops
{
    using System.Linq;
    using Bunnies.Contracts;
    using Contracts;
    using Eggs.Contracts;

    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            while (bunny.Energy > 0 
                   && bunny.Dyes.Any(d => !d.IsFinished()) 
                   && !egg.IsDone())
            {
                var dye = bunny.Dyes.FirstOrDefault(d => !d.IsFinished());

                dye.Use();
                bunny.Work();
                egg.GetColored();
            }
        }
    }
}
