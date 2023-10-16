using CamundaState.Models.consts;
using CamundaState.Models.enums;

namespace CamundaState.Models
{
    public class ProjectWf : ObjectWf
    {

	    public ProjectWf(Guid objectId, string objectName)
		    : base(Statuses.Idea, ObjectType.PROJECT, objectId, objectName)
	    {
	    }

        protected ProjectWf()
        {
        }

        public void AssociateWithProcessInstance(string processInstanceId)
        {
            ProcessInstanceId = processInstanceId;
        }

        public void Idea()
        {
            StatusId = Statuses.Idea;
        }

        public void Agree()
        {
            StatusId = Statuses.Agreed;
        }

        public void SendApproveClosure()
        {
            StatusId = Statuses.SendApproveClosure;
        }
        public void SendAgree()
        {
            StatusId = Statuses.SendAgree;
        }
        public void Approve()
        {
            StatusId = Statuses.Approved;
        }

        public void InAgree()
        {
            StatusId = Statuses.InAgreed;
        }

        public void InAgreeWithRemark()
        {
            StatusId = Statuses.InAgreedWithRemark;
        }

        public void ApproveClosure()
        {
            StatusId = Statuses.ApproveClosure;
        }

        public void ApproveClosureeWithRemark()
        {
            StatusId = Statuses.ApproveClosureWithRemark;
        }

        public void CreateInJira()
        {
            StatusId = Statuses.CreatingInJira;
        }

        public void CreatedInJira()
        {
            StatusId = Statuses.CreatedInJira;
        }

        public void NotCreatedInJira()
        {
            StatusId = Statuses.NotCreatedInJira;
        }

        public void NotCompletedInJira()
        {
            StatusId = Statuses.NotCompletedInJira;
        }

        public void NotArchivedInJira()
        {
            StatusId = Statuses.NotArchivedInJira;
        }

        public void NotDoneInJira()
        {
            StatusId = Statuses.NotDoneInJira;
        }

        public void NotDeclinedInJira()
        {
            StatusId = Statuses.NotDeclinedInJira;
        }

        public void Developing()
        {
            StatusId = Statuses.Developing;
        }

        public void AfterDeveloping()
        {
            StatusId = Statuses.AfterDeveloping;
        }

        public void ToDoneStatus()
        {
            StatusId = Statuses.Done;
        }

        public void Complete()
        {
            StatusId = Statuses.Completed;
        }

        public void Archive()
        {
            StatusId = Statuses.Archived;
        }

        public void Decline()
        {
            StatusId = Statuses.Declined;
        }

        public void Suspend()
        {
            StatusId = Statuses.Suspended;
        }

        public void DontAgreed()
        {
            StatusId = Statuses.DontAgreed;
        }

        public void DontApproveClosure()
        {
            StatusId = Statuses.DontApproveClosure;
        }

        public void DontApproved()
        {
            StatusId = Statuses.DontApproved;
        }

        public void AgainApprove()
        {
            StatusId = Statuses.WaitApproved;
        }

        public void ApproveAfterInApproveClosure()
        {
            StatusId = Statuses.ApproveAfterInApproveClosure;
        }

        public void DontApproveAfterInApproveClosure()
        {
            StatusId = Statuses.DontApproveAfterInApproveClosure;
        }
        /// <summary>
        /// Метод использовать только при миграции
        /// </summary>
        /// <param name="statusId"></param>
        public void StatusChangeDuringMigration(Guid statusId)
        {
            StatusId = statusId;
        }

    }
    public enum ProjectStatus
    {
        Idea,
        Agreed,
        Approved,
        CreatingInJira,
        CreatedInJira,
        Developing,
        Done,
        Completed,
        Archived,
        Declined,
        Suspended,
    }

    public static class ProjectStatusExtensions
    {
        private static readonly Dictionary<ProjectStatus, string> ProjectStatusDictionary = new()
        {
            [ProjectStatus.Idea] = "Идея",
            [ProjectStatus.Agreed] = "Согласование",
            [ProjectStatus.Approved] = "Утвержден",
            [ProjectStatus.CreatedInJira] = "Создан в Jira",
            [ProjectStatus.CreatingInJira] = "Создание в Jira",
            [ProjectStatus.Developing] = "В работе",
            [ProjectStatus.Done] = "Выполнен",
            [ProjectStatus.Completed] = "Завершен",
            [ProjectStatus.Archived] = "Заархивирован",
            [ProjectStatus.Declined] = "Отклонён",
            [ProjectStatus.Suspended] = "Приостановлен",
        };
        public static string GetName(this ProjectStatus projectStatus)
        {
            return ProjectStatusDictionary[projectStatus];
        }
    }
}
