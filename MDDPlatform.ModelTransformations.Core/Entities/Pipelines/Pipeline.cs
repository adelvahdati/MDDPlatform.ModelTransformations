using MDDPlatform.ModelTransformations.Core.Enums;
using MDDPlatform.SharedKernel.Entities;

namespace MDDPlatform.ModelTransformations.Core.Entities;
public class Pipeline : BaseEntity<Guid>
{
    private List<PipelineStage> _stages;
    public string Title {get;private set;}
    public IReadOnlyList<IPipelineStage> Stages => _stages;
    public PipelineStatus Status => GetPipelineStatus();
    public Guid ProblemDomainId {get;private set;}


    private PipelineStatus GetPipelineStatus()
    {
        if(_stages.Any(stage=>stage.Status == StageStatus.Failed))
            return PipelineStatus.Failed;
        
        if(_stages.All(stage=> stage.Status == StageStatus.Done))
            return PipelineStatus.Done;

        if(_stages.All(stage=> stage.Status == StageStatus.Ready))
            return PipelineStatus.Ready;

        var stage = _stages.Where(st=>st.Status !=StageStatus.Done && st.Status!=StageStatus.Failed).FirstOrDefault();
        if(!Equals(stage,null) && stage.Type == StageType.Manual && stage.Status !=StageStatus.Done)
            return PipelineStatus.Pending;
        
        return PipelineStatus.InProgress;        
    }

    private Pipeline(string title,Guid problemDomainId)
    {
        Id = Guid.NewGuid();
        Title = title;
        _stages = new();
        ProblemDomainId = problemDomainId;
    }

    private Pipeline(Guid id, string title, List<PipelineStage> stages,Guid problemDomainId)
    {
        Id = id;
        Title = title;
        _stages = stages;
        ProblemDomainId = problemDomainId;
    }

    public static Pipeline Create(string title,Guid problemDomainId)
    {
        return new(title,problemDomainId);
    }
    public static Pipeline Load(Guid id, string title, List<PipelineStage> stages,Guid problemDomainId){
        return new Pipeline(id,title,stages,problemDomainId);
    }
    public void AddManualStage(string title,Guid taskId = default(Guid))
    {
        var stage = PipelineStage.CreateManualStage(title,taskId);
        _stages.Add(stage);
    }
    public void AddAutomaticStage(string title,Guid taskId){
        var stage = PipelineStage.CreateAutomaticStage(title,taskId);
        _stages.Add(stage);        
    }
    public void RemoveStage(Guid stageId){
        var stage = _stages.Find(st=>st.Id == stageId);
        if(Equals(stage,null))
            throw new Exception("StageId is not valid");

        if(stage.Status == StageStatus.Start)
            throw new Exception("Running stage can not be removed");
        
        _stages.Remove(stage);
    }
    public IPipelineStage? Next()
    {
        PipelineStage? stage;
        stage = _stages.Where(st=>st.Status == StageStatus.Failed).FirstOrDefault();
        if(!Equals(stage,null))
            throw new Exception($"Pipeline stage Failed.(title : {stage.Title})");

        stage = _stages.Where(st=>st.Status == StageStatus.Start).FirstOrDefault();
        if(!Equals(stage,null))
            throw new Exception($"{stage.Title} (StageID : {stage.Id}) is started and not yet finished");

        stage = _stages.Where(st=>st.Status == StageStatus.Ready).FirstOrDefault();
        return stage;
    }
    public void StartStage(Guid stageId)
    {
        var stage = _stages.Where(stage=>stage.Id == stageId).FirstOrDefault();
        if(!Equals(stage,null))
            stage.Start();
    }
    public void EndStage(Guid stageId)
    {
        var stage = _stages.Where(stage=>stage.Id == stageId).FirstOrDefault();
        if(!Equals(stage,null))
            stage.End();
    }
    public void RejectStage(Guid stageId)
    {
        var stage = _stages.Where(stage=>stage.Id == stageId).FirstOrDefault();
        if(!Equals(stage,null))
            stage.Reject();        
    }
    public void ResetPipline()
    {
        foreach(var stage in _stages){
            stage.Reset();
        }
    }
    public void ResetStage(Guid stageId){
        var stage = _stages.Find(st=>st.Id == stageId);
        if(!Equals(stage,null))
            stage.Reset();
    }
    public IPipelineStage GetStage(Guid stageId){
        var stage = _stages.Find(st=>st.Id == stageId);
        if(Equals(stage,null))
            throw new Exception("Stage not found");
        
        return stage;
    }
    public void Update(string title, List<Stage> stages)
    {
        var newPipelineStages = new List<PipelineStage>();
        PipelineStage newStage;
        foreach(var stage in stages)
        {
            var currentStage = _stages.Find(st=>st.Id==stage.Id);
            if(Equals(currentStage,null))
            {
                newStage = PipelineStage.CreateStage(stage.Title,stage.Type,stage.TaskId);                
            }else
            {
                string newTitle = stage.Title;
                long newSequenceNumber = DateTime.UtcNow.Ticks;
                newStage = PipelineStage.LoadStage(currentStage.Id,newTitle,currentStage.TaskId,currentStage.Type,currentStage.Status,newSequenceNumber);
            }
            newPipelineStages.Add(newStage);

        }
        Title = title;
        _stages = newPipelineStages;
    }
}