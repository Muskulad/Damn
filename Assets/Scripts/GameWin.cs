using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameWin : MonoBehaviour
{
    public Vector3 endStairsPosition;
    public float stairsDuration;
    public Transform stairsTransform;

    public Vector3 endPlayerPosition;
    public float playerDuration;
    public Transform playerTransform;

    public Vector3 endCameraPosition;
    public float cameraDuration;
    public Transform cameraTransform;

    public Animator playerAnimator;
    private bool isAnimationStarted;

   
    public GameObject gameWinCanvas;
    public GameObject gameCanvas;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartAnimation()
    {
        if (isAnimationStarted == true)
        {
            return;
        }
        isAnimationStarted = true;
        Sequence animation = DOTween.Sequence();
        animation.Append(stairsTransform.DOMove(endStairsPosition, stairsDuration))
            .Insert(1, playerTransform.DOMove(endPlayerPosition, playerDuration))
            .Insert(1, cameraTransform.DOMove(endCameraPosition, cameraDuration))
            .Append(playerTransform.DOMove(endPlayerPosition + (Vector3.forward * 4), 3))
            .OnComplete(() =>
            {
                playerAnimator.SetTrigger("StartDancing");
                playerTransform.DORotate(Vector3.up * 180, 1);
            });
        Sequence cameraAnimation = DOTween.Sequence();
        cameraAnimation.AppendInterval(11)
       .Append(cameraTransform.DOMove(endCameraPosition + (Vector3.forward * 11), 3))
       .OnComplete(() =>
       {
           gameWinCanvas.SetActive(true);
           gameCanvas.SetActive(false);

       });
    }
    
}
