using System.Collections.Generic;
using UnityEngine;

public enum Language
{
    English,
    Vietnamese
}

public class LanguageManager : MonoBehaviour
{
    public static LanguageManager Instance { get; private set; }

    public Language currentLanguage = Language.Vietnamese;

    private Dictionary<string, string> vietnamese = new Dictionary<string, string>()
    {
        { "0", "An" },
        { "3", "Ngày hôm nay có gì ăn vậy mẹ ?" },
        { "5", "Ồ hôm nay ngon thế bình thường nhà mình toàn ăn khoai mà lại còn bị úng nữa chứ" },
        { "7", "..." },

        { "11", "con chào ba ạ" },

        { "12", "Con ăn xong rồi. Thưa mẹ con đi" },
        { "15", "Này cậu còn sống không vậy, tỉnh lại đi" },
        { "17", "Này tớ có chút đồ ăn, ăn tạm đi nha" },
        { "14", "(Nhà mình chọn sống trong rừng là vì nếu có người biết cả nhà mình phải đóng thế thân mất, " +
            "mà như thế thì còn khổ hơn là đói, dù sao thì " +
            "khu rừng này cũng có đủ đồ ăn mà.)" },
        


        { "1", "Ba" },
        { "8", "Thôi con mau ngồi xuống ăn đi" },

        { "9", "Thôi, ba ăn xong rồi, ba đi làm trước đây. Chào hai mẹ con nha." },


        { "2", "Mẹ" },
        { "4", "Bữa nay có ít cháo nè con" },
        { "6", "Ừ lâu lâu nhà mình đổi món chút đó mà, nắm gạo cuối cùng của nhà mình rồi" },

        { "10", "Chào anh nha, nhớ về sớm với em nha" },
        { "13", "Ừ chào con nha " },
      

        { "Play", "Thức" },
        { "Settings", "Tiềm thức" },
        { "Exit", "Buông" },
        { "Exit1", "Rời" },
        { "Continue", "Níu" },
        { "Resolution", "Độ phân giải" },
        { "Sensitivity", "Độ nhạy" },
        { "Language", "Ngôn ngữ" },

        { "Tu", "Tu" },
        { "16", "Hu hu hu… con tới gặp mọi người đây ạ." },

        { "Findfood", "Tìm thức ăn" },



        
    };

    private Dictionary<string, string> english = new Dictionary<string, string>()
{
    { "0", "An" },
    { "3", "Huh? Where did it go?" },
    { "4", "Maybe I'm still sleepy..." },
    { "5", "I better keep looking..." },
    { "6", "Again...? Really...?" },
    { "7", "Am I going crazy...?" },
    { "8", "Oh... It was here all along." },
    { "9", "Wait—where's my Teddy?" },
    { "10", "Did I drop it somewhere?" },
    { "11", "No... I'm still holding Teddy." },
    { "16", "Why's the door stuck...?" },

    { "1", "Dad" },
    { "14", "Wait. I'm coming." },
    { "15", "If you're hungry, then eat." },

    { "2", "Mom" },
    { "12", "Sweetie, help mommy set the table." },
    { "13", "Go call daddy in for dinner, okay?" },
    { "17", "Let me open that for you." },

    { "Door_1", "I haven’t found Teddy yet :((" },

    { "Play", "Awaken" },
    { "Settings", "Subconscious" },
    { "Exit", "Leave" },
    { "Exit1", "Exit" },
    { "Continue", "Cling" },
    { "Resolution", "Resolutions" },
    { "Sensitivity", "Sensitivity" },
    { "Language", "Language" },
};


    private void Awake()
    {
        // Đảm bảo Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Không bị huỷ khi đổi scene
    }

    /// <summary>
    /// Trả về bản dịch tương ứng theo ngôn ngữ hiện tại.
    /// Nếu không có key, trả về chính key đó và cảnh báo.
    /// </summary>
    public string GetText(string key)
    {
        Dictionary<string, string> dict = currentLanguage == Language.Vietnamese ? vietnamese : english;

        if (dict.TryGetValue(key, out string value))
            return value;

        Debug.LogWarning("Thiếu bản dịch cho key: " + key);
        return key;
    }

    /// <summary>
    /// Đổi ngôn ngữ trong lúc chạy game.
    /// </summary>
    public delegate void OnLanguageChanged();
    public event OnLanguageChanged LanguageChanged;

    public void SetLanguage(Language lang)
    {
        if (currentLanguage == lang) return;

        currentLanguage = lang;
        Debug.Log("Đã đổi ngôn ngữ sang: " + lang);

        // Gọi sự kiện để mọi UI biết và cập nhật
        LanguageChanged?.Invoke();
    }



}
