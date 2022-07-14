using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using static ChessSpawnArrowEnum;
public class WaveS
{
    public string type;//몬스터 종류
    public string keyboardArrow;
    public bool multi;
    public int childCount;
}
public class tutoSpawner : MonoBehaviour
{

    private enum ChessMal { Pawn, Knight, Bishop, Rook, King, Queen };

    ChessMal chessState = ChessMal.Pawn;


    public bool isSpawn;
    public ChessArrow arrow;
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

   

    public List<WaveS> spawnList;
    public int spawnIndex; //다음녀석 다음녀석
    public bool spawnEnd;

    double currentTime = 0d;


    public bool isMultiSPawn = true;

    public bool isRead;

    private bool isMulti;
    private int count;

    int i;
    private void Awake()
    { 
        spawnList = new List<WaveS>();
        //ReadSpawnFile("tutorialText");
    }

    void ReadSpawnFile(string patern)
    {

        Debug.Log("읽기");
        isRead = false;
        spawnList.Clear(); //모두 클리어

        spawnIndex = 0;
        spawnEnd = false; //변수 초기화

        // 리스폰 파일 읽기'
        TextAsset textFile = Resources.Load(patern) as TextAsset;//텍스트 파일 에셋 클래스
        StringReader stringReader = new StringReader(textFile.text); //파일 내의 문자열 읽기 클래스

        while (stringReader != null)
        {
            Debug.Log("읽기반복");
            string line = stringReader.ReadLine(); //한줄씩 반환


            if (line == null)
            {
                break;
            }
            WaveS spawnData = new WaveS();
            spawnData.type = line.Split(',')[0];
 
            spawnData.keyboardArrow = line.Split(',')[1];
            spawnData.multi = bool.Parse(line.Split(',')[2]);
            spawnData.childCount = int.Parse(line.Split(',')[3]);
            spawnList.Add(spawnData); //변수를 초기화하고 변수를 넣은걸 추가한다.
        }
        Debug.Log("isRoad: " + isRead);
        isRead = true;

        Debug.Log("isRoad: " + isRead);
        //#. 텍스트 파일 닫기
        stringReader.Close();

    }



    bool isTrue =true;
    public void StartSpawn()
    {
        isSpawn = true;
        if (isTrue == true)
        {
            isTrue = false;
            tutoList(TutoDialogManager.Instance.tuto.Level);//다이얼로그가 끝나면 해주는 함수
            isRead = true;

            Debug.Log("isRead StartSpawn" + isRead);
        }

    }
    void FixedUpdate()
    {
        if (GameManager.Instance.dialogPanel.isOpen)
        {
            return; //열려있다면 소환금지ㅋ
        }

     


        if (isSpawn == false)
        {
            return;
        }

        currentTime += Time.deltaTime;
        isRead = true;
        if (currentTime >= (60f / Sync_Gijoo.Instance.realMusicBpm) && !spawnEnd && isMultiSPawn == true && isRead == true)
        {

            Debug.Log("라라");
            MonsterSpawn();
            currentTime -= 60f / Sync_Gijoo.Instance.realMusicBpm;
            //25 - 5; 

        }
        else if (spawnEnd == true && isRead == true)
        {
            //그리고 플레이어한테 죽고 다시 스타트해주면 
            //이걸해주는걸 다이얼로그가 끝나고


            TutoDialogManager.Instance.tuto.Level++;
            tutoList(TutoDialogManager.Instance.tuto.Level);
        

            //스폰이 끝나고 그뭐냐 대화가 끝나면 소환
        }
    
        

    }

    public void tutoList(int l)
    {
        Debug.Log("읽기리스트");
        switch (l)
        {
            case 0:
                ReadSpawnFile("tutorialText");
                Debug.Log("읽기리스트0");
                break;
            case 1:
                ReadSpawnFile("tutorialText1");
                Debug.Log("읽기리스트1");
                break;
            case 2:
                ReadSpawnFile("tutorialText2");
                Debug.Log("읽기리스트2");
                break;
            case 3:
                ReadSpawnFile("tutorialTextR");
                Debug.Log("읽기리스트R");
                break;
            
        }

        isRead = true;
        Debug.Log("isRead tutoList: " + isRead);
    }

    void MonsterSpawn()
    {

        Debug.Log("몬스터 스폰");

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
                    monsterPostionSet = new Vector2(monsterSpawnPostion.x + 0.5f, monsterSpawnPostion.y + 0.5f);
                }
                else
                {
                    monsterSpawnPostion = grid.GetWorldPosition(X, Y);
                    monsterPostionSet = new Vector2(monsterSpawnPostion.x + 0.5f, monsterSpawnPostion.y + 0.5f);
                }


                Debug.Log(grid.GetWorldPosition(X, Y));
                //Prefab를 가져온다. 
                //Enum으로 가져오는 오브젝트를 정하는거야
                GameObject enmeyObj = Instantiate(enemy, monsterPostionSet, Quaternion.identity);

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
                monsterPostionSet = new Vector2(monsterSpawnPostion.x + 0.5f, monsterSpawnPostion.y + 0.5f);
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
