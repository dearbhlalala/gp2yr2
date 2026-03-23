using UnityEngine;

public class DoorAnimate : MonoBehaviour
{
    Animator anim;
    public int doorOpenCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator> ();
    }

    void OnTriggerEnter(Collider other){

	
        if (other.gameObject.name == "Soldier" && anim.GetBool("doorOpen") == false) {

            anim.SetBool ("doorOpen", true);
            GameManager.instance.saveDataSO.saveData.doorOpenCount++;
            Debug.Log(GameManager.instance.saveDataSO.saveData.doorOpenCount);

        }
    }

    void OnTriggerExit(Collider other){
	
	if (other.gameObject.name == "Soldier") {

		anim.SetBool ("doorOpen", false);
		Debug.Log ("Door Close:" + other.gameObject.name);
	} 
}
}
