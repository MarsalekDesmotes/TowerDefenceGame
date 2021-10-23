using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShoot : MonoBehaviour
{
    ShootControl shootControl;
    [SerializeField] GameObject pointerShootControl;
    Rigidbody rigidbody;
    Transform GunTransform; 
    public float time = 0f;
    [SerializeField] float speed;
    isGround isGround;
    GameObject respawns;

    [SerializeField] GameObject isGroundPointer;

    private void Start()
    {
        

        shootControl = pointerShootControl.GetComponent<ShootControl>();
        rigidbody = GetComponent<Rigidbody>();

        //GunTransform = GetComponent<Transform>();

        GunTransform = GameObject.Find("GunRotation").GetComponent<Transform>();



    }

    private void Update()
    {
        //rigidbody.constraints = RigidbodyConstraints.FreezeRotationZ;
        
        shoot();
        
        /*if (Input.GetMouseButtonDown(0))
        {
            shoot();
        }*/
    }

    public void shoot()
    {
        if (time < 0.1) //velocity'nin etki edece�i s�re
        {
            
            time += Time.deltaTime;
            //Burada neden transform de�erini mermiden de�il de silahtan ald�k:
            //��nk� mermi hareket halindeyken unity uzay�nda yer �ekimi kuvvetine maruz kal�r ve top'un y�n� s�rekli olarak de�i�ir bu nedenle top d�zensiz hareketler sergiler.
            Vector3 a = new Vector3(-GunTransform.forward.x, 0f, -GunTransform.forward.z); //Topun karsiya gitmesini saglayan z.
            //Vector3 a = new Vector3(-GunRotation.gunTransform.forward.x, 0f, -GunRotation.gunTransform.forward.z);
            rigidbody.velocity = a * speed;
            
        }
        
    }
}
