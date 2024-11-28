using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 noPackageColour = new Color32 (1,1,1,1);
    [SerializeField] Color32 hasPackageColour = new Color32 (1,1,1,1);
    [SerializeField] float destroyDelay = 0.1f;
   bool hasPackage;

   SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Ouch");
    }
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package Aquired");
            hasPackage = true;
            spriteRenderer.color = hasPackageColour;
            Destroy(other.gameObject, destroyDelay);
        }
        else if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package Derrivered");
            hasPackage = false;
            spriteRenderer.color = noPackageColour;
        }
    }
}
