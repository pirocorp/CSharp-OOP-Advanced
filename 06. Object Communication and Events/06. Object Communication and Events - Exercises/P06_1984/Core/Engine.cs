namespace P06_1984.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Factories;
    using Interfaces;
    using IO;

    public class Engine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IEntityFactory entityFactory;
        private readonly IInstitutionsFactory institutionsFactory;

        private readonly Dictionary<int, IEntity> entities;
        private readonly Dictionary<int, IInstitution> institutions;

        public Engine()
            :this(new ConsoleReader(), new ConsoleWriter(), new EntityFactory(), new InstitutionsFactory())
        {
            
        }

        public Engine(IReader reader, IWriter writer, IEntityFactory entityFactory, IInstitutionsFactory institutionsFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.entityFactory = entityFactory;
            this.institutionsFactory = institutionsFactory;

            this.entities = new Dictionary<int, IEntity>();
            this.institutions = new Dictionary<int, IInstitution>();
        }

        public void Run()
        {
            var inputParams = this.reader.ReadLine()
                .Split(new []{" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var entitiesCount = inputParams[0];
            var institutionsCount = inputParams[1];
            var changesCount = inputParams[2];

            this.InitializeEntities(entitiesCount);
            this.InitializeInstitutions(institutionsCount);
            this.MakeChanges(changesCount);
            this.ReportChanges();
        }

        private void ReportChanges()
        {
            foreach (var institution in this.institutions)
            {
                this.writer.WriteLine(institution.Value.ReportChanges());
            }
        }

        private void MakeChanges(int changesCount)
        {
            for (var i = 0; i < changesCount; i++)
            {
                var inputData = this.reader.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

                var entityId = int.Parse(inputData[0]);
                var entity = this.entities[entityId];

                var entityPropAsString = inputData[1];
                var entityProp = entity
                    .GetType()
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public)
                    .FirstOrDefault(x => x.Name.ToLower() == entityPropAsString);

                var newValue = inputData[2];
                if (entityProp != null)
                {
                    if (entityPropAsString.ToLower() == "name")
                    {
                        entityProp.SetValue(entity, newValue);

                    }
                    else
                    {
                        entityProp.SetValue(entity, int.Parse(newValue));
                    }
                }
            }
        }

        private void InitializeInstitutions(int institutionsCount)
        {
            for (var i = 0; i < institutionsCount; i++)
            {
                var institutionData = this.reader.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                var currentInstitution = this.institutionsFactory.CreateInstitution(institutionData);

                var institutionInterests = institutionData.Skip(3).ToArray();

                foreach (var interest in institutionInterests)
                {
                    foreach (var entity in this.entities.Values)
                    {
                        var entityProp = entity.GetType()
                            .GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public)
                            .FirstOrDefault(x => x.Name.ToLower() == interest);

                        if (entityProp != null)
                        {
                            currentInstitution.RegisterInterest(interest, entity);
                        }
                    }
                }

                this.institutions.Add(currentInstitution.Id, currentInstitution);
            }
        }

        private void InitializeEntities(int entitiesCount)
        {
            for (var i = 0; i < entitiesCount; i++)
            {
                var entityData = this.reader.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
                var entity = this.entityFactory.CreateEntity(entityData);
                this.entities.Add(entity.Id, entity);
            }
        }
    }
}