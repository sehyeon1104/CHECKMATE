using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
public class SwipeUI : MonoBehaviour
{
    public TestSync testBpm;
    [SerializeField]
    VolumeProfile volumeProfile; //����Ʈ ���μ���
    Bloom bloom;
    ChromaticAberration chromaticAberration;
    [SerializeField]
    private Scrollbar scrollBar;                    // Scrollbar�� ��ġ�� �������� ���� ������ �˻�
    [SerializeField]
    private Transform[] circleContents;             // ���� �������� ��Ÿ���� �� Image UI���� Transform
    [SerializeField]
    private float swipeTime = 0.2f;         // �������� Swipe �Ǵ� �ð�
    [SerializeField]
    private float swipeDistance = 0;        // �������� Swipe�Ǳ� ���� �������� �ϴ� �ּ� �Ÿ�
    [SerializeField]
    private GameObject[] diffLockPanels;         //�������� ��Ͽ� ���� ����

    // ���ǰ���
    public AudioSource[] difAudio = null;

    private float swipeTimer = 0;
    private float notSwipeTime = 0.25f;
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
        diffLockPanels[0].SetActive(false);
        diffLockPanels[1].SetActive(false);

        volumeProfile.TryGet(out chromaticAberration);
        volumeProfile.TryGet(out bloom);
        // ��ũ�� �Ǵ� �������� �� value ���� �����ϴ� �迭 �� �� �Ҵ�
        scrollPageValues = new float[transform.childCount];

        // ��ũ�� �Ǵ� ������ ������ �Ÿ�
        valueDistance = 1f / (scrollPageValues.Length - 1);

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
        int eie = currentPage;
        switch(eie)
        {
            case 0:
                testBpm.musicBpm = 75;
                chromaticAberration.intensity.Override(0.5f);
                bloom.tint.Override(Color.magenta);
                break;
            case 1:
                testBpm.musicBpm = 75;
                chromaticAberration.intensity.Override(0.5f);
                bloom.tint.Override(Color.magenta);
                break;
            case 2:
                testBpm.musicBpm = 110;
                chromaticAberration.intensity.Override(0.5f);
                bloom.tint.Override(Color.green);
                diffLockPanels[0].SetActive(false);
                diffLockPanels[1].SetActive(false);
                break;  
            case 3:
                testBpm.musicBpm = 128;
                chromaticAberration.intensity.Override(0.5f);
                bloom.tint.Override(Color.blue);
                if(PlayerPrefs.GetInt("TiemrScoreEasy") >= 60f)
                {
                    diffLockPanels[0].SetActive(false);
                    diffLockPanels[1].SetActive(false);
                }
                else
                {
                    diffLockPanels[1].SetActive(false);
                    diffLockPanels[0].SetActive(true);
                }
                break;
            case 4:
                testBpm.musicBpm = 146;
                bloom.tint.Override(Color.red);
                chromaticAberration.intensity.Override(1f);
                if (PlayerPrefs.GetInt("TiemrScore") >= 60f)
                {
                    diffLockPanels[1].SetActive(false);
                    diffLockPanels[0].SetActive(false);
                }
                else
                {
                    diffLockPanels[0].SetActive(false);
                    diffLockPanels[1].SetActive(true);
                }
                break;
        }
        swipeTimer += Time.deltaTime;
        NextScene();
        UpdateInput();

        // �Ʒ��� ��ġ�� ������ ��ư ����
        UpdateCircleContent();
        CurrChag();
    }
    private void UpdateInput()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("StartScene");
        }
        if (Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(swipeTimer < notSwipeTime)
            {
                return;
            }
            if (currentPage <= 0)
            {
                return;
            }
            --currentPage;
            StartCoroutine(OnSwipeOneStep(currentPage));
        }
        if (Input.GetKeyDown(KeyCode.D)||Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (swipeTimer < notSwipeTime)
            {
                return;
            }
            if (currentPage >= maxPage - 1)
            {
                return;
            }
            ++currentPage;
            StartCoroutine(OnSwipeOneStep(currentPage));
        }
        // ���� Swipe�� �������̸� ��ġ �Ұ�
        if (isSwipeMode == true) return;


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
        if(swipeTimer<notSwipeTime)
        {
            StartCoroutine(OnSwipeOneStep(currentPage));
            return;
        }
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
       
        swipeTimer = 0;
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
        swipeTimer = 0;
    }

     bool check = true;
     int flaseCur;
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
            if (flaseCur != 0)
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
                difAudio[0].Stop();
                difAudio[1].Stop();
                difAudio[3].Stop();
                difAudio[2].Play();
                break;
            case 4:
                difAudio[0].Stop();
                difAudio[2].Stop();
                difAudio[3].Play();
                break;

        }
    }


    void NextScene()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            switch (currentPage)
            {
                case 1:
                    SceneManager.LoadScene("TutorialScene");
                    break;
                case 2:
                    SceneManager.LoadScene("EasyScene");
                    break;
                case 3:
                    if(PlayerPrefs.GetInt("TiemrScoreEasy") >= 60f)
                        SceneManager.LoadScene("NormalScene");
                    break;
                case 4:
                    if (PlayerPrefs.GetInt("TiemrScore") >= 60f)
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
                circleContents[i].GetComponent<Image>().color =bloom.tint.value;
            }
        }
    }
}




