using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockElement : MonoBehaviour
{

    [SerializeField]
    public bool m_ISMine;
    public int minecount = 0;
    public int mouseRight = 0;


    public void SetMine(bool p_ismine)
    {
        m_ISMine = p_ismine;
    }


    public void SetMouseClick()
    {
        Sprite img;
        if (m_ISMine)
        {
            img = ResourceManager.Instance.m_Boomber;
        }
        else
        {
            img = ResourceManager.Instance.m_Sprites[minecount];
        }
        GetComponent<SpriteRenderer>().sprite = img;
    }

    public void SetMouseRightClick()
    {
        Sprite img;
        img = ResourceManager.Instance.m_QuestList[mouseRight];
        GetComponent<SpriteRenderer>().sprite = img;
        mouseRight++;
        if (mouseRight >= 3)
            mouseRight = 0;
    }

    void Start()
    {
    }

    void Update()
    {

    }
}
