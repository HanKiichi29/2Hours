using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UniRx;

public class RandamCameKiichi : MonoBehaviour
{

    [SerializeField] private GameObject Kiichi;
    [SerializeField] private float KiichiSpeed;
    [SerializeField] private Button PikUpButton;
    [SerializeField] private AudioClip Tyarin;
    [SerializeField] private ScoreScript _scoreScript;


    private Vector2 D_transform;
    private int RandomNum;

    private AudioSource audi;

    private void Start()
    {
        PikUpButton.GetComponent<Button>();
        audi = GetComponent<AudioSource>();
        D_transform = Kiichi.transform.position;

        
    }


    public void RandomCome()
    {
        RandomNum = Random.Range(0, 10);
        audi.PlayOneShot(Tyarin);

        if (RandomNum == 0)
        {

            _scoreScript.ScoreCheck();
            PikUpButton.interactable = false;
            audi.PlayOneShot(audi.clip);
            Kiichi.transform.DOMoveX(-20, KiichiSpeed)
                .SetEase(Ease.Linear)
                .SetLink(gameObject)
                .OnComplete(() => { Invoke("Refresh", 1.3f);  });

            Initialize();

        }
        else
        {
            _scoreScript.AddScore();
        }

        


    }

    private void Initialize()
    {
        _scoreScript.ScoreReset();
    }

    private void Refresh()
    {
        Kiichi.transform.position = D_transform;
        PikUpButton.interactable = true;
    }
}
