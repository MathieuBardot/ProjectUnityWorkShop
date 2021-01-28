using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CSharpTheory;
using CSharpTheory.InHeritance;
using CSharpTheory.Genericity;
using MemberHidding = CSHarpTheory.MemberHidding;
using CSharpTheory.Interface;
using CSharpTheory.Enumerator;

public class MoveBehaviour : MonoBehaviour
{
    public float speed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        /*Property p = new Property();
        p.Hours = 30;
        Debug.Log(p.Minutes); //1800
        p.Minutes = 30;
        Debug.Log(p.Hours);*/ //0.5

        //StaticFields.monChamp = 10;

        /*Singleton single = Singleton.instance;
        Singleton.Instance.groupName = "NewName";
        Singleton.Instance.nbInstance = 42;*/

        /*MethodOverloading mo = new MethodOverloading();
        mo.text("Hello wolrd !!");
        Debug.Log(mo.text());*/

        /*ParentClass c1 = new ParentClass("Jean", 42, 20);
        ParentClass c2 = new ChildClass("Marion", 45, 17,15);

        c1.attack(c2);
        Debug.Log(c1.getHp()); // 20
        Debug.Log(c2.getHp()); // 12

        c2.attack(c1);
        Debug.Log(c1.getHp()); // 13
        Debug.Log(c2.getHp()); // 12
        Debug.Log(((ChildClass)c2).getMp());*/ // 13

        /*Group<User> userGroup = new Group<User>();

        Female female = new Female();
        userGroup.AddUser(female);
        Male male = new Male();
        userGroup.AddUser(male);
        User user = new User();
        userGroup.AddUser(user);

        foreach(User u in userGroup.GetList())
            Debug.Log(u.SelfDescribe());*/

        /*MemberHidding.ParentClass parent = new MemberHidding.ParentClass();
        MemberHidding.ParentClass child = new MemberHidding.ChildClass();

        Debug.Log(parent.Name);
        Debug.Log(child.Name);*/

        //IMyInterface attacker = new Attacker();
        //attacker.Attack();

        /*Enumerator enumerators = new Enumerator();
        IEnumerator enumerator = enumerators.myEnumerator();
        while (true){
            if (enumerator.MoveNext())
                Debug.Log(enumerator.Current);
            else
                break;
        }*/

        //Delegate d = new Delegate();

        Lists l = new Lists();
        l.initialize();
    }

    // Update is called once per frame
    void Update()
    {
        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");
        Vector3 velocity = new Vector3(inputH, 0, inputV);
        //if(Input.GetButton("Fire1")
        transform.Translate(velocity * speed * Time.deltaTime);
    }
    
}
