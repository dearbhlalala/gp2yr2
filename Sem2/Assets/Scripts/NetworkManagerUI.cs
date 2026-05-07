using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NetworkManagerUI : MonoBehaviour
{
    [SerializeField] private Button Btn_Server;
    [SerializeField] private Button Btn_Host;
    [SerializeField] private Button Btn_Client;

    private void Awake()
    {
        
        Btn_Server.onClick.AddListener(() => {
            NetworkManager.Singleton.StartServer();
        });

        
        Btn_Host.onClick.AddListener(() => {
            NetworkManager.Singleton.StartHost();
        });

        
        Btn_Client.onClick.AddListener(() => {
            NetworkManager.Singleton.StartClient();
        });
    }
}
