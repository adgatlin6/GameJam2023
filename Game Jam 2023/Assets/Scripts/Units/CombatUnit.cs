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
  
    public CombatTeam Team { get;  set; }

    public List<MoveType> Moves { get; protected set; }

    public TargetType UnitType { get; set; }

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
            default:
                Debug.Log("Invalid move");
                break;
        }
    }

    public virtual void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0) 
        {
            Debug.Log("Unit has died");
        }
    }

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
