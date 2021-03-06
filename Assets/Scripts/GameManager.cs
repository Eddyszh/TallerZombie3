﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                                                                       //Librería de interfaz de usuario.
using NPC.Ally;                                                                             //namespace ally, pertenece al namespace NPC y contiene la clase del ciudadano.
using NPC.Enemy;                                                                            //namespace enemy, pertenece al namespace NPC y contiene la clase del zombie.

public class GameManager : MonoBehaviour
{
    ZombieInformation zombieInfo;                                                           //Declaración de la estructura del zombie.
    CitizenInformation citizenInfo;                                                         //Declaración de la estructura del ciudadano.
    public static List<GameObject> npc = new List<GameObject>();                                          //Lista donde se agrega los npc existentes en la escena.
    public Text citizenText;                                                                //Texto que indica la cantidad de ciudadanos en la escena.
    public Text zombieText;                                                                 //Texto que indica la cantidad de zombies en la escena.
    public Text citizenTextMsg;
    public Text zombieTextMsg;
    public GameObject citizenMsg;
    public GameObject zombieMsg;
    public Image heroDied;

    public const int MAX = 25;                                                              //Variable constante que tiene la cantidad máxima de cubos a crear.
    public int citizenCount = 0;                                                                   //Contador para ciudadanos.
    public int zombieCount = 0;                                                                    //Contador para zombies.
	void Start ()
    {
        zombieMsg.SetActive(false);
        citizenMsg.SetActive(false);
        heroDied.gameObject.SetActive(false);
        int spawn = -1;                                                                     //Inicia el default del switch para asignar el heroe.
        for (int i = 0; i < Random.Range(new MinValue().minValue, MAX); i++)                //Bucle que crea una cantidad aleatoria de primitivas con posición aleatoria.                                                 
        {
            GameObject humanoid = GameObject.CreatePrimitive(PrimitiveType.Cube);           
            Vector3 pos = new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50));     
            humanoid.transform.position = pos;
            switch (spawn)                                                                  //Asigna "personalidades" de manera aleatoria.
            {
                case 1:                                                                     //Asigna "personalidad" de ciudadano añadadiendo la clase.
                    humanoid.name = "Citizen";
                    humanoid.AddComponent<Citizen>();
                    break;
                case 2:                                                                     //Asigna "personalidad" de zombie añadiendo clase y color.
                    humanoid.name = "Zombie";
                    humanoid.AddComponent<Zombie>();
                    break;
                default:                                                                    //Asigna "personalidad" de heroe añadiendo clase y color.
                    humanoid.name = "Hero";
                    humanoid.gameObject.tag = "Player";
                    humanoid.AddComponent<Hero>();
                    humanoid.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                    break;
            }
            spawn = Random.Range(1, 3);                                                     //Selecion aleatoria de "personalidad".
            if(humanoid.gameObject != null)                                                 //Condición para agregar npc a la lista.
                npc.Add(humanoid);                                                          //Agrega npc a la lista. 
        }
        foreach (GameObject go in npc)                                                      //Por cada elemento en la lista, aumenta el contador de ciudadano o zombie.
        {
            if(go.name == "Citizen")
            {
                citizenCount++;
                citizenText.text = "Citizen: " + citizenCount.ToString();
            }
            if(go.name == "Zombie")
            {
                zombieCount++;
                zombieText.text = "Zombie: " + zombieCount.ToString();
            }
        }
    }	
}
public class MinValue                                                                          //Constructor para obtener el valor de creación mínimo de personajes, por medio de una variable entera de solo lectura.
{
    public readonly int minValue;
    public MinValue()
    {
        minValue = Random.Range(5, 15);
    }
}
