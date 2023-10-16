using System.ComponentModel.DataAnnotations;
using CamundaState.Models.enums;


namespace CamundaState.Models
{
    public class ObjectWf
    {
	    public Guid Id { get; }
	    public Guid StatusId { get; protected set; }
	    public string? ProcessInstanceId { get; protected set; }
	    public ObjectType ObjectType { get; set; }
	    public Guid ObjectId { get; set; }
	    [Required]
	    public string? ObjectName { get; set; }

	    public virtual Status Status { get; set; } = default!;
	    public Guid? TypeId { get; set; }
	    public Guid? CategoryId { get; set; }

	    public ObjectWf(Guid statusId, ObjectType objectType, Guid objectId, string objectName)
	    {
		    Id = Guid.NewGuid();
		    StatusId = statusId;
		    ObjectType = objectType;
		    ProcessInstanceId = null;
		    ObjectId = objectId;
		    ObjectName = objectName;
	    }

	    protected ObjectWf()
	    {
	    }
    }
}
