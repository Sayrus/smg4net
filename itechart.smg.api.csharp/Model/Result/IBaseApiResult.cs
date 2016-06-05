namespace itechart.smg.api.csharp.Model.Result
{
    public interface IBaseApiResult<in TOutput>
    {
        void InitializeFromOutput(TOutput output);
    }
}