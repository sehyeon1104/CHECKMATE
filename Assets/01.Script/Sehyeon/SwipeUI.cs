using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SwipeUI : MonoBehaviour
{
    [SerializeField]
    private Scrollbar scrollBar;                    // Scrollbar�� ��ġ�� �������� ���� ������ �˻�
    [SerializeField]
    private Transform[] circleContents;             // ���� �������� ��Ÿ���� �� Image UI���� Transform
    [SerializeField]
    private float swipeTime = 0.2f;         // �������� Swipe �Ǵ� �ð�
    [SerializeField]
    private float swipeDistance = 0;        // �������� Swipe�Ǳ� ���� �������� �ϴ� �ּ� �Ÿ�

    // ���ǰ���
    public AudioSource[] difAudio = null;

    private float timer;
    bool isswipe;
    private float[] scrollPageValues;           // �� �������� ��ġ �� [0.0 - 1.0]
    private float valueDistance = 0;            // �� ������ ������ �Ÿ�
    public int currentPage = 0;            // ���� ������
    private int maxPage = 0;                // �ִ� ������
    private float startTouchX;              // ��ġ ���� ��ġ
    private float endTouchX;                    // ��ġ ���� ��ġ
    private bool isSwipeMode = false;       // ���� Swipe�� �ǰ� �ִ��� üũ
    private float circleContentScale = 1.6f;    // ���� �������� �� ũ��(����)

    private void Awake()
    {   
        // ��ũ�� �Ǵ� �������� �� value ���� �����ϴ� �迭 �� �� �Ҵ�
        scrollPageValues = new float[transform.childCount];

        // ��ũ�� �Ǵ� ������ ������ �Ÿ�
        valueDistance = 1f / (scrollPageValues.Length-1);

        // ��ũ�� �Ǵ� �������� �� value ��ġ ���� [0 <= value <= 1]
        for (int i = 0; i < scrollPageValues.Length; ++i)
        {
            scrollPageValues[i] = valueDistance * i;
        }

        // �ִ� �������� ��
        maxPage = transform.childCount;
    }

     void Start()
    {
        swipeDistance = Screen.width / 2;
        SetScrollBarValue(1);
    }

    public void SetScrollBarValue(int index)
    {
        currentPage = index;
        scrollBar.value = valueDistance * index;
    }

    private void Update()
    {
        NextScene();
        UpdateInput();

        // �Ʒ��� ��ġ�� ������ ��ư ����
        UpdateCircleContent();
        CurrChag();
    }

    private void UpdateInput()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if(currentPage<=0)
            {
                return;   
            }
            --currentPage;
            StartCoroutine(OnSwipeOneStep(currentPage));
            
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if(currentPage>=maxPage-1)
            {
                return;
            }
            ++currentPage;
            StartCoroutine(OnSwipeOneStep(currentPage));
        }
        // ���� Swipe�� �������̸� ��ġ �Ұ�
        if (isSwipeMode == true) return;

#if UNITY_EDITOR
        // ���콺 ���� ��ư�� ������ �� 1ȸ
        if (Input.GetMouseButtonDown(0))
        {
            // ��ġ ���� ���� (Swipe ���� ����)
            startTouchX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // ��ġ ���� ���� (Swipe ���� ����)
            endTouchX = Input.mousePosition.x;

            UpdateSwipe();
        }
#endif

#if UNITY_ANDROID
		if ( Input.touchCount == 1 )
		{
			Touch touch = Input.GetTouch(0);

			if ( touch.phase == TouchPhase.Began )
			{
				// ��ġ ���� ���� (Swipe ���� ����)
				startTouchX = touch.position.x;
			}
			else if ( touch.phase == TouchPhase.Ended )
			{
				// ��ġ ���� ���� (Swipe ���� ����)
				endTouchX = touch.position.x;

				UpdateSwipe();
			}
		}
#endif
    }

    private void UpdateSwipe()
    {
       
        // �ʹ� ���� �Ÿ��� �������� ���� Swipe X
        if (Mathf.Abs(startTouchX - endTouchX) < swipeDistance)
        {
            // ���� �������� Swipe�ؼ� ���ư���
            StartCoroutine(OnSwipeOneStep(currentPage));
            return;
        }

        // Swipe ����
        bool isLeft = startTouchX < endTouchX ? true : false;

        // �̵� ������ ������ ��
        if (isLeft == true)
        {
            // ���� �������� ���� ���̸� ����
            if (currentPage == 0) return;

            // �������� �̵��� ���� ���� �������� 1 ����
            currentPage--;
        }
        // �̵� ������ �������� ��
        else
        {
            // ���� �������� ������ ���̸� ����
            if (currentPage == maxPage - 1) return;

            // ���������� �̵��� ���� ���� �������� 1 ����
            currentPage++;
        }

        // currentIndex��° �������� Swipe�ؼ� �̵�
        StartCoroutine(OnSwipeOneStep(currentPage));
    }

    /// <summary>
    /// �������� �� �� ������ �ѱ�� Swipe ȿ�� ���
    /// </summary>
    private IEnumerator OnSwipeOneStep(int index)
    {
      
        float start = scrollBar.value;
        float current = 0;
        float percent = 0;

        isSwipeMode = true;
        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / swipeTime;

            scrollBar.value = Mathf.Lerp(start, scrollPageValues[index], percent);

            yield return null;
        }

        isSwipeMode = false;
        timer += Time.deltaTime;
    }

    public bool check = true;
    public int flaseCur;
    private void CurrChag()
    {
        if (check)
        {
            flaseCur = currentPage;
            check = false;
            StartCoroutine(WaitForIt());
        }
        if (flaseCur != currentPage)
        {
            if(flaseCur != 0)
            {
                AudioManaher();
            }
        }
    }

    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(0.5f);
        check = true;
    }

    private void AudioManaher()
    {
        switch (currentPage)
        {
            case 0:
                break;
            case 1:
                difAudio[1].Stop();
                difAudio[0].Play();
                break;
            case 2:
                difAudio[0].playOnAwake = false;
                difAudio[0].Stop();
                difAudio[2].Stop();
                difAudio[1].Play();
                break;
            case 3:
                difAudio[1].Stop();
                difAudio[3].Stop();
                difAudio[2].Play();
                break;
            case 4:
                difAudio[2].Stop();
                difAudio[3].Play();
                break;

        }
    }


    void NextScene()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            switch(currentPage)
            {
                case 1:
                    SceneManager.LoadScene("TutorialScene");
                    break;
                case 2:
                    SceneManager.LoadScene("EasyScene");
                    break;
                case 3:
                    SceneManager.LoadScene("NormalScene");
                    break;
                case 4:
                    SceneManager.LoadScene("HardScene");
                    break;
            }
        }
    }
    private void UpdateCircleContent()
    {
        // �Ʒ��� ��ġ�� ������ ��ư ũ��, ���� ���� (���� �ӹ��� �ִ� �������� ��ư�� ����)
        for (int i = 0; i < scrollPageValues.Length; ++i)
        {
            circleContents[i].localScale = new Vector2(0.5f, 0.5f);
            circleContents[i].GetComponent<Image>().color = Color.white;

            // �������� ������ �Ѿ�� ���� ������ ���� �ٲٵ���
            if (scrollBar.value < scrollPageValues[i] + (valueDistance / 2) && scrollBar.value > scrollPageValues[i] - (valueDistance / 2))
            {
                circleContents[i].localScale = new Vector2(0.5f, 0.5f) * circleContentScale;
                circleContents[i].GetComponent<Image>().color = Color.black;
            }
        }
    }
}




