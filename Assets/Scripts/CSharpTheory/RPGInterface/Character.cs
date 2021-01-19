using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CSharpTheory.RPGInterface
{
    public class Character //: IRPGInterface
    {
        public string name;
        protected int Hp;
        protected int Atq;
        protected int Def;

        public Character (string name, int Hp, int Atq, int Def)
        {
            this.name = name;
            this.Hp = Hp;
            this.Atq = Atq;
            this.Def = Def;
        }

        public void Attack(Character player)
        {
            player.Hp -= this.Atq;
        }

        public void Defense(Character player)
        {
            this.Hp -= (player.Atq - this.Def);
        }

        public int getHp()
        {
            return Hp;
        }

        public void setHp(int Hp)
        {
            this.Hp = Mathf.Max(0, Hp);
        }

        public int getAtq()
        {
            return Atq;
        }

        public void setAtq(int Atq)
        {
            this.Atq = Atq;
        }

        public int getDef()
        {
            return Def;
        }

        public void setDef(int Def)
        {
            this.Def = Def;
        }
    }
}