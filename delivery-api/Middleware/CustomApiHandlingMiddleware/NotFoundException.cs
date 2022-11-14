namespace delivery_api.Middleware.CustomApiHandlingMiddleware
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string msg) : base(msg) { }
    }
}
