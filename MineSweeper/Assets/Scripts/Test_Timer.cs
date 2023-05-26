using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Test_Timer : MonoBehaviour
{
    public int m_TimerMin = 0; 
    public int m_TimerSec = 0;

    private void Awake()
    {
        StartCoroutine(TimerCoroutine());
    }

    int count = 0;
    IEnumerator TimerCoroutine()
    {
        while (true)
        {
            this.GetComponent<TMP_Text>().text = $"Timer  {m_TimerMin}:{m_TimerSec++}";

            yield return new WaitForSeconds(1.0f);

            if (m_TimerSec == 60)
            {
                m_TimerSec = 0;
                m_TimerMin++;
            }
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
