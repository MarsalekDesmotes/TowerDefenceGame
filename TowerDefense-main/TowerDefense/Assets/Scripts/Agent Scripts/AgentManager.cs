using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentManager : MonoBehaviour
{

    int i;
    // Dizi Yard�m�yla T�m Ajanlar Al�nacak
    public static int PiyadeCounter;
    public static int EnemyCounter;
    Transform SpawnYeri;
    public GameObject spawnPoint1;
    public NavMeshAgent[] Agent;
    public NavMeshAgent[] Tank;
    public NavMeshAgent[] Ucak;
    float zaman;

    
    public GameObject Tower;
    
    


    void Start()
    {
        

        SpawnYeri = spawnPoint1.GetComponent<Transform>();
        
        
        
        EnemyCounter = Agent.Length + Tank.Length + Ucak.Length;
    }


    public void AgentInstantiate()
    {
        

        switch (RoundController.roundChecker)
        {

            case 0:
                Debug.Log("Ca");
                break;

            case 1:

                while (RoundController.isSpawnEnemy)
                {

                    for (i = 0; i < Agent.Length -1 ; i++)
                    {
                        // Invoke("InstantiateAgent1", 4f);

                        if (zaman > 2f)
                        {


                            Instantiate(Agent[i], new Vector3(-78f, -0.72f, 32f), Quaternion.identity);
                            // Agent[i].transform.SetParent(SpawnYeri, false);
                            // Agent[i].SetDestination(Tower.transform.position);
                            // Agent[i].Warp(Tower.transform.position);

                            zaman = 0f;


                        


                            }




                    }





                    
                        if (i == Agent.Length-1)
                        {

                            RoundController.isSpawnEnemy = false;


                        }



                }
               /* for (int i = 0; i < Tank.Length; i++)
                {
                    
                    Instantiate(Tank[i], SpawnYeri);

                }
                for (int i = 0; i < Ucak.Length; i++)
                {
                    Instantiate(Ucak[i], SpawnYeri);

                } 
                */
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







            default:
                break;






        }




    }

    // Update is called once per frame
    void Update()
    {
        zaman += Time.deltaTime;
        if (RoundController.isSpawnEnemy)
        {

            AgentInstantiate();
           

        }
        
            
     


    }
}
