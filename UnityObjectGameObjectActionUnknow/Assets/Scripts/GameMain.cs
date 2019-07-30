using System;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    #region
    public class Tools
    {
        public static void Create(Action<GameObject> a)
        {
        }

        public static void Create(Action<UnityEngine.Object> a)
        {
        }
    }

    private void Awake()
    {
        /** 这里这个我也不知道是为什么, 所以记录一下。
         *  Tools类有2个重载的静态Create方法, public static void Create(Action<GameObject> a) 和 public static void Create(Action<UnityEngine.Object> a)。
         *  其中GameObject继承自Object, GameObject和Object都是Unity的类。
         *  这里很神奇, 调用Tools.Create(CreateUnityObject);, 就会报方法或者属性二义性的错误。
         *  调用Tools.Create(CreateGameObject);, 则不会报方法或者属性二义性的错误。
         * */
        //Tools.Create(CreateUnityObject);
        Tools.Create(CreateGameObject);
    }

    public void CreateUnityObject(UnityEngine.Object go)
    {
     
    }

    public void CreateGameObject(GameObject go)
    {

    }
    #endregion

    #region
    public class Helper
    {
        public static void Create(GameObject a)
        {
        }

        public static void Create(UnityEngine.Object a)
        {
        }
    }

    private void Start()
    {
        // 这一点没有问题
        UnityEngine.Object obj = new UnityEngine.Object();
        Helper.Create(obj);
    }
    #endregion

    #region
    public class People
    {
        public string name;
    }

    public class Man : People
    {

    }

    public class Woman : People
    {

    }

    public static class Unitity
    {
        public static void Create(Action<string, bool, Man> a)
        {
            string identity = "Boss";

            if (a != null)
            {
                Man man = new Man();
                man.name = "Dawei";
                a.Invoke(identity, true, man);
            }
        }

        public static void Create(Action<string, bool, People> a)
        {
            string identity = "Manager";

            if (a != null)
            {
                People people = new People();
                people.name = "Lucy";
                a.Invoke(identity, true, people);
            }
        }
    }

    public static void CreatePeople(string identity, bool confirmIdentity, People people)
    {
        if (string.IsNullOrEmpty(identity) || people == null)
        {
            return;
        }

        Debug.Log(identity + " want create a " + people.name + (confirmIdentity ? " and identity confirm success." : " but identify confirm failed."));
        if (confirmIdentity)
        {
            Debug.Log("Create " + people.name + " success.");
        }
    }

    public static void CreateMan(string identity, bool confirmIdentity, Man man)
    {
        if (string.IsNullOrEmpty(identity) || man == null)
        {
            return;
        }

        Debug.Log(identity + " want create a " + man.name + (confirmIdentity ? " and identity confirm success." : " but identify confirm failed."));
        if (confirmIdentity)
        {
            Debug.Log("Create " + man.name + " success.");
        }
    }

    private void OnEnable()
    {
        //Unitity.Create(CreatePeople); 它又出现了二义性
        Unitity.Create(CreateMan);
    }
    #endregion

}
