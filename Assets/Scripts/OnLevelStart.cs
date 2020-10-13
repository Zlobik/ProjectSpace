using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEditorInternal;
using UnityEngine;

public class OnLevelStart : MonoBehaviour
{
    [SerializeField] private GameObject _rocket;
    [SerializeField] private Sprite _rocket1Sprite;
    [SerializeField] private Animator _rocket1Animator;
    [SerializeField] private Sprite _rocket2Sprite;
    [SerializeField] private Animator _rocket2Animator;
    [SerializeField] private Sprite _rocket3Sprite;
    [SerializeField] private Animator _rocket3Animator;

    private void Start()
    {
        string choosedRocket = PlayerPrefs.GetString("ChoosedRocket");

        if (choosedRocket == "Rocket1")
        {
            SetChoosedRocketAnimator(_rocket1Animator);
            SetChooseSprite(_rocket1Sprite);
        }
        else if (choosedRocket == "Rocket2")
        {
            SetChoosedRocketAnimator(_rocket2Animator);
            SetChooseSprite(_rocket2Sprite);
        }
        else if (choosedRocket == "Rocket3")
        {
            SetChoosedRocketAnimator(_rocket3Animator);
            SetChooseSprite(_rocket3Sprite);

        }
        else
            Debug.Log("Это непредвиденная ошибочка блеать");
    }

    private void SetChooseSprite(Sprite renderer)
    {
        _rocket.GetComponent<SpriteRenderer>().sprite = renderer;
    }

    private void SetChoosedRocketAnimator(Animator rocketAnimator)
    {
        Animator animator = _rocket.GetComponent<Animator>();
        animator.runtimeAnimatorController = rocketAnimator.runtimeAnimatorController;
    }
}
