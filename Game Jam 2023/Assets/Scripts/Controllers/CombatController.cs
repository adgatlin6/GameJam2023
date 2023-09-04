using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CombatController : MonoBehaviour
{
    public List<CombatUnit> LivingUnits { get; protected set; }

    public abstract void DoMove(GameObject actingUnit, GameObject receivingUnit, CombatUnit.MoveType move);

    /*This class should be used to manage each team's units. 
     * There should be two subclasses made from this. PlayerCombatController and EnemyCombatController
     * They will serve similar functions but will be distinct. Both will manage selecting units to bring into battle
     * However, the EnemyCombatController will also need to act as the AI, selecting which moves to use on what friendly units.
     */
    public bool UnitsAlive()
    {
        //LivingUnits[0].Moves[0];
        //if (CombatUnit.TargetType.Friendly.Equals(LivingUnits[0].Moves[0]))
        return LivingUnits.Count > 0;
    }

    public abstract void Initialize();

}
