

namespace WorkFlow.API.Enums
{
    public enum WorkflowTemplateEnum
    {
        #region ClaimRequest process
        //process
        ClaimRequest = 1,

        //step
        ClaimRequest_Initiator = 100,
        //action
        ClaimRequest_Initiator_Submit = 201,

        //step
        ClaimRequest_Assessor = 101,
        //action
        ClaimRequest_Assessor_Approve = 202,
        ClaimRequest_Assessor_Reject = 203,
        ClaimRequest_Assessor_ReturnForEditing = 204,
        ClaimRequest_Assessor_RecommendReject = 205,

        //step
        ClaimRequest_Endorser = 102,
        //action
        ClaimRequest_Endorser_Approve = 206,
        ClaimRequest_Endorser_Reject = 207,
        ClaimRequest_Endorser_ReturnForEditing = 208,
        ClaimRequest_Endorser_RecommendReject = 209,

        //step
        ClaimRequest_Approver = 103,
        //action
        ClaimRequest_Approver_Approve = 210,
        ClaimRequest_Approver_Reject = 211,
        ClaimRequest_Approver_ReturnForEditing = 212,

        // Final step
        ClaimRequest_Approved = 104,
        ClaimRequest_Rejected = 105,
        ClaimRequest_Cancelled = 106,
        #endregion
    }

    public enum ActionTypesEnum
    {
        Submit = 1,
        Approve = 2,
        Return = 3,
        Reject = 4,
        UnderReview = 5,
        ApproveForSubmission = 6,
        RecommendForApproval = 7,
        RecommendForRejection = 8,
        Cancel = 8
    }
    public enum StepTypesEnum
    {
        Draft = 1,
        InProgress = 2,
        Approved = 3,
        Rejected = 4,
        Canceled = 5,
        Assessor = 6,
        Endorser = 7,
        Approver = 8,
        Initiator = 9,
        CommitteeReview = 10,
        Removed = 11,
    }
}
