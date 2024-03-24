using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeCaster : MonoBehaviour
{
    public Rigidbody grenadePrefab;
    public Transform grenadeSource;

    public float force = 10;
    public float delay = 1.0f; // Задержка между выстрелами в секундах

    private float lastShotTime = 0; // Время последнего выстрела

    void Update()
    {
        if (Input.GetMouseButton(1) && Time.time > lastShotTime + delay)
        {
            var grenade = Instantiate(grenadePrefab);
            grenade.transform.position = grenadeSource.position;
            grenade.GetComponent<Rigidbody>().AddForce(grenadeSource.forward * force);

            lastShotTime = Time.time; // Обновляем время последнего выстрела
        }
    }
}