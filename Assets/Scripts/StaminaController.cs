using UnityEngine;
using UnityEngine.UI;

public class StaminaController : MonoBehaviour
{
    [Header("UI")]
    public Image staminaBar;          // Ảnh thanh dọc, kiểu Filled – Vertical 

    [Header("Stamina")]
    public float maxStamina = 100f;   // Giá trị tối đa
    public float currentStamina;      // Giá trị hiện tại
    public float drainRate = 20f;     // Mất bao nhiêu mỗi giây khi di chuyển

    void Start()
    {
        currentStamina = maxStamina;
        UpdateStaminaUI();
    }

    void Update()
    {
        // Kiểm tra có đang nhấn phím di chuyển (WASD / mũi tên)
        bool isMoving = Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0;

        if (isMoving && currentStamina > 0f)
        {
            currentStamina -= drainRate * Time.deltaTime;
            currentStamina = Mathf.Max(currentStamina, 0f);
            UpdateStaminaUI();
        }

        /* Không hồi stamina, nên không làm gì khi đứng yên */
    }

    void UpdateStaminaUI()
    {
        // Với thanh dọc, đổi Fill Method thành "Vertical" và Fill Origin = Bottom (hoặc Top tùy bạn).
        if (staminaBar != null)
        {
            staminaBar.fillAmount = currentStamina / maxStamina;  // 0 → 1
        }
    }
}
