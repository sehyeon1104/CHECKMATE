using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Wave
{
    public string type;//몬스터 종류
<<<<<<< HEAD
<<<<<<< HEAD
    public int x;
    public int y;
=======
<<<<<<< HEAD
    public int x;
    public int y;
    public float delay;

=======
    //public int x;
    //public int y;
    public string keyboardArrow;
>>>>>>> ace609edff14e927174ec35c09eba4abd78deee7
=======
    public int x;
    public int y;
>>>>>>> parent of 8c7228c (�뒪�룿 �떆�뒪�뀥 議곗젙)
    public bool multi;
    public int childCount;
>>>>>>> 8c7228c07f5a1705709f9a18458f6c5025638e75
    // 스폰딜레이
}

public class Testing : MonoBehaviour
{
    private enum ChessMal {  Pawn, Knight, Bishop, Rook, King, Queen};

    ChessMal chessState = ChessMal.Pawn; 

    private void Awake()
    {
        spawnList = new List<Wave>();
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> parent of 8c7228c (�뒪�룿 �떆�뒪�뀥 議곗젙)
        ReadSpawnFile("N1");
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
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
        int ran = Random.Range(0, 3);
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
        }
>>>>>>> 8c7228c07f5a1705709f9a18458f6c5025638e75
>>>>>>> ace609edff14e927174ec35c09eba4abd78deee7
=======
>>>>>>> parent of 8c7228c (�뒪�룿 �떆�뒪�뀥 議곗젙)

        ReadSpawnFile();
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

    

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
<<<<<<< HEAD
<<<<<<< HEAD
        
        if(currentTime >=  (60d / bpm) && !spawnEnd && isMultiSPawn == true && isRead == true)
=======
<<<<<<< HEAD

        if(currentTime >= 60d / bpm && !spawnEnd)
        {
            MonsterSpawn();
            currentTime -= 60d / bpm;
=======

        if (currentTime >= (60f / Sync_Gijoo.Instance.musicBpm) && !spawnEnd && isMultiSPawn == true && isRead == true)
>>>>>>> ace609edff14e927174ec35c09eba4abd78deee7
        {
=======
        
        if(currentTime >=  (60d / bpm) && !spawnEnd && isMultiSPawn == true && isRead == true)
        {
>>>>>>> parent of 8c7228c (�뒪�룿 �떆�뒪�뀥 議곗젙)
            MonsterSpawn(); 
            currentTime -=  60d / bpm;
            //25 - 5; 

        }
        else if(spawnEnd == true && isRead == true)
        {
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> parent of 8c7228c (�뒪�룿 �떆�뒪�뀥 議곗젙)
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
           
<<<<<<< HEAD
=======
            int ran = Random.Range(0, 3);
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
            }
>>>>>>> 8c7228c07f5a1705709f9a18458f6c5025638e75

>>>>>>> ace609edff14e927174ec35c09eba4abd78deee7
=======
>>>>>>> parent of 8c7228c (�뒪�룿 �떆�뒪�뀥 議곗젙)
        }
    }
    void ReadSpawnFile()
    {
        spawnList.Clear(); //모두 클리어

        spawnIndex = 0;
        spawnEnd = false; //변수 초기화

        // 리스폰 파일 읽기'
        TextAsset textFile = Resources.Load("tutorial") as TextAsset;//텍스트 파일 에셋 클래스
        StringReader stringReader = new StringReader(textFile.text); //파일 내의 문자열 읽기 클래스


        while(stringReader != null)
        {
            string line = stringReader.ReadLine(); //한줄씩 반환

            Debug.Log(line);

            if(line == null)
            {
                break; 
            }
            Wave spawnData = new Wave();
            spawnData.type = line.Split(',')[0];
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> parent of 8c7228c (�뒪�룿 �떆�뒪�뀥 議곗젙)
            spawnData.x = int.Parse(line.Split(',')[1]);
            spawnData.y = int.Parse(line.Split(',')[2]);
            spawnData.multi = bool.Parse(line.Split(',')[3]);
            spawnData.childCount = int.Parse(line.Split(',')[4]);
<<<<<<< HEAD
=======
<<<<<<< HEAD
            spawnData.x = int.Parse(line.Split(',')[1]);
            spawnData.y = int.Parse(line.Split(',')[2]);
            spawnData.delay = float.Parse(line.Split(',')[3]);
=======
            //spawnData.x = int.Parse(line.Split(',')[1]);
            //spawnData.y = int.Parse(line.Split(',')[2]);
            spawnData.keyboardArrow = line.Split(',')[1];
            spawnData.multi = bool.Parse(line.Split(',')[2]);
            spawnData.childCount = int.Parse(line.Split(',')[3]);
>>>>>>> 8c7228c07f5a1705709f9a18458f6c5025638e75
>>>>>>> ace609edff14e927174ec35c09eba4abd78deee7
=======
>>>>>>> parent of 8c7228c (�뒪�룿 �떆�뒪�뀥 議곗젙)
            spawnList.Add(spawnData); //변수를 초기화하고 변수를 넣은걸 추가한다.
        }

        //#. 텍스트 파일 닫기
        stringReader.Close();



    }

    //
    void MonsterSpawn()
    {
        int enemyIndex = 0;

        Debug.Log(spawnList[spawnIndex].type);
        switch(spawnList[spawnIndex].type)
        {
<<<<<<< HEAD
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
        }
=======
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
>>>>>>> 8c7228c07f5a1705709f9a18458f6c5025638e75


        GameObject enemy = monsterMob[enemyIndex];

        int enemyPointX = spawnList[spawnIndex].x;
        int enemyPointY = spawnList[spawnIndex].y;

<<<<<<< HEAD

<<<<<<< HEAD

<<<<<<< HEAD
=======
        //텍스트로 적소환차기
        Vector2 monsterSpawnPostion = grid.GetWorldPosition(enemyPointX, enemyPointY);
        Vector2 monsterPostionSet = new Vector2(monsterSpawnPostion.x + 1, monsterSpawnPostion.y + 1);
        //Prefab를 가져온다. 
        //Enum으로 가져오는 오브젝트를 정하는거야
        Instantiate(enemy, monsterPostionSet, Quaternion.identity);


        spawnIndex++;
=======


>>>>>>> ace609edff14e927174ec35c09eba4abd78deee7
=======
>>>>>>> parent of 8c7228c (�뒪�룿 �떆�뒪�뀥 議곗젙)
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
>>>>>>> 8c7228c07f5a1705709f9a18458f6c5025638e75

        if(spawnIndex == spawnList.Count)
        {
            spawnEnd = true;
            return;
        }

       

    }
  
}
