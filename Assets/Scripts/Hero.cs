using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC.Ally;                                                                                   //namespace ally, pertenece al namespace NPC y contiene la clase del ciudadano.
using NPC.Enemy;                                                                                  //namespace enemy, pertenece al namespace NPC y contiene la clase del zombie.

public class Hero : MonoBehaviour
{
    CitizenInformation citizenInfo;                                                               //Declaración de la estructura del ciudadano.
    ZombieInformation zombieInfo;                                                                 //Declaración de la estructura del zombie.
    void Start ()                                                                                 //Agrega los scripts de movimiento al heroe, asigna la cámara como hijo y la ubica en la posición del heroe.
    {
        gameObject.AddComponent<FPSAim>();
        gameObject.AddComponent<FPSMove>().speed += new MovSpeed().movSpeed;
        gameObject.AddComponent<Rigidbody>().freezeRotation = enabled;
        Camera.main.gameObject.transform.localPosition = gameObject.transform.position;
        Camera.main.transform.SetParent(gameObject.transform);
        Camera.main.gameObject.AddComponent<FPSAim>();
    }

    public void OnCollisionEnter(Collision collision)                                            //Método OnCollisionEnter, compara con el cubo que colisione si es ciudadano o zombie y muestre el mesaje correspondiente.
    {
        if (collision.gameObject.GetComponent<Citizen>())
        {
            citizenInfo = collision.gameObject.GetComponent<Citizen>().CitizenInfo();            //Asigna la información del ciudadano para usar en el mensaje.
            Debug.Log("Hola soy " + citizenInfo.name + " y tengo " + citizenInfo.age);           //Mensaje que da el ciudadano al entrar en contacto.
        }

        if (collision.gameObject.GetComponent<Zombie>())
        {
            zombieInfo = collision.gameObject.GetComponent<Zombie>().ZombieInfo();               //Asigna la información del zombie para usar en el mensaje.
            Debug.Log("Waaaarrrr quiero comer " + zombieInfo.taste);                             //Mensaje que da el zombie al entrar en contacto.
        }
    }
}
public class MovSpeed                                                                            //Constructor para asignar la velocidad de moviento del heroe al azar por medio de una variable flotante de solo lectura.
{
    public readonly float movSpeed;
    public MovSpeed()
    {
        movSpeed = Random.Range(0.2f, 0.5f);
    }
}