using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum E_PlantType
{
    SunFollower,    // ���� 1��¥�� �عٶ��
    //DoubleSubFollower,  // ���� 2��¥�� �عٶ��
    ShotFollower,
    MAX,
}

public class InGameSelectManager : SingleTon_Mono<InGameSelectManager>
{
    public E_PlantType SelectPlantType = E_PlantType.MAX;


    public GameObject ClonePlantResourceData()
    {
        string loadpath = $"Temp_{SelectPlantType}";
        GameObject resourceobj = Resources.Load(loadpath) as GameObject;


        PlantsInfoData infodata = resourceobj.GetComponent<PlantsInfoData>();
        int coin = InGamePlayDatas.GetInstance().GetCoin();
        if (coin < infodata.UseCoin)
        {
            Debug.Log("���� �ݾ��� �����մϴ�.");
            return null;
        }




        GameObject cloneobj = null;
        if (resourceobj != null)
        {
            cloneobj = GameObject.Instantiate(resourceobj);
        }

        InGamePlayDatas.GetInstance().AddPlayerCoin(-infodata.UseCoin);

        return cloneobj;
    }
    

    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
