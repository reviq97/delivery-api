namespace delivery_api.Middleware.CustomApiHandlingMiddleware
{
    public class EntityExistsException : Exception
    {
        public EntityExistsException(string msg) : base(msg) { }
    }
}
