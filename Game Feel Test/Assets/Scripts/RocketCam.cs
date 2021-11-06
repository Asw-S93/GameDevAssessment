using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class RocketCam : MonoBehaviour
{

    [SerializeField]
    PlayableDirector playable;
    CinemachineVirtualCamera rocketCam;

   

    private void Awake()
    {
        rocketCam = GetComponent<CinemachineVirtualCamera>();
    }


    public void SetAnchorPlay(Transform target, Transform anchor)
    {
        rocketCam.transform.SetParent(anchor);
        rocketCam.transform.position = anchor.position;
        rocketCam.LookAt = target;
        playable.Play();

    }



}
