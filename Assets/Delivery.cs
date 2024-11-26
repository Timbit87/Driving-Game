using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] float destroyDelay = 0.1f;
   bool hasPackage;

    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Ouch");
    }
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Package" && !hasPackage)
        {
            hasPackage = true;
            Debug.Log("Package Aquired");
            Destroy(other.gameObject, destroyDelay);
        }
        else if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Customer squished");
            hasPackage = false;
        }
    }
}
