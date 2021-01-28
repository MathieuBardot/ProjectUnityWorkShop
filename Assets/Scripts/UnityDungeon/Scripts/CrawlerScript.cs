using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityDungeon
{
    public class CrawlerScript : MonoBehaviour
    {
        public CharacterData player;
        public RoomData currentRoom;
        public RevealText revealText;
        public Animator panelAnimator;
        public FightScript fightScript;
        public GameObject buttons;
        public GameObject buttonLeft;
        public GameObject buttonRight;

        public enum CrawlerState
        {
            BEGIN,
            IN_ROOM,
            CHOOSE_ROOM,
            END
        }

        private CrawlerState state;

        IEnumerator Start()
        {
            state = CrawlerState.BEGIN;
            buttons.SetActive(false);
            player = Instantiate(player);
            // Créer le donjon
            // Afficher le panel de crawling
            // Récupérer le player
            fightScript.onFightEnd.AddListener(OnFightEnd);
            fightScript.player = player;
            yield return StartCoroutine(ChangeText(currentRoom.description));
            yield return new WaitForSeconds(1.0f);
            yield return StartCoroutine(ChooseDoor());
            buttons.SetActive(true);
        }

        IEnumerator ChooseDoor()
        {
            state = CrawlerState.CHOOSE_ROOM;
            buttons.SetActive(true);
            if (currentRoom.roomLeft == null && currentRoom.roomRight == null)
            {
                EndGame();
            }
            else
            {
                yield return StartCoroutine(ChangeText("Choisissez une porte "));
            }
        }

        public void OnLeftRoomButtonPressed()
        {
            if (state == CrawlerState.CHOOSE_ROOM)
            {
                StartCoroutine(SelectRoom(true));
            }
        }

        public void OnRightRoomButtonPressed()
        {
            if (state == CrawlerState.CHOOSE_ROOM)
            {
                StartCoroutine(SelectRoom(false));
            }
        }

        IEnumerator SelectRoom (bool left)
        {
            buttons.SetActive(false);
            currentRoom = left ? currentRoom.roomLeft : currentRoom.roomRight;
            string door = left ? "gauche" : "droite";
            buttonLeft.SetActive(currentRoom.roomLeft != null);
            buttonRight.SetActive(currentRoom.roomRight != null);

            yield return StartCoroutine(ChangeText($" {player.name} ouvre la porte de {door}"));
            yield return new WaitForSeconds(1.0f);
            yield return StartCoroutine(ChangeText(currentRoom.description));
            yield return new WaitForSeconds(1.0f);

            ScriptableObject occupant = currentRoom.occupant;
            if (occupant is CharacterData)
            {
                panelAnimator.SetBool("CrawlerPanelActive", true);
                fightScript.ennemy = (CharacterData) occupant;
                yield return StartCoroutine(fightScript.StartFight());
            }
            else
            {
                // Découverte Objet
                ItemData item = (ItemData)occupant;
                yield return StartCoroutine(ChangeText($"{player.name} trouve {item.name}"));
                yield return new WaitForSeconds(1.0f);
                if (item.incrementDefense > 0)
                {
                    player.defense += item.incrementDefense;
                    yield return StartCoroutine(ChangeText($"{player.name} gagne {item.incrementDefense} de défense"));
                    yield return new WaitForSeconds(1.0f);
                }
                if (item.incrementStrenght > 0)
                {
                    player.strength += item.incrementStrenght;
                    yield return StartCoroutine(ChangeText($"{player.name} récupère {item.incrementStrenght} de force"));
                    yield return new WaitForSeconds(1.0f);
                }
                if (item.incrementIntelligence > 0)
                {
                    player.intelligence += item.incrementIntelligence;
                    yield return StartCoroutine(ChangeText($"{player.name} gagne {item.incrementIntelligence} d'intelligence"));
                    yield return new WaitForSeconds(1.0f);
                }
                if (item.incrementHP > 0)
                {
                    player.Heal(item.incrementHP);
                    yield return StartCoroutine(ChangeText($"{player.name} gagne {item.incrementHP} de vie"));
                    yield return new WaitForSeconds(1.0f);
                }
                yield return StartCoroutine(ChooseDoor());
            }
        }

        void EndGame()
        {
            if (state == CrawlerState.END)
            {
                StartCoroutine(ChangeText("Vous avez terminé le donjon ! BRAVO !!"));
            }
        }

        void OnFightEnd(bool won)
        {
            panelAnimator.SetBool("CrawlerPanelActive", false);
            if (won)
            {
                StartCoroutine(ChooseDoor());
            }
            else
            {
                StartCoroutine(ChangeText("Vous avez perdu. Malheur à vous ....."));
            }
        }

        IEnumerator ChangeText(string text)
        {
            yield return StartCoroutine(revealText.ChangeText(text));
        }
    }
}
