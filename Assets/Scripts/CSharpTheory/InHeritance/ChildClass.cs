using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CSharpTheory.InHeritance
{
    public class ChildClass : ParentClass
    {
        private int mp;

        public ChildClass(string name, int age, int hp, int mp) : base(name,age,hp)
        {
            this.mp = mp;
        }

        public override void attack(ParentClass character)
        {
            character.setHp(character.getHp() - 7);
            mp -= 2;
        }

        public int getMp()
        {
            return mp;
        }

        public void setMp(int mp)
        {
            this.mp = Mathf.Max(0,mp);
        }
    }
}

