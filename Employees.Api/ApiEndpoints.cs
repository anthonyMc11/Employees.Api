namespace Employees.Api;

public class ApiEndpoints
{
    private const string ApiBase = "api";

    public static class Employees
    {
        private const string Base = $"{ApiBase}/employees";

        public const string Create = Base;
        public const string Get = $"{Base}/{{id:Guid}}";
        public const string GetAll = Base;
    }
}