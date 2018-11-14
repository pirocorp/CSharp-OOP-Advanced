using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class GameController : IGameController
{
    private const string COMMAND_PREFIX = "Parse";
    private const string COMMAND_SUFFIX = "Command";
    private const string REGENERATE_COMMAND = "Regenerate";
    private const string RESULT_OUTPUT = "Results:";
    private const string SOLDIERS_OUTPUT = "Soldiers:";

    private readonly MissionController missionController;
    private readonly SoldierFactory soldiersFactory;
    private readonly MissionFactory missionFactory;
    private readonly IWriter writer;
    private readonly IWareHouse wareHouse;
    private readonly IArmy army;

    public GameController(IWriter writer)
    {
        this.wareHouse = new WareHouse();
        this.writer = writer;
        this.army = new Army();
        this.missionController = new MissionController(this.army, this.wareHouse);
        this.soldiersFactory = new SoldierFactory();
        this.missionFactory = new MissionFactory();
    }

    public void ProcessCommand(string input)
    {
        var data = input.Split().ToList();
        var commandType = data[0];
        data.RemoveAt(0);

        var commandFullName = COMMAND_PREFIX + commandType + COMMAND_SUFFIX;

        try
        {
            this.GetType()
                .GetMethod(commandFullName, BindingFlags.NonPublic | BindingFlags.Instance)
                ?.Invoke(this, new object[] { data });
        }
        catch (TargetInvocationException tie)
        {
            throw tie.InnerException;
        }
    }

    private void ParseWareHouseCommand(IList<string> data)
    {
        var name = data[0];
        var quantity = int.Parse(data[1]);
        this.wareHouse.AddAmmunitions(name, quantity);
    }

    private void ParseSoldierCommand(IList<string> data)
    {
        if (data[0] == REGENERATE_COMMAND)
        {
            this.army.RegenerateTeam(data[1]);
        }
        else
        {
            this.AddSoldierToArmy(data);
        }
    }

    private void AddSoldierToArmy(IList<string> data)
    {
        var type = data[0];
        var name = data[1];
        var age = int.Parse(data[2]);
        var experience = double.Parse(data[3]);
        var endurance = double.Parse(data[4]);

        var soldier = this.soldiersFactory.CreateSoldier(type, name, age, experience, endurance);

        if (!this.wareHouse.TryEquipSoldier(soldier))
        {
            throw new ArgumentException(string.Format(OutputMessages.NoWeaponsForSoldierType, type, name));
        }

        this.army.AddSoldier(soldier);
    }

    private void ParseMissionCommand(IList<string> data)
    {
        var difficultyLevel = data[0];
        var scoreToComplete = double.Parse(data[1]);
        var mission = this.missionFactory.CreateMission(difficultyLevel, scoreToComplete);

        this.writer.StoreMessage(this.missionController.PerformMission(mission));
    }

    public void ProduceSummary()
    {
        var orderedArmy = this.army.Soldiers.OrderByDescending(s => s.OverallSkill).ToList();
        this.missionController.FailMissionsOnHold();

        this.writer.StoreMessage(RESULT_OUTPUT);
        this.writer.StoreMessage(string.Format(OutputMessages.MissionsSummarySuccessful, this.missionController.SuccessMissionCounter));
        this.writer.StoreMessage(string.Format(OutputMessages.MissionsSummaryFailed, this.missionController.FailedMissionCounter));
        this.writer.StoreMessage(SOLDIERS_OUTPUT);

        foreach (var soldier in orderedArmy)
        {
            this.writer.StoreMessage(soldier.ToString());
        }
    }
}