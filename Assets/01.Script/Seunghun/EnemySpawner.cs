using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using static ChessSpawnArrowEnum;

public class Wave
{
    public string type;
    public string keyboardArrow;
    public bool multi;
    public int childCount;
}
public class EnemySpawner : MonoBehaviour
{
    private enum ChessMal { Pawn, Knight, Bishop, Rook, King, Queen };

    ChessMal chessState = ChessMal.Pawn;

    public bool isSpawn;
    public ChessArrow arrow;
    private List<TextAsset> testList = new List<TextAsset>();
    private void Awake()
    {
        for (int i = 0; i < Directory.GetFiles($"Assets/Resources/{HighScoreManager.timerCheck}").Length / 2; i++)
        {
            TextAsset item = Resources.Load($"{HighScoreManager.timerCheck}/{i + 1}") as TextAsset;
            testList.Add(item);
        }
        SpawnChaebo();
    }
    public List<GameObject> monsterMob = new List<GameObject>();


    private Grid grid;
    public float cellSize;

    private int[,] arr;

    private int[,] gridArray;
    void Start()
    {

        grid = new Grid(5, 5, cellSize, new Vector3(transform.position.x, transform.position.y));

        gridArray = new int[5, 5];

    }



    public List<Wave> spawnList = new List<Wave>();
    public int spawnIndex; //다음녀석 다음녀석
    public bool spawnEnd;

    double currentTime = 0d;


    bool isMultiSPawn = true;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (isSpawn == false)
        {
            return;
        }
        currentTime += Time.deltaTime;

        if (currentTime >= (60f / Sync_Gijoo.Instance.realMusicBpm) && !spawnEnd && isMultiSPawn && isRead)
        {
            MonsterSpawn();
            currentTime -= 60f / Sync_Gijoo.Instance.realMusicBpm;

        }
        else if (spawnEnd && isRead)
        {
            SpawnChaebo();
        }
    }

    public void SpawnChaebo()
    {
        int ran = Random.Range(0, testList.Count);
        Debug.Log(ran + 1);
        ReadSpawnFile(ran);
    }

    bool isRead;
    void ReadSpawnFile(int patern)
    {
        isRead = false;
        spawnList.Clear(); //모두 클리어

        spawnIndex = 0;
        spawnEnd = false; //변수 초기화

        StringReader stringReader = new StringReader(testList[patern].text); //파일 내의 문자열 읽기 클래스

        
        while (stringReader != null)
        {
            string line = stringReader.ReadLine(); //한줄씩 반환


            if (line == null)
            {
                break;
            }
            Wave spawnData = new Wave();
            spawnData.type = line.Split(',')[0];
            spawnData.keyboardArrow = line.Split(',')[1];
            spawnData.multi = bool.Parse(line.Split(',')[2]);
            spawnData.childCount = int.Parse(line.Split(',')[3]);
            spawnList.Add(spawnData);
        }

        //#. 텍스트 파일 닫기
        stringReader.Close();


        isRead = true;
    }

    private bool isMulti;
    private int count;
    void MonsterSpawn()
    {

        if (isMultiSPawn == false) return;

        isMulti = spawnList[spawnIndex].multi;

        if (isMulti == true)
        {
            isMulti = false;
            isMultiSPawn = false;
            count = spawnList[spawnIndex].childCount;
            for (int i = 0; i < count; i++)
            {
                int enemyIndex = 0;
                SelectChess(ref enemyIndex);

                if (enemyIndex == 5)
                {
                    spawnIndex++;
                    if (spawnIndex == spawnList.Count)
                    {
                        spawnEnd = true;
                        return;
                    }
                    return;
                }

                GameObject enemy = monsterMob[enemyIndex];

                int X = 0;
                int Y = 0;

                KeyBoardArrowSW(ref X, ref Y);

                Vector2 monsterSpawnPostion;
                Vector2 monsterPostionSet;
                
                monsterSpawnPostion = grid.GetWorldPosition(X, Y);
                monsterPostionSet = new Vector2(monsterSpawnPostion.x + 0.5f, monsterSpawnPostion.y + 0.5f);
                

                GameObject enmeyObj =  Instantiate(enemy, monsterPostionSet, Quaternion.identity);

                IArrow arr = enmeyObj.GetComponent<IArrow>();

                if (arr != null)
                {
                    arr.ArrowCopySW(arrow);
                }
                spawnIndex++;



                if (spawnIndex == spawnList.Count)
                {
                    spawnEnd = true;
                    isMultiSPawn = true;
                    return;
                }

            }
            isMultiSPawn = true;

        }
        else
        {
            int enemyIndex = 0;

            SelectChess(ref enemyIndex);

            if (enemyIndex == 5)
            {
                spawnIndex++;


                if (spawnIndex == spawnList.Count)
                {
                    spawnEnd = true;
                    return;
                }
                return;
            }
            GameObject enemy = monsterMob[enemyIndex];
            int X = 0;
            int Y = 0;


            KeyBoardArrowSW(ref X, ref Y);


            Vector2 monsterSpawnPostion = grid.GetWorldPosition(X, Y);
            Vector2 monsterPostionSet = new Vector2(monsterSpawnPostion.x + 0.5f, monsterSpawnPostion.y + 0.5f);
            
            GameObject enmeyObj = Instantiate(enemy, monsterPostionSet, Quaternion.identity);

            IArrow arr = enmeyObj.GetComponent<IArrow>();

            if (arr != null)
            {
                arr.ArrowCopySW(arrow);
            }

            spawnIndex++;

            if (spawnIndex == spawnList.Count)
            {
                spawnEnd = true;
                return;
            }

        }



    }

    private void SelectChess(ref int enemyIndex)
    {
        switch (spawnList[spawnIndex].type)
        {
            case "P":
                chessState = ChessMal.Pawn;
                enemyIndex = 0;
                break;
            case "K":
                chessState = ChessMal.Knight;
                enemyIndex = 1;
                break;
            case "B":
                chessState = ChessMal.Bishop;
                enemyIndex = 2;
                break;
            case "R":
                chessState = ChessMal.Rook;
                enemyIndex = 3;
                break;
            case "Q":
                chessState = ChessMal.Queen;
                enemyIndex = 4;
                break;
            case "N":
                enemyIndex = 5;
                break;
        }
    }

    private void KeyBoardArrowSW(ref int X, ref int Y)
    {
        switch (spawnList[spawnIndex].keyboardArrow)
        {
            case "W":
                arrow = ChessArrow.W;
                X = 2;
                Y = 4;
                break;
            case "S":
                arrow = ChessArrow.S;
                X = 2;
                Y = 0;
                break;
            case "A":
                arrow = ChessArrow.A;
                X = 0;
                Y = 2;
                break;
            case "D":
                arrow = ChessArrow.D;
                X = 4;
                Y = 2;
                break;
            case "AW":
            case "WA":
                arrow = ChessArrow.AW;
                X = 0;
                Y = 4;
                break;
            case "DW":
            case "WD":
                arrow = ChessArrow.DW;
                X = 4;
                Y = 4;
                break;
            case "SA":
            case "AS":
                arrow = ChessArrow.SA;
                X = 0;
                Y = 0;
                break;
            case "SD":
            case "DS":
                arrow = ChessArrow.SD;
                X = 4;
                Y = 0;
                break;
        }
    }

}
