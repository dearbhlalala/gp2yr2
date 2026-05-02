using Unity.AI.Navigation.Samples;
using Unity.Cinemachine;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    CinemachineCamera cam;
    void Awake()
    {
        cam = GetComponent<CinemachineCamera>();
    }

    public void CameraFollow()
    {
        cam.Follow = FindFirstObjectByType<ClickToMove>().transform;
    }
}
