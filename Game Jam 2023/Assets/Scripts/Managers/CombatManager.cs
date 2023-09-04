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

    //Sets up the battle. Initializes turn order for units and CombatControllers.
    public void InitializeCombat()
    {

        player.Initialize();
        enemy.Initialize();


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
        bool kingAlive = false;
        bool enemiesAlive = false;
        foreach (CombatUnit unit in combatOrder)
        {
            if(unit.GetType() == typeof(PlayerKing))
            {
                kingAlive = true;
            }
            if(unit.Team == CombatUnit.CombatTeam.Enemy)
            {
                enemiesAlive = true;
            }
        }

        return !kingAlive || !enemiesAlive;
    }

    private void StartNewTurn()
    {
        foreach (CombatUnit unit in combatOrder)
        {
            if (unit.CurrentHealth <= 0)
            {
                combatOrder.Remove(unit);
                //update UI to show new turn order
                //Remove dead character from combat
            }
        }
        //sets the screen up to play a new combat turn
        //Select the next unit in CombatOrder to go. Set ActingUnit.ActingUnit to the next unit in the list
    }

    private void ReturnToGame()
    {
        combatOrder.Clear();
        //reset character health
        //move camera back to player and enable controls.
    }
}
