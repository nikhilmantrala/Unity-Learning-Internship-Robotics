using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    new MeshRenderer renderer;
    new Rigidbody rigidbody;
    
    [SerializeField] private float timeToWait = 3f;


    private void Start() {
        renderer = GetComponent<MeshRenderer>();
        rigidbody = GetComponent<Rigidbody>();

        renderer.enabled = false;
        rigidbody.useGravity = false;
    }
   // Update is called once per frame
    void Update()
    {
        if (Time.time >= timeToWait) 
        {
            //Debug.Log("3 seconds have elapsed");
            renderer.enabled = true;
            rigidbody.useGravity = true;
        }
    }
}
