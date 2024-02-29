using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{

    public float speed;
    public float lifetime;

    private void FixedUpdate()
    {
       MoveFixedUpdate();
    }

    private void MoveFixedUpdate()
    {
        transform.position += transform.forward * speed * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        DestroyFireBall();
    }

    private void DestroyFireBall()
    {
        Destroy(gameObject);
    }

    private void Start()
    {
        Invoke ("DestroyFireBall", lifetime);
    }

}
