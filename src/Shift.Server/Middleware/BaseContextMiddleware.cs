using Microsoft.EntityFrameworkCore;

namespace Shift.Server.Middleware
{
    public abstract class BaseContextMiddleware<T, U> : IMiddleware where U : DbContext
    {
        private readonly ILogger<T> _logger;
        private readonly U _context;

        public BaseContextMiddleware(ILogger<T> logger, U context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
                await _context.Database.CommitTransactionAsync();
            }
            catch
            {
                try
                {
                    await _context.Database.RollbackTransactionAsync();
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Unable to rollback transaction.");
                }

                throw;
            }
        }
    }
}
