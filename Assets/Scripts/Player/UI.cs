using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class UI : MonoBehaviour
{

    public Text Health;
    public Text Ammo;
    public Text Wave;
    public Text EnemiesLeft;

    private GameObject playerObj;
    private Player player;
    private Weapon weapon;
    private WaveSpawner spawner;
    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.Find("Player");
        player = playerObj.GetComponent<Player>();
        weapon = playerObj.GetComponent<Weapon>();
        spawner = GameObject.Find("Spawner").GetComponent<WaveSpawner>();

        player.OnHealthChange.AddListener(HealthChange);
        Health.text = player.Health.ToString() + " HP";
    }

    // Update is called once per frame
    void Update()
    {
        Wave.text = "Wave: " + spawner.WaveNumber;
        EnemiesLeft.text = "Enemies left: " + WaveSpawner.HowMuchSpawned;
        Ammo.text = weapon.remainingAmmo + "/" + weapon.AmmoCount;
    }

    void HealthChange()
    {
        Health.text = player.Health.ToString() + " HP";
    }
}
