using Fusion;

public abstract class UIWindow : NetworkBehaviour
{
    public virtual void Enable()
	{
		gameObject.SetActive(true);
	}

	public virtual void Disable()
	{
		gameObject.SetActive(false);
	}

	public virtual void GoBack()
	{
		UIStack.Instance.Pop(this);
	}
}
