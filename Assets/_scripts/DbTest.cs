using UnityEngine;
using System.Collections.Generic;
using System;
using System.Reflection;
using System.Data;
using Mono.Data.Sqlite;

using Assets._scripts;


public class DbTest : MonoBehaviour
{
    public GameObject myPrefab;

    // Use this for initialization
    void Start()
    {
        Gacha myGacha = new Gacha();
        myGacha.name = "Ethan";

        //bool b = Database.AddGacha(myGacha);
        //Debug.Log(b);
        List<Gacha> gachas = Database.GetGachas();
        foreach (Gacha gacha in gachas)
        {
            Debug.Log(gacha.name);
            for(int i = 0; i < 5; i++)
            {
                GameObject newObject = Instantiate<GameObject>(Resources.Load<GameObject>(gacha.name));
                newObject.transform.Translate(Vector3.forward * i);
            }
            
        }
        
    }




}
