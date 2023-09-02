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
        MaxHealth = 1;
        CurrentHealth = MaxHealth;
        Moves.Add(MoveType.Attack);
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
