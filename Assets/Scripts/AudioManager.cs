using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;  // Singleton 패턴 사용
    private AudioSource bgmSource;
    public Slider bgmSlider;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 씬이 변경되어도 유지
        }
        else
        {
            Destroy(gameObject); // 중복 방지
            return;
        }

        bgmSource = GetComponent<AudioSource>(); // 바로 가져옴
    }

    void Start()
    {
        if (bgmSlider != null)
            bgmSource.volume = bgmSlider.value;
    }

    void Update()
    {
        if (bgmSlider != null)
            bgmSource.volume = bgmSlider.value;
    }

    // 씬이 변경될 때 슬라이더를 다시 연결하는 함수
    public void SetBgmSlider(Slider slider)
    {
        bgmSlider = slider;
        if (bgmSlider != null)
            bgmSource.volume = bgmSlider.value;
    }
}