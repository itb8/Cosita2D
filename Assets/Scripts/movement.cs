using UnityEngine;

public class movement : MonoBehaviour
{
    float speed = 20f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");
        Vector3 inputs = new Vector3(horizInput, vertInput, 0);

        this.transform.position = this.transform.position + inputs * speed * Time.deltaTime;
        
    }
}
