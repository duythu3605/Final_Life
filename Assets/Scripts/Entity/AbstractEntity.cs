using UnityEngine;

public abstract class AbstractEntity : IEntity
{
    public string OwnedKey => "Owned" + Id.ToString();
    public string ActivatedKey => "Activated" + Id.ToString();

    public abstract int Id { get; }

    [field: SerializeField]
    public string Name { get; set; }

    public bool IsOwn => PlayerPrefs.HasKey(OwnedKey);

    public bool IsActivated => PlayerPrefs.HasKey(ActivatedKey);

    public void Activated()
    {
        PlayerPrefs.SetInt(ActivatedKey, 1);
    }

    public void Own()
    {
        PlayerPrefs.SetInt(OwnedKey, 1);
    }

    public void DeActivated()
    {
        PlayerPrefs.DeleteKey(ActivatedKey);
    }

    public void DeOwn()
    {
        PlayerPrefs.DeleteKey(OwnedKey);
    }
}
