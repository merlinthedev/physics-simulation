using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private GameManager gameManager;

    private void Start() {
        initializeObject();
        DontDestroyOnLoad(gameObject);
    }

    public void initializeObject() {
        _rigidbody = GetComponent<Rigidbody>();
        gameManager = GameManager.getInstance();

        switch(gameManager.getChoice()) {
            case 0:
                _rigidbody.collisionDetectionMode = CollisionDetectionMode.Discrete;
                break;
            case 1:
                _rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
                break;
            case 2:
                _rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
                break;
            case 3:
                _rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
                break;
            default:
                _rigidbody.collisionDetectionMode = CollisionDetectionMode.Discrete;
                break;

        }

    }
}
