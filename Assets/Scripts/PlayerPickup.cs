using UnityEngine;



public class PlayerPickup : MonoBehaviour
{
    
    [HideInInspector] public int numberOfGold;
    [HideInInspector] public int numberOfCrystal;

    void Start()
    {
        numberOfGold = 0;
        numberOfCrystal = 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Gold")  //(other.gameObject.CompareTag("Player")
        {
            other.gameObject.SetActive(false);
            // Destroy(other.gameObject);

            numberOfGold++;
        }

        if (other.gameObject.tag == "Crystal")  //(other.gameObject.CompareTag("Player")
        {
            other.gameObject.SetActive(false);
            //            Destroy(other.gameObject);

            numberOfCrystal++;
        }

        if(other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
        }
    }
    
}