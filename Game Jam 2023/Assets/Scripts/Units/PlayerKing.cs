using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKing : CombatUnit
    //New unit type must inheret from CombatUnit
{
    private void Awake()
    {
        /*This the template that all new unit types will need to follow. PawnUnit.cs is another example to reference.
         * Declare stats - MinDamage, MaxDamage, MaxHealth etc.
         * Declare the Moves availabel to the unit as below, using whatever moves you want
         * Team should only be declared if this unit type is ONLY available to player or enemies, like the King
         * If you decide to make a unit that could be either player or enemy, the team will have to be set from somewhere else. (It may be easier to have a PlayerPawn and EnemyPawn class, for example)
         * */

        MinDamage = 5;
        MaxDamage = 10;
        MinHealing = 10;
        MaxHealing = 15;
        MaxHealth = 50;
        CurrentHealth = MaxHealth;
        Defense = 10;
        Moves = new List<MoveType>() { MoveType.Attack, /* Remove SommonUnit if not implemented */MoveType.SommonUnit, MoveType.Heal, MoveType.Defend };
        Team = CombatTeam.Player;
    }
}
