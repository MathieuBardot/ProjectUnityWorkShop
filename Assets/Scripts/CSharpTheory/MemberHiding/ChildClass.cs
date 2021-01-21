using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CSHarpTheory.MemberHidding
{
    public class ChildClass : ParentClass
    {
        public override string Name { get { return "child"; } }
    }
}
