using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYBACK.App.Services
{
    public class PayBackService : IPayBackService
    {
        private string token;
        private PayBackServiceReference.ExtintPortTypeClient GetClient()
        {
            return new PayBackServiceReference.ExtintPortTypeClient("ExtintSoapBinding_ExtintPortType");
        }
        public string Authenticate()
        {
            try
            {

                var authRequest = new PayBackServiceReference.AuthenticateRequest
                {
                    Authentication = new PayBackServiceReference.MemberAliasAuthenticationType
                    {
                        Identification = new PayBackServiceReference.MemberIdentificationType
                        {
                            Alias = "9966108838",
                            AliasType = PayBackServiceReference.PrincipalVariantType.Item3,
                            AliasTypeSpecified = true
                        },
                        Security = new PayBackServiceReference.MemberSecurityType
                        {
                            SecretType = PayBackServiceReference.PrincipalSecretType.Item0
                        }
                    },
                    CommunicationChannel = "1"
                };

                //var ress = GetClient().GetMemberCardDetailsByMobile(new PayBackServiceReference.GetMemberCardDetailsByMobileRequest
                //{
                //    MobileNumber = "9966108838"
                //});
                var res = GetClient().Authenticate(authRequest);

                if (!string.IsNullOrEmpty(res.Token))
                    token = res.Token;
                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string GetAccountBalance()
        {
            try
            {

                var req = new PayBackServiceReference.GetAccountBalanceRequest
                {
                    Authentication = new PayBackServiceReference.AuthenticationType
                    {
                        Principal = new PayBackServiceReference.PrincipalType
                        {
                            PrincipalValue = "9966108838",
                            PrincipalClassifier = "3"
                        },
                        Credential = "7282"
                    },
                    SendLoyCardNo = PayBackServiceReference.StatusType.YES,

                };

                var res = GetClient().GetAccountBalance(req);
                if (res.AccountBalanceDetails != null)
                    return string.Format("Total Points: {0}", res.AccountBalanceDetails.TotalPointsAmount);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
