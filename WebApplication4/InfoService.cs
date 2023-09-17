  public class InfoService
    {
        private readonly IConfiguration _configuration;

        public InfoService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetInfo()
        {
            return ($"\nFirst Name: {_configuration["FirstName"]}\nLast Name: {_configuration["LastName"]}\nAge: {_configuration["Age"]}");



        }
    }   

