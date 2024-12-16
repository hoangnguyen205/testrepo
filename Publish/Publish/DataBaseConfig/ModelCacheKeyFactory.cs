using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;


public class EntityModelCacheKey : IModelCacheKeyFactory
{
    public object Create(DbContext context, bool designTime)
        => context is ResourceContext dynamicContext ? (context.GetType(), dynamicContext.Schema, designTime) : context.GetType();
}
