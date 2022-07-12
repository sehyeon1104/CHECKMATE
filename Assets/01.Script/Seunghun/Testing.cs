using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Wave
{
    public string type;//몬스터 종류
    public int x;
    public int y;
    public bool multi;
    public int childCount;
    // 스폰딜레이
}

public class Testing : MonoBehaviour
{
    private enum ChessMal {  Pawn, Knight, Bishop, Rook, King, Queen};

    ChessMal chessState = ChessMal.Pawn; 

    private void Awake()
    {

        spawnList = new List<Wave>();
        ReadSpawnFile("patternA");
        //int ran = Random.Range(0, 3);
        //switch (ran)
        //{
        //    case 0:
        //        ReadSpawnFile("patternA");
        //        break;
        //    case 1:
        //        ReadSpawnFile("patternB");
        //        break;
        //    case 2:
        //        ReadSpawnFile("patternC");
        //        break;
        //}

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

    public int bpm;
    double currentTime = 0d;


    bool isMultiSPawn = true;
    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        
        if(currentTime >=  (60d / bpm) && !spawnEnd && isMultiSPawn == true && isRead == true)
        {
            MonsterSpawn(); 
            currentTime -=  60d / bpm;
            //25 - 5; 

        }
        else if(spawnEnd == true && isRead == true)
        {
            //int ran = Random.Range(0, 3);
            //switch(ran)
            //{
            //    case 0:
            //        ReadSpawnFile("patternA");
            //        break;
            //    case 1:
            //        ReadSpawnFile("patternB");
            //        break;
            //    case 2:
            //        ReadSpawnFile("patternC");
            //        break;
            //}
           
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


        while(stringReader != null)
        {
            string line = stringReader.ReadLine(); //한줄씩 반환


            if(line == null)
            {
                break; 
            }
            Wave spawnData = new Wave();
            spawnData.type = line.Split(',')[0];
            spawnData.x = int.Parse(line.Split(',')[1]);
            spawnData.y = int.Parse(line.Split(',')[2]);
            spawnData.multi = bool.Parse(line.Split(',')[3]);
            spawnData.childCount = int.Parse(line.Split(',')[4]);
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
                //3번반복이 안되네
                //3개가 되나
               
                //자식중에 멀티하는게 있다면은 

                
                Debug.Log(spawnList[spawnIndex].childCount);
                int enemyIndex = 0;

                Debug.Log(spawnList[spawnIndex].type);
                switch (spawnList[spawnIndex].type)
                {
                    case "P":
                        chessState = ChessMal.Pawn;
                        enemyIndex = 0;
                        break;
                    case "K":
                        Debug.Log("비숍소환");
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

                if(enemyIndex == 5)
                {
                    spawnIndex++;
                    return;
                }

                GameObject enemy = monsterMob[enemyIndex];

                int enemyPointX = spawnList[spawnIndex].x; 
                int enemyPointY = spawnList[spawnIndex].y;

                Debug.Log(  "EnemyPointX"  + enemyPointX);
                Debug.Log("EnemyPointY" + enemyPointY);

                //텍스트로 적소환차기
                Vector2 monsterSpawnPostion = grid.GetWorldPosition(enemyPointX, enemyPointY);
                Vector2 monsterPostionSet = new Vector2(monsterSpawnPostion.x + 0.5f, monsterSpawnPostion.y + 0.5f);

                Debug.Log(grid.GetWorldPosition(enemyPointX, enemyPointY));
                //Prefab를 가져온다. 
                //Enum으로 가져오는 오브젝트를 정하는거야
                Instantiate(enemy, monsterPostionSet, Quaternion.identity);


                spawnIndex++;

                //isMulti = false;
                //isMulti = spawnList[spawnIndex].multi;
                //if (isMulti == true)
                //{
                //    //i와 카운트를 다시 조정
                //    i = 0;
                //    count = spawnList[spawnIndex].childCount;
                //    //그럼 다시 for문을 도나?
                //}



            

             




                if (spawnIndex == spawnList.Count)
                {
                    spawnEnd = true;
                    isMultiSPawn = true;
                    return;
                }

            }
           isMultiSPawn = true;

        }
        else if(isMulti == false)
        {
            int enemyIndex = 0;

            Debug.Log(spawnList[spawnIndex].type);
            switch (spawnList[spawnIndex].type)
            {
                case "P":
                    chessState = ChessMal.Pawn;
                    enemyIndex = 0;
                    break;
                case "K":
                    Debug.Log("비숍소환");
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

            if (enemyIndex == 5)
            {
                spawnIndex++;
                return;
            }


            GameObject enemy = monsterMob[enemyIndex];

            int enemyPointX = spawnList[spawnIndex].x;
            int enemyPointY = spawnList[spawnIndex].y;



            //텍스트로 적소환차기
            Debug.Log(enemyPointX);
            Debug.Log(enemyPointY);
            Vector2 monsterSpawnPostion = grid.GetWorldPosition(enemyPointX, enemyPointY);
            Vector2 monsterPostionSet = new Vector2(monsterSpawnPostion.x + 0.5f, monsterSpawnPostion.y + 0.5f);
            //Prefab를 가져온다. 
            //Enum으로 가져오는 오브젝트를 정하는거야
            Instantiate(enemy, monsterPostionSet, Quaternion.identity);


            spawnIndex++;

            if (spawnIndex == spawnList.Count)
            {
                spawnEnd = true;
                return;
            }

        }



    }
  
}
