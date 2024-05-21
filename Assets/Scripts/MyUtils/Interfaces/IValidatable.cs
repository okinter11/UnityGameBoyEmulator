namespace MyUtils.Interfaces
{
    /// <summary>
    ///     可验证的接口
    /// </summary>
    public interface IValidatable
    {
        /// <summary>
        ///     验证运行时数据是否有效
        /// </summary>
        bool Valid();
    }
}