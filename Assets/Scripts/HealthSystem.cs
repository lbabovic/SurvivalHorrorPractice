using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class HealthSystem : MonoBehaviour {
    public Slider healthSlider;
    public float maxHealth;
    public float currentHealth;
    public GameObject player;
    public GameObject playerCamera;

    public GameObject deathText;
    public GameObject fadeScreenIn;
    public GameObject HUD;

    bool done = false;
    bool playerDidDie = false;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = currentHealth / maxHealth;
        //if(!done) {
        //    StartCoroutine(TestRoutine());
      //  }

        if (currentHealth <= 0 && HUD.activeInHierarchy) {
            StartCoroutine(Die());
            HUD.SetActive(false);
        }

        if (playerDidDie && Input.GetButtonDown("SpaceAction")) {
            MySceneManager.ReloadLevel();
        }
    }

    public void DamagePlayerFor(float hp) {
        currentHealth -= hp;
        playerCamera.GetComponent<Animation>().Play("HitAnimation");
    }

    IEnumerator Die() {
        playerCamera.GetComponent<Animation>().Play("DeathAnimation");
        player.GetComponent<FirstPersonController>().enabled = false;
        fadeScreenIn.GetComponent<Animation>().enabled = false;
        yield return new WaitForSeconds(1f);
        fadeScreenIn.SetActive(true);
        fadeScreenIn.GetComponent<RawImage>().color = new Color32(0, 0, 0, 255);
        deathText.SetActive(true);
        playerDidDie = true;
    }

    IEnumerator TestRoutine() {
        done = true;
        yield return new WaitForSeconds(1f);
        currentHealth -= 10;
        done = false;
    }
}
