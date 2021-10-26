using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumProjectileCreator : MonoBehaviour
{

    [SerializeField] Transform newprojectilePosition;
    [SerializeField] GameObject MediumProjectile; //mermi
    ProjectileShoot projectileShootMedium;
    [Range(0,2)]
    [SerializeField] float attackSpeed;
    float time;
    float projectileLifeCycle;
    bool controlEnemy; //alan i�ersinde d��man varsa mermi �retilecek

    // Start is called before the first frame update
    void Start()
    {
        projectileShootMedium = MediumProjectile.GetComponent<ProjectileShoot>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        

        
    }

    //Buraya yazmay� g�zden ge�ir kasmaya neden olabilir.
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            controlEnemy = true;
            if (time > attackSpeed)
            {
                projectileShootMedium.time = 0f;
                Debug.Log("Mermi �retildi");
                Instantiate(MediumProjectile, transform.position, transform.rotation);
                time = 0;

                //EnemyHp.tekMermiTekHasarSayac� = 0;
            }

        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            controlEnemy = false;
        }
    }
}
