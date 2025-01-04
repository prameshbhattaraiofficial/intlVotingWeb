using System.ComponentModel.DataAnnotations;

namespace VotingAdmin.Web.Dtos.GlobalSetting
{
    public class GlobalsettingDto : IValidatableObject
    {
        public string languageCode { get; set; }
        public string currencyFormat { get; set; }
        public string dateFormat { get; set; }
        public string timeFormat { get; set; }
        public string delimeter { get; set; }
        public bool emailVerificationRequiredForTxn { get; set; }
        public bool mobileVerificationRequiredForTxn { get; set; }
        public bool kycVerificationRequiredForTxn { get; set; }
        public bool buyTxnChargeApplicable { get; set; }
        public bool sellTxnChargeApplicable { get; set; }
        public bool investTxnChargeApplicable { get; set; }
        public bool deliveryTxnChargeApplicable { get; set; }
        public bool giftTxnChargeApplicable { get; set; }
        public bool ornamentTxnChargeApplicable { get; set; }
        public bool buyTxnLimitRequired { get; set; }
        public double buyMinimumTxnLimit { get; set; }
        public double buyMaximumTxnLimit { get; set; }
        public bool sellTxnLimitRequired { get; set; }
        public double sellMinimumTxnLimit { get; set; }
        public double sellMaximumTxnLimit { get; set; }
        public bool investTxnLimitRequired { get; set; }
        public double investMinimumTxnLimit { get; set; }
        public double investMaximumTxnLimit { get; set; }
        public bool deliveryTxnLimitRequired { get; set; }
        public double deliveryMinimumTxnLimit { get; set; }
        public double deliveryMaximumTxnLimit { get; set; }
        public bool giftTxnLimitRequired { get; set; }
        public double giftMinimumTxnLimit { get; set; }
        public double giftMaximumTxnLimit { get; set; }
        public bool ornamentTxnLimitRequired { get; set; }
        public double ornamentMinimumTxnLimit { get; set; }
        public double ornamentMaximumTxnLimit { get; set; }
        public bool sendEmailNotification { get; set; }
        public bool sendMobileNotification { get; set; }
        public bool sendMobileOTP { get; set; }
        public bool sendEmailOTP { get; set; }
        public int otpLength { get; set; }
        public bool forcedChangePasswordRequired { get; set; }
        [Required(ErrorMessage = "Forced Changed Password Duration is Required!")]
        [Range(1, 12, ErrorMessage = "Invalid Month Value")]
        public int forcedChangedPasswordDurationInMonth { get; set; }
        public int registerPwdExpTimeInMinute { get; set; }
        public int SameEmailRegistrationGapTimeInMinute { get; set; }
        [Required(ErrorMessage = "Failed Login Attempt Count is Required!")]
        public int failedLoginAttemptCount { get; set; }
        public bool adminApprovalRequiredForBuyTxn { get; set; }
        public bool adminApprovalRequiredForSellTxn { get; set; }
        public bool adminApprovalRequiredForInvestTxn { get; set; }
        public bool adminApprovalRequiredForDeliveryTxn { get; set; }
        public bool adminApprovalRequiredForGiftTxn { get; set; }
        public bool adminApprovalRequiredForOrnamentTxn { get; set; }
        public float defaultBuyChargeValue { get; set; }
        public float defaultSellChargeValue { get; set; }
        public float defaultInvestChargeValue { get; set; }
        public float defaultGiftChargeValue { get; set; }
        public float defaultOrnamentChargeValue { get; set; }
        public float defaultDeliveryChargeValue { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            if (buyTxnLimitRequired == true)
            {
                if (buyMinimumTxnLimit == 0 || buyMaximumTxnLimit == 0)
                {
                    yield return new ValidationResult("buy min and max value should be greater than '0' ", new[] { "buyMaximumTxnLimit" });
                }
                if (buyMinimumTxnLimit > buyMaximumTxnLimit)
                {
                    yield return new ValidationResult("Min Limits Cann't be greater than max", new[] { "buyMinimumTxnLimit" });
                }
            }
            if (sellTxnLimitRequired == true)
            {
                if (sellMinimumTxnLimit == 0 || sellMaximumTxnLimit == 0)
                {
                    yield return new ValidationResult("sell min and max value should be greater than '0' ", new[] { "sellMaximumTxnLimit" });
                }
                if (sellMinimumTxnLimit > sellMaximumTxnLimit)
                {
                    yield return new ValidationResult("Min Limits Cann't be greater than max", new[] { "sellMinimumTxnLimit" });
                }
            }
            if (investTxnLimitRequired == true)
            {
                if (investMinimumTxnLimit == 0 || investMaximumTxnLimit == 0)
                {
                    yield return new ValidationResult("invest min and max value should be greater than '0' ", new[] { "investMaximumTxnLimit" });

                }
                if (investMinimumTxnLimit > investMaximumTxnLimit)
                {
                    yield return new ValidationResult("Min Limits Cann't be greater than max", new[] { "investMinimumTxnLimit" });
                }
            }
            if (deliveryTxnLimitRequired == true)
            {
                if (deliveryMinimumTxnLimit == 0 || deliveryMaximumTxnLimit == 0)
                {
                    yield return new ValidationResult("deliver min and max value should be greater than '0' ", new[] { "deliveryMaximumTxnLimit" });

                }
                if (deliveryMinimumTxnLimit > deliveryMaximumTxnLimit)
                {
                    yield return new ValidationResult("Min Limits Cann't be greater than max", new[] { "deliveryMinimumTxnLimit" });
                }
            }
            if (giftTxnLimitRequired == true)
            {
                if (giftMinimumTxnLimit == 0 || giftMaximumTxnLimit == 0)
                {
                    yield return new ValidationResult("Gift min and max value should be greater than '0' ", new[] { "giftMaximumTxnLimit" });

                }
                if (giftMinimumTxnLimit > giftMaximumTxnLimit)
                {
                    yield return new ValidationResult("Min Limits Cann't be greater than max", new[] { "giftMinimumTxnLimit" });
                }
            }
            if (ornamentTxnLimitRequired == true)
            {
                if (ornamentMinimumTxnLimit == 0 || ornamentMaximumTxnLimit == 0)
                {
                    yield return new ValidationResult("Ornaments min value should be greater than '0' ", new[] { "ornamentMaximumTxnLimit" });
                }
                if (ornamentMinimumTxnLimit > ornamentMaximumTxnLimit)
                {
                    yield return new ValidationResult("Min Limits Cann't be greater than max", new[] { "ornamentMinimumTxnLimit" });
                }
            }
        }
    }
}
