using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] Transform newprojectilePosition;
    [SerializeField] GameObject soBadProjectile; //mermi
    ProjectileShoot projectileShootSoBad;
    [Range(0, 2)]
    [SerializeField] float attackSpeed;
    float time;
    bool controlEnemy; //alan i�ersinde d��man varsa mermi �retilecek
    

    // Start is called before the first frame update
    void Start()
    {
        projectileShootSoBad = soBadProjectile.GetComponent<ProjectileShoot>(); //hard projectile i�ersindeki zamana ula�mak i�in
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            controlEnemy = true;
            if (time > attackSpeed)
            {
                projectileShootSoBad.time = 0f;
                Instantiate(soBadProjectile, transform.position, transform.rotation);
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
