using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public int Health = 100;
    public int Score;
    public AudioSource CoinSound;
    public AudioSource WeaponAmmoAddSound;
    public AudioSource HealthPackAudio;
    public AudioSource WinAudio;
    public Text ScoreCountText;
    public Text WinText;
    public Text HealthCount;
    public WeaponManager weaponManager;

    // Start is called before the first frame update
    void Start()
    {
        ScoreCountText.GetComponent<Text>();
        ScoreCountText.text = "Score: " + Score;

        WinText.GetComponent<Text>();
        WinText.text = "";

        HealthCount.GetComponent<Text>();
        HealthCount.text = "Health: " + Health;
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "coin")
        {
            Destroy(other.gameObject);
            Score++;
            ScoreCountText.text = "Score: " + Score;
            CoinSound.Play();
        }

        if (other.gameObject.tag == "end" && Score == 4)
        {
            WinText.text = "You have won the game!";
            WinAudio.Play();
        }

        if (other.gameObject.tag == "bullet")
        {
            Health -= 10;
            HealthCount.text = "Health: " + Health;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "health pack")
        {
            Health += 10;
            HealthCount.text = "Health: " + Health;
            Destroy(other.gameObject);
            HealthPackAudio.Play();
        }

        if (other.gameObject.tag == "gun ammo")
        {
            if (weaponManager != null)
            {
                weaponManager.WeaponAmmoAdd();
                Destroy(other.gameObject);
                WeaponAmmoAddSound.Play();
            }
        }
    }
}
