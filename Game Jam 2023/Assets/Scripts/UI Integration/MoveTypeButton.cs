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

    public void SetMove()
    {
        UnitMoveButton.Move = Move;
    }

}
