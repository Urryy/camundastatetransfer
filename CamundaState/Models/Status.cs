namespace CamundaState.Models
{
    public class Status
    {
	    public Status(Guid id, string name, Guid colorId, string description, bool isTechnicalStatus)
	    {
		    Id = id;
		    Name = name;
		    ColorId = colorId;
		    Description = description;
		    IsTechnicalStatus = isTechnicalStatus;
	    }

	    public Status(string name, Guid colorId, string description, bool isTechnicalStatus)
		    : this(Guid.NewGuid(), name, colorId, description, isTechnicalStatus)
	    {
	    }

	    protected Status()
	    {
	    }

	    public Guid Id { get; private set; }
	    public string Name { get; private set; } = default!;
	    public string Description { get; private set; } = default!;
	    public Guid ColorId { get; set; }
	    public bool IsTechnicalStatus { get; set; }
    }
}
