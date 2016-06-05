namespace itechart.smg.api.csharp.Model.Parameters
{
    public interface IBaseApiParameters<out TInput>
    {
        TInput ToInput();
    }
}