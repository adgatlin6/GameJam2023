using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    [SerializeField]
    readonly CombatController player;
    [SerializeField]
    readonly CombatController enemy;

    readonly List<CombatUnit> combatOrder;


    private bool TurnOver { get; set; }

    public void InitializeCombat()
    {
        //Temporary. Logic will be added to set units later
        player.Initialize(null);
        enemy.Initialize(null);


        int playerCount = player.LivingUnits.Count;
        int enemyCount = enemy.LivingUnits.Count;
        int count = Mathf.Max(playerCount, enemyCount);

        for (int i = 0; i < count; i++)
        {
            if (player.LivingUnits.Count > i)
            {
                combatOrder.Add(player.LivingUnits[i]);
            }
            if(enemy.LivingUnits.Count > i)
            {
                combatOrder.Add(enemy.LivingUnits[i]);
            }
        }
    }

    public void EndTurn()
    {
        if (true /* If king and at least one enemy unit is still alive */)
        {
            StartNewTurn();
        } else if (CombatOver())
        {
            ReturnToGame();
        }
    }

    //Returns true when the current combat has ended
    private bool CombatOver()
    {
        return false; /* if king is dead or no units left alive on enemy team return true*/
    }

    private void StartNewTurn()
    {
        foreach (CombatUnit unit in combatOrder)
        {
            if (unit.CurrentHealth <= 0)
            {
                combatOrder.Remove(unit);
                //update UI to show new turn order
            }
        }
        //sets the screen up to play a new combat turn
    }

    private void ReturnToGame()
    {
        combatOrder.Clear();
        //reset character health? Tidy up character stats, give exp etc.
        //move camera back to player and enable controls.
    }
}
