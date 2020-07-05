using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core;

public static class TimeManager
{
    private static Tween _tweenTime;

    public static void DoSlowDown(){
        if(_tweenTime != null) return;
        _tweenTime = DOTween.To(()=> Time.timeScale, x => {
            Time.timeScale = x;
            Time.fixedDeltaTime = x * .02f;
        }, .1f, .7f).SetEase(Ease.OutQuart).SetUpdate(true);
    }

    public static void DoNormal(){
        _tweenTime.Kill();
        _tweenTime = null;
        Time.timeScale = 1f;
        Time.fixedDeltaTime = .02f;
    }
}
