using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMoveButton : MonoBehaviour
{
    public static CombatUnit.MoveType Move { private get; set; }

    //Confirms and runs the code based on the units selected as acting and receiving unit. No updates to this code should be necessary
    public void DoAction()
    {
        CombatUnit actingUnit = CharacterSelector.ActingUnit;
        CombatUnit receivingUnit = CharacterSelector.ReceivingUnit;
        actingUnit.DoMove(receivingUnit, Move); 
    }
}
