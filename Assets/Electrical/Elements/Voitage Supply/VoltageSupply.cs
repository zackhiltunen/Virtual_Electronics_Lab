/// <summary>
///NOTE: Attach leads as children of supply gameObject.
/// </summary>
public class VoltageSupply : Component
{
    private void Awake()
    {
        Type = ComponentType.Supply;
    }
}