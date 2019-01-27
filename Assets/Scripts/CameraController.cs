using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;       //Public variable to store a reference to the player game object
    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        if (!player)
        {
            player = GameObject.Find("playerPossum(Clone)");
            offset = transform.position - player.transform.position;
        }
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        if (player) {
            transform.position = player.transform.position + offset;
        }
    }
    /*
    private GameObject player;
    private Vector3 minBoundX;
    private Vector3 maxBoundX;
    private Vector3 minBoundY;
    private Vector3 maxBoundY;
    public GameObject startLimitLevel;
    public GameObject endLimitLevel;
    public float smooth;

    void Start()
    {
        smooth = 10.0f;
    }

    void LateUpdate()
    {
        if (!player)
        {
            player = GameObject.Find("playerPossum(Clone)");
        }
        
        SetBounds();

        if (!IsLimitLevel() &&
            IsBound())
        {
            Vector3 playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, playerPosition, smooth * Time.deltaTime);
        }
    }

    void SetBounds()
    {
        minBoundX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 0.3f, Camera.main.transform.position.y, Camera.main.transform.position.z));
        maxBoundX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 0.7f, Camera.main.transform.position.y, Camera.main.transform.position.z));
        minBoundY = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.transform.position.x, Screen.height * 0.4f, Camera.main.transform.position.z));
        maxBoundY = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.transform.position.x, Screen.height * 0.7f, Camera.main.transform.position.z));
    }

    bool IsBound()
    {
        if (player.transform.position.x > maxBoundX.x ||
            player.transform.position.x < minBoundX.x ||
            player.transform.position.y > maxBoundY.y ||
            player.transform.position.y < minBoundY.y)
        {
            return true;
        }
        return false;
    }

    bool IsLimitLevel()
    {
        if (player.transform.position.x < startLimitLevel.transform.position.x - 2.0f ||
            player.transform.position.x > endLimitLevel.transform.position.x - 4.0f)
        {
            return true;
        }
        return false;
    }
    */
}
