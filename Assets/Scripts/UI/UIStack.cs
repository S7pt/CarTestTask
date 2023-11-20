using System.Collections.Generic;
using UnityEngine;

public class UIStack : MonoBehaviour
{
    private Stack<UIWindow> _uiComponentsStack = new Stack<UIWindow>();

    public static UIStack Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void Push(UIWindow component)
	{
        _uiComponentsStack.Push(component);
        component.Enable();
	}

    public void Pop(UIWindow component)
	{
        if(component != _uiComponentsStack.Peek())
		{
            return;
		}
        component.Disable();
        _uiComponentsStack.Pop();
        _uiComponentsStack.Peek().Enable();
	}
}
