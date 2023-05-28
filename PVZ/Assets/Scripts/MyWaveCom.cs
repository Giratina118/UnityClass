using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class WaveInfoData
{
    public float DelaySec = 2.0f;
    public int ZombieNum = 0;
}

public class MyWaveCom : MonoBehaviour
{
    public List<WaveInfoData> waveInfo = new List<WaveInfoData>();
    public List<Zombie> zombies = null;


    void ZombieCreate()
    {
        /*
        string loadpath = $"Zombie/Zombie{waveInfo.ZombieNum}"
        Zombie zombie = Resources.Load<Zombie>("Zombie/BaseZombie");
        Zombie cloneobj = GameObject.Instantiate(zombie);

        cloneobj.transform.position = zombieSpoonPos[Random.Range(0, zombieSpoonPos.Count)].position;
        */
    }

    void Awake()
    {
        
    }

    void Update()
    {
        
    }
}
