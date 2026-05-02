using System.Globalization;
using Unity.Cinemachine;
using UnityEngine;
using Unity.Netcode;

public class NetworkCamera : NetworkBehaviour
{
    [SerializeField] private CinemachineCamera cam;
    [SerializeField] private AudioListener listener;
    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            listener.enabled = true;
            cam.Priority = 1;
        }
        else
        {
            cam.Priority = 0;
        }
    }
}
