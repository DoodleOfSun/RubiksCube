using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;  // Singleton ���� ���
    private AudioSource bgmSource;
    public Slider bgmSlider;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // ���� ����Ǿ ����
        }
        else
        {
            Destroy(gameObject); // �ߺ� ����
            return;
        }

        bgmSource = GetComponent<AudioSource>(); // �ٷ� ������
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

    // ���� ����� �� �����̴��� �ٽ� �����ϴ� �Լ�
    public void SetBgmSlider(Slider slider)
    {
        bgmSlider = slider;
        if (bgmSlider != null)
            bgmSource.volume = bgmSlider.value;
    }
}