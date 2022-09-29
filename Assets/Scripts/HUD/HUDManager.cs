using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class HUDManager : MonoBehaviour
{
    #region Fields
    SetTargetVelocityEvent setTargetVelocityEvent = new SetTargetVelocityEvent();
    SetCannonBallVelocityEvent setCannonBallVelocityEvent = new SetCannonBallVelocityEvent();
    SetBurstNumberEvent setBurstNumberEvent = new SetBurstNumberEvent();
    SetBurstTimeEvent setBurstTimeEvent = new SetBurstTimeEvent();

    [SerializeField]
    TMP_InputField setTargetVelocityInputBox;
    [SerializeField]
    TMP_InputField setCannonBallVelocityInputBox;
    [SerializeField]
    TMP_InputField setBurstNumberInputBox;
    [SerializeField]
    TMP_InputField setBurstTimeInputBox;
    #endregion

    #region Unity methods
    // Start is called before the first frame update
    void Start()
    {
        EventManager.AddSetTargetVelocityInvoker(this);
        EventManager.AddSetCannonBallVelocityInvoker(this);
        EventManager.AddSetBurstNumberInvoker(this);
        EventManager.AddSetBurstTimeInvoker(this);

        setTargetVelocityInputBox.onEndEdit.AddListener(delegate { SetTargetVelocity(setTargetVelocityInputBox); });
        setCannonBallVelocityInputBox.onEndEdit.AddListener(delegate { SetCannonBallVelocity(setCannonBallVelocityInputBox); });
        setBurstNumberInputBox.onEndEdit.AddListener(delegate { SetBurstNumber(setBurstNumberInputBox); });
        setBurstTimeInputBox.onEndEdit.AddListener(delegate { SetBurstTimer(setBurstTimeInputBox); });
    }
    #endregion

    #region Private methods
    void SetTargetVelocity(TMP_InputField input)
    {
        if (input.text.Length > 0)
        {
            Debug.Log("SetTargetVelocity " + input.text);
            setTargetVelocityEvent.Invoke(float.Parse(input.text));
        }
        else if (input.text.Length == 0)
        {
            Debug.Log("Input Empty");
        }
    }

    void SetCannonBallVelocity(TMP_InputField input)
    {
        if (input.text.Length > 0)
        {
            Debug.Log("SetCannonBallVelocity " + input.text);
            setCannonBallVelocityEvent.Invoke(float.Parse(input.text));
        }
        else if (input.text.Length == 0)
        {
            Debug.Log("Input Empty");
        }
    }

    void SetBurstNumber(TMP_InputField input)
    {
        if (input.text.Length > 0)
        {
            Debug.Log("SetBurstNumber " + input.text);
            setBurstNumberEvent.Invoke(float.Parse(input.text));
        }
        else if (input.text.Length == 0)
        {
            Debug.Log("Input Empty");
        }
    }

    void SetBurstTimer(TMP_InputField input)
    {
        if (input.text.Length > 0)
        {
            Debug.Log("SetBurstTimer " + input.text);
            setBurstTimeEvent.Invoke(float.Parse(input.text));
        }
        else if (input.text.Length == 0)
        {
            Debug.Log("Input Empty");
        }
    }
    #endregion

    #region Event methods
    public void AddSetTargetVelocityListener(UnityAction<float> listener)
    {
        setTargetVelocityEvent.AddListener(listener);
    }

    public void AddSetCannonBallVelocityListener(UnityAction<float> listener)
    {
        setCannonBallVelocityEvent.AddListener(listener);
    }

    public void AddSetBurstNumberListener(UnityAction<float> listener)
    {
        setBurstNumberEvent.AddListener(listener);
    }

        public void AddSetBurstTimeListener(UnityAction<float> listener)
    {
        setBurstTimeEvent.AddListener(listener);
    }
    #endregion
}
