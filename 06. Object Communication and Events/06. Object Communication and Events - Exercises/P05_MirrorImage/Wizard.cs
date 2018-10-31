namespace P05_MirrorImage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Wizard
    {
        private Wizard leftWizard;
        private Wizard rightWizard;

        public Wizard(string name, int magicalPower, int currentIndex = 0)
        {
            this.Id = currentIndex;
            this.Name = name;
            this.MagicalPower = magicalPower;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public int MagicalPower { get; private set; }

        public Wizard LeftWizard
        {
            get => this.leftWizard;
            set => this.leftWizard = value;
        }

        public Wizard RightWizard
        {
            get => this.rightWizard;
            set => this.rightWizard = value;
        }

        public string Reflection(int wizardId)
        {
            var sb = new StringBuilder();

            var rootWizard = this.FindWizardById(wizardId, this);

            var wizardsToCastSpell = this.IteratorWizard(rootWizard).Where(x => x.LeftWizard == null).ToArray();

            var maxId = wizardsToCastSpell.OrderByDescending(x => x.Id).First().Id;

            foreach (var wizard in wizardsToCastSpell)
            {
                wizard.ProduceReflection(maxId);
                sb.AppendLine($"{wizard.Name} {wizard.Id} casts Reflection");
                maxId += 2;
            }

            return sb.ToString().Trim();
        }

        public string Fireball(int wizardId)
        {
            var result = new StringBuilder();

            var rootWizard = this.FindWizardById(wizardId, this);

            var wizardsToCastSpell = this.IteratorWizard(rootWizard).ToArray();

            foreach (var wizard in wizardsToCastSpell)
            {
                result.AppendLine(wizard.ProduceFireball());
            }

            return result.ToString().Trim();
        }

        public override string ToString()
        {
            return $"{this.Id} {this.Name} - {this.MagicalPower}";
        }

        private void ProduceReflection(int maxId)
        {
            if (this.LeftWizard == null)
            {
                var newMagicalPower = this.MagicalPower / 2;
                var newId = maxId + 1;

                this.LeftWizard = new Wizard(this.Name, newMagicalPower, newId);
            }

            if (this.RightWizard == null)
            {
                var newMagicalPower = this.MagicalPower / 2;
                var newId = maxId + 2;

                this.RightWizard = new Wizard(this.Name, newMagicalPower, newId);
            }
        }

        private string ProduceFireball()
        {
            return $"{this.Name} {this.Id} casts Fireball for {this.MagicalPower} damage";
        }

        private IEnumerable<Wizard> IteratorWizard(Wizard rootWizard)
        {
            yield return rootWizard;

            var currentLeftRoot = rootWizard.leftWizard;

            if (currentLeftRoot != null)
            {
                var result = this.IteratorWizard(currentLeftRoot).ToArray();

                foreach (var wizard in result)
                {
                    yield return wizard;
                }
            }

            var currentRightRoot = rootWizard.RightWizard;

            if (currentRightRoot != null)
            {
                var result = this.IteratorWizard(currentRightRoot).ToArray();

                foreach (var wizard in result)
                {
                    yield return wizard;
                }
            }
        }

        private Wizard FindWizardById(int id, Wizard wizard)
        {
            if (wizard == null)
            {
                return null;
            }
            else
            {
                if (wizard.Id == id)
                {
                    return wizard;
                }

                if (wizard.LeftWizard != null && wizard.LeftWizard.Id == id)
                {
                    return wizard.LeftWizard;
                }

                if (wizard.RightWizard != null && wizard.RightWizard.Id == id)
                {
                    return wizard.RightWizard;
                }

                var result = this.FindWizardById(id, wizard.LeftWizard);

                if (result != null)
                {
                    return result;
                }
                else
                {
                     return this.FindWizardById(id, wizard.RightWizard);
                }
            }
        }
    }
}