using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float speedRotate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spin();
    }
    void spin()
    {
        transform.Rotate(Vector3.forward * speedRotate * Time.deltaTime);
    }
}
