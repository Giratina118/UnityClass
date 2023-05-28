using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGamePlayDatas : SingleTon_Mono<InGamePlayDatas>
{
    [SerializeField]
    protected int m_PlayerCoin = 50;


    public void AddPlayerCoin(int p_coin)
    {
        m_PlayerCoin += p_coin;

    }

    public int GetCoin()
    {
        return m_PlayerCoin;
    }

    void Start()
    {

    }

    void Update()
    {
        
    }
}
