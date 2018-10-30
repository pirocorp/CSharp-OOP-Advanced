namespace P02_KingsGambit.Core
{
    using System;
    using System.Collections.Generic;
    using Factories;
    using Interfaces;
    using IO;
    using Models;

    public class Initializer
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IUnitFactory unitFactory;
        private readonly IDictionary<string, IUnit> military;
        private IKing king;

        public Initializer(IDictionary<string, IUnit> military)
            :this(new ConsoleReader(), new ConsoleWriter(), new UnitFactory(), military)
        {

        }

        public Initializer(IReader reader, IWriter writer, IUnitFactory unitFactory, IDictionary<string, IUnit> military)
        {
            this.reader = reader;
            this.writer = writer;
            this.unitFactory = unitFactory;
            this.military = military;
        }

        public IKing Initialize()
        {
            var nameOfKing = this.reader.ReadLine();
            this.king = new King(this.writer, nameOfKing);

            this.Initialize("RoyalGuard");
            this.Initialize("Footman");

            return this.king;
        }

        private void Initialize(string unitType)
        {
            var unitNames = this.reader.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            
            foreach (var name in unitNames)
            {
                var currentUnit = this.unitFactory.CreateUnit(unitType, name);

                this.king.KingUnderAttack += currentUnit.RespondToAttack;

                this.military.Add(name, currentUnit);
            }
        }
    }
}