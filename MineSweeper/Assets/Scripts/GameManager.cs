using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BlockElement m_CloneBlockElement = null;

    public int XSize = 4, YSize = 4;

    public Camera LinkCam = null;
    public bool[,] isMineArr;
    public int[,] aroundMine;
    public BlockElement[,] AllBlockElementArr = null;

    int mineCount = 0;

    protected void InitMineSeeting()
    {
        isMineArr = new bool[YSize, XSize];
        aroundMine = new int[YSize, XSize];


        for (int y = 0; y < YSize; y++)
        {
            for (int x = 0; x < XSize; x++)
            {
                isMineArr[y, x] = false;
            }
        }


        if (true)
        {
            isMineArr[1, 2] = true;
        }


        for (int y = 0; y < YSize; y++)
        {
            for (int x = 0; x < XSize; x++)
            {
                AllBlockElementArr[y, x].SetMine(isMineArr[y, x]);
            }
        }

    }



    void AroundMine(int y, int x)
    {
        mineCount = 0;

        if (y + 1 < YSize && x + 1 < XSize && isMineArr[y + 1, x + 1])
            mineCount++;
        if (y + 1 < YSize && isMineArr[y + 1, x])
            mineCount++;
        if (y + 1 < YSize && x - 1 >= 0 && isMineArr[y + 1, x - 1])
            mineCount++;

        if (x + 1 < XSize && isMineArr[y, x + 1])
            mineCount++;
        if (x - 1 >= 0 && isMineArr[y, x - 1])
            mineCount++;

        if (y - 1 >= 0 && x + 1 < XSize && isMineArr[y - 1, x + 1])
            mineCount++;
        if (y - 1 >= 0 && isMineArr[y - 1, x])
            mineCount++;
        if (y - 1 >= 0 && x - 1 >= 0 && isMineArr[y - 1, x - 1])
            mineCount++;

    }

    private void Awake()
    {
        CreateMine();
        InitMineSeeting();
        CenterCamsraPos();
    }


    void CenterCamsraPos()
    {
        float offsetSizeX = (float)XSize * 0.5f - 0.5f;
        float offsetSizeY = (float)YSize * 0.5f - 0.5f;

        LinkCam.transform.position = new Vector3(offsetSizeX, offsetSizeY, LinkCam.transform.position.z);

    }

    void CreateMine()
    {
        AllBlockElementArr = new BlockElement[YSize, XSize];
        for (int y = 0; y < YSize; y++)
        {
            for (int x = 0; x < XSize; x++)
            {
                Vector3 pos = new Vector3(YSize - 1 - y, x, 0);
                BlockElement cloneobj = GameObject.Instantiate(m_CloneBlockElement, pos, Quaternion.identity);

                cloneobj.name = $"Mine_[{y},{x}]";
                AllBlockElementArr[y, x] = cloneobj;

            }
        }
    }

    
    void UpdateClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = LinkCam.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitinfo;
            if (Physics.Raycast(ray, out hitinfo, 999f))
            {
                BlockElement element = hitinfo.transform.GetComponent<BlockElement>();
                if (element != null)
                {
                    Debug.Log($"ºÎµúÈû {YSize - 1 - (int)element.transform.position.y} {(int)element.transform.position.x}");

                    AroundMine(YSize - 1 - (int)element.transform.position.y, (int)element.transform.position.x);


                    if (element.m_ISMine)
                        Debug.Log("Áö·Ú");
                    else
                        Debug.Log($"±ÙÃ³ Áö·Ú °³¼ö {mineCount}");

                    Sprite img = ResourceManager.Instance.m_QuestList[mineCount];


                }
                else
                {
                    Debug.Log($"Àß¸ø ´­·È½À´Ï´Ù. ");
                }

            }

        }
    }


    


    void Start()
    {
        
    }


    void Update()
    {
        UpdateClick();

    }
}
