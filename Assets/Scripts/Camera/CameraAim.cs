using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraAim : MonoBehaviour {
    public Camera cam;
    public Transform defaultView, aimView;

    public void SwitchToDefault() {
        cam.transform.DOMove(defaultView.position, 0.5f);
        cam.transform.DORotate(defaultView.rotation.eulerAngles,0.5f);

    }

    public void SwitchToAimView() {
        cam.transform.DOMove(aimView.position, 0.5f);
        cam.transform.DORotate(aimView.rotation.eulerAngles, 0.5f);
    }
}
