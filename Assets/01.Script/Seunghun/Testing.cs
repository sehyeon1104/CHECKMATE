using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Wave
{
    public string type;//���� ����
    public int x;
    public int y;
    public bool multi;
    public int childCount;
    // ����������
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

        

        //������ ��� �� ��ȯ 
        //�ؽ�Ʈ�� ��������



    }

 

    public List<Wave> spawnList;
    public int spawnIndex; //�����༮ �����༮
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
        spawnList.Clear(); //��� Ŭ����

        spawnIndex = 0;
        spawnEnd = false; //���� �ʱ�ȭ

        // ������ ���� �б�'
        TextAsset textFile = Resources.Load(patern) as TextAsset;//�ؽ�Ʈ ���� ���� Ŭ����
        StringReader stringReader = new StringReader(textFile.text); //���� ���� ���ڿ� �б� Ŭ����


        while(stringReader != null)
        {
            string line = stringReader.ReadLine(); //���پ� ��ȯ


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
            spawnList.Add(spawnData); //������ �ʱ�ȭ�ϰ� ������ ������ �߰��Ѵ�.
        }

        //#. �ؽ�Ʈ ���� �ݱ�
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
                //3���ݺ��� �ȵǳ�
                //3���� �ǳ�
               
                //�ڽ��߿� ��Ƽ�ϴ°� �ִٸ��� 

                
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
                        Debug.Log("����ȯ");
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

                //�ؽ�Ʈ�� ����ȯ����
                Vector2 monsterSpawnPostion = grid.GetWorldPosition(enemyPointX, enemyPointY);
                Vector2 monsterPostionSet = new Vector2(monsterSpawnPostion.x + 0.5f, monsterSpawnPostion.y + 0.5f);

                Debug.Log(grid.GetWorldPosition(enemyPointX, enemyPointY));
                //Prefab�� �����´�. 
                //Enum���� �������� ������Ʈ�� ���ϴ°ž�
                Instantiate(enemy, monsterPostionSet, Quaternion.identity);


                spawnIndex++;

                //isMulti = false;
                //isMulti = spawnList[spawnIndex].multi;
                //if (isMulti == true)
                //{
                //    //i�� ī��Ʈ�� �ٽ� ����
                //    i = 0;
                //    count = spawnList[spawnIndex].childCount;
                //    //�׷� �ٽ� for���� ����?
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
                    Debug.Log("����ȯ");
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



            //�ؽ�Ʈ�� ����ȯ����
            Debug.Log(enemyPointX);
            Debug.Log(enemyPointY);
            Vector2 monsterSpawnPostion = grid.GetWorldPosition(enemyPointX, enemyPointY);
            Vector2 monsterPostionSet = new Vector2(monsterSpawnPostion.x + 0.5f, monsterSpawnPostion.y + 0.5f);
            //Prefab�� �����´�. 
            //Enum���� �������� ������Ʈ�� ���ϴ°ž�
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
