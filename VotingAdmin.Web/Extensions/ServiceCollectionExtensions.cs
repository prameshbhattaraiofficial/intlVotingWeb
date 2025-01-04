using VotingAdmin.Web.Common.Helpers.ViewToString;
using VotingAdmin.Web.Data.Repository;
using VotingAdmin.Web.Data.Repository.CommonDDL;
using VotingAdmin.Web.Data.Repository.GlobalSetting;
using VotingAdmin.Web.Data.Repository.Menus;
using VotingAdmin.Web.Data.Repository.Merchants;
using VotingAdmin.Web.Data.Repository.Package;
using VotingAdmin.Web.Data.Repository.Report;
using VotingAdmin.Web.Data.Repository.Roles;
using VotingAdmin.Web.Data.Repository.Users;
using VotingAdmin.Web.Data.Repository.VotingContest;
using VotingAdmin.Web.Data.Repository.VotingContestant;
using VotingAdmin.Web.Services;
using VotingAdmin.Web.Services.CommonDDl;
using VotingAdmin.Web.Services.Contest;
using VotingAdmin.Web.Services.Contestant;
using VotingAdmin.Web.Services.FileServices;
using VotingAdmin.Web.Services.GlobalSetting;
using VotingAdmin.Web.Services.Http.Voting;
using VotingAdmin.Web.Services.Menus;
using VotingAdmin.Web.Services.MenusMock;
using VotingAdmin.Web.Services.Merchants;
using VotingAdmin.Web.Services.Package;
using VotingAdmin.Web.Services.Report;
using VotingAdmin.Web.Services.Roles;
using VotingAdmin.Web.Services.Users;

namespace VotingAdmin.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IDgHttpClient, DgHttpClient>();

            #region Repositories
            services.AddScoped<IMenuManagerRepository, MenuManagerRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IUsersRepo, UsersRepo>();

            services.AddScoped<IVotingContestRepository, VotingContestRepository>();
            services.AddScoped<IContestantRepository, ContestantRepository>();
            services.AddScoped<IPackageRepository, PackageRepository>();
            services.AddScoped<IVotingReportRepository, VotingReportRepository>();

            services.AddScoped<ICommonddlRepo, CommonddlRepo>();
            services.AddScoped<IRoleRepo, RoleRepo>();

            services.AddScoped<IGlobalSettingRepo, GlobalSettingRepo>();

            services.AddScoped<IMerchantsRepository, MerchantsRepository>();
            #endregion

            #region Services
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IMenuManagerService, MenuManagerService>();
            services.AddScoped<IMenuManagerServiceMock, MenuManagerServiceMock>();
            services.AddScoped<IUsersServices, UsersServices>();
            services.AddScoped<IFileService, FileService>();

            services.AddScoped<IVotingContestService, VotingContestService>();
            services.AddScoped<IContestantService, ContestantService>();
            services.AddScoped<IPackageService, PackageService>();
            services.AddScoped<IVotingReportService, VotingReportService>();

            services.AddScoped<ICommonddlServices, CommonddlServices>();
            services.AddScoped<IRoleServices, RoleServices>();

            services.AddScoped<IGlobalSettingServices, GlobalSettingServices>();

            services.AddScoped<IMerchantsService, MerchantsService>();
            #endregion

            #region ExternalServices
            services.AddScoped<IViewRenderService, ViewRenderService>();
            #endregion

            return services;
        }

        public static IServiceCollection AddHostedApplicationServices(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection ConfigureApplicationAndServices(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

            return services;
        }
    }
}
