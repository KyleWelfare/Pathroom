using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float minSpeed;

    [SerializeField] private float xMax;
    void Awake()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }

    void Update()
    {
        if (transform.position.x >= xMax)
        {
            Destroy(gameObject);
        }             
    }

    void FixedUpdate()
    {        
        transform.position = new Vector2((transform.position.x + speed), transform.position.y);
    }
}
