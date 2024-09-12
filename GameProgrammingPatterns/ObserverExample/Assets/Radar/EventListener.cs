using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UnityGameObjectEvent : UnityEvent<GameObject> {

}
public class EventListener : MonoBehaviour
{
    public Event GetEvent;
    public UnityGameObjectEvent response = new UnityGameObjectEvent();

    private void OnEnable()
    {
        GetEvent.Register(this);
    }

    private void OnDisable()
    {
        GetEvent.Unregister(this);
    }

    public void OnEnvetOccurs(GameObject gObj) {
        response.Invoke(gObj);
    }
}
