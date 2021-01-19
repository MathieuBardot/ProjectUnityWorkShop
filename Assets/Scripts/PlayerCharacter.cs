using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using CSharpTheory.RPGInterface;

public class PlayerCharacter : MonoBehaviour
{
    public Character Player = new Character("Rodeur", 20, 8, 4);
    public Character Enemy = new Character("Orc", 17, 6, 5);

    void Update()
    {

    }

    public void AttackPlayer()
    {
        GameObject text = GameObject.Find("Text (TMP) 1");
        TextMeshProUGUI tm = text.GetComponent<TextMeshProUGUI>();
        Player.Attack(Enemy);
        //Debug.Log(Enemy.getHp());
        string life = (Enemy.getHp()).ToString(); 
        tm.text = "Hp Enemy = " + life;
    }

    public void AttackEnemy()
    {
        GameObject text = GameObject.Find("Text (TMP) 1");
        TextMeshProUGUI tm = text.GetComponent<TextMeshProUGUI>();
        Enemy.Attack(Player);
        //Debug.Log(Player.getHp());
        string life = (Player.getHp()).ToString();
        tm.text = "Hp Player = " + life;
    }

    public void DefenseEnnemy()
    {
        GameObject text = GameObject.Find("Text (TMP) 1");
        TextMeshProUGUI tm = text.GetComponent<TextMeshProUGUI>();
        Enemy.Defense(Player);
        //Debug.Log(Player.getHp());
        string life = (Enemy.getHp()).ToString();
        tm.text = "Hp Enemy = " + life;
    }

    public void DefensePlayer()
    {
        GameObject text = GameObject.Find("Text (TMP) 1");
        TextMeshProUGUI tm = text.GetComponent<TextMeshProUGUI>();
        Player.Defense(Enemy);
        //Debug.Log(Enemy.getHp());
        string life = (Player.getHp()).ToString();
        tm.text = "Hp Player = " + life;
    }
}
