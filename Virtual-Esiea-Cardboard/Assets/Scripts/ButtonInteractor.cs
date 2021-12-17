using UnityEngine;
using UnityEngine.Events;

public class ButtonInteractor : MonoBehaviour
{
    private bool m_watch;

    [SerializeField]
    private Timer m_timer;

    [SerializeField]
    private UnityEvent click;

    // Start is called before the first frame update
    void Start()
    {
        m_watch = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_timer.IsActive && m_watch == true)
        {
            click.Invoke();
        }
    }

    public void OnPointerEnter()
    {
        m_watch = true;
        m_timer.Activate();
    }

    public void OnPointerExit()
    {
        m_watch = false;
        m_timer.NullTimerCharger();
    }
}
