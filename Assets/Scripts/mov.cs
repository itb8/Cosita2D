using UnityEngine;

public class mov : MonoBehaviour
{

    float speed = 50f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0);
        this.transform.position = this.transform.position + movement * speed * Time.deltaTime;
        
    }
}
