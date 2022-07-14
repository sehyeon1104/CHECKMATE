using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using static ChessSpawnArrowEnum;
public class WaveS
{
    public string type;//���� ����
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
    public int spawnIndex; //�����༮ �����༮
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

        Debug.Log("�б�");
        isRead = false;
        spawnList.Clear(); //��� Ŭ����

        spawnIndex = 0;
        spawnEnd = false; //���� �ʱ�ȭ

        // ������ ���� �б�'
        TextAsset textFile = Resources.Load(patern) as TextAsset;//�ؽ�Ʈ ���� ���� Ŭ����
        StringReader stringReader = new StringReader(textFile.text); //���� ���� ���ڿ� �б� Ŭ����

        while (stringReader != null)
        {
            Debug.Log("�б�ݺ�");
            string line = stringReader.ReadLine(); //���پ� ��ȯ


            if (line == null)
            {
                break;
            }
            WaveS spawnData = new WaveS();
            spawnData.type = line.Split(',')[0];
 
            spawnData.keyboardArrow = line.Split(',')[1];
            spawnData.multi = bool.Parse(line.Split(',')[2]);
            spawnData.childCount = int.Parse(line.Split(',')[3]);
            spawnList.Add(spawnData); //������ �ʱ�ȭ�ϰ� ������ ������ �߰��Ѵ�.
        }
        Debug.Log("isRoad: " + isRead);
        isRead = true;

        Debug.Log("isRoad: " + isRead);
        //#. �ؽ�Ʈ ���� �ݱ�
        stringReader.Close();

    }



    bool isTrue =true;
    public void StartSpawn()
    {
        isSpawn = true;
        if (isTrue == true)
        {
            isTrue = false;
            tutoList(TutoDialogManager.Instance.tuto.Level);//���̾�αװ� ������ ���ִ� �Լ�
            isRead = true;

            Debug.Log("isRead StartSpawn" + isRead);
        }

    }
    void FixedUpdate()
    {
        if (GameManager.Instance.dialogPanel.isOpen)
        {
            return; //�����ִٸ� ��ȯ������
        }

     


        if (isSpawn == false)
        {
            return;
        }

        currentTime += Time.deltaTime;
        isRead = true;
        if (currentTime >= (60f / Sync_Gijoo.Instance.realMusicBpm) && !spawnEnd && isMultiSPawn == true && isRead == true)
        {

            Debug.Log("���");
            MonsterSpawn();
            currentTime -= 60f / Sync_Gijoo.Instance.realMusicBpm;
            //25 - 5; 

        }
        else if (spawnEnd == true && isRead == true)
        {
            //�׸��� �÷��̾����� �װ� �ٽ� ��ŸƮ���ָ� 
            //�̰����ִ°� ���̾�αװ� ������


            TutoDialogManager.Instance.tuto.Level++;
            tutoList(TutoDialogManager.Instance.tuto.Level);
        

            //������ ������ �׹��� ��ȭ�� ������ ��ȯ
        }
    
        

    }

    public void tutoList(int l)
    {
        Debug.Log("�б⸮��Ʈ");
        switch (l)
        {
            case 0:
                ReadSpawnFile("tutorialText");
                Debug.Log("�б⸮��Ʈ0");
                break;
            case 1:
                ReadSpawnFile("tutorialText1");
                Debug.Log("�б⸮��Ʈ1");
                break;
            case 2:
                ReadSpawnFile("tutorialText2");
                Debug.Log("�б⸮��Ʈ2");
                break;
            case 3:
                ReadSpawnFile("tutorialTextR");
                Debug.Log("�б⸮��ƮR");
                break;
            
        }

        isRead = true;
        Debug.Log("isRead tutoList: " + isRead);
    }

    void MonsterSpawn()
    {

        Debug.Log("���� ����");

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

                //�ؽ�Ʈ�� ����ȯ����
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
                //Prefab�� �����´�. 
                //Enum���� �������� ������Ʈ�� ���ϴ°ž�
                GameObject enmeyObj = Instantiate(enemy, monsterPostionSet, Quaternion.identity);

                IArrow arr = enmeyObj.GetComponent<IArrow>();

                Debug.Log(arrow);
                if (arr != null)
                {
                    arr.ArrowCopySW(arrow);
                }
                //���ʹ��� �Լ��� �����Ű�� �����Ű�� �ڱ⿡�Ե� �װ��ִµ� �װ� �Լ��� �����ϴ� �ž�
                //���⿡ enum�� �־���� ���¸� ��������
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

            //��ȯ�ϴ� ���ӿ�����Ʈ���ٰ� x,y������ Arrow�� �������ִ� �Լ��� �־��ִ� 
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
            //Prefab�� �����´�. 
            //Enum���� �������� ������Ʈ�� ���ϴ°ž�
            GameObject enmeyObj = Instantiate(enemy, monsterPostionSet, Quaternion.identity);

            IArrow arr = enmeyObj.GetComponent<IArrow>();

            //�׷����� ��ȣ�� �װ� ���ݾ�?
            Debug.Log(arrow);
            if (arr != null)
            {

                Debug.Log("�ȵǴ� �ǰ�");
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
                //��ȯ�� �ǰ� �����
                //��ȯ�ɋ� //��ȯ�Ǵ� ������Ʈ�ٰ� ��ũ��Ʈ�� ���̰� �Ҽ����� ������ 
                //ü�� �Ǿ��ְ�, W�� �ϰ�,  W���� �ε����� ����
                //�ε����� ������ ����� ������Ʈ��? 
                //
                //���ʹ��� ���¸� �����ϴ� �Լ��� ������ ��
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
