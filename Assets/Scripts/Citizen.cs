using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPC                                                                           //namespace NPC, contiene los namespace ally y enemy.
{
    namespace Ally                                                                      //namespace Ally, pertenece al namespace NPC y contiene la clase del ciudadano.
    {
        public class Citizen : Npc
        {
            CitizenInformation citizenInfo;                                             //Declaración de la estructura del ciudadano.
	        void Start ()
            {
                citizenInfo.name = (CitizenName)Random.Range(0, 20);                    //Asigna el nombre de manera aleatoria.
                gameObject.AddComponent<Rigidbody>();
	        }
	
	       public CitizenInformation CitizenInfo()                                      //Función que devuelve la estructura del ciudadano.
           {
                return citizenInfo;

           }
        }
    }
}

public enum CitizenName                                                                 //Enumerador que contiene la lista de nombres que se asignan al azar.
{
    Adolfo,
    Ramiro,
    Bob,
    Jimmy,
    Josefo,
    Leopoldo,
    Cirilo,
    Fabio,
    Yisus,
    Jasinto,
    Arnulfa,
    Berta,
    Gregoria,
    Gertrudis,
    Lola,
    Marta,
    Eva,
    Beatriz,
    Facunda,
    Pepa
}
public struct CitizenInformation                                                    //Estructura que contiene la informacion del ciudadano.
{
    public CitizenName name;
    static public explicit operator ZombieInformation(CitizenInformation c)
    {
        return new ZombieInformation();
    }
}


