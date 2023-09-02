using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{

    private Camera GameCamera;

    public static CombatUnit ActingUnit;

    public static CombatUnit ReceivingUnit;

    public CombatUnit acting;

    private void Awake()
    {
        GameCamera = Camera.main;
        ActingUnit = acting;
    }
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
