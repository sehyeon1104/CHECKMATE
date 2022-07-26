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
    VolumeProfile volumeProfile; //포스트 프로세싱
    Bloom bloom;
    ChromaticAberration chromaticAberration;
    [SerializeField]
    private Scrollbar scrollBar;                    // Scrollbar의 위치를 바탕으로 현재 페이지 검사
    [SerializeField]
    private Transform[] circleContents;             // 현재 페이지를 나타내는 원 Image UI들의 Transform
    [SerializeField]
    private float swipeTime = 0.2f;         // 페이지가 Swipe 되는 시간
    [SerializeField]
    private float swipeDistance = 0;        // 페이지가 Swipe되기 위해 움직여야 하는 최소 거리
    [SerializeField]
    private GameObject[] diffLockPanels;         //페이지의 기록에 따른 제한

    // 음악관련
    public AudioSource[] difAudio = null;

    private float swipeTimer = 0;
    private float notSwipeTime = 0.25f;
    bool isswipe;
    private float[] scrollPageValues;           // 각 페이지의 위치 값 [0.0 - 1.0]
    private float valueDistance = 0;            // 각 페이지 사이의 거리
    public int currentPage = 0;            // 현재 페이지
    private int maxPage = 0;                // 최대 페이지
    private float startTouchX;              // 터치 시작 위치
    private float endTouchX;                    // 터치 종료 위치
    private bool isSwipeMode = false;       // 현재 Swipe가 되고 있는지 체크
    private float circleContentScale = 1.6f;    // 현재 페이지의 원 크기(배율)

    private void Awake()
    {
        diffLockPanels[0].SetActive(false);
        diffLockPanels[1].SetActive(false);

        volumeProfile.TryGet(out chromaticAberration);
        volumeProfile.TryGet(out bloom);
        // 스크롤 되는 페이지의 각 value 값을 저장하는 배열 메 모리 할당
        scrollPageValues = new float[transform.childCount];

        // 스크롤 되는 페이지 사이의 거리
        valueDistance = 1f / (scrollPageValues.Length - 1);

        // 스크롤 되는 페이지의 각 value 위치 설정 [0 <= value <= 1]
        for (int i = 0; i < scrollPageValues.Length; ++i)
        {
            scrollPageValues[i] = valueDistance * i;
        }

        // 최대 페이지의 수
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

        // 아래에 배치된 페이지 버튼 제어
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
        // 현재 Swipe를 진행중이면 터치 불가
        if (isSwipeMode == true) return;


        // 마우스 왼쪽 버튼을 눌렀을 때 1회
        if (Input.GetMouseButtonDown(0))
        {
            // 터치 시작 지점 (Swipe 방향 구분)
            startTouchX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // 터치 종료 지점 (Swipe 방향 구분)
            endTouchX = Input.mousePosition.x;

            UpdateSwipe();
        }
#if UNITY_ANDROID
		if ( Input.touchCount == 1 )
		{
			Touch touch = Input.GetTouch(0);

			if ( touch.phase == TouchPhase.Began )
			{
				// 터치 시작 지점 (Swipe 방향 구분)
				startTouchX = touch.position.x;
			}
			else if ( touch.phase == TouchPhase.Ended )
			{
				// 터치 종료 지점 (Swipe 방향 구분)
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
        // 너무 작은 거리를 움직였을 때는 Swipe X
        if (Mathf.Abs(startTouchX - endTouchX) < swipeDistance)
        {
            // 원래 페이지로 Swipe해서 돌아간다
            StartCoroutine(OnSwipeOneStep(currentPage));
            return;
        }

        // Swipe 방향
        bool isLeft = startTouchX < endTouchX ? true : false;

        // 이동 방향이 왼쪽일 때
        if (isLeft == true)
        {
            // 현재 페이지가 왼쪽 끝이면 종료
            if (currentPage == 0) return;

            // 왼쪽으로 이동을 위해 현재 페이지를 1 감소
            currentPage--;
        }
        // 이동 방향이 오른쪽일 떄
        else
        {
            // 현재 페이지가 오른쪽 끝이면 종료
            if (currentPage == maxPage - 1) return;

            // 오른쪽으로 이동을 위해 현재 페이지를 1 증가
            currentPage++;
        }

        // currentIndex번째 페이지로 Swipe해서 이동
        StartCoroutine(OnSwipeOneStep(currentPage));
    }

    /// <summary>
    /// 페이지를 한 장 옆으로 넘기는 Swipe 효과 재생
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
        // 아래에 배치된 페이지 버튼 크기, 색상 제어 (현재 머물고 있는 페이지의 버튼만 수정)
        for (int i = 0; i < scrollPageValues.Length; ++i)
        {
            circleContents[i].localScale = new Vector2(0.5f, 0.5f);
            circleContents[i].GetComponent<Image>().color = Color.white;

            // 페이지의 절반을 넘어가면 현재 페이지 원을 바꾸도록
            if (scrollBar.value < scrollPageValues[i] + (valueDistance / 2) && scrollBar.value > scrollPageValues[i] - (valueDistance / 2))
            {
                circleContents[i].localScale = new Vector2(0.5f, 0.5f) * circleContentScale;
                circleContents[i].GetComponent<Image>().color =bloom.tint.value;
            }
        }
    }
}




