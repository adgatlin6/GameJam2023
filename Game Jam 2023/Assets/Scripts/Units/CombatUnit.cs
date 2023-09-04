using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CombatUnit : MonoBehaviour
{
    public enum MoveType { Attack = TargetType.OtherTeam, Heal = TargetType.SameTeam, Defend = TargetType.Self, SommonUnit = TargetType.Self }
    public enum CombatTeam { Player, Enemy }
    public enum TargetType { SameTeam, OtherTeam, Self }

    public int MaxHealth { get; protected set; }
    public int CurrentHealth { get; protected set; }
    public int Defense { get; protected set; }
    public int MinDamage { get; protected set; }
    public int MaxDamage { get; protected set; }
    public int MinHealing { get; protected set; }
    public int MaxHealing { get; protected set; }
    public bool IsDefending { get; set; }
  
    public CombatTeam Team { get;  set; }

    public List<MoveType> Moves { get; protected set; }

    public TargetType UnitType { get; set; }

    /*
     * To add new moves, first add the move to MoveType enum and assign what the move targets
     * Then, add a new case to DoMove for the new Move and add whatever code needed for the case
     * */
    public void DoMove(CombatUnit target, MoveType move)
    {

        switch (move)
        {
            case MoveType.Attack:
                target.TakeDamage((int)Random.Range(MinDamage, MaxDamage + 1));
                break;
            case MoveType.Heal:
                target.TakeDamage(-(int)Random.Range(MinHealing, MaxHealing + 1));
                break;
            case MoveType.Defend:
                IsDefending = true;
                break;
            default:
                Debug.Log("Invalid move");
                break;
        }
    }

    //Removes health. If unit has used Defend move since the last time it has been attacked, then the unit will take damage - defense in total damage.
    //Healing is done by simply passing in a negative value, and the unit will heal for that amount.
    public virtual void TakeDamage(int damage)
    {
        if (damage > 0 && IsDefending)
        {
            int damageTaken = damage - Defense;
            if (damageTaken < 0) { damageTaken = 0; }
            CurrentHealth -= damageTaken;
            IsDefending = false;
        }
        else
        {
            CurrentHealth -= damage;
        }
    }

    //Returns a list of Moves available to this unit based on the target.
    //I.E. The Player King will be able to attack enemy units, but not heal them. And can heal friendly units, but not attack them.
    public List<MoveType> AvailableMoves(CombatUnit target)
    {
        bool self = false;
        bool friendly = target.Team.Equals(Team);
        List<MoveType> result = new List<MoveType>();
        if (target.Equals(this))
        {
            self = true;
            friendly = true;
        }

        foreach (MoveType move in Moves)
        {
            TargetType type = (TargetType)move;
            if (self && (type.Equals(TargetType.Self) || type.Equals(TargetType.SameTeam)))
            {
                result.Add(move);
            } else if (friendly && type.Equals(TargetType.SameTeam))
            {
                result.Add(move);
            } else if (!friendly && !self && type.Equals(TargetType.OtherTeam))
            {
                result.Add(move);
            }
        }
        return result;
    }




}
