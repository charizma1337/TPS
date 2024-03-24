using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallCaster : MonoBehaviour
{
    public FireBall fireballPrefab;
    public Transform fireballSourceTransform;

    public float fireRate = 1.0f; // Частота выстрелов в секунду
    private float nextFireTime = 0.0f; // Время следующего выстрела

    private void Update()
    {
        if (Input.GetMouseButton(0) && Time.time > nextFireTime)
        {
            nextFireTime = Time.time + (1 / fireRate);
            Instantiate(fireballPrefab, fireballSourceTransform.position, fireballSourceTransform.rotation);
        }
    }
}