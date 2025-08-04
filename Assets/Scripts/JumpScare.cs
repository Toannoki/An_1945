using UnityEngine;

public class JumpScare : MonoBehaviour
{
    public AudioClip scareSound; // Kéo thả âm vào đây
    private AudioSource audioSource;
    public float fadeDuration = 2f; // Thời gian fade out

    void Start()
    {
        
    }

    System.Collections.IEnumerator HideAfterDelay()
    {
        yield return new WaitForSeconds(0.5f); // chờ 1 giây trước khi fade

        // Bắt đầu fade out
        float startVolume = audioSource.volume;
        float t = 0f;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, 0f, t / fadeDuration);
            yield return null;
        }

        audioSource.Stop();
        gameObject.SetActive(false); // ẩn vật thể
    }

    public void JumpAndHide()
    {
        gameObject.SetActive(true);
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = scareSound;
        audioSource.volume = 10f;
        audioSource.Play();

        StartCoroutine(HideAfterDelay());
    }
}
