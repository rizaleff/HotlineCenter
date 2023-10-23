using System.Net;

namespace API.Utilities.Handlers;
public class ResponseOKHandler<TEntity>
{
    //Deklarasi atribug
    public int Code { get; set; }
    public string Status { get; set; }
    public string Message { get; set; }
    public TEntity? Data { get; set; }

    public ResponseOKHandler(TEntity? data)
    {
        Code = StatusCodes.Status200OK; 
        Status = HttpStatusCode.OK.ToString(); 
        Message = "Success"; 
        Data = data; 
    }

    public ResponseOKHandler(string message)
    {
        Code = StatusCodes.Status200OK; 
        Status = HttpStatusCode.OK.ToString(); 
        Message = message; 
    }
    public ResponseOKHandler()
    {
        Code = StatusCodes.Status200OK;
        Status = HttpStatusCode.OK.ToString(); 

    }
    public ResponseOKHandler(string message, TEntity data)
    {
        Code = StatusCodes.Status200OK;
        Status = HttpStatusCode.OK.ToString();
        Message = message;
        Data = data;
    }
}
