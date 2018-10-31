namespace P05_MirrorImage
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var wizardData = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            var wizardName = wizardData[0];
            var wizardDamage = int.Parse(wizardData[1]);

            var wizard = new Wizard(wizardName, wizardDamage);

            string inputLine;

            while ((inputLine = Console.ReadLine()) != "END")
            {
                var tokens = inputLine.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                var id = int.Parse(tokens[0]);
                var spell = tokens[1];

                switch (spell)
                {
                    case "FIREBALL":
                        Console.WriteLine(wizard.Fireball(id));
                        ;
                        break;
                    case "REFLECTION":
                        Console.WriteLine(wizard.Reflection(id));
                        ;
                        break;
                }
            }

            //var wizard = new Wizard("Oz", 12);
            //wizard.LeftWizard = new Wizard(wizard.Name, wizard.MagicalPower, 1);
            //wizard.RightWizard = new Wizard(wizard.Name, wizard.MagicalPower, 2);
            //wizard.LeftWizard.LeftWizard = new Wizard(wizard.Name, wizard.MagicalPower, 3);
            //wizard.LeftWizard.RightWizard = new Wizard(wizard.Name, wizard.MagicalPower, 4);
            //wizard.RightWizard.LeftWizard = new Wizard(wizard.Name, wizard.MagicalPower, 5);
            //wizard.RightWizard.RightWizard = new Wizard(wizard.Name, wizard.MagicalPower, 6);
            //wizard.LeftWizard.LeftWizard.LeftWizard = new Wizard(wizard.Name, wizard.MagicalPower, 7);
            //wizard.LeftWizard.LeftWizard.RightWizard = new Wizard(wizard.Name, wizard.MagicalPower, 8);
            //wizard.LeftWizard.RightWizard.LeftWizard = new Wizard(wizard.Name, wizard.MagicalPower, 9);
            //wizard.LeftWizard.RightWizard.RightWizard = new Wizard(wizard.Name, wizard.MagicalPower, 10);
            //wizard.RightWizard.LeftWizard.LeftWizard = new Wizard(wizard.Name, wizard.MagicalPower, 11);
            //wizard.RightWizard.LeftWizard.RightWizard = new Wizard(wizard.Name, wizard.MagicalPower, 12);
            //wizard.RightWizard.RightWizard.LeftWizard = new Wizard(wizard.Name, wizard.MagicalPower, 13);
            //wizard.RightWizard.RightWizard.RightWizard = new Wizard(wizard.Name, wizard.MagicalPower, 14);
            //wizard.Reflection(0);
            //wizard.Reflection(0);
            //Console.WriteLine(wizard.Fireball(0));
        }
    }
}
