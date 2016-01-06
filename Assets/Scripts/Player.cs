using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    public string UserName;
    public bool Human;
    private Player _player;

	// Use this for initialization
	void Start () {
        _player = transform.root.GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
