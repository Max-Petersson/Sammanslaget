using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField] private GameObject thingToFollow;
    [SerializeField] private GameObject textThatFollows;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textThatFollows.transform.position = thingToFollow.transform.position;
    }
}
