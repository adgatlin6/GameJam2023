using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{

    private Camera GameCamera;

    public static CombatUnit ActingUnit;

    public static CombatUnit ReceivingUnit;

    //this is test code. When combat is fully set up, remove "acting" variable and all references to it
    public CombatUnit acting;

    private void Awake()
    {
        GameCamera = Camera.main;
        ActingUnit = acting;
    }

    /*When left mouse button is pressed, if the user clicked on a unit, it will select that unit and generate MoveTypeButtons based on available moves that can be performed
     * For example, if the PlayerKing is the ActingUnit, and the player clicks on their king unit, it will generate buttons for all moves that the king can use on itself, E.G. defend, heal
     * No updates should be needed for this code, however the CombatManager will need to set ActingUnit to whichever unit's turn it is in combat every time it becomes a new unit's turn.
     */ 
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(GameCamera.ScreenToWorldPoint(Input.mousePosition).x, GameCamera.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero, 0f);
            CombatUnit selection = null;
            if (hit.collider != null)
            {
                selection = hit.collider.gameObject.GetComponent<CombatUnit>();
            }
            if (selection != null)
            {
                ReceivingUnit = selection;
                ButtonGenerator.Instance.ClearButtons();
                ButtonGenerator.Instance.GenerateButtons(ActingUnit.AvailableMoves(ReceivingUnit));

                //Test code
                foreach(CombatUnit.MoveType move in ActingUnit.AvailableMoves(ReceivingUnit))
                {
                    Debug.Log("Move: " + move.ToString());
                }
            }

        }

    }



}
