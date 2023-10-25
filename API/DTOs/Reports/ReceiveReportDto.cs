
namespace API.Dtos.Reports
{
    public class ReceiveReportDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid EmployeeGuid { get; set; }
        public IFormFile PhotoFile { get; set; }
    }
}
