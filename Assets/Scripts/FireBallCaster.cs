using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallCaster : MonoBehaviour
{

    public FireBall fireballPrefab;
    public Transform fireballSourceTransform;
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Instantiate(fireballPrefab, fireballSourceTransform.position, fireballSourceTransform.rotation);
        }
    }
}
