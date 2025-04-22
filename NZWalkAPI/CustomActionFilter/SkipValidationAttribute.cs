namespace NZWalkAPI.CustomActionFilter
{
    // This attribute is used to skip validation for specific actions or controllers.
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class ,AllowMultiple = false)]
    internal class SkipValidationAttribute : Attribute
    {
        
    }
}