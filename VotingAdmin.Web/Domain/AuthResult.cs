namespace VotingAdmin.Web.Domain
{
    public class AuthResult
    {
        public AuthResult()
        {
            Errors = new List<string>();
        }
        public bool Success => !Errors.Any();

        public void AddError(string error)
        {
            Errors.Add(error);
        }

        public IList<string> Errors { get; set; }
    }
}
