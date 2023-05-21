using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BlockElement m_CloneBlockElement = null;

    public int XSize = 6, YSize = 6;

    public Camera LinkCam = null;
    public bool[,] isMineArr;
    public int[,] aroundMine;
    public BlockElement[,] AllBlockElementArr = null;
    bool[,] blockOpenChecked;

    protected void InitMineSeeting()
    {
        isMineArr = new bool[YSize, XSize];
        aroundMine = new int[YSize, XSize];

        for (int y = 0; y < YSize; y++)
            for (int x = 0; x < XSize; x++)
                isMineArr[y, x] = false;

        int mineNum = XSize * YSize / 10 + 1;
        
        for (int i = 0; i < mineNum; i++)
        {
            int mineX = Random.Range(0, XSize - 1);
            int mineY = Random.Range(0, YSize - 1);
            
            if (isMineArr[mineX, mineY])
            {
                i--;
                continue;
            }
            else
                isMineArr[mineX, mineY] = true;
        }

        for (int y = 0; y < YSize; y++)
            for (int x = 0; x < XSize; x++)
                AllBlockElementArr[y, x].SetMine(isMineArr[y, x]);

    }

    bool IsBlock(int x, int y)
    {
        if (y >= YSize || y < 0)
            return false;
        else if (x >= XSize || x < 0)
            return false;

        return true;
    }

    int AroundMine(int y, int x)
    {
        int mineCount = 0;

        
        if (IsBlock(y + 1, x + 1) && isMineArr[y + 1, x + 1])
            mineCount++;
        if (IsBlock(y + 1, x) && isMineArr[y + 1, x])
            mineCount++;
        if (IsBlock(y + 1, x - 1) && isMineArr[y + 1, x - 1])
            mineCount++;

        if (IsBlock(y, x + 1) && isMineArr[y, x + 1])
            mineCount++;
        if (IsBlock(y, x - 1) && isMineArr[y, x - 1])
            mineCount++;

        if (IsBlock(y - 1, x + 1) && isMineArr[y - 1, x + 1])
            mineCount++;
        if (IsBlock(y - 1, x) && isMineArr[y - 1, x])
            mineCount++;
        if (IsBlock(y - 1, x - 1) && isMineArr[y - 1, x - 1])
            mineCount++;

        return mineCount;
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
                    int y = (int)element.transform.position.y;
                    int x = (int)element.transform.position.x;

                    Debug.Log($"ºÎµúÈû {YSize - 1 - y} {x}");

                    /*
                    int mineCount = AroundMine(YSize - 1 - y, x);

                    if (element.m_ISMine)
                        Debug.Log("Áö·Ú");
                    else
                        Debug.Log($"±ÙÃ³ Áö·Ú °³¼ö {mineCount}");
                    AllBlockElementArr[XSize - 1 - x, y].minecount = mineCount;
                    */

                    //AllBlockElementArr[XSize - 1 - x, y].SetMouseClick();
                    //BlockOpen(XSize - 1 - x, y);

                    if (AllBlockElementArr[XSize - 1 - x, y].m_ISMine)
                        AllBlockElementArr[XSize - 1 - x, y].SetMouseClick();
                    BlockOpenProcess(XSize - 1 - x, y);
                }
                else
                {
                    Debug.Log($"Àß¸ø ´­·È½À´Ï´Ù. ");
                }
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Ray ray = LinkCam.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitinfo;
            if (Physics.Raycast(ray, out hitinfo, 999f))
            {
                BlockElement element = hitinfo.transform.GetComponent<BlockElement>();
                if (element != null)
                {
                    int y = (int)element.transform.position.y;
                    int x = (int)element.transform.position.x;
                    AllBlockElementArr[XSize - 1 - x, y].SetMouseRightClick();
                }
            }
        }
    }

    

    void BlockOpen(int x, int y)
    {
        BlockOpenProcess(x, y + 1);
        BlockOpenProcess(x - 1, y);
        BlockOpenProcess(x, y - 1);
        BlockOpenProcess(x + 1, y);
    }



    void BlockOpenProcess(int x, int y)
    {
        if (IsBlock(x, y) && !blockOpenChecked[x, y] && !AllBlockElementArr[x, y].m_ISMine)
        {
            AllBlockElementArr[x, y].minecount = AroundMine(x, y);
            AllBlockElementArr[x, y].SetMouseClick();
            blockOpenChecked[x, y] = true;

            if (AllBlockElementArr[x, y].minecount == 0)
            {
                
                BlockOpen(x, y);
                //yield return StartCoroutine(OpenCoroutine());
            }
                
        }
    }

    private IEnumerator OpenCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
    }


    public void _On_RestartGame()
    {

    }

    protected RectTransform m_GameOverPanel = null;
    public void GameOver()
    {
        //m_GameOverPanel
    }


    void Start()
    {
        blockOpenChecked = new bool[YSize, XSize];
        for (int x = 0; x < XSize; x++)
            for (int y = 0; y < YSize; y++)
                blockOpenChecked[y, x] = false;
    }


    void Update()
    {
        UpdateClick();
    }
}
