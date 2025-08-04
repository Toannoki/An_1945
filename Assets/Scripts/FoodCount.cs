using TMPro;
using UnityEngine;

public class FoodCount : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private int target = 10;
    private int currentCount = 0;

    private TextMeshProUGUI m_TextMeshPro;
    private void Start()
    {

        m_TextMeshPro = GetComponent<TextMeshProUGUI>();
        if (m_TextMeshPro !=null)
        {
            m_TextMeshPro.text = "("+ currentCount +"/" + target +")"; 
        }
    }

    public void SetTargetCount(int target)
    {
        this.target = target;
    }
    public void NextCurrentCount()
    {
        currentCount++;
        m_TextMeshPro.text = "(" + currentCount + "/" + target + ")";
    }
    public int getTarget()
    {
        return target;
    }
    public int getCurrent()
    {
        return currentCount;
    }
    public void setCurrent(int current)
    {
        this.currentCount = current;
        m_TextMeshPro.text = "(" + currentCount + "/" + target + ")";
    }
}
