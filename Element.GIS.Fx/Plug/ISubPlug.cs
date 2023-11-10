namespace Element.GIS.Fx.Plug
{
    public interface ISubPlug
    {
        string Name { get; }
        string Title { get; }
        string Description { get; }
        bool FreeUse { get; }
        object AvaloniaControl { get; }
        void ButtonClick();
    }
}