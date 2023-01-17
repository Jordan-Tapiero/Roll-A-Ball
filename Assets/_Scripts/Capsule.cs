using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Capsule : MonoBehaviour
{
    public GameObject prefab;
    public int x;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < x; i++)
        {
            spawnIn();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    void spawnIn()
    {
        GameObject a = Instantiate(prefab) as GameObject;
        a.transform.position = new Vector3(Random.Range(-8, 8), 1, Random.Range(-8, 8));

    }
}
