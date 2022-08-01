using Newtonsoft.Json;
using RedArbor.Models;
using RedArbor.Services;

namespace GherkinTests.StepDefinitions
{
	[Binding]
	public sealed class RedArborStepDefinitions
	{
		 
		RedArborService<Employees> _RedArborService = new RedArborService<Employees>();
		object _createresult = null;

		public RedArborStepDefinitions(RedArborService<Employees> redArborService)
		{	
			_RedArborService = redArborService;
		}
		
		[When(@"User call create endpoint")]
		public void WhenUserCallCreateEndpoint()
		{
			_createresult = _RedArborService.Create(new Employees
			{
				CompanyId = 1,
				CreatedOn = "2022-08-01 19:18:48.807",
				DeletedOn = "2022-08-01 19:18:48.807",
				Email = "rodriguezbelmonte@gmail.com",
				Fax = String.Empty,
				Lastlogin = "2022-08-01 19:18:48.807",
				Name = "daniel",
				Password = "1234",
				PortalId = 1,
				RoleId = 1,
				StatusId = 1,
				Telephone = "699005876",
				UpdatedOn = "2022-08-01 19:18:48.807",
				Username = "danirodribe"
			}); 
		}

		[Then(@"Employee are created")]
		public void ThenEmployeeAreCreated()
		{
			var employee = new Employees
			{
				CompanyId = 1,
				CreatedOn = "2022-08-01 19:18:48.807",
				DeletedOn = "2022-08-01 19:18:48.807",
				Email = "rodriguezbelmonte@gmail.com",
				Fax = String.Empty,
				Lastlogin = "2022-08-01 19:18:48.807",
				Name = "daniel",
				Password = "1234",
				PortalId = 1,
				RoleId = 1,
				StatusId = 1,
				Telephone = "699005876",
				UpdatedOn = "2022-08-01 19:18:48.807",
				Username = "danirodribe"
			};

			JsonConvert.SerializeObject(_createresult).Should().Be(JsonConvert.SerializeObject(employee));
		}

	}
}