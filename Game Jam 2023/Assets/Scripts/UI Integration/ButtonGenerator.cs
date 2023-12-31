using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonGenerator : MonoBehaviour
{

    public static ButtonGenerator Instance { get; private set; }

    public GameObject Parent;
    public GameObject ButtonPrefab;

    public RectTransform FirstButtonLocation;

    private List<GameObject> activeButtons;

    //Generates buttons for each move available given the selecting ActingUnit and ReceivingUnit in CharacterSelector script
    public void GenerateButtons(List<CombatUnit.MoveType> moves)
    {
        for (int i = 0; i < moves.Count; i++)
        {
            GameObject newButton = Instantiate(ButtonPrefab, Parent.transform);
            activeButtons.Add(newButton);

            RectTransform rect = newButton.GetComponent<RectTransform>();
            rect.localPosition = new Vector3(rect.localPosition.x, rect.localPosition.y - (60 * i), rect.localPosition.z);
            MoveTypeButton button = newButton.GetComponent<MoveTypeButton>();
            button.Move = moves[i];
        }
    }

    //Clears old buttons when new Acting or Receiving unit is selected
    public void ClearButtons()
    {
        foreach (GameObject obj in activeButtons)
        {
            Destroy(obj);
        }
    }

    //Sets up a Singleton to be references globally
    private void Awake()
    {
        if(Instance == null ) { Instance = this; }
        else if (Instance != null && Instance != this) { Destroy(this.gameObject);  }
        activeButtons = new List<GameObject>();
    }
}
