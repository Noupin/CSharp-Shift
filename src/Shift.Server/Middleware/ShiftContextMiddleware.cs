using Shift.Server.Context;

namespace Shift.Server.Middleware
{
    public class ShiftContextMiddleware : IMiddleware
    {
        private readonly ILogger<ShiftContextMiddleware> _logger;
        private readonly ShiftContext _shiftContext;

        public ShiftContextMiddleware(ILogger<ShiftContextMiddleware> logger, ShiftContext shiftContext)
        {
            _logger = logger;
            _shiftContext = shiftContext;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
                await _shiftContext.Database.CommitTransactionAsync();
            }
            catch
            {
                try
                {
                    await _shiftContext.Database.RollbackTransactionAsync();
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
