using Unity.VisualScripting;
using UnityEngine;

public class Driver : MonoBehaviour 
{
    [SerializeField] float steerSpeed = 300f;
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float slowSpeed = 10f;
    [SerializeField] float boostSpeed = 30f;

    void Start()
    {
        
    }

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

        void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Boost")
        {
            Debug.Log("WAHHOOOOO");
            moveSpeed = boostSpeed;
        }
    }
        void OnCollisionEnter2D (Collider2D other)
    {
        if (other.tag == "Obstacle")
        {
            Debug.Log("Slowdown son");
            moveSpeed = slowSpeed;
        }
    }
}

