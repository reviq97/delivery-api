using delivery_api.Middleware.CustomApiHandlingMiddleware;

namespace delivery_api.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
			try
			{
				await next.Invoke(context);
			}
			catch (NotFoundException nfe)
			{
				context.Response.StatusCode = 404;
				await context.Response.WriteAsync(nfe.Message);

			}
			catch(EntityExistsException eee)
			{
				context.Response.StatusCode = 400;
				await context.Response.WriteAsync(eee.Message);
			}
			catch (Exception e)
			{
				context.Response.StatusCode = 500;
				await context.Response.WriteAsync($"Something goes wrong: {e.Message}");
			}
        }
    }
}
