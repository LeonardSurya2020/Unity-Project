using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum Batllestate { START, PLAYERTURN, ENEMYTURN, WON, LOST}

public class battle_system : MonoBehaviour
{
    public Batllestate state;

    public GameObject enemy_prefab;
    public GameObject player_prefab;
    public Transform enemy_BS;

    public Button button_attack;
    public Button button_defend;
    public Button button_item;

    unit enemyunit;
    unit playerunit;

    public TextMeshProUGUI enemyHP;
    public TextMeshProUGUI enemyName;

    public TextMeshProUGUI playerHP;
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI playerSP;

    public TextMeshProUGUI turn;

    void Start()
    {
        state = Batllestate.START;
        SetUpBattle();
    }

    void SetUpBattle()
    {
        GameObject enemyGO =  Instantiate(enemy_prefab, enemy_BS);
        enemyunit = enemyGO.GetComponent<unit>();

        enemyName.text = enemyunit.unitName + "  :";
        enemyHP.text = enemyunit.currentHP.ToString() + "/" + enemyunit.maxHP.ToString();

        GameObject playerGO = Instantiate(player_prefab, enemy_BS);
        playerunit = playerGO.GetComponent<unit>();

        playerName.text = playerunit.unitName;
        playerHP.text = playerunit.currentHP.ToString() + "/" + playerunit.maxHP.ToString();

        state = Batllestate.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator playerAttack ()
    {
        bool isDead = enemyunit.TakeDamage(playerunit.damage);
        enemyHP.text = enemyunit.currentHP.ToString() + "/" + enemyunit.maxHP.ToString();

        turn.text = "Attack is Successfully!";

        yield return new WaitForSeconds(1f);

        if(isDead)
        {
            //end battle
            state = Batllestate.WON;
            endBattle();
        }
        else
        {
            //enemy turn
            state = Batllestate.ENEMYTURN;
            
            StartCoroutine(EnemyTurn());
            

        }
    }

    void PlayerTurn()
    {
        turn.text = "Your Turn";
        button_attack.enabled = true;
        button_defend.enabled = true;
        button_item.enabled = true;
    }

    IEnumerator EnemyTurn()
    {
        button_attack.enabled = false;
        button_defend.enabled = false;
        button_item.enabled = false;
        turn.text = enemyunit.unitName + " turn";
        yield return new WaitForSeconds(1f);
        
        turn.text = enemyunit.unitName + " Attack!!";

        yield return new WaitForSeconds(1f);

        bool isDead = playerunit.TakeDamage(enemyunit.damage);
        playerHP.text = playerunit.currentHP.ToString() + "/" + playerunit.maxHP.ToString();

        yield return new WaitForSeconds(1f);

        if(isDead)
        {
            state = Batllestate.LOST;
            endBattle();
        }
        else
        {
            state = Batllestate.PLAYERTURN;
            
            PlayerTurn();
        }
    
    }

    public void OnAttackButton()
    {
        if (state != Batllestate.PLAYERTURN)
            return;

        StartCoroutine(playerAttack());
    }

    void endBattle()
    {
        if(state == Batllestate.WON)
        {
            turn.text = "You Won!";
        }
        else if(state == Batllestate.LOST)
        {
            turn.text = "Defeated!";
        }
    }
}
