namespace CamundaState.Models.consts
{
    public static class Statuses
    {
        public static readonly Guid None = Guid.Parse("00000000-0000-0000-0000-000000000001");
        public static readonly Guid Idea = Guid.Parse("00000000-0000-0000-0000-00000000c001");
        public static readonly Guid Agreed = Guid.Parse("2baf7e4f-d69b-44db-bbd3-2565b9828923");
        public static readonly Guid SendAgree = Guid.Parse("cf6fe228-cbaf-4741-9607-2598fa1aa3bc");
        public static readonly Guid SendApproveClosure = Guid.Parse("edb4f480-eaff-4296-80b1-fa287162a791");
        public static readonly Guid DontAgreed = Guid.Parse("2fdc27e1-a12d-4af5-ac5e-071e7decf29e");
        public static readonly Guid DontApproveClosure = Guid.Parse("c83e97b6-a0f3-4554-9ebc-17a422391ae9");

        public static readonly Guid InAgreed = Guid.Parse("A058F1EB-77C2-418D-B0FD-EB7077172685");
        public static readonly Guid InAgreedWithRemark = Guid.Parse("0B78A8A6-300E-4DF4-AD57-4573999858A0");

        public static readonly Guid ApproveClosure = Guid.Parse("678757A4-ACB5-4A30-AE37-0A8EFFBB0068");
        public static readonly Guid ApproveClosureWithRemark = Guid.Parse("51AD835D-09D8-4500-A659-C23D9D117621");

        public static readonly Guid Approved = Guid.Parse("73644d74-542f-432f-94de-154492fa5d9a");
        public static readonly Guid CreatingInJira = Guid.Parse("cb2d8477-d372-4258-9d5d-496ede9ccffa");
        public static readonly Guid CreatedInJira = Guid.Parse("cb2d8477-d372-4258-9d5d-496edf9ccffa");
        public static readonly Guid Developing = Guid.Parse("872c6cd6-20c9-445c-8014-1f2425e1d29c");
        public static readonly Guid Done = Guid.Parse("90e731ee-aad2-4669-bcf6-c269066e76c4");
        public static readonly Guid Completed = Guid.Parse("0fed7f87-625a-40b4-8153-22b34e5c0f79");
        public static readonly Guid Archived = Guid.Parse("ab4f1707-ab91-4049-8896-9ff403353017");
        public static readonly Guid Declined = Guid.Parse("235ca890-33d4-4b52-967e-cf1dd8ad9d12");
        public static readonly Guid Suspended = Guid.Parse("110f9a22-7847-4ed9-af71-d949748e73f0");
        public static readonly Guid NotCreatedInJira = Guid.Parse("633392ff-cb98-40d3-8a20-90dbc653e3f9");
        public static readonly Guid NotCompletedInJira = Guid.Parse("eff1a362-c2c5-48d6-94ba-557659149598");
        public static readonly Guid NotArchivedInJira = Guid.Parse("bcdbdbb7-830b-499d-a4bd-430bd7770bc5");
        public static readonly Guid NotDeclinedInJira = Guid.Parse("1854BCA9-A0F9-4E2A-B935-AA83970C7EE0");
        public static readonly Guid NotDoneInJira = Guid.Parse("B3F9A8B3-41A3-4955-90A2-CCAC1E09B399");
        public static readonly Guid AfterDeveloping = Guid.Parse("911E4B8B-5DEA-4254-8F5E-F6147E51999F");

        public static readonly Guid DontApproved = Guid.Parse("09A4E4EE-339A-4CA8-AA74-B9E8B943887B");
        public static readonly Guid WaitApproved = Guid.Parse("0616cc0b-8f51-4779-916a-b9aea213c197");
        public static readonly Guid ApproveAfterInApproveClosure = Guid.Parse("3cb77714-ff65-445c-b6c3-69814301a9ef");
        public static readonly Guid DontApproveAfterInApproveClosure = Guid.Parse("b616fac6-33b8-4065-81e8-dcfb246f6e6e");
    }
}
