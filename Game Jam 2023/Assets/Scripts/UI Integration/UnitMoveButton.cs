using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMoveButton : MonoBehaviour
{
    public static CombatUnit.MoveType Move { private get; set; }


    public void DoAction()
    {
        CombatUnit actingUnit = CharacterSelector.ActingUnit;
        CombatUnit receivingUnit = CharacterSelector.ReceivingUnit;
        actingUnit.DoMove(receivingUnit, Move); 
    }
}
