using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSprite : MonoBehaviour
{
    protected GameObject m_LinkGameObj = null;


    private void OnMouseDown()
    {
        Debug.Log($"Å¬¸¯ Àû¿ëµÊ : {this.name} ");


        m_LinkGameObj = InGameSelectManager.GetInstance().ClonePlantResourceData();

        if (m_LinkGameObj != null)
        {
            m_LinkGameObj.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0.0f);
        }
            
    }

    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
