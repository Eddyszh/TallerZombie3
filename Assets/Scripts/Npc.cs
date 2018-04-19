using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC.Ally;
using NPC.Enemy;

public class Npc : MonoBehaviour
{
    ZombieInformation zombieInfo;
    CitizenInformation citizenInfo;
    public HumanoidInformation humanoidInfo;

    public float closestDistance;
    public float furthestDistance;
    public GameObject closestGameObject;
    public GameObject furthestGameObject;
    public int move;
    
    void Awake ()
    {
        closestDistance = Mathf.Infinity;
        StartCoroutine(Behaviour());
	}	
	
	void Update ()
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
                transform.Rotate(Vector3.up * humanoidInfo.rotatingSpeed);
                break;
            case 7:
                transform.position += new Vector3(0, 0, 0);
                transform.Rotate(Vector3.down * humanoidInfo.rotatingSpeed);
                break;
        }
    }
    public IEnumerator Behaviour()                                                              //Corrutina que elige el comportamiento del zombie y ciudadano de manera aleatoria cada 3 segunsdos.
    {
        yield return new WaitForSeconds(3);
        humanoidInfo.hb = (HumanoidBehaviour)Random.Range(0, 4);
        Movement();
        Debug.Log(humanoidInfo.hb);
        yield return new WaitForSeconds(3);
    }

    public void Movement()                                                                     //Método que inicia los comportamientos del zombie y ciudadano por medio de un switch.
    {
        switch (humanoidInfo.hb)
        {
            case 0:
                move = 5;
                StartCoroutine(Behaviour());
                break;
            case (HumanoidBehaviour)1:
                move = Random.Range(1, 5);
                //MoveAround();
                StartCoroutine(Behaviour());
                break;
            case (HumanoidBehaviour)2:
                move = Random.Range(6, 8);
                humanoidInfo.rotatingSpeed = Random.Range(1, 5);
                StartCoroutine(Behaviour());
                break;
            case (HumanoidBehaviour)3:
                HumanoidReaction();
                closestDistance = Mathf.Infinity;
                furthestDistance = 5f;
                MoveAround();
                StartCoroutine(Behaviour());
                break;
        }
    }
   
    public void MoveAround()
    {
        Vector3 moveAway = (transform.position - closestGameObject.transform.position).normalized;
        Vector3 moveTo = (transform.position - furthestGameObject.transform.position).normalized;

        Vector3 directionToMove = moveAway - moveTo;

        transform.forward = directionToMove;
        gameObject.GetComponent<Rigidbody>().velocity = directionToMove * humanoidInfo.movementSpeed;
        Debug.DrawRay(transform.position, directionToMove, Color.blue);
        Debug.DrawLine(transform.position, closestGameObject.transform.position, Color.red);
        Debug.DrawLine(transform.position, furthestGameObject.transform.position, Color.green);
    }

    virtual public void HumanoidReaction()
    {
        GameObject[] humanoid = (GameObject[])GameObject.FindObjectsOfType(typeof(GameObject));
        foreach (GameObject go in humanoid)
        {
            Zombie z = go.GetComponent<Zombie>();
            Citizen c = go.GetComponent<Citizen>();
            if (z == null || z == this && c == null || c == this)
            {
                continue;
            }
            Vector3 v = go.transform.position - transform.position;
            float distanceToGo = v.magnitude;

            if (distanceToGo < closestDistance)
            {
                closestDistance = distanceToGo;
                closestGameObject = go;
            }
            if (distanceToGo > furthestDistance)
            {
                furthestDistance = distanceToGo;
                furthestGameObject = go;
            }
        }
    }
}

public enum HumanoidBehaviour                                                                     //Enumerador que contiene los comportamientos del zombie y ciudadano.
{
    Idle,
    Moving,
    Rotating,
    Reaction
}

public struct HumanoidInformation
{
    public HumanoidBehaviour hb;
    public float rotatingSpeed;
    public float movementSpeed;
}