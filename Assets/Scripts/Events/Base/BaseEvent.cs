namespace Events.Base
{
    public class BaseEvent
    {
        public void Dispatch()
        {
            Model.Instance.EventController.HandleEvent(this);
        }
    }
}
