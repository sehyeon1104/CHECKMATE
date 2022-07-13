using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using static ChessSpawnArrowEnum;
public class Wave
{
    public string type;//몬스터 종류
    //public int x;
    //public int y;
    public string keyboardArrow;
    public bool multi;
    public int childCount;
    // 스폰딜레이
}

public class Testing : MonoBehaviour
{
    private enum ChessMal { Pawn, Knight, Bishop, Rook, King, Queen };

    ChessMal chessState = ChessMal.Pawn;


    public bool isSpawn;
    public ChessArrow arrow;
    private void Awake()
    {

        spawnList = new List<Wave>();
        int ran = Random.Range(0, 8);
        switch (ran)
        {
            case 0:
                ReadSpawnFile("N1");
                break;
            case 1:
                ReadSpawnFile("N2");
                break;
            case 2:
                ReadSpawnFile("N3");
                break;
            case 3:
                ReadSpawnFile("N4");
                break;
            case 4:
                ReadSpawnFile("N5");
                break;
            case 5:
                ReadSpawnFile("N6");
                break;
            case 6:
                ReadSpawnFile("N7");
                break;
            case 7:
                ReadSpawnFile("N8");
                break;
        }

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



        //적들을 담는 걸 소환 
        //텍스트로 만들어놓음



    }



    public List<Wave> spawnList;
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

        if (currentTime >= (60f / Sync_Gijoo.Instance.realMusicBpm) && !spawnEnd && isMultiSPawn == true && isRead == true)
        {
            MonsterSpawn();
            currentTime -= 60f / Sync_Gijoo.Instance.realMusicBpm;
            //25 - 5; 

        }
        else if (spawnEnd == true && isRead == true)
        {
            int ran = Random.Range(0, 8);
            switch (ran)
            {
                case 0:
                    ReadSpawnFile("N1");
                    break;
                case 1:
                    ReadSpawnFile("N2");
                    break;
                case 2:
                    ReadSpawnFile("N3");
                    break;
                case 3:
                    ReadSpawnFile("N4");
                    break;
                case 4:
                    ReadSpawnFile("N5");
                    break;
                case 5:
                    ReadSpawnFile("N6");
                    break;
                case 6:
                    ReadSpawnFile("N7");
                    break;
                case 7:
                    ReadSpawnFile("N8");
                    break;
            }

        }
    }

    bool isRead;
    void ReadSpawnFile(string patern)
    {
        isRead = false;
        spawnList.Clear(); //모두 클리어

        spawnIndex = 0;
        spawnEnd = false; //변수 초기화

        // 리스폰 파일 읽기'
        TextAsset textFile = Resources.Load(patern) as TextAsset;//텍스트 파일 에셋 클래스
        StringReader stringReader = new StringReader(textFile.text); //파일 내의 문자열 읽기 클래스

        while (stringReader != null)
        {
            string line = stringReader.ReadLine(); //한줄씩 반환


            if (line == null)
            {
                break;
            }
            Wave spawnData = new Wave();
            spawnData.type = line.Split(',')[0];
            //spawnData.x = int.Parse(line.Split(',')[1]);
            //spawnData.y = int.Parse(line.Split(',')[2]);
            spawnData.keyboardArrow = line.Split(',')[1];
            spawnData.multi = bool.Parse(line.Split(',')[2]);
            spawnData.childCount = int.Parse(line.Split(',')[3]);
            spawnList.Add(spawnData); //변수를 초기화하고 변수를 넣은걸 추가한다.
        }

        //#. 텍스트 파일 닫기
        stringReader.Close();


        isRead = true;
    }

    //
    private bool isMulti;
    private int count;

    int i;
    void MonsterSpawn()
    {

        if (isMultiSPawn == false) return;
        isMulti = spawnList[spawnIndex].multi;




        if (isMulti == true)
        {
            isMulti = false;
            isMultiSPawn = false;
            count = spawnList[spawnIndex].childCount;
            //
            for (i = 0; i < count; i++)
            {

                int enemyIndex = 0;


                //
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

                //Debug.Log(  "EnemyPointX"  + enemyPointX);
                //Debug.Log("EnemyPointY" + enemyPointY);

                KeyBoardArrowSW(ref X, ref Y);

                //텍스트로 적소환차기
                Vector2 monsterSpawnPostion;
                Vector2 monsterPostionSet;
                if (chessState == ChessMal.Bishop || chessState == ChessMal.Rook)
                {
                    monsterSpawnPostion = grid.GetWorldPosition(X, Y);
                    monsterPostionSet = new Vector2(monsterSpawnPostion.x * 2 + 1f, monsterSpawnPostion.y * 2 + 1f);
                }
                else
                {
                    monsterSpawnPostion = grid.GetWorldPosition(X, Y);
                    monsterPostionSet = new Vector2(monsterSpawnPostion.x + 0.5f, monsterSpawnPostion.y + 0.5f);
                }


                Debug.Log(grid.GetWorldPosition(X, Y));
                //Prefab를 가져온다. 
                //Enum으로 가져오는 오브젝트를 정하는거야
                GameObject enmeyObj =  Instantiate(enemy, monsterPostionSet, Quaternion.identity);

                IArrow arr = enmeyObj.GetComponent<IArrow>();

                Debug.Log(arrow);
                if (arr != null)
                {
                    arr.ArrowCopySW(arrow);
                }
                //에너미의 함수를 실행시키자 실행시키면 자기에게도 그게있는데 그걸 함수를 전달하는 거야
                //여기에 enum을 넣어가지고 상태를 물려주자
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
        else if (isMulti == false)
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

            //소환하는 게임오브젝트에다가 x,y에따라 Arrow를 설정해주는 함수를 넣어주는 
            if (chessState == ChessMal.Bishop || chessState == ChessMal.Rook)
            {
                monsterSpawnPostion = grid.GetWorldPosition(X, Y);
                monsterPostionSet = new Vector2(monsterSpawnPostion.x * 2 + 1f, monsterSpawnPostion.y * 2 + 1f);
            }
            else
            {
                monsterSpawnPostion = grid.GetWorldPosition(X, Y);
                monsterPostionSet = new Vector2(monsterSpawnPostion.x + 0.5f, monsterSpawnPostion.y + 0.5f);
            }
            //Prefab를 가져온다. 
            //Enum으로 가져오는 오브젝트를 정하는거야
            GameObject enmeyObj = Instantiate(enemy, monsterPostionSet, Quaternion.identity);

            IArrow arr = enmeyObj.GetComponent<IArrow>();

            //그러고보니 신호는 그게 없잖아?
            Debug.Log(arrow);
            if (arr != null)
            {

                Debug.Log("안되는 건가");
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


    //w면 w만의 인덱스를 가지게 만들려면 
    private void KeyBoardArrowSW(ref int X, ref int Y)
    {
        switch (spawnList[spawnIndex].keyboardArrow)
        {
            case "W":
                //소환이 되게 만들어
                //소환될떄 //소환되는 오브젝트다가 스크립트를 붙이게 할수있지 않을까 
                //체스 되어있고, W로 하고,  W만의 인덱스를 가짐
                //인덱스를 가지게 만들어 스테이트를? 
                //
                //에너미의 상태를 결정하는 함수를 만들어야 함
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
                X = 4;
                Y = 0;
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
