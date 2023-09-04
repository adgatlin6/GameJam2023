using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnUnit : CombatUnit
{
    public bool PlayerTeam;
    private void Awake()
    {
        Moves = new List<MoveType>();
        MinDamage = 1;
        MaxDamage = 5;
        MaxHealth = 15;
        Defense = 5;
        CurrentHealth = MaxHealth;
        Moves = new List<CombatUnit.MoveType> { MoveType.Attack, MoveType.Defend };
        if (PlayerTeam)
        {
            Team = CombatTeam.Player;
        }
        else
        {
            Team = CombatTeam.Enemy;
        }
    }

}
