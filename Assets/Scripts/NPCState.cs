using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC.Ally;
using NPC.Enemy;

public class NPCState : MonoBehaviour
{
    ZombieInformation zombieInfo;
    CitizenInformation citizenInfo;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    
}

public class NPCZombieState : Zombie
{

}

public class NPCCitizenState : Citizen
{
    CitizenInformation citizenInfo;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Zombie>())
        {
            ZombieInformation zombieInfo = (ZombieInformation)citizenInfo;
        }
    }
}