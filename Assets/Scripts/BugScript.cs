using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugScript : MonoBehaviour
{

    public float speed = 1.0f;
    public Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        // rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // transfrom.Translate(Vestor3.lert * (-1) * speed *Time.deltaTime);

        // if (transfrom.position.x < lertBound)
        // {
        //     transfrom.Translate(Vestor3.right * (1) * speed *Time.deltaTime);
        // }else if(transfrom.position.x > rightBound){
        //     transfrom.Translate(Vestor3.right * (-1) * speed *Time.deltaTime);
        // }
    }
}
