using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotFollower : MonoBehaviour
{
    public float DelaySec = 1.0f;
    public Transform ChildBulletPos = null;


    IEnumerator PlantsShotCortinue()
    {
        while(true)
        {
            yield return new WaitForSeconds(DelaySec);
            Shot();
        }
    }

    void Shot()
    {
        Plant_Bullet bullet = Resources.Load<Plant_Bullet>("Bullet");
        Plant_Bullet cloneobj = GameObject.Instantiate(bullet);
        cloneobj.transform.position = ChildBulletPos.position;

    }

    private void Awake()
    {
        ChildBulletPos = this.transform.Find("BulletPos");
    }

    void Start()
    {
        StartCoroutine(PlantsShotCortinue());
    }


    void Update()
    {
        
    }
}
