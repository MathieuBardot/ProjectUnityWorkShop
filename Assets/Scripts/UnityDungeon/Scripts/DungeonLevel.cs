using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace UnityDungeon
{
    public class DungeonLevel : MonoBehaviour
    {
        public TextMeshProUGUI textMesh;
        public GameObject button;
        public RevealText revealText;

        public enum FightState
        {
            BEGIN,
            WAITING,
            CHOICE_WAY,
            END
        }

        private FightState state;

        IEnumerator Start()
        {
            state = FightState.BEGIN;
            button.SetActive(false);
            yield return StartCoroutine(ChangeText($"Welcome to the DUNGEON !"));
            yield return new WaitForSeconds(1.0f);
            yield return StartCoroutine(ChangeText($"You have to choose between two door ..."));
            yield return StartCoroutine(ChangeText($"...behind one you have a monster to defeat, and behind the other a bonus. You have to choose your way!"));
            state = FightState.WAITING;
        }

        IEnumerator ChangeText(string text)
        {
            yield return StartCoroutine(revealText.ChangeText(text));
        }

        public void OnDoorLeftButtonPressed()
        {
            button.SetActive(true);
            if (state == FightState.WAITING)
            {
               
            }
        }

        IEnumerator Monster()
        {
            yield return StartCoroutine(ChangeText($"There is a monster here !"));
            // Déclenchement du fightscript
        }

        IEnumerator Bonus(BonusCharacter player)
        {
            yield return StartCoroutine(ChangeText($"There is a bonus in this room !"));
            player.TakeBonus();
        }

        public void OnDoorRightButtonPressed()
        {
            button.SetActive(true);
            if (state == FightState.WAITING)
            {
                
            }
        }

        void OpenDoorLeft()
        {
            
        }

        void OpenDoorRight()
        {

        }
    }
}

