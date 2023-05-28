using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum E_PlantType
{
    SunFollower,    // 코인 1개짜리 해바라기
    //DoubleSubFollower,  // 코인 2개짜리 해바라기
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
            Debug.Log("현재 금액이 부족합니다.");
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
