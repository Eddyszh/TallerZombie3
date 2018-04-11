using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPC                                                                                   //namespace NPC, contiene los namespace ally y enemy.
{
    namespace Enemy                                                                             //namespace Enemy, pertenece al namespace NPC y contiene la clase del zombie.
    {
        public class Zombie : MonoBehaviour
        {
            ZombieInformation zombieInfo;                                                       //Declaración de la estructura del zombie.
            int move;                                                                           //Variable para el switch del movimiento.
	        void Start ()
            {
                zombieInfo.taste = (Taste)Random.Range(0, 5);                                   //Asigna el gusto del zombie al azar.
                StartCoroutine(Behaviour());                                                    //Inicia la corrutina del comportamiento del zombie.
                gameObject.AddComponent<Rigidbody>();                                           //Añade cuerpo rigido al zombie.
	        }	
	        
	        void Update ()                                                                      //Contiene un switch donde está la dirección de moviento y de rotación.
            {
                switch (move)
                {
                    case 1:
                        transform.position += transform.forward * 2f * Time.deltaTime;
                        transform.Rotate(Vector3.zero);
                        break;
                    case 2:
                        transform.position -= transform.forward * 2f * Time.deltaTime;
                        transform.Rotate(Vector3.zero);
                        break;
                    case 3:
                        transform.position += transform.right * 2f * Time.deltaTime;
                        transform.Rotate(Vector3.zero);
                        break;
                    case 4:
                        transform.position -= transform.right * 2f * Time.deltaTime;
                        transform.Rotate(Vector3.zero);
                        break;
                    case 5:
                        transform.position += new Vector3(0, 0, 0);
                        transform.Rotate(Vector3.zero);
                        break;
                    case 6:
                        transform.position += new Vector3(0, 0, 0);
                        transform.Rotate(Vector3.up * zombieInfo.rotatingSpeed);
                        break;
                    case 7:
                        transform.position += new Vector3(0, 0, 0);
                        transform.Rotate(Vector3.down * zombieInfo.rotatingSpeed);
                        break;
                }               
            }

            void Movement()                                                                     //Método que inicia los comportamientos del zombie por medio de un switch.
            {
                switch(zombieInfo.zb)
                {
                    case 0:
                        move = 5;
                        StartCoroutine(Behaviour());
                        break;
                    case (ZombieBehaviour)1:
                        move = Random.Range(1, 5);
                        StartCoroutine(Behaviour());
                        break;
                    case (ZombieBehaviour)2:
                        move = Random.Range(6, 8);
                        zombieInfo.rotatingSpeed = Random.Range(1, 5);
                        StartCoroutine(Behaviour());
                        break;
                }                
            }

            IEnumerator Behaviour()                                                              //Corrutina que elige el comportamiento del zombie de manera aleatoria cada 3 segunsdos.
            {
                yield return new WaitForSeconds(3);
                zombieInfo.zb = (ZombieBehaviour)Random.Range(0, 3);                
                Movement();
                yield return new WaitForSeconds(3);
            }

            public ZombieInformation ZombieInfo()                                               //Función que devuelve la estructura del zombie.
            {
                return zombieInfo;
            }
        }

    }
}
public enum ZombieBehaviour                                                                     //Enumerador que contiene los comportamientos del zombie.
{
    idle,
    moving,
    rotating
}

public enum Taste                                                                               //Enumerador que contiene los gustos del zombie.
{
    cerebro,
    brazos,
    piernas,
    pechos,
    tripas
}

public struct ZombieInformation                                                                 //Estructura que contiene la información del zombie.
{
    public Color[] color;
    public Taste taste;
    public ZombieBehaviour zb;
    public float rotatingSpeed;
}
