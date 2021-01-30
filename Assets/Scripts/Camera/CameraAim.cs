using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraAim : MonoBehaviour {
    public Camera cam;
    public Transform defaultView, aimView;

    public void SwitchToDefault() {
        cam.transform.DOLocalMove(defaultView.position, 0.5f);
        cam.transform.DOLocalRotate(defaultView.rotation.eulerAngles,0.5f);

    }

    public void SwitchToAimView() {
        cam.transform.DOLocalMove(aimView.position, 0.5f);
        cam.transform.DOLocalRotate(aimView.rotation.eulerAngles, 0.5f);
    }
}
