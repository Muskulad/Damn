using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameOver : MonoBehaviour
{
    public SpawnManager ducks;
    public SpawnManager trash;

    public Animator playerAnimator;
    private bool isAnimationStarted;

    public Transform playerTransform;

    public Transform endPlayerPosition;
    public float playerDuration;

    public GameObject gameOverCanvas;
    public GameObject gameCanvas;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void gameOver()
    {
        ducks.isSpawnable = false;
        trash.isSpawnable = false;
        if (isAnimationStarted == true)
        {
            return;
        }
        isAnimationStarted = true;
        Sequence animation = DOTween.Sequence();
        animation.Append(playerTransform.DORotate(Vector3.up * 180, 1))
            
         .OnComplete(() =>
         {
             playerAnimator.SetTrigger("Jumping");
             playerTransform.DOMove(endPlayerPosition.position, playerDuration)
                .OnComplete(() =>
                {
                    gameOverCanvas.SetActive(true);
                    gameCanvas.SetActive(false);
                });
         });
        
    }
}
