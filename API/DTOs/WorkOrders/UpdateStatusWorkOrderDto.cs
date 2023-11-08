using API.Utilities.Enums;

namespace API.DTOs.WorkOrders;
public class UpdateStatusWorkOrderDto
{
    public Guid Guid { get; set; }
    public StatusWorkOrderLevel Status { get; set; }
}
