using API.Dtos.Tasks;

namespace API.DTOs.WorkOrders;
public class CreateWoDto
{
    public CreateWorkOrderDto workOrderDto { get; set; }
    public List<Guid> CsGuid {  get; set; }
}