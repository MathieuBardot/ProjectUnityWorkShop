using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityDungeon
{
    [CreateAssetMenu(fileName ="New Character", menuName ="CustomScripts/Character")]
    public class CharacterData : ScriptableObject
    {
        public new string name;
        public int maxHp;
        public int strength;
        public int defense;
        public int intelligence;
        [Tooltip("Chances for the attack to succeed. Must be between 0 and 1")]
        public float precision;

        private float currentHp;
        public int HP
        {
            get
            {
                return Mathf.RoundToInt(currentHp);
            }
        }

        /*CharacterData()
        {
            currentHp = maxHp;
        }*/

        void OnEnable()
        {
            currentHp = maxHp;
        }

        public void TakeDamage(float damage)
        {
            currentHp = Mathf.Max(currentHp - damage, 0);
            /*currentHp -= damage;
            if (currentHp < 0)
            {
                currentHp = 0;
            }*/
        }

        public void Heal (float health)
        {
            currentHp = Mathf.Min(maxHp,currentHp + health);
            /*currentHp += health;
            if (currentHp > maxHp)
            {
                currentHp = maxHp;
            }*/
        }
    }
}
