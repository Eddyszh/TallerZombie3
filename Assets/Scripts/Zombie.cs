using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPC                                                                                   //namespace NPC, contiene los namespace ally y enemy.
{
    namespace Enemy                                                                             //namespace Enemy, pertenece al namespace NPC y contiene la clase del zombie.
    {
        public class Zombie : Npc
        {
            ZombieInformation zombieInfo;                                                       //Declaración de la estructura del zombie.
            
	        void Start ()
            {
                zombieInfo.taste = (Taste)Random.Range(0, 5);                                   //Asigna el gusto del zombie al azar.
                zombieInfo.zombieAge = Random.Range(15, 100);                                   //Asigna edad aleatoria al zombie.
                gameObject.AddComponent<Rigidbody>();                                           //Añade cuerpo rigido al zombie.
	        }

            public ZombieInformation ZombieInfo()                                               //Función que devuelve la estructura del zombie.
            {
                return zombieInfo;
            }
        }        
    }
}

public enum Taste                                                                               //Enumerador que contiene los gustos del zombie.
{
    cerebro,
    brazos,
    piernas,
    pechos,
    tripas
}

public struct ZombieInformation                                                         //Estructura que contiene la información del zombie.
{
    public Color[] color;
    public Taste taste;
    public float zombieAge;
}