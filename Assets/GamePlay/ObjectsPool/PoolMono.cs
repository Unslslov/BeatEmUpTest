using System.Collections.Generic;
using UnityEngine;

public class PoolMono<T> where T : MonoBehaviour
{
    public T prefab {get;}
    public bool autoExpand {get; set;}
    public Transform container {get;}

    private List<T> pool;

    public PoolMono(T prefab, int count, Transform container)
    {
        this.prefab = prefab;
        this.container = container;

        CreatePool(count);
    }

    private void CreatePool(int count)
    {
        pool = new List<T>();

        for(int i=0; i < count; i++)
            CreateObject();
        
    }

    private T CreateObject(bool isActiveByDefault = false)
    {
        var createObject = Object.Instantiate(this.prefab, this.container);
        createObject.gameObject.SetActive(isActiveByDefault);
        this.pool.Add(createObject);
        return createObject;
    }

    public bool HasFreeElement(out T element)
    {
        foreach(var mono in pool)
        {
            if(!mono.gameObject.activeInHierarchy)
            {
                element = mono;
                mono.gameObject.SetActive(true);

                return true;
            }
        }

        element = null;
        return false;
    }

    public T GetFreeElement()
    {
        if(this.HasFreeElement(out var element))
            return element;

        if(this.autoExpand)
            return this.CreateObject(true);

        throw new System.Exception($"There is no free elements in pool of type {typeof(T)}");
    }

    public List<T> GetFreeSomeElement(int count)
    {
        List<T> elements = new List<T>();

        for (int i = 0; i < count; i++)
        {
            if (this.HasFreeElement(out var element))
            {
                elements.Add(element);
            }
            else if (this.autoExpand)
            {
                elements.Add(this.CreateObject(true));
            }
            else
            {
                break; // If there are not enough elements, exit the loop
            }
        }

        if (elements.Count == 0)
        {
            throw new System.Exception($"There are no free elements in pool of type {typeof(T)} or unable to expand.");
        }

        return elements;
    }
}
