using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum WeapState {
        Ready,
        Unloaded,
        Shooting,
        Reloading
    }


    public AudioSource audioSource;
    public GameObject round;
    public float Damage;
    public int AmmoCount;
    public float ReloadTime;
    public float FireRate;
    public float MuzzleVelocity;
    public float RoundSpread;

    public int remainingAmmo;
    private WeapState State = WeapState.Ready;

    private float nextShootTime = 0;

    private void Start()
    {
        remainingAmmo = AmmoCount;
        audioSource.volume = GameSettings.Volume;
    }

    private void Update()
    {
        switch (State)
        {
            case WeapState.Unloaded:
                break;
            case WeapState.Shooting:
                if (Time.time > nextShootTime)
                {
                    State = WeapState.Ready;
                }
                break;
            case WeapState.Reloading:
                if (Time.time > nextShootTime)
                {
                    remainingAmmo = AmmoCount;
                    State = WeapState.Ready;
                }
                break;
        }
    }

    public void Shoot()
    {
        if (State == WeapState.Ready)
        {
            //Play the sound
            if(audioSource!=null)
            {
                audioSource.Play();
            }


            // Instantiates the round at the muzzle position
            GameObject spawnedRound = Instantiate(
                round,
                transform.position,
                transform.rotation
            );

            Rigidbody rb = spawnedRound.GetComponent<Rigidbody>();
            rb.velocity = spawnedRound.transform.right * MuzzleVelocity;

            Round spawnedroundclass = spawnedRound.GetComponent<Round>();
            spawnedroundclass.SetDamage(Damage);

            remainingAmmo--;

            if(remainingAmmo > 0)
            {
                nextShootTime = Time.time + (1 / FireRate);
                State = WeapState.Shooting;
            }
            else
            {
                State = WeapState.Unloaded;
                Reload();
            }
        }



    }

    public void Reload()
    {
        // Checks that the gun is ready to be reloaded
        if (State == WeapState.Ready || State == WeapState.Unloaded)
        {
            nextShootTime = Time.time + ReloadTime;
            State = WeapState.Reloading;
        }
    }
}
