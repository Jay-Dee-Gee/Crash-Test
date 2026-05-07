using UnityEngine;

public class CrashDetection : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("There has been a collision with the crashdetection collider");
        if (collision.gameObject.CompareTag("Vehicle"))
        {
           Debug.Break();
           Application.Quit(); 
        }       
    }
}
