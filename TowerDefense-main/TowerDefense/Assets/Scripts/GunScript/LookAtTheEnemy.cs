using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTheEnemy : MonoBehaviour
{

    Quaternion neededRotation;
    [SerializeField] float rotationSpeed;
    float x;
    float y;
    float z;
    bool isEnemy;
    Transform body; //destination
    Transform enemyBody; //source
    Rigidbody rigidbody;
    GameObject enemy;
    public int sayac=0; //Obje destroy olmadan sayac = 0 olmal�
    public static float distance;
    // Start is called before the first frame update
    void Start()
    {
        body = this.GetComponent<Transform>();
        x = transform.rotation.x;
        y = transform.rotation.y;
        z = transform.rotation.z;
        rigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (isEnemy == true)
        {

            
            
            if(enemy != null) //e�er enemy null oldu�u durumlarda da referans alma kodu �al���rsa referans al�namaz ve hata d�ner. O nedenle burada bu kontrol� yap�yoruz.
            {
                enemyBody = enemy.GetComponent<Transform>();

                //direction = destination(enemy) - source(Our Gun)
                Vector3 direction = enemyBody.position - transform.position;

                //access our current rotation = Quaternion Look Rotation
                neededRotation = Quaternion.LookRotation(direction);

                //for slowly turn 
                transform.rotation = Quaternion.Slerp(this.transform.rotation, neededRotation, Time.deltaTime * rotationSpeed);
                
                distance = Vector3.Distance(enemyBody.position, transform.position);
                Debug.Log("Distance: " + distance);
            }
            
            

            //body.transform.LookAt(enemyBody);



            
        }
        

        
        

        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0); //bu kod sayesinde silah zemine yap���yor ve a�a�� yukar� bakm�yor.

    }

    

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Gun")) //kesisim noktas�nday�z demektir kesi�im noktas�nda �len objeler i�in static bir �l�m haberi gereklidir ki her yerden bilgi alabilelim.
        {
            sayac = 0;
            Debug.Log("Kesisim Bolgesinde");
            if (EnemyHp.isDead == true)
            {
                

                sayac = 0; //e�er �ld�yse sayac degerim 0 olsun ki tekrar fokus olabileyim
                Debug.Log("Kesisim Bolgesinde");
                EnemyHp.isDead = false;
                

            }
        }
        
        Debug.Log("Buraya girildi");
        
        //sayac 0 olursa ve o s�rada alan i�erisinde herhangi bir d��man yoksa sayac direk 1 olucak ve bir d��man �lene kadar silah kitlenecek.
        if (other.CompareTag("enemy") && sayac == 0)
        {

            
            Debug.Log("Buraya girildi");
            enemy = other.gameObject;
            isEnemy = true;
            sayac++;


        }
        /*else
        {
            isEnemy = false;
        }*/
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Buraya girildi");
        if (other.CompareTag("enemy"))
        {
            sayac = 0;
            Debug.Log("Buraya girildi Exit");
            enemy = other.gameObject;
            isEnemy = false;
        }
        /*else
        {
            isEnemy = false;
        }*/
    }
}
