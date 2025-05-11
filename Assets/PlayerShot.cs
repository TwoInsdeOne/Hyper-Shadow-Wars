using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShot : MonoBehaviour
{
    
    public List<GameObject> gun;
    public int currentGun;
    public PlayerActions playerActions;
    public Transform bulletExit;
    public Shake shake;
    public float shakeDuration;
    public float shakeStrenght;
    // Start is called before the first frame update
    void Start()
    {
        playerActions = new PlayerActions();
        playerActions.Actions.Enable();
        playerActions.Actions.Shot.started += Shot;
    }

    public void Shot(InputAction.CallbackContext context)
    {
        GameObject bullet = Instantiate(gun[currentGun]);
        bullet.transform.position = bulletExit.position;
        shake.StartShake(shakeDuration, shakeStrenght, false);
    }
}
