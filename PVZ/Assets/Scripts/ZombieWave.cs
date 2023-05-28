using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieWave : MonoBehaviour
{
    public float DelaySec = 3.0f;
    public List<Transform> zombieSpoonPos = null;
    
    IEnumerator ZombieCortinue()
    {
        while (true)
        {
            yield return new WaitForSeconds(DelaySec);
            ZombieCreate();
        }
    }

    void ZombieCreate()
    {
        Zombie zombie = Resources.Load<Zombie>("Zombie/BaseZombie");
        Zombie cloneobj = GameObject.Instantiate(zombie);

        cloneobj.transform.position = zombieSpoonPos[Random.Range(0, zombieSpoonPos.Count)].position;
    }

    void Awake()
    {
        StartCoroutine(ZombieCortinue());
    }

    void Update()
    {
        
    }
}
