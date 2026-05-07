using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private GameObject hasKeyText;
    [SerializeField] private GameObject noKeyText;
    [SerializeField] private GameObject bouncer;


    public KeyScript keyScript;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && keyScript.hasKey==true)
        {
            Debug.Log("has key");

            hasKeyText.SetActive(true);
            bouncer.SetActive(false);
        }
        else if (other.CompareTag("Player") && keyScript.hasKey == false)
        {
            Debug.Log("no key");
            noKeyText.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        hasKeyText.SetActive(false);
        noKeyText.SetActive(false);
    }
}
