using EFCore.BulkExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Publish.Model;

namespace Publish.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublicReceiverController ( ResourceContext resourceContext, IDbContextFactory<ResourceContext> dbContextFactory)
    : ControllerBase
    {

        [Route("publicreceiver"), HttpGet]
        public async Task PublicReceiver(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var file = await response.Content.ReadAsStringAsync();
                        var dto = JsonConvert.DeserializeObject<PublicReceiverDTO>(file);

                        resourceContext.Database.EnsureCreated();
                        await resourceContext.Resources.AddRangeAsync(dto.changes.resource.created);
                        resourceContext.SaveChanges();

                        var resourceIdList = dto.changes.resource.created.Select(x => x.Id).Distinct().ToList();
                        var lstTask = new List<Task>();
                        foreach (var resourceId in resourceIdList)
                        {
                            var context =  dbContextFactory.CreateDbContext();
                            context.Resource = resourceId;
                            await Task.Delay(5000);
                            context.Database.EnsureCreated();
                            await context.BulkInsertAsync(dto.changes.resourcedata.created.Where(x => x.ResourceId == resourceId));
                            //lstTask.Add(context.BulkInsertAsync(dto.changes.resourcedata.created.Where(x=>x.ResourceId == resourceId)));
                        }
                        //Task.WaitAll(lstTask.ToArray());
                        Console.WriteLine($"Import thành công");
                    }
                    else
                    {
                        Console.WriteLine($"Lỗi khi tải tệp: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");
                }
            }
        }
    }
}
