using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public List<Sprite> m_Sprites = new List<Sprite>();
    public Sprite m_Boomber = null;
    public List<Sprite> m_QuestList = new List<Sprite>();


    protected static ResourceManager m_Instance = null;
    public static ResourceManager Instance
    {
        get
        {
            if( m_Instance == null )
            {
                m_Instance = GameManager.FindObjectOfType<ResourceManager>();
            }
            return m_Instance;
        }
    }



    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
