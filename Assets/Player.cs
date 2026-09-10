using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 5f;
     

   void Start()
    {
        transform.position = new Vector3(0, 0, 0); //detects and updates movement frame by frame
    }

    // Update is called once per frame
    void Update()
    {
       Move();
    }

    void Move() // Input functions for player movement
    {
    float horizontalInput = Input.GetAxis("Horizontal");
    float verticalInput = Input.GetAxis("Vertical");

    transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
    transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
    }
    
}
