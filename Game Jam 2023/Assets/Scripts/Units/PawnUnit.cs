using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnUnit : CombatUnit
{
    private void Awake()
    {
        Moves = new List<MoveType>();
        Moves.Add(MoveType.Attack);
    }

}
