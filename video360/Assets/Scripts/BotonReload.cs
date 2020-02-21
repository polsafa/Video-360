

public class BotonReload : ObjectDisableOnClick
{
    public override void onclick()
    {
        VRmanager.instance.realoadvideo();
    }
}
