using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentManager : MonoBehaviour
{
    // Dizi Yardýmýyla Tüm Ajanlar Alýnacak
    public static int EnemyCounter; 
    public Transform spawnPoint;
    public NavMeshAgent[] Agent;
    public NavMeshAgent[] Tank;
    public NavMeshAgent[] Ucak;
    
    public GameObject Tower;
    
    


    void Start()
    {
        EnemyCounter = Agent.Length + Tank.Length + Ucak.Length;
    }


    public void AgentInstantiate(int round)
    {

        switch (round)
        {

            case 1:
                for (int i = 0; i < Agent.Length; i++)
                {
                    Instantiate(Agent[i], spawnPoint);

                }
                for (int i = 0; i < Tank.Length; i++)
                {
                    Instantiate(Tank[i], spawnPoint);

                }
                for (int i = 0; i < Ucak.Length; i++)
                {
                    Instantiate(Ucak[i], spawnPoint);

                }

                break;
            case 2:
                //Instantiate
                break;
            case 3:
                //Instantiate
                break;
            case 4:
                //Instantiate
                break;














        }




    }

    // Update is called once per frame
    void Update()
    {
        for(int i =0; i < Agent.Length; i++)
        {
            Agent[i].SetDestination(Tower.transform.position);

        }
        for (int i = 0; i < Tank.Length; i++)
        {
            Tank[i].SetDestination(Tower.transform.position);

        }
        for (int i = 0; i < Ucak.Length; i++)
        {
            Ucak[i].SetDestination(Tower.transform.position);

        }


    }
}
