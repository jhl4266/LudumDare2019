using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float speed;
    private float counter = 0;

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * -transform.forward * speed;
        counter += Time.deltaTime;
        if (counter > 30.0f) {
            Destroy(gameObject);
        }
    }
}
