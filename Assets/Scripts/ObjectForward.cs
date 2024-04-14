using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectForward : MonoBehaviour
{
    public float speed;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
        if (transform.position.z < -15)
        {
            Destroy(gameObject);
        }
    }
}
