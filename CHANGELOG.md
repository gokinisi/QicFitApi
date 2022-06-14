# Change Log

### Update October 14, 2019

Major Update is related to usage of .NET Core 3.0 backend.

Please update following files for backend

src/*.sln
src/Common/Common.DTO/AuthDTO/RoleDTO.cs
src/Common/Common.DTO/UserDTO.cs
src/Common/Common.DataAccess.EFCore/Common.DataAccess.EFCore.csproj
src/Common/Common.DataAccess.EntityFramework/Common.DataAccess.EntityFramework.csproj
src/Common/Common.IdentityManagement/Common.IdentityManagement.csproj
src/Common/Common.IdentityManagementCore/Common.IdentityManagementCore.csproj
src/Common/Common.WebApi/Common.WebApi.csproj
src/Common/Common.WebApi/Controllers/RolesController.cs
src/Common/Common.WebApi/Identity/RoleService.cs
src/Common/Common.WebApi/Interfaces/IRoleService.cs
src/Common/Common.WebApiCore/BaseStartup.cs
src/Common/Common.WebApiCore/Common.WebApiCore.csproj
src/Common/Common.WebApiCore/Controllers/RolesController.cs
src/Common/Common.WebApiCore/Identity/RoleService.cs
src/Common/Common.WebApiCore/Interfaces/IRoleService.cs
src/Common/Common.WebApiCore/Setup/BaseSwaggerConfig.cs
src/ECommerce/ECommerce.DIContainer/ECommerce.DIContainer.csproj
src/ECommerce/ECommerce.DIContainerCore/ECommerce.DIContainerCore.csproj
src/ECommerce/ECommerce.DataAccess.EFCore/ECommerce.DataAccess.EFCore.csproj
src/ECommerce/ECommerce.DataAccess.EFCore/Migrations/20190709132728_Initial.Designer.cs
src/ECommerce/ECommerce.DataAccess.EFCore/Migrations/20190709132728_Initial.cs
src/ECommerce/ECommerce.DataAccess.EFCore/Migrations/ECommerceDataContextModelSnapshot.cs
src/ECommerce/ECommerce.DataAccess.EFCore/Repositories/OrderAggregatedRepository.cs
src/ECommerce/ECommerce.DataAccess.EntityFramework/ECommerce.DataAccess.EntityFramework.csproj
src/ECommerce/ECommerce.DataAccess.Tests/App.config
src/ECommerce/ECommerce.DataAccess.Tests/ECommerce.DataAccess.Tests.csproj
src/ECommerce/ECommerce.Services.Infrastructure/MappingProfiles/UserProfile.cs
src/ECommerce/ECommerce.WebApi/App_Start/UnityConfig.cs
src/ECommerce/ECommerce.WebApi/ECommerce.WebApi.csproj
src/ECommerce/ECommerce.WebApi/Web.config
src/ECommerce/ECommerce.WebApi/packages.config
src/ECommerce/ECommerce.WebApiCore/ECommerce.WebApiCore.csproj
src/ECommerce/ECommerce.WebApiCore/Setup/DependenciesConfig.cs
src/ECommerce/ECommerce.WebApiCore/Setup/IdentityConfig.cs
src/ECommerce/ECommerce.WebApiCore/appsettings.Development.json
src/IoT/IoT.DIContainer/IoT.DIContainer.csproj
src/IoT/IoT.DIContainerCore/IoT.DIContainerCore.csproj
src/IoT/IoT.DataAccess.EFCore/IoT.DataAccess.EFCore.csproj
src/IoT/IoT.DataAccess.EFCore/Migrations/20190709132908_Initial.Designer.cs
src/IoT/IoT.DataAccess.EFCore/Migrations/20190709132908_Initial.cs
src/IoT/IoT.DataAccess.EFCore/Migrations/IoTDataContextModelSnapshot.cs
src/IoT/IoT.DataAccess.EFCore/Repositories/ElectricityConsumptionAggregatedRepository.cs
src/IoT/IoT.DataAccess.EntityFramework/App.config
src/IoT/IoT.DataAccess.EntityFramework/IoT.DataAccess.EntityFramework.csproj
src/IoT/IoT.Services.Infrastructure/MappingProfiles/UserProfile.cs
src/IoT/IoT.WebApi/App_Start/UnityConfig.cs
src/IoT/IoT.WebApi/Controllers/TrafficAggregatedController.cs
src/IoT/IoT.WebApi/IoT.WebApi.csproj
src/IoT/IoT.WebApi/Web.config
src/IoT/IoT.WebApi/packages.config
src/IoT/IoT.WebApiCore/Controllers/TrafficAggregatedController.cs
src/IoT/IoT.WebApiCore/IoT.WebApiCore.csproj
src/IoT/IoT.WebApiCore/Setup/DependenciesConfig.cs
src/IoT/IoT.WebApiCore/Setup/IdentityConfig.cs
src/IoT/IoT.WebApiCore/appsettings.Development.json
