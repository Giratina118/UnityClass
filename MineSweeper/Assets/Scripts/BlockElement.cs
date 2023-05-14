using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockElement : MonoBehaviour
{

    [SerializeField]
    public bool m_ISMine;



    public void SetMine(bool p_ismine)
    {
        m_ISMine = p_ismine;
    }


    void Start()
    {
    }

    void Update()
    {

    }
}
