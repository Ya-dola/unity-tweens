using ElRaccoone.Tweens.Core;
using UnityEngine;

namespace ElRaccoone.Tweens.Core.Drivers {
  [AddComponentMenu ("")]
  public class EulerAnglesZTween : Tween<float> {
    private Quaternion quaternionValueFrom;
    private Quaternion quaternionValueTo;

    public override bool OnInitialize () {
      return true;
    }

    public override float OnGetFrom () {
      return this.transform.eulerAngles.z;
    }

    public override void OnUpdate (float easedTime) {
      this.quaternionValueFrom = Quaternion.Euler (this.transform.eulerAngles.x, this.transform.eulerAngles.y, this.valueFrom);
      this.quaternionValueTo = Quaternion.Euler (this.transform.eulerAngles.x, this.transform.eulerAngles.y, this.valueTo);
      this.transform.rotation = Quaternion.Lerp (this.quaternionValueFrom, this.quaternionValueTo, easedTime);
    }
  }
}