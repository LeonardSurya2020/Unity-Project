using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unit : MonoBehaviour
{
    public string unitName;

    public int damage;
    battle_system system;
    public int maxHP;
    public int maxSP;
    public int currentHP;
    private int random;

    public bool TakeDamage(int dmg)
    {
        random = Random.Range(0, dmg);
        currentHP -= random;
        if(dmg == damage)
        {
            currentHP -= dmg / 2;
            system.turn.text = "Critical Hit!";
        }
        if(currentHP <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
