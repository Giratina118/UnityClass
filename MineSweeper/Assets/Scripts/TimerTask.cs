using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using TMPro;

public class TimerTask : MonoBehaviour
{
    public int m_TimerSec = 0;

    public async void UpdateTimer()
    {
        while (true)
        {
            await Task.Delay(1000);
            this.GetComponent<TMP_Text>().text = $"Timer: {m_TimerSec++}";
        }
        

    }


    void Start()
    {
        UpdateTimer();
    }


    void Update()
    {
        
    }
}
