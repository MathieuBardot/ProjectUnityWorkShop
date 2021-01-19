using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CSharpTheory
{
    public class Property
    {
        private int seconds;

        /*public setHours(float hours)
        {
            this.seconds = hours * 3600;
        }*/

        public float Hours
        {
            set
            {   
                seconds = (int)value*3600;
            }

            get
            {
                return (float)seconds / 3600;
            }
        }

        public float Minutes
        {
            set
            {   
                seconds = (int)value*60;
            }

            get
            {
                return (float)seconds / 60;
            }
        }
    }
}