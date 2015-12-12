using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

    public static GameController Controller;

    void Awake()
    {
        if (Controller == null)
        {
            DontDestroyOnLoad(gameObject);
            Controller = this;
        }
        else if (Controller != this)
        {
            Destroy(gameObject);
        }
    }
}
