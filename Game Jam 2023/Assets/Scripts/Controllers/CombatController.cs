using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CombatController : MonoBehaviour
{
    public List<CombatUnit> LivingUnits { get; protected set; }

    public abstract void DoMove(GameObject actingUnit, GameObject receivingUnit, CombatUnit.MoveType move);

    public bool UnitsAlive()
    {
        //LivingUnits[0].Moves[0];
        //if (CombatUnit.TargetType.Friendly.Equals(LivingUnits[0].Moves[0]))
        return LivingUnits.Count > 0;
    }

    public abstract void Initialize(List<CombatUnit> units);

}
