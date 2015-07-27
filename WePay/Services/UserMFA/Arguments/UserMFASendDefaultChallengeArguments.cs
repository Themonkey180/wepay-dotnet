using Newtonsoft.Json;
using WePay.Entities.Structure;

namespace WePay.UserMFA
{
    public class UserMFASendDefaultChallengeArguments
    {
        public string BatchUrl() { return "/user/mfa/send_default_challenge"; }
    }
}
