using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityDungeon
{
    public class DungeonRule : MonoBehaviour
    {
        public enum RoomContent
        {
            MONSTER,
            BONUS,
            BOSS
        }

        [Tooltip("Define the number of different stage you have to pass to won")]
        private RoomContent[] Rooms = new RoomContent[5];

        void Start()
        {
            createDungeon();
        }

        //Exemle : 
        //First Stage : DoorLeft = monster et DoorRight = bonus
        //Second Stage : DoorLeft = bonus et DoorRight = monster
        //Third Stage : DoorLeft = monster et DoorRight = bonus
        //Four Stage : DoorLeft = monster et DoorRight = bonus
        //Five Stage : DoorLeft = DoorRight = final boss
        void createDungeon()
        {
            for (int i = 0; i < Rooms.Length - 1 ; i++)
            {
                if (Random.Range(0.0f,1.0f) < 0.5f)
                {
                    Rooms[i] = RoomContent.MONSTER;
                }
                else
                {
                    Rooms[i] = RoomContent.BONUS;
                }
            }
            Rooms[4] = RoomContent.BOSS;
        }
    }
}

