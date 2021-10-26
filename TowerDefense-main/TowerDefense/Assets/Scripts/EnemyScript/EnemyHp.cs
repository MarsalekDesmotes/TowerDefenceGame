using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{

    LookAtTheEnemy lookAtTheEnemy;
    

    public static bool isDead;

    public static float tekMermiTekHasarSayac� = 0;
    public float characterHp = 1000;
    // Start is called before the first frame update
    void Start()
    {

        isDead = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "projectile") //gelen mermi tag'� hangisiyse ona g�re damage vurmas� ayarlanabilir.
        {
            Debug.Log("characterHp: " + characterHp); //Bilgisayar h�z�na ba�l� olarak bu b�lgede birden �ok kare tekrar edebilir ve her bilgisayar�n h�z�na ba�l� olarak d�zensiz hp d���r�r bunun �n�ne ge�mek i�in bu kod sat�rlar� her mermide bir defa �al��s�n diye yukardaki saya� parametresini kullad�k.
            characterHp -= 25; //gelen mermi tag'� hangisiyse ona g�re damage vurmas� ayarlanabilir.
            if (characterHp <= 0)
            {
                //sadece bir d��mana fokus olmay� sa�layan sayac                
                Destroy(this.gameObject);
                isDead = true;
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "projectile") //gelen mermi tag'� hangisiyse ona g�re damage vurmas� ayarlanabilir.
        {
            Debug.Log("characterHp: " + characterHp); //Bilgisayar h�z�na ba�l� olarak bu b�lgede birden �ok kare tekrar edebilir ve her bilgisayar�n h�z�na ba�l� olarak d�zensiz hp d���r�r bunun �n�ne ge�mek i�in bu kod sat�rlar� her mermide bir defa �al��s�n diye yukardaki saya� parametresini kullad�k.
            characterHp -= 25; //gelen mermi tag'� hangisiyse ona g�re damage vurmas� ayarlanabilir.
            if (characterHp <= 0)
            {
                //sadece bir d��mana fokus olmay� sa�layan sayac                
                Destroy(this.gameObject);
                isDead = true;
            }

        }
    }
}
