using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShoot : MonoBehaviour
{
    new Rigidbody rigidbody;   
    public float time = 0f;
    [SerializeField] float speed;   
    
    float projectileLifeCycle;
    [Range(0, 5)]
    [SerializeField] float ayarlaSil;

    //so bad, medium , very low , hard
    public enum SelectGun
    {
        soBad,veryLow, low,medium,hard,veryHard
    }



    [SerializeField]SelectGun selectGun;

    private void Start()
    {


        
        rigidbody = GetComponent<Rigidbody>();

        //GunTransform = GetComponent<Transform>();

        if (selectGun == SelectGun.veryLow)
        {
            //ozelle�tirme
        }
        if (selectGun == SelectGun.low)
        {
            //ozelle�tirme
        }
        if(selectGun == SelectGun.medium)
        {
            //ozelle�tirme
        }
        if (selectGun == SelectGun.hard)
        {
            //ozelle�tirme
        }







    }

    private void Update()
    {
        
        
        shoot();
        
        
    }

    public void shoot()
    {
        if (time < 0.1) //velocity'nin etki edece�i s�re
        {
            
            time += Time.deltaTime;
            //Burada neden transform de�erini mermiden de�il de silahtan ald�k:
            //��nk� mermi hareket halindeyken unity uzay�nda yer �ekimi kuvvetine maruz kal�r ve top'un y�n� s�rekli olarak de�i�ir bu nedenle top d�zensiz hareketler sergiler.

            if (selectGun == SelectGun.soBad)
            {
                Vector3 a = new Vector3(-transform.forward.x, -0.1f, -transform.forward.z); //Topun karsiya gitmesini saglayan z.
                                                                                            //Vector3 a = new Vector3(-GunRotation.gunTransform.forward.x, 0f, -GunRotation.gunTransform.forward.z);
                rigidbody.velocity = a * speed * LookAtTheEnemy.distance;
            }

            if (selectGun == SelectGun.veryLow)
            {
                Vector3 a = new Vector3(transform.forward.x, ayarlaSil, transform.forward.z); //Topun karsiya gitmesini saglayan z.
                                                                                         //Vector3 a = new Vector3(-GunRotation.gunTransform.forward.x, 0f, -GunRotation.gunTransform.forward.z);
                rigidbody.velocity = a * speed * LookAtTheEnemy.distance; //uzakl�kla do�ru orant�l� at�� h�z� artar
            }
            if (selectGun == SelectGun.low)
            {
                Vector3 a = new Vector3(transform.forward.x, -0.05f, transform.forward.z); //Topun karsiya gitmesini saglayan z.
                                                                                           //Vector3 a = new Vector3(-GunRotation.gunTransform.forward.x, 0f, -GunRotation.gunTransform.forward.z);
                rigidbody.velocity = a * speed * LookAtTheEnemy.distance;
                
            }
            if (selectGun == SelectGun.medium)
            {
                Vector3 a = new Vector3(transform.forward.x, -0.1f, transform.forward.z); //Topun karsiya gitmesini saglayan z.
                                                                                               //Vector3 a = new Vector3(-GunRotation.gunTransform.forward.x, 0f, -GunRotation.gunTransform.forward.z);
                rigidbody.velocity = a * speed *LookAtTheEnemy.distance;
            }

            

            if (selectGun == SelectGun.hard)
            {
                Vector3 a = new Vector3(transform.forward.x, -0.1f, transform.forward.z); //Topun karsiya gitmesini saglayan z.
                                                                                          //Vector3 a = new Vector3(-GunRotation.gunTransform.forward.x, 0f, -GunRotation.gunTransform.forward.z);
                rigidbody.velocity = a * speed * LookAtTheEnemy.distance;
                
            }


        }

        if(selectGun != SelectGun.veryLow) //VeryLow Kategorisindeki silah havan oldu�u i�in ona daha uzun s�re vermeliyiz
        {
            projectileLifeCycle += Time.deltaTime;

            if (projectileLifeCycle > 1)
            {
                Destroy(this.gameObject);
                projectileLifeCycle = 0;
            }
        }
        if (selectGun == SelectGun.veryLow) //VeryLow Kategorisindeki silah havan oldu�u i�in ona daha uzun s�re vermeliyiz
        {
            projectileLifeCycle += Time.deltaTime;

            if (projectileLifeCycle > 3)
            {
                Destroy(this.gameObject);
                projectileLifeCycle = 0;
            }
        }




    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            Destroy(this.gameObject);
        }
        if(collision.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
    }
}
