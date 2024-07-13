using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_Idk : MonoBehaviour
{
    public bool reloadTrue = false;
    public CharacterController cc;
    public AnimationControlScript anim;
    public GameObject GFX; 
    public GameObject GameOver;
    // Start is called before the first frame update
    void Start()
    {
        GameOver.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = GFX.transform.position + new Vector3(0, 1, 0);
        if(reloadTrue&&Input.anyKey){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void OnTriggerEnter(Collider collider){
        if (collider.gameObject.CompareTag("Enemy")){
            cc.enabled = false;
            anim.isDead = true;
            reloadTrue = true;
            GameOver.SetActive(true);
            if(Input.anyKey){
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
            }
        }
    }
}
