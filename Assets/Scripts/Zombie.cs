using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC.Ally;

namespace NPC                                                                                   //namespace NPC, contiene los namespace ally y enemy.
{
    namespace Enemy                                                                             //namespace Enemy, pertenece al namespace NPC y contiene la clase del zombie.
    {
        public class Zombie : Npc
        {
            ZombieInformation zombieInfo;                                                       //Declaración de la estructura del zombie.
            CitizenInformation citizenInfo;
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

            public override void Reaction()
            {
                //base.Reaction();
                foreach (GameObject go in GameManager.npc)
                {
                    if(go.GetComponent<Hero>() || go.GetComponent<Citizen>())
                    {
                        float dist = Vector3.Distance(go.transform.position, transform.position);
                        //Debug.Log(dist);
                        Debug.Log(humanoidInfo.movementSpeed);
                        if (dist <= 5f)
                        {
                            transform.position = Vector3.MoveTowards(transform.position, go.transform.position, humanoidInfo.movementSpeed);
                            //transform.Translate = Vector3.forward * humanoidInfo.movementSpeed;
                        }
                    }
                }
            }
            private void OnCollisionEnter(Collision collision)
            {
                /*if (collision.gameObject.GetComponent<Citizen>())
                    collision.gameObject.GetComponent<Citizen>().*/
            }
        }
    }
}

public enum Taste                                                                               //Enumerador que contiene los gustos del zombie.
{
    cerebros,
    brazos,
    piernas,
    ojos,
    tripas
}

public struct ZombieInformation                                                         //Estructura que contiene la información del zombie.
{
    public Color[] color;
    public Taste taste;
    public float zombieAge;
}