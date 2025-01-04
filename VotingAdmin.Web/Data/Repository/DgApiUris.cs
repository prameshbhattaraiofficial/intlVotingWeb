namespace VotingAdmin.Web.Data.Repository
{
    public static class DgApiUris
    {
        #region Authentication
        public const string MerchantAuthTokenRequestUri = "/api/merchant/auth/token";
        public const string UserAuthTokenRequestUri = "/api/user/auth/token";
        #endregion

        #region Menus
        public const string MenusSubmenusForCurrentUserUri = "api/menumanager/get-menus-submenus-for-current-user";
        public const string UpdateMenuToRole = "/api/menumanager/update-menus-to-role";
        public const string GetMenuByRoleId = "/api/menumanager/get-menus-by-role-id";
        public const string GetMenuById = "/api/menumanager/get-menu-by-id";
        public const string DeleteMenuById = "/api/menumanager/delete-menu";
        public const string GetMenusAll = "api/MenuManager/get-menus-all";
        public const string GetParentMenusAll = "api/menumanager/get-menus-parent-all";
        public const string AddMenu = "api/menumanager/add-menu";
        public const string UpdateMenu = "api/menumanager/update-menu";
        public const string UpdateMenuIsActive = "api/menumanager/update-menu-isactive";
        public const string UpdateMenuDisplayOrder = "api/menumanager/update-menu-display-order";
        #endregion

        #region Users
        public const string GetAllUsersDetailsUri = "api/user/get-users";
        public const string GetUsersDetailsByIdUri = "/api/user/get-user-by-id";
        public const string CreateUserUri = "/api/user/create-user";
        public const string UpdateUserUri = "api/user/update-user";
        public const string RemoveUserUri = "api/user/delete-user";
        public const string AssignUserToRole = "/api/user/assign-user-to-roles";
        public const string GetUserToRole = "/api/user/get-user-roles";
        public const string ResetUserPassword = "/api/user/reset-user-password";
        public const string MerchantChangePassword = "/api/merchant/login/changepassword";
        public const string UserChangePassword = "/api/user/login/changepassword";
        public const string ChangePassword = "/api/merchant/login/changepassword";
        public const string ChangeAcessCode = "/api/user/changeaccesspin";
        public const string ValidateAcessCode = "/api/user/validateaccesscode";
        public const string UserActivityUrl = "/api/user/get-useractivity-report";
        #endregion

        #region Customer
        public const string KycListUrl = "api/kyc/get-kyc-list";
        public const string customerListUrl = "api/customer/get-customers";
        public const string KycByIdUrl = "api/kyc/get-kyc-bycustomerid?customerId=";
        public const string KycHistoryByIdUrl = "api/kyc/get-kyc-history-list?customerId=";
        public const string EditKyc = "api/kyc/update-kyc";
        #endregion

        #region VotingContest
        public const string VotingContestUrl = "/api/contest/get-contests";
        public const string VotingContestDetailUrl = "/api/contest/get-contest-detail";
        public const string VotingContestAddlUrl = "/api/contest/add-contest";
        public const string VotingContestAddSubUrl = "/api/contest/add-subcontest";
        public const string VotingContestByIDUrl = "/api/contest/get-contest-byid";
        public const string VotingSubContestByIDUrl = "/api/contest/get-subcontest-byid";
        public const string VotingMerchantDdl = "/api/ddl/get-merchant-ddl";
        public const string VotingContestUpdateUrl = "/api/contest/update-contest";
        public const string VotingSubContestUpdateUrl = "/api/contest/update-subcontest";
        public const string VotingContestDeleteUrl = "/api/contest/delete-contest";
        public const string VotingContestPublishUrl = "/api/contest/publish-contest";
        public const string VotingContestUnPublishUrl = "/api/contest/unpublish-contest";
        public const string VotingSubContestDeleteUrl = "/api/contest/delete-subcontest";

        #endregion
        #region VotingContestant
        public const string VotingContestantUrl = "/api/contestant/get-contestants";
        public const string VotingContestantAddUrl = "/api/contestant/add-contestant";
        public const string VotingContestantUpdateUrl = "/api/contestant/update-contestant";
        public const string VotingContestantDeleteUrl = "/api/contestant/delete-contestant";
        public const string VotingContestantByIDUrl = "/api/contestant/get-contestant-byid";


        #endregion
        #region Package
        public const string VotingPackageListtUrl = "/api/package/get-voting-packages";
        public const string VotingPackageAddUrl = "/api/package/add-voting-package";
        public const string VotingPackageUpdateUrl = "/api/package/update-voting-package";
        public const string VotingPackageDeleteUrl = "/api/package/delete-voting-package";
        public const string VotingPackageByIDUrl = "/api/package/get-voting-package-byid";

        #endregion
        #region Report
        public const string VotingReportListUrl = "/api/report/get-voting-txn-report";
       

        #endregion


        #region Rate
        public const string GetAllRateListUri = "/api/rate/get-rate-list";
        public const string GetRateHistoryList = "/api/rate/get-rate-history";
        public const string GetRateByIdUri = "/api/rate/get-rate-byid";
        public const string CreateRateUri = "/api/rate/create-rate";
        public const string UpdateRateUri = "/api/rate/update-rate";
        public const string DeleteRateUri = "/api/rate/delete-rate";
        public const string GetCurrentRateUri = "/api/rate/get-current-rate";
        #endregion

        #region Products
        public const string GetAllProductListUri = "/api/product/bind-product-ddl";
        public const string GetAllProductTypeListUri = "/api/product/bind-product-type-ddl";
        #endregion

        #region ServiceType
        public const string GetAllServiceTypeListUri = "/api/servicetype/get-service-type-list";
        public const string CreateServiceTypeUri = "/api/servicetype/create-service-type";
        public const string UpdateServiceTypeUri = "/api/servicetype/update-service-type";
        public const string GetServiceTypeByIdUri = "/api/servicetype/get-service-type-byid";
        public const string DeleteServiceTypeUri = "/api/servicetype/delete-service-type";
        public const string BindtxnServiceTypeUri = "/api/servicetype/bind-txn-service-type-ddl";
        public const string BindfeeServiceTypeUri = "/api/servicetype/bind-fee-service-type-ddl";
        public const string BindloanintrestServiceTypeUri = "/api/servicetype/bind-loan-interest-service-type-ddl";
        public const string BindServiceTypecodeUri = "/api/servicetype/get-new-service-type-code";
        #endregion

        #region Products
        public const string GetAllCountryddlUri = "/api/commonddl/bind-country-ddl";
        public const string GetAllContryCallingCodeUri = "api/commonddl/bind-countrycallingcode-ddl";
        public const string GetAllNationalityddlUri = "/api/commonddl/bind-nationality-ddl";
        public const string GetAllGenderddlUri = "/api/commonddl/bind-gender-ddl";
        public const string GetAllMaritalStatusddlUri = "/api/commonddl/bind-marital-status-ddl";
        #endregion

        #region Roles
        public const string GetAllRolesurl = "/api/userroles/get-roles";
        public const string GetRoleByIdurl = "/api/userroles/get-role-by-id";
        public const string CreateRoleurl = "/api/userroles/create-role";
        public const string UpdateRoleurl = "/api/userroles/update-role";
        public const string DeleteRoleurl = "/api/userroles/delete-role";
        #endregion

        #region charge

        #region chargetype
        public const string GetAllChargeTypeUrl = "/api/chargetype/bind-charge-type-ddl";

        #endregion

        #region TransactionCharge
        public const string GettransactionalChargeurl = "api/transactionalcharge/get-txn-charge-list";
        public const string GettransactionalChargeByIdurl = "api/transactionalcharge/get-txn-charge-byid?id=";
        public const string AddtransactionalChargeByIdurl = "api/transactionalcharge/create-txn-charge";
        public const string UpdatetransactionalChargeByIdurl = "api/transactionalcharge/update-txn-charge";
        public const string DeletetransactionalChargeByIdurl = "api/transactionalcharge/delete-txn-charge?id=";

        #endregion

        #region OthersFee
        public const string GetAllOtherFeeListUrl = "/api/otherfee/get-other-fee-list";
        public const string GetOtherFeeByIdUrl = "/api/otherfee/get-other-fee-byid";
        public const string CreateOthersFeeUrl = "/api/otherfee/create-other-fee";
        public const string UpdateOthersFeeUrl = "/api/otherfee/update-other-fee";
        public const string DeleteOthersFeeUrl = "/api/otherfee/delete-other-fee";
        #endregion

        #endregion

        #region TxnRequest
        public const string GetAllBuyTransactionalRequestUrl = "/api/transactionrequest/get-buy-transaction-request";
        public const string GetAllSellTransactionalRequestUrl = "/api/transactionrequest/get-sell-transaction-request";
        public const string GetBuyTxnRequestbureferenceUrl = "/api/transactionrequest/get-buy-request-byuniquereferenceno";
        public const string GetsellTxnRequestbureferenceUrl = "/api/transactionrequest/get-sell-request-byuniquereferenceno";
        public const string GetTransactionstatusUpdateUrl = "/api/transactionrequest/transaction-status-update";

        #endregion

        #region Reports
        public const string GetTxnSettlementReportUrl = "/api/transactionrequest/get-transaction-settlement-report";
        public const string sendMailrecipt = "/api/receipt/mail-merchant-Recipt";
        public const string GetTxnReportUrl = "/api/Report/get-txn-Report";

        #endregion

        #region LoanManagemnet

        #region LoanType
        public const string GetAllLoanTypeurl = "/api/loantype/get-loan-type-list";
        public const string GetloanTypeByIdurl = "/api/loantype/get-loan-type-byid";
        public const string CreateLoanTypeurl = "/api/loantype/create-loan-type";
        public const string UpdateLoanTypeurl = "/api/loantype/update-loan-type";
        public const string DeleteLoanTypeurl = "/api/loantype/delete-loan-type";
        public const string BindLoanTypeurl = "/api/loantype/bind-loan-type-ddl";
        #endregion

        #region LoanInterest
        public const string GetAllLoanInteresturl = "/api/loaninterest/get-loan-interest-list";
        public const string GetloanInterestByIdurl = "/api/loaninterest/get-loan-interest-byid";
        public const string CreateLoanInteresturl = "/api/loaninterest/create-loan-interest";
        public const string UpdateLoanInteresturl = "/api/loaninterest/update-loan-interest";
        public const string DeleteLoanInteresturl = "/api/loaninterest/delete-loan-interest";
        #endregion

        #endregion

        #region DDl
        public const string GetAllStatusUrl = "/api/ddl/get-contest-status-ddl";
        public const string GetcontestUrl = "/api/ddl/get-contest-ddl";
        public const string GetSubContestUrl = "/api/ddl/get-subcontest-ddl";
        public const string paymentddlurl = "/api/ddl/bind-paymentmethod-ddl";
        //public const string Getpaymentmethod = "​api/ddl/bind-paymentmethod-ddl";


        public const string GetAllProvisionListUrl = "/api/commonddl/bind-province-ddl";
        public const string GetAllDistrictListUrl = "/api/commonddl/bind-district-ddl";
        public const string GetAllLoacllevalListUrl = "api/commonddl/bind-local-level-ddl";
        public const string GetAllIdTypeListUrl = "api/commonddl/bind-identification-type-ddl";
        public const string GetAllKycstatusListUrl = "api/commonddl/bind-kyc-status-ddl";
        public const string GettxnservicetypeuseforddlUrl = "/api/commonddl/bind-txn-service-type-usefor-ddl";
        public const string GettxnservicetypeddlUrl = "/api/commonddl/bind-txn-service-type-ddl";
        public const string GetfeeservicetypeddlUrl = "/api/commonddl/bind-fee-service-type-ddl";
        public const string GetloaninterestservicetypeddlUrl = "/api/commonddl/bind-loan-interest-service-type-ddl";
        public const string GetproductbalancetypeddlUrl = "/api/commonddl/bind-productbalancetype-ddl";
        public const string GetAdminApprovalStatusddl = "/api/commonddl/bind-adminapprovalstatus-ddl";

        #endregion

        #region GlobalSetting
        public const string GetAllGlobalSettingurl = "/api/globalsetting/get-global-setting";
        public const string UpdateGlobalSettingurl = "/api/globalsetting/update-global-setting";
        public const string GetGlobalSettinghistoryurl = "/api/globalsetting/get-global-settings-history";
        public const string GetVerificationTypeSettingurl = "/api/globalsetting/verification-type-settings";
        public const string GetVerificationTypeSettingByIdurl = "/api/globalsetting/get-verification-type-byid";
        public const string AddVerificationTypeSettingurl = "/api/globalsetting/create-verification-type";
        public const string UpdateVerificationTypeSettingurl = "/api/globalsetting/update-verification-type";
        #endregion

    }
}
