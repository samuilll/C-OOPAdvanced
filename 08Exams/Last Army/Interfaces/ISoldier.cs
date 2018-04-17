using System.Collections.Generic;

public interface ISoldier
{
    string Name { get; }

    int Age { get; }

    double Experience { get; }

    double Endurance { get; }

    double OverallSkill { get; }

    IDictionary<string, IAmmunition> Weapons { get; }

     IReadOnlyList<string> WeaponsAllowed { get; }

    void Regenerate();

    bool ReadyForMission(IMission mission);

    void CompleteMission(IMission mission);

    bool GetWeapon(IAmmunition weapon);
}