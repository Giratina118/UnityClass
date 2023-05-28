using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarCoin : MonoBehaviour
{
    [SerializeField]
    protected float DestroySec = 3.0f;


    private void OnMouseDown()
    {
        Debug.Log("���� 1�� ä����");

        InGamePlayDatas.GetInstance().AddPlayerCoin(1);

        GameObject.Destroy(this.gameObject);
    }


    void Start()
    {
        GameObject.Destroy(this.gameObject, DestroySec);
    }


    void Update()
    {
        
    }
}
