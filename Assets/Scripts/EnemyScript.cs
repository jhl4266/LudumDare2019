using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject projectile;

    void Start()
    {
        transform.parent = GameObject.Find("LevelManager").transform;
    }

    void OnNewBeat()
    {
        if (Random.Range(0, 100.0f) < 3.0f)
        {
            FireProjectile();
        }
    }

    void FireProjectile()
    {
        Instantiate(projectile, transform.position, transform.rotation);
    }
}
