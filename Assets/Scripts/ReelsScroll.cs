using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ReelsScroll : MonoBehaviour
{
    [SerializeField] private RectTransform[] reels;
    [SerializeField] private float delayStep;
    [SerializeField] private Ease startEase;
    [SerializeField] private Button playButton;
    [SerializeField] private int countRotation, timeRotation;
    public void DoMoveReel()
    {
        playButton.interactable = false;
        for (int i = 0; i < reels.Length; i++)
        {
            reels[i].DOAnchorPosY(countRotation * -800, timeRotation)
                .SetDelay(i * delayStep)
                .SetEase(startEase)
                .OnComplete(() =>
                {
                    ResetGame();
                });

        }
    }

    public void ResetLocalPosition(RectTransform reel)
    {
        SymbolsMove symbolsOnReel = reel.GetComponent<SymbolsMove>();
        symbolsOnReel.ResetLocalPosition(countRotation * -800);
        reel.localPosition = new Vector3(0, 0);
    }
    void ResetGame()
    {
        if (reels[2].localPosition.y <= countRotation * -800 + 1)
        {
            playButton.interactable = true;

            foreach (RectTransform reel in reels)
            {
                ResetLocalPosition(reel);
            }
        }

    }
}
