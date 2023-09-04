using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoveTypeButton : MonoBehaviour
{
    private CombatUnit.MoveType _move;
    public CombatUnit.MoveType Move 
    { 
        get { return _move; } 
        set 
        {
            Debug.Log(value);
            _move = value;
            TextMeshProUGUI text = GetComponentInChildren<TextMeshProUGUI>();
            text.SetText(_move.ToString());
        } 
    }

    //Sets the MoveType assigned to this button. This script shouldn't need any updating
    public void SetMove()
    {
        UnitMoveButton.Move = Move;
    }

}
