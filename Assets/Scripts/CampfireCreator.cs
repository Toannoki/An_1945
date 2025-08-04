using UnityEngine;
using TMPro;

public class CampfireCreator : MonoBehaviour
{
    public GameObject Campfire;
    public FoodCount Wood;
    public float distanceFromPlayer = 2f;

    private float holdTime = 1f;
    private float holdTimer = 0f;
    private bool isHolding = false;

    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            isHolding = true;
            holdTimer += Time.deltaTime;

            if (holdTimer >= holdTime)
            {
                TryCreateCampfire();
                holdTimer = 0f;
                isHolding = false;
            }
        }
        else
        {
            isHolding = false;
            holdTimer = 0f;
        }
    }

    void TryCreateCampfire()
    {
        int currentWood = Wood.getCurrent();

        if (currentWood >= 5) // giả sử cần 5 gỗ
        {
            Vector3 spawnPosition = transform.position + transform.forward * distanceFromPlayer;
            Instantiate(Campfire, spawnPosition, Quaternion.identity);

        currentWood -= 5;
        Wood.setCurrent(currentWood);
    }
        else
        {
            Debug.Log("Không đủ gỗ để tạo campfire!");
        }
    }
}
