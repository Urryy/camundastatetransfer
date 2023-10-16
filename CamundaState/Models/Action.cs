using CamundaState.Models.enums;

namespace CamundaState.Models;

public class Action
{
	public Action(Guid id, string name, ObjectType objectType, Guid startStatusId, Guid endStatusId)
	{
		Id = id;
		Name = name;
		StartStatusId = startStatusId;
		EndStatusId = endStatusId;
	}

	public Action(string name, ObjectType objectType, Guid startStatusId, Guid endStatusId)
		: this(Guid.NewGuid(), name, objectType, startStatusId, endStatusId)
	{
	}

	protected Action()
	{
	}

	public Guid Id { get; set; }
	public string Name { get; set; } = default!;
	public ObjectType ObjectType { get; set; } = default!;
	public string? Description { get; set; }
	public Guid StartStatusId { get; set; }
	public Guid EndStatusId { get; set; }
	public List<string>? Accesses { get; set; }

	public virtual Status StartStatus { get; set; } = default!;
	public virtual Status EndStatus { get; set; } = default!;
}