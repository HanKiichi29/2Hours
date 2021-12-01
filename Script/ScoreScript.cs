using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ScoreScript : MonoBehaviour
{

    [SerializeField] private Text ScoreText;
    [SerializeField] private Text HightScoreText;
    [SerializeField] private Text S_HightScore;
    [SerializeField] private Text TotyuuScore;


    [SerializeField] private List<AudioClip> ToTyuu = new List<AudioClip>();
   


    private int ScoreNum;
    private int HightScoreNum;


    private AudioSource audioSource;
    


    private void Start()
    {
        audioSource=GetComponent<AudioSource>();
        HightScoreText.text = "ハイスコア：" + HightScoreNum.ToString();
        ScoreReset();
    }


    public void ScoreReset()
    {
        ScoreNum = 0;
        DrowText();
    }

    public void AddScore()
    {

        ScoreNum += 100;
        TotyuuMoney();
        DrowText();
    }

    private void DrowText()
    {
        ScoreText.text = "拾ったお金："+ScoreNum.ToString();

    }

    public void ScoreCheck()
    {
        if (HightScoreNum<ScoreNum)
        {
            
            HightScoreNum = ScoreNum;
            HightScoreText.text = "ハイスコア："+HightScoreNum.ToString();
            Invoke("SayHight", 1);
          

        }
        else
        {
            return;
        }
    }

    private void SayHight()
    {
        S_HightScore.DOFade(1, 1)
            .SetLink(gameObject)
            .SetLoops(2, LoopType.Yoyo);

        audioSource.PlayOneShot(audioSource.clip);
    }
   

    private void TotyuuMoney()
    {
        if (ScoreNum == 1000)
        {
            audioSource.PlayOneShot(ToTyuu[0]);
            fadeText();
        }
        else if (ScoreNum == 2000)
        {
            audioSource.PlayOneShot(ToTyuu[1]);
            fadeText();
        }
        else if (ScoreNum == 3000)
        {
            audioSource.PlayOneShot(ToTyuu[2]);

            fadeText();
        }
        else if (ScoreNum == 4000)
        {
            audioSource.PlayOneShot(ToTyuu[3]);
            fadeText();
        }
        else if (ScoreNum == 5000)
        {
            audioSource.PlayOneShot(ToTyuu[4]);
            fadeText();
        }
    }


    private void fadeText()
    {
        TotyuuScore.text = ScoreNum.ToString() + "円突破！！";

        TotyuuScore.DOFade(1, 0.5f)
            .SetLink(gameObject)
            .SetEase(Ease.Linear)
            .SetLoops(2, LoopType.Yoyo);
    }
}
