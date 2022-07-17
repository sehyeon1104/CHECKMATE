using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using System;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class DialogPanel : MonoBehaviour
{
    [SerializeField]
    VolumeProfile volume;
    Vignette vign;
    public RectTransform sss;
    public Sprite[] changeImage;
    public Image image;

    private List<TextVO> list;
    private RectTransform panel;

    public TMP_Text dialogText;
    private WaitForSeconds shortWs = new WaitForSeconds(0.08f);

    private bool clickToNext = false;
    private bool isOpen = false;

    public GameObject nextIcon;
    public Image profileImage;
    public AudioSource typeClip;

    private int currentIndex;
    private RectTransform textTransform;

    private Dictionary<int, Sprite> imageDictionary = new Dictionary<int, Sprite>();

    private Action endDialogCallback = null;
    int level = 0;
    private void Awake()
    {
        volume.TryGet(out vign);
        panel = GetComponent<RectTransform>();
        textTransform = dialogText.GetComponent<RectTransform>();
    }

    public void StartDialog(List<TextVO> list, Action callback = null)
    {
        endDialogCallback = callback;
        this.list = list;
        ShowDialog();
    }


    public void ChessMalChangeDial(int Level)
    {
        switch (Level)
        {
            case 0:
            case 5:
                vign.color.Override(Color.yellow);
                break;
            case 1:
                vign.color.Override(Color.magenta);
                break;
            case 2:
                vign.color.Override(Color.green);
                break;
            case 3:
                vign.color.Override(Color.red);
                break;
            case 4:
                vign.color.Override(Color.blue);
                break;

        }
        if (Level > 0 && level <= 4)
        {
            image.sprite = changeImage[0];
        }
        else
        {
            image.sprite = changeImage[2];
        }
        GameManager.ShowDialog(Level);
    }
    void GoScene()
    {
        SceneManager.LoadScene("SelectScene");
    }
    public void ShowDialog()
    {
        currentIndex = 0;
        GameManager.Instance.TimeScale = 0f;

        profileImage.sprite = null;
        dialogText.text = "";
        SpriteSet(list[currentIndex]);
        panel.DOScale(new Vector3(1, 1, 1), 0.8f).OnComplete(() =>
        {
            TypeIt(list[currentIndex]);
            isOpen = true;
        });
    }


    public void SpriteSet(TextVO vo)
    {
        int idx = vo.icon;

        if (!imageDictionary.ContainsKey(idx))
        {
            Sprite img = Resources.Load<Sprite>($"profile{idx}");
            imageDictionary.Add(idx, img);
        }

        profileImage.sprite = imageDictionary[idx];
    }
    public void TypeIt(TextVO vo)
    {


        dialogText.text = vo.msg;
        nextIcon.SetActive(false);
        clickToNext = false;
        StartCoroutine(Typing());
    }

    IEnumerator Typing()
    {
        dialogText.ForceMeshUpdate();
        dialogText.maxVisibleCharacters = 0;
        int totalVisibleChar = dialogText.textInfo.characterCount;
        for (int i = 1; i <= totalVisibleChar; i++)
        {
            typeClip.Play();
            dialogText.maxVisibleCharacters = i;


            if (clickToNext)
            {
                dialogText.maxVisibleCharacters = totalVisibleChar;
                break;
            }
            yield return shortWs;
        }

        currentIndex++;
        clickToNext = true;
        nextIcon.SetActive(true);
    }



    private void Update()
    {
        print(level);
        if (level == 6)
        {
            Invoke("GoScene", 1f);
        }
        if (!isOpen) return;

        if ((Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.Return)) && clickToNext)
        {
            if (currentIndex >= list.Count)
            {

                panel.DOScale(new Vector3(0, 0, 1), 0.8f).OnComplete(() =>
                {
                    GameManager.Instance.TimeScale = 1f;
                    isOpen = false;
                    if (endDialogCallback != null)
                    {

                        endDialogCallback();
                    }
                    ++level;
                    ChessMalChangeDial(level);


                });


            }
            else
            {
                TypeIt(list[currentIndex]);
            }
        }
        else if (Input.GetButtonDown("Jump"))
        {
            clickToNext = true;
        }
    }
}
