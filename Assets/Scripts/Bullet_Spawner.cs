using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Spawner : MonoBehaviour
{
    public GameObject bullet;
    public float spawnTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BulletSpawnLoop());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator BulletSpawnLoop()
    {
        yield return new WaitForSeconds(spawnTime);
        GameObject.Instantiate(bullet, transform.position, Quaternion.identity);
        StartCoroutine(BulletSpawnLoop());
    }
}
