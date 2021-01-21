using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace UnityDungeon
{
    public class BonusCharacter
    {
        public int bonusStrenght;
        public int bonusDefense;
        public int bonusIntelligence;

        public TextMeshProUGUI textMesh;
        public CharacterData player;
        public void TakeBonus()
        {
            int random = Random.Range(0, 2);
            if (random==0)
            {
                player.strength += bonusStrenght;
                textMesh.text = $"Your character won a bonus of {bonusStrenght} !";
            }
            if (random == 1)
            {
                player.defense += bonusDefense;
                textMesh.text = $"Your character won a bonus of {bonusDefense} !";
            }
            if (random == 2)
            {
                player.intelligence += bonusIntelligence;
                textMesh.text = $"Your character won a bonus of {bonusIntelligence} !";
            }
        }
    }
}