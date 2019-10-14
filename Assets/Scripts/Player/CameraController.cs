using UnityEngine;
using UnityEngine.Tilemaps;

namespace Medieval.Player
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] float xOffset = 0;

        Vector2 topRightLimit;
        Vector2 botLeftLimit;
        float halfHeight;
        float halfWidth;

        GameObject playerBody;
        Tilemap map;

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
            playerBody = FindObjectOfType<Manager>().GetComponentInChildren<SpriteRenderer>().gameObject;
            halfHeight = UnityEngine.Camera.main.orthographicSize;
            halfWidth = halfHeight * UnityEngine.Camera.main.aspect;
            map = FindObjectOfType<Grid>().GetComponentInChildren<Tilemap>();
            botLeftLimit = map.localBounds.min;
            topRightLimit = map.localBounds.max;
        }

        private void FollowPlayer()
        {
            float posX = Mathf.Clamp(playerBody.transform.position.x + halfWidth * xOffset, botLeftLimit.x + halfWidth + 1, topRightLimit.x - halfWidth + halfWidth * 2 * xOffset);
            float posY = Mathf.Clamp(playerBody.transform.position.y, botLeftLimit.y + halfHeight + 1, topRightLimit.y - halfHeight);
            transform.position = new Vector3(posX, posY, transform.position.z);
        }
    }
}