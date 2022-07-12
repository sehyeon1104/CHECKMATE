using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Wave
{
    public string type;//���� ����
    //public int x;
    //public int y;
    public string keyboardArrow;
    public bool multi;
    public int childCount;
    // ����������
}

public class Testing : MonoBehaviour
{
    private enum ChessMal { Pawn, Knight, Bishop, Rook, King, Queen };

    ChessMal chessState = ChessMal.Pawn;

    private void Awake()
    {

        spawnList = new List<Wave>();
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

    double currentTime = 0d;


    bool isMultiSPawn = true;
    // Update is called once per frame
    void FixedUpdate()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= (60f / Sync_Gijoo.Instance.musicBpm) && !spawnEnd && isMultiSPawn == true && isRead == true)
        {
            MonsterSpawn();
            currentTime -= 60f / Sync_Gijoo.Instance.musicBpm;
            //25 - 5; 

        }
        else if (spawnEnd == true && isRead == true)
        {
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

        while (stringReader != null)
        {
            string line = stringReader.ReadLine(); //���پ� ��ȯ


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

                if (enemyIndex == 5)
                {
                    spawnIndex++;
                    return;
                }

                GameObject enemy = monsterMob[enemyIndex];

                int X = 0;
                int Y = 0;

                //Debug.Log(  "EnemyPointX"  + enemyPointX);
                //Debug.Log("EnemyPointY" + enemyPointY);

                switch (spawnList[spawnIndex].keyboardArrow)
                {
                    case "W":
                        X = 2;
                        Y = 4;
                        break;
                    case "S":
                        X = 2;
                        Y = 0;
                        break;
                    case "A":
                        X = 0;
                        Y = 2;
                        break;
                    case "D":
                        X = 4;
                        Y = 2;
                        break;
                    case "AW":
                    case "WA":
                        X = 4;
                        Y = 0;
                        break;
                    case "DW":
                    case "WD":
                        X = 4;
                        Y = 4;
                        break;
                    case "SA":
                    case "AS":
                        X = 0;
                        Y = 0;
                        break;
                    case "SD":
                    case "DS":
                        X = 4;
                        Y = 0;
                        break;
                }

                //�ؽ�Ʈ�� ����ȯ����
                Vector2 monsterSpawnPostion;
                Vector2 monsterPostionSet;
                if (chessState == ChessMal.Bishop || chessState == ChessMal.Rook)
                {
                    monsterSpawnPostion = grid.GetWorldPosition(X, Y);
                    monsterPostionSet = new Vector2(monsterSpawnPostion.x*2 + 0.5f, monsterSpawnPostion.y*2 + 0.5f);
                }
                else
                {
                    monsterSpawnPostion = grid.GetWorldPosition(X, Y);
                    monsterPostionSet = new Vector2(monsterSpawnPostion.x + 0.5f, monsterSpawnPostion.y + 0.5f);
                }
               

                Debug.Log(grid.GetWorldPosition(X, Y));
                //Prefab�� �����´�. 
                //Enum���� �������� ������Ʈ�� ���ϴ°ž�
                Instantiate(enemy, monsterPostionSet, Quaternion.identity);


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
            int X = 0;
            int Y = 0;


            switch (spawnList[spawnIndex].keyboardArrow)
            {
                case "W":
                    X = 2;
                    Y = 4;
                    break;
                case "S":
                    X = 2;
                    Y = 0;
                    break;
                case "A":
                    X = 0;
                    Y = 2;
                    break;
                case "D":
                    X = 4;
                    Y = 2;
                    break;
                case "AW":
                case "WA":
                    X = 4;
                    Y = 0;
                    break;
                case "DW":
                case "WD":
                    X = 4;
                    Y = 4;
                    break;
                case "SA":
                case "AS":
                    X = 0;
                    Y = 0;
                    break;
                case "SD":
                case "DS":
                    X = 4;
                    Y = 0;
                    break;
            }


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
