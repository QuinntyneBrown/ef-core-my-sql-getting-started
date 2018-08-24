using GoodCode.API.Features.Users;
using GoodCode.Core.Extensions;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    public class UserScenarios: UserScenarioBase
    {


        [Fact]
        public async Task ShouldGetAll()
        {
            using (var server = CreateServer())
            {
                var response = await server.CreateClient()
                    .GetAsync<GetUsersQuery.Response>(Get.Users);

                Assert.True(response.Users.Count() > 0);
            }
        }
       
    }
}
