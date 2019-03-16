using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerCamera : MonoBehaviour
{
    GameObject playerBody;
    Tilemap map;
    Vector2 topRightLimit;
    Vector2 botLeftLimit;
    float halfHeight;
    float halfWidth;

    private void Start()
    {
        SetVariables();
    }

    private void Update()
    {
        FollowPlayer();
    }

    private void SetVariables()
    {
        playerBody = Player.instance.GetComponentInChildren<SpriteRenderer>().gameObject;
        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect;
        map = FindObjectOfType<Grid>().GetComponentInChildren<Tilemap>();
        botLeftLimit = map.localBounds.min;
        topRightLimit = map.localBounds.max;
    }

    private void FollowPlayer()
    {
        float posX = Mathf.Clamp(playerBody.transform.position.x, botLeftLimit.x + halfWidth + 1, topRightLimit.x - halfWidth);
        float posY = Mathf.Clamp(playerBody.transform.position.y, botLeftLimit.y + halfHeight + 1, topRightLimit.y - halfHeight);
        transform.position = new Vector3(posX, posY, transform.position.z);
    }
}
