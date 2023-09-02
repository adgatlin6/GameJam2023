using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKing : CombatUnit
{
    private void Awake()
    {
        MinDamage = 5;
        MaxDamage = 10;
        MinHealing = 10;
        MaxHealing = 15;
        MaxHealth = 1;
        CurrentHealth = MaxHealth;
        Moves = new List<MoveType>() { MoveType.Attack, MoveType.SommonUnit, MoveType.Heal};
        Team = CombatTeam.Player;
    }
}
