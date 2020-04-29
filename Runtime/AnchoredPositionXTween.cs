using ElRaccoone.Tweens.Core;
using UnityEngine;

namespace ElRaccoone.Tweens {
  public static class AnchoredPositionXTween {
    public static Tween<float> TweenAnchoredPositionX (this Component self, float to, float duration) =>
      self.gameObject.TweenAnchoredPositionX (to, duration);

    public static Tween<float> TweenAnchoredPositionX (this GameObject self, float to, float duration) =>
      self.AddComponent<Tween> ().Finalize (duration, to);

    private class Tween : Tween<float> {
      private RectTransform rectTransform;
      private Vector2 anchoredPosition;

      public override bool OnInitialize () {
        this.rectTransform = this.gameObject.GetComponent<RectTransform> ();
        return this.rectTransform != null;
      }

      public override float OnGetFrom () {
        return this.rectTransform.anchoredPosition.x;
      }

      public override void OnUpdate (float easedTime) {
        this.anchoredPosition = this.rectTransform.anchoredPosition;
        this.valueCurrent = this.InterpolateValue (this.valueFrom, this.valueTo, easedTime);
        this.anchoredPosition.x = this.valueCurrent;
        this.rectTransform.anchoredPosition = this.anchoredPosition;
      }
    }
  }
}